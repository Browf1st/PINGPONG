using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public Spawner SpawnPlayers;

    [Header("Ball")]
    public GameObject ball;

    [Header("Score UI")]
    public TextMeshProUGUI Player1Text;
    public TextMeshProUGUI Player2Text;
    public TextMeshProUGUI countdownText;

    private int Player1Score;
    private int Player2Score;

    private int winningScore = 5; 

    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGameCountdown());

    }
    public void Player1Scored()
    {
        if (!isGameOver)
        {
            Player1Score++;
            Player1Text.text = Player1Score.ToString();
            CheckForWinner();
            ResetPosition();
        }
    }

    public void Player2Scored()
    {
        if (!isGameOver)
        {
            Player2Score++;
            Player2Text.text = Player2Score.ToString();
            CheckForWinner();
            ResetPosition();
        }
    }

    private void CheckForWinner()
    {
        if (Player1Score >= winningScore)
        {
            Debug.Log("Player 1 Wins!");
            isGameOver = true;
            SceneManager.LoadScene(3);
        }
        else if (Player2Score >= winningScore)
        {
            Debug.Log("Player 2 Wins!");
            isGameOver = true;
            SceneManager.LoadScene(4);
        }
    }

    private void ResetPosition()
    {
        if (Player1Score < winningScore && Player2Score < winningScore)
        {
            StartCoroutine(StartRoundCountdown()); // Start the countdown before each round
            ball.GetComponent<Ball>().Reset();

            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

        private IEnumerator StartGameCountdown()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        countdownText.text = "";

        // Call the Launch() method on the BallBehavior script
        
        Ball ballBehavior = ball.GetComponent<Ball>();
        ballBehavior.Launch();
    }
    
        private IEnumerator StartRoundCountdown()
    {

        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        countdownText.text = "";

        // Call the Launch() method on the BallBehavior script
        Ball ballBehavior = ball.GetComponent<Ball>();
        ballBehavior.Launch();

    }

}
