using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    Rigidbody rbTarget;
    float xBound = 4.4f;
    float ySpawnPosition=-3;
    float maxTorque = 10;
    float minSpeed = 12;
    float maxSpeed = 18;
    int maxPoints = 5;
    int minPoints = 2;
    int addPoints = 0;
    int extraPoints = 100;
    int deathPoints = -100;
    int incrementLive=1;
    

    GameManager gameManager;
    void Start()
    {
        rbTarget = GetComponent<Rigidbody>();

        rbTarget.AddForce(RandomForceVector(), ForceMode.Impulse);
        rbTarget.AddTorque(RandomTorqueVector(), ForceMode.Impulse);
        gameManager = GameObject.Find("Game Manager").GetComponent <GameManager> ();
        transform.position = RandomSpawnPosition();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnMouseDown()
    {
        if(!gameManager.isGameOver)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            CalculatePoints(gameManager.pointBonus);
            gameManager.UpdateScore(addPoints);

        }

    }*/

    Vector3 RandomForceVector() 
    
    {
        return Vector3.up * (Random.Range(minSpeed, maxSpeed));
        
    }

    Vector3 RandomTorqueVector()
    { 
        return new Vector3 (Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));
        
    }

    Vector3 RandomSpawnPosition() 
    {
        return new Vector3(Random.Range(-xBound, xBound), ySpawnPosition);
    }

    int CalculatePoints(int z)
    {


        if (gameObject.CompareTag("Boom"))

        {

            addPoints += -maxPoints * z;

        }

        else if (gameObject.CompareTag("Ball"))

        {

            addPoints += minPoints * z;
        }

        else if (gameObject.CompareTag("Box"))

        {

            addPoints += Random.Range(minPoints, maxPoints) * z;
        }

        else if (gameObject.CompareTag("BlackBall"))

        {
            addPoints += maxPoints * minPoints * z;

        }

        else if (gameObject.CompareTag("Live"))

        {
            addPoints += extraPoints;
            gameManager.UpdateLives(incrementLive);
        }

        else if (gameObject.CompareTag("Death"))

        {
            addPoints += deathPoints;
            gameManager.UpdateLives(-incrementLive);
        }

        return addPoints;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Boom")&&!gameObject.CompareTag("Death")&& !gameObject.CompareTag("Live"))
        {

                if (gameManager.lives > 0)
                {
                    gameManager.UpdateLives(-incrementLive);

                }

        }

    }

    public void DestroyTarget()
    {
       if (!gameManager.isGameOver)
       { 
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            CalculatePoints(gameManager.pointBonus);
            gameManager.UpdateScore(addPoints);

       }
    }

}
