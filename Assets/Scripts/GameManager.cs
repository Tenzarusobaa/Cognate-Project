using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public TileBoard board;
    public CanvasGroup gameOver;
    public CanvasGroup winGame;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;

    private int score;

    private void Start() {
        NewGame();
    }

    public void NewGame() {
        SetScore(0);
        hiscoreText.text = LoadHiscore().ToString();
        gameOver.alpha = 0f;
        gameOver.interactable = false;
        winGame.alpha = 0f;
        winGame.interactable = false;
        board.ClearBoard();
        board.GenerateNewTile();
        board.GenerateNewTile();
        board.enabled = true;
    }

    public void GameOver() {
        board.enabled = false;
        gameOver.interactable = true;
        StartCoroutine(Fade(gameOver, 1f, 1f));
    }

    public void GameWin() {
        board.enabled = false;
        winGame.interactable = true;
        StartCoroutine(Fade(winGame, 1f, 1f));
    }

    public void Endless() {
        winGame.alpha = 0f;
        winGame.interactable = false;
        board.enabled = true;
    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay = 0f) {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while (elapsed < duration) {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = to;
    }

    public void IncreaseScore(int points) {
        SetScore(score + points);
    }

    private void SetScore(int score) {
        this.score = score;
        scoreText.text = score.ToString();

        SaveHiscore();
    }

    private void SaveHiscore() {
        int hiscore = LoadHiscore();

        if (score > hiscore) {
            PlayerPrefs.SetInt("highest", score);
        }
    }

    private int LoadHiscore() {
        return PlayerPrefs.GetInt("highest", 0);
    }



}
