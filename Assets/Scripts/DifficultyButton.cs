using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    Button button;
    private GameManager gameManager;
    public float difficulty = 0;
    public int pointMultipler = 0;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        
       /* if (button.gameObject.name == "Easy Button")
        {
            difficulty = 1.2f;
            pointMultipler = 1;
        }

        if (button.gameObject.name == "Medium Button")
        {
            difficulty = 0.9f;
            pointMultipler = 2;
        }
        if (button.gameObject.name == "Hard Button")
        {
            difficulty = 0.6f;
            pointMultipler = 4;
        }*/

        gameManager.StartGame(difficulty, pointMultipler);

        GameObject.Find("Start UI").SetActive(false);
        
    }
}
