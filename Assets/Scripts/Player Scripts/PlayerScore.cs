using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	[SerializeField]
	private AudioClip coinClip, lifeClip;

	private CameraScript cameraScript;

	private Vector3 previousPosition;

	private bool countScore;

	public static int scoreCount;
	public static int liveScore;
	public static int coinScore;

	void Awake (){
		cameraScript = Camera.main.GetComponent<CameraScript> ();
	}

	// Use this for initialization
	void Start () {
		previousPosition = transform.position;
		countScore = true;
	}
	
	// Update is called once per frame
	void Update () {
		CountScore ();
	
	}

	void CountScore(){
		if (countScore) {
			if (transform.position.y < previousPosition.y) {
				scoreCount++;
			}
			previousPosition = transform.position;
			GamePlayController.instance.SetScore (scoreCount);
		}
	}

	void OnTriggerEnter2D(Collider2D target){

		if (target.tag == "Coin") {
			coinScore++;
			scoreCount += 200;

			GamePlayController.instance.SetScore (scoreCount);
			GamePlayController.instance.SetCoinScore (coinScore);

			AudioSource.PlayClipAtPoint (coinClip, transform.position);
			target.gameObject.SetActive (false);
		}

		if(target.tag == "Live"){
			liveScore++;
			scoreCount += 300;

			GamePlayController.instance.SetScore (scoreCount);
			GamePlayController.instance.SetLiveScore (liveScore);

			AudioSource.PlayClipAtPoint (lifeClip, transform.position);
			target.gameObject.SetActive (false);
		}

		if (target.tag == "Bounds" || target.tag == "Deadly") {
			cameraScript.isCameraInMove = false;
			countScore = false;

			transform.position = new Vector3 (500, 500, 0);
			liveScore--;

			GameManager.instance.CheckGameStatus (scoreCount, coinScore, liveScore);

		}
	}
}
