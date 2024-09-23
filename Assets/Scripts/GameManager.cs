using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject coinPlayer1;
    public GameObject coinPlayer2;

    public InputCol[] inputCols;

    private int player1score = 0;
    private int player2score = 0;

    public GameObject winCanvas;
    public GameObject pauseCanvas;
    private bool pause = false;

    public GameObject LogCanvas;
    public Text logGameText;

    private State state = null;

    void Start()
    {
        StartGame() ; 
    }

    void Update()
    {

        if (IsGameActive())
        {
            logGameText.text = PlayerTurn() == '1' ? "Red's turn" : "Yellow's turn";
            LogCanvas.SetActive(true);
        }
        else
        {
            LogCanvas.SetActive(false);
        }
    }

    private void StartGame()
    {
        Start2PlayersGame();
    }

    public void Start2PlayersGame()
    {
        state = new State('1');
        pause = false;
    }

    public bool IsGameActive()
    {
        return state != null && !pause;
    }

    public char PlayerTurn()
    {
        return state?.PlayerTurn ?? '0';
    }

    public void SelectCol(int col)
    {
        if (state == null)
        {
            return;
        }

        Debug.Log("playerTurn:" + state.PlayerTurn + " col:" + col);
        state.addPosition(col);

        if (state.Done)
        {
            UpdateScores();
            ShowWinScreen();
        }
    }

    private void UpdateScores()
    {
        if (state.PlayerWin == '1')
        {
            player1score++;
        }
        else if (state.PlayerWin == '2')
        {
            player2score++;
        }
    }

    private void ShowWinScreen()
    {
        pause = true;

        Transform playerWonTextTransform = winCanvas.transform.Find("PlayerWonText");
        Text playerWonText = playerWonTextTransform.GetComponent<Text>();

        if (state.PlayerWin == '1')
        {
            playerWonText.text = "Red wins";
            playerWonText.color = Color.red;
        }
        else if (state.PlayerWin == '2')
        {
            playerWonText.text = "Yellow wins";
            playerWonText.color = Color.yellow;
        }
        else
        {
            playerWonText.text = "Draw";
            playerWonText.color = Color.black;
        }

        Transform player1ScoreTextTransform = winCanvas.transform.Find("Player1ScoreText");
        Text player1ScoreText = player1ScoreTextTransform.GetComponent<Text>();
        player1ScoreText.text = player1score.ToString();

        Transform player2ScoreTextTransform = winCanvas.transform.Find("Player2ScoreText");
        Text player2ScoreText = player2ScoreTextTransform.GetComponent<Text>();
        player2ScoreText.text = player2score.ToString();

        winCanvas.SetActive(true);
    }

    public void Restart()
    {
        ClearGame();
        StartGame();
    }

    public void ShowMainMenu()
    {
        ClearGame();
        player1score = 0;
        player2score = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void ClearGame()
    {
        foreach (GameObject playerCoin in GameObject.FindGameObjectsWithTag("coins"))
        {
            Destroy(playerCoin);
        }

        state = null;
    }

    
}
