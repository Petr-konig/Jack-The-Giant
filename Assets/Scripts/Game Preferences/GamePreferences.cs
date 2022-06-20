using UnityEngine;
using System.Collections;

public static class GamePreferences {

	public static string EasyDifficulty = "EasyDifficulty";
	public static string MediumDifficulty = "MediumDifficulty";
	public static string HardDifficulty = "HardDifficulty";

	public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
	public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
	public static string HardDifficultyHighScore = "HardDifficultyHighScore";

	public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
	public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
	public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

	public static string IsMusicOn = "IsMusicOn";

	//Get and Set Music
	public static void SetMusicState(int state){
		PlayerPrefs.SetInt (IsMusicOn, state);
	}

	public static int GetMusicState() {
		return PlayerPrefs.GetInt (IsMusicOn);
	}

	//Get and Set Difficulty
	public static void SetEasyDifficultyState(int status){
		PlayerPrefs.SetInt (EasyDifficulty, status);
	}

	public static int GetEasyDifficultyState(){
		return PlayerPrefs.GetInt (EasyDifficulty);
	}

	public static void SetMediumDifficultyState(int status){
		PlayerPrefs.SetInt (MediumDifficulty, status);
	}

	public static int GetMediumDifficultyState(){
		return PlayerPrefs.GetInt (MediumDifficulty);
	}

	public static void SetHardDifficultyState(int status){
		PlayerPrefs.SetInt (HardDifficulty, status);
	}

	public static int GetHardDifficultyState(){
		return PlayerPrefs.GetInt (HardDifficulty);
	}

	//Get and Set HighScore
	public static void SetEasyDifficultyHighScore(int status){
		PlayerPrefs.SetInt (EasyDifficultyHighScore, status);
	}

	public static int GetEasyDifficultyHighScore(){
		return PlayerPrefs.GetInt (EasyDifficultyHighScore);
	}

	public static void SetMediumDifficultyHighScore(int status){
		PlayerPrefs.SetInt (MediumDifficultyHighScore, status);
	}

	public static int GetMediumDifficultyHighScore(){
		return PlayerPrefs.GetInt (MediumDifficultyHighScore);
	}

	public static void SetHardDifficultyHighScore(int status){
		PlayerPrefs.SetInt (HardDifficultyHighScore, status);
	}

	public static int GetHardDifficultyHighScore(){
		return PlayerPrefs.GetInt (HardDifficultyHighScore);
	}

	//Get and Set CoinScore
	public static void SetEasyDifficultyCoinScore(int status){
		PlayerPrefs.SetInt (EasyDifficultyCoinScore, status);
	}

	public static int GetEasyDifficultyCoinScore(){
		return PlayerPrefs.GetInt (EasyDifficultyCoinScore);
	}

	public static void SetMediumDifficultyCoinScore(int status){
		PlayerPrefs.SetInt (MediumDifficultyCoinScore, status);
	}

	public static int GetMediumDifficultyCoinScore(){
		return PlayerPrefs.GetInt (MediumDifficultyCoinScore);
	}

	public static void SetHardDifficultyCoinScore(int status){
		PlayerPrefs.SetInt (HardDifficultyCoinScore, status);
	}

	public static int GetHardDifficultyCoinScore(){
		return PlayerPrefs.GetInt (HardDifficultyCoinScore);
	}

}
