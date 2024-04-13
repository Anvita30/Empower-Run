using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float runSpeed;
    private int jumpCount = 0;
    private bool canJump = true;
    Animator anim;
    public bool isGameOver = false;
    public GameObject GameOverPanel, scoreText, text1, text2, text3, text4, image;
    public TextMeshProUGUI FinalScoreText, HighScoreText;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine("IncreaseGameSpeed");
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            transform.position = Vector3.right * runSpeed * Time.deltaTime + transform.position;
        }

        
        if (jumpCount == 3)
        {
            canJump = false;
        }

        if (Input.GetMouseButtonDown(0) && canJump && !isGameOver)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (touchPos.y < transform.position.y + 1) // You can adjust the threshold for jumping
            {
                rb2d.velocity = Vector3.up * 7.5f;
                anim.SetTrigger("Jump");
                jumpCount += 1;
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        anim.SetTrigger("death");
        StopCoroutine("IncreaseGameSpeed");

        StartCoroutine("ShowGameOverPanel");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            canJump = true;
        }

        if(collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }

        if(collision.gameObject.CompareTag("BottomDetector"))
        {
            GameOver();
        }

        if(collision.gameObject.CompareTag("Points"))
        {
            Destroy(collision.gameObject);
            GameObject.Find("ScoreDetector").GetComponent<ScoreSystem>().score += 2;
            GameObject.Find("ScoreDetector").GetComponent<ScoreSystem>().UpdateScoreText();
        }
    }

    IEnumerator IncreaseGameSpeed()
    {
        while(true)
        {
            yield return new WaitForSeconds(10);

            if(runSpeed < 8)
            {
                runSpeed += 0.4f;
            }

            if(GameObject.Find("GroundSpawner").GetComponent<ObstacleSpawner>().obstacleSpawnInterval > 1)
            {
                GameObject.Find("GroundSpawner").GetComponent<ObstacleSpawner>().obstacleSpawnInterval -= 0.1f;
            }
            
        }

    }

    IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(1.5f);

        GameOverPanel.SetActive(true);
        scoreText.SetActive(false);
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
        image.SetActive(false);

        FinalScoreText.text = "SCORE >> " + GameObject.Find("ScoreDetector").GetComponent<ScoreSystem>().score;

        HighScoreText.text = "HIGH SCORE >> " + PlayerPrefs.GetInt("HighScore");
    }
}
