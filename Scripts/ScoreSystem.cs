using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isGameOver)
        {
            if(PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
                Debug.Log("NEW HIGH SCORE >> " + score);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            score += 1;
            scoreText.text = "SCORE : " + score;
        }

        /*else if(collision.gameObject.CompareTag("Points"))
        {
            score += 2;
            scoreText.text = "SCORE : " + score;
            
        }*/
    }

    public void UpdateScoreText()
    {
        scoreText.text = "SCORE : " + score;
    }
}
