using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OptionsMenuController : MonoBehaviour {

	[SerializeField]
	private GameObject easyDifficulty, mediumDifficulty, hardDifficulty;

	// Use this for initialization
	void Start () {
		SetTheDifficulty ();
	}

	void SetCheckSigns(string difficulty){
		switch (difficulty) {
		case "easy":
			easyDifficulty.SetActive (true);
			mediumDifficulty.SetActive (false);
			hardDifficulty.SetActive (false);
			break;
		case "medium":
			easyDifficulty.SetActive (false);
			mediumDifficulty.SetActive (true);
			hardDifficulty.SetActive (false);
			break;
		case "hard":
			easyDifficulty.SetActive (false);
			mediumDifficulty.SetActive (false);
			hardDifficulty.SetActive (true);
			break;
		}
	}

	public void SetEasyDifficulty(){
		GamePreferences.SetEasyDifficultyState (1);
		GamePreferences.SetMediumDifficultyState (0);
		GamePreferences.SetHardDifficultyState (0);

		SetCheckSigns ("easy");
	}

	public void SetMediumDifficulty(){
		GamePreferences.SetEasyDifficultyState (0);
		GamePreferences.SetMediumDifficultyState (1);
		GamePreferences.SetHardDifficultyState (0);

		SetCheckSigns ("medium");
	}

	public void SetHardDifficulty(){
		GamePreferences.SetEasyDifficultyState (0);
		GamePreferences.SetMediumDifficultyState (0);
		GamePreferences.SetHardDifficultyState (1);

		SetCheckSigns ("hard");
	}

	void SetTheDifficulty(){
		if(GamePreferences.GetEasyDifficultyState() == 1){
			SetCheckSigns ("easy");
		}

		if(GamePreferences.GetMediumDifficultyState() == 1){
			SetCheckSigns ("medium");
		}

		if(GamePreferences.GetHardDifficultyState() == 1){
			SetCheckSigns ("hard");
		}
	}


	
	public void MainMenu (){
		FaderScript.instance.LoadLevel ("MainMenuScene");
	}


}
