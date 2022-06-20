using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {

	public static GamePlayController instance;

	[SerializeField]
	private Text scoreText, coinText, liveText, finalScoreText, finalCoinText;


	[SerializeField]
	private GameObject pausePanel, gameOverPanel;

	[SerializeField]
	private GameObject readyButton;

	// Use this for initialization
	void Awake () {
		MakeInstance ();
	}

	void Start (){
		Time.timeScale = 0f;
		readyButton.SetActive (true);
	}

	void MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	public void StartTheGame(){
		Time.timeScale = 1f;
		readyButton.SetActive (false);
	}

	public void SetFinalScore(int finalScore, int finalCoin){
		finalScoreText.text = finalScore.ToString ();
		finalCoinText.text = finalCoin.ToString ();
		gameOverPanel.SetActive (true);
		StartCoroutine (GameOverLoadMainMenu ());
	}

	public void RestartAFterPlayerDied(){
		StartCoroutine (RestartAFterPlayerDeath ());
	}

	IEnumerator RestartAFterPlayerDeath(){
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene("GamePlayScene");
	}

	IEnumerator GameOverLoadMainMenu(){
		yield return new WaitForSeconds(3f);
		FaderScript.instance.LoadLevel ("MainMenuScene");
	}

	public void SetScore(int score){
		scoreText.text = score.ToString();
	}

	public void SetCoinScore(int coinScore){
		coinText.text = "x" + coinScore;
	}

	public void SetLiveScore(int liveScore){
		liveText.text = "x" + liveScore;
	}

	public void PauseTheGame(){
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
	}

	public void ResumeTheGame(){
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void QuitGame(){
		Time.timeScale = 1f;
		FaderScript.instance.LoadLevel ("MainMenuScene");
	}
}
