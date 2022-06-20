using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FaderScript: MonoBehaviour {

	public static FaderScript instance;

	[SerializeField]
	private GameObject fadePanel;

	[SerializeField]
	private Animator anim;

	// Use this for initialization
	void Awake () {
		MakeSingleton ();
	}

	void MakeSingleton(){

		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void LoadLevel(string level){
		StartCoroutine(FadeInOut(level));
	}
	
	IEnumerator FadeInOut (string level)
	{
		fadePanel.SetActive (true);
		anim.Play ("Fade In");

		yield return StartCoroutine (MyCoroutine.WaitForRealSeconds (1f));

		SceneManager.LoadScene (level);

		anim.Play ("Fade Out");

		yield return StartCoroutine (MyCoroutine.WaitForRealSeconds (0.7f));

		fadePanel.SetActive (false);
	}
}
