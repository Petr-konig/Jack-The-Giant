using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[HideInInspector]
	public bool gameStartedFromMainMenu, gameStartedAFterPlayerDeath;

	[HideInInspector]
	public int score, coinScore, liveScore;

	void Awake(){
		MakeSingleton ();
	}

	void Start(){
		FirstStartGameSettings ();
	}

	void MakeSingleton(){
		if(instance != null){
			Destroy(gameObject);
		}else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void OnEnable(){
		SceneManager.sceneLoaded += CurrentSceneLoaded;
	}

	void OnDisable(){
		SceneManager.sceneLoaded -= CurrentSceneLoaded;
	}

	void CurrentSceneLoaded(Scene scene, LoadSceneMode mode){
		if (scene.name == "GamePlayScene"){

			if(gameStartedAFterPlayerDeath){
				GamePlayController.instance.SetScore (score);
				GamePlayController.instance.SetCoinScore (coinScore);
				GamePlayController.instance.SetLiveScore (liveScore);

				PlayerScore.scoreCount = score;
				PlayerScore.coinScore = coinScore;
				PlayerScore.liveScore = liveScore;

			} else {

				PlayerScore.scoreCount = 0;
				PlayerScore.coinScore = 0;
				PlayerScore.liveScore = 2;

				GamePlayController.instance.SetScore (0);
				GamePlayController.instance.SetCoinScore (0);
				GamePlayController.instance.SetLiveScore (2);
			}
		}
	}


	void FirstStartGameSettings(){

		if (!PlayerPrefs.HasKey ("firstLaunch")) {
			GamePreferences.SetMusicState (0);

			GamePreferences.SetEasyDifficultyState (0);
			GamePreferences.SetMediumDifficultyState (1);
			GamePreferences.SetHardDifficultyState (0);

			GamePreferences.SetEasyDifficultyHighScore (0);
			GamePreferences.SetMediumDifficultyHighScore (0);
			GamePreferences.SetHardDifficultyHighScore (0);

			GamePreferences.SetEasyDifficultyCoinScore (0);
			GamePreferences.SetMediumDifficultyCoinScore (0);
			GamePreferences.SetHardDifficultyCoinScore (0);

			PlayerPrefs.SetString ("firstLaunch", "launched");
		}

	}

	public void CheckGameStatus(int score, int coinScore, int liveScore){
		if (liveScore < 1) {

			if (GamePreferences.GetEasyDifficultyState () == 1) {
				int highScore = GamePreferences.GetEasyDifficultyHighScore ();
				int coinCount = GamePreferences.GetEasyDifficultyCoinScore ();

				if (highScore < score) {
					GamePreferences.SetEasyDifficultyHighScore (score);
				}

				if (coinCount < coinScore) {
					GamePreferences.SetEasyDifficultyCoinScore (coinScore);
				}
			}

			if (GamePreferences.GetMediumDifficultyState () == 1) {
				int highScore = GamePreferences.GetMediumDifficultyHighScore ();
				int coinCount = GamePreferences.GetMediumDifficultyCoinScore ();

				if (highScore < score) {
					GamePreferences.SetMediumDifficultyHighScore (score);
				}

				if (coinCount < coinScore) {
					GamePreferences.SetMediumDifficultyCoinScore (coinScore);
				}
			}

			if (GamePreferences.GetHardDifficultyState () == 1) {
				int highScore = GamePreferences.GetHardDifficultyHighScore ();
				int coinCount = GamePreferences.GetHardDifficultyCoinScore ();

				if (highScore < score) {
					GamePreferences.SetHardDifficultyHighScore (score);
				}

				if (coinCount < coinScore) {
					GamePreferences.SetHardDifficultyCoinScore (coinScore);
				}
			}

			gameStartedFromMainMenu = false;
			gameStartedAFterPlayerDeath = false;

			GamePlayController.instance.SetFinalScore (score, coinScore);
			 
		} else {

			this.score = score;
			this.coinScore = coinScore;
			this.liveScore = liveScore;

			gameStartedFromMainMenu = false;
			gameStartedAFterPlayerDeath = true;

			GamePlayController.instance.RestartAFterPlayerDied ();
		}
	}

}