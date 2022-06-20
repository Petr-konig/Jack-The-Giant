using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	[SerializeField]
	private Button musicButton;

	[SerializeField]
	private Sprite[] musicIcon;

	void Start(){
		CheckToPlayMusic ();
	}

	void CheckToPlayMusic(){
		if (GamePreferences.GetMusicState () == 1) {
			MusicController.instance.PlayMusic (true);
			musicButton.image.sprite = musicIcon [1];
		} else {
			MusicController.instance.PlayMusic (false);
			musicButton.image.sprite = musicIcon [0];
		}
	}

	public void StartGame () {
		GameManager.instance.gameStartedFromMainMenu = true;
		FaderScript.instance.LoadLevel ("GamePlayScene");
	}

	public void HighScore (){
		FaderScript.instance.LoadLevel ("HighScoreScene");
	}

	public void OptionsMenu (){
		FaderScript.instance.LoadLevel ("OptionsMenuScene");
	}

	public void QuitGame (){
		Application.Quit();
	}

	public void MusicButton(){
		if (GamePreferences.GetMusicState () == 0) {
			GamePreferences.SetMusicState (1);
			MusicController.instance.PlayMusic (true);
			musicButton.image.sprite = musicIcon [1];
		} else {
			GamePreferences.SetMusicState (0);
			MusicController.instance.PlayMusic (false);
			musicButton.image.sprite = musicIcon [0];
		}
	}

}
