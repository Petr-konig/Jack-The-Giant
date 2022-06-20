using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] clouds;

	private float distance = 3f;

	private float minX;
	private float maxX;

	private float lastCloudPositionY;

	private float controlX;

	[SerializeField]
	private GameObject[] collectables;

	private GameObject player;

	// Use this for initialization
	void Awake () {
		setMinAndMaxX ();
		positionClouds ();
		player = GameObject.Find("Player");

		for (int i = 0; i < collectables.Length; i++) {
			collectables [i].SetActive (false);
		}
	}


	void Start(){
		positionPlayer ();
	}

	void setMinAndMaxX() {
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0));

		maxX = bounds.x - 0.5f;
		minX = -bounds.x + 0.5f;
	}

	void shuffleArray(GameObject[] array) {
		for (int i = 0; i < array.Length; i++) {
			int random = Random.Range (i, array.Length - 1);
			GameObject temp = array [i];
			array [i] = array [random];
			array [random] = temp;
		}
	}

	void positionClouds(){

		shuffleArray (clouds);

		float positionY = 0f;

		for (int i = 0; i < clouds.Length; i++) {

			Vector3 temp = clouds[i].transform.position;

			temp.y = positionY;

			lastCloudPositionY = temp.y;

			if (controlX == 0) {
				temp.x = Random.Range (0.0f, minX);
				controlX++ ;
			} else if (controlX == 1) {
				temp.x = Random.Range (0.0f, maxX);
				controlX++ ;
			} else if (controlX == 2) {
				temp.x = Random.Range (-1.0f, minX);
				controlX++ ;
			} else if (controlX == 3) {
				temp.x = Random.Range (1.0f, maxX);
				controlX = 0;
			}

			clouds[i].transform.position = temp;

			positionY -= distance;

		}

		if (clouds [0].tag == "Deadly") {
			GameObject[] normal = GameObject.FindGameObjectsWithTag("Cloud");
			Vector3 temp = clouds [0].transform.position;
			clouds [0].transform.position = normal [0].transform.position;
			normal [0].transform.position = temp;
		}
	}

	void positionPlayer() {

		Vector3 position = new Vector3 (0, 0, 0);

		foreach (GameObject cloud in clouds) {
			if (cloud.transform.position.y == 0) {
				position = cloud.transform.position;
			}
		}

		position.y += 0.8f;

		player.transform.position = position;
	}

	void OnTriggerEnter2D(Collider2D target) {

		if (target.tag == "Cloud" || target.tag == "Deadly") {

			if (target.transform.position.y == lastCloudPositionY) {

				shuffleArray (clouds);
				shuffleArray (collectables);

				Vector3 temp = target.transform.position;

				foreach(GameObject cloud in clouds) {
					if (!cloud.activeInHierarchy) {
						
						if (controlX == 0) {
							temp.x = Random.Range (0.0f, minX);
							controlX++ ;
						} else if (controlX == 1) {
							temp.x = Random.Range (0.0f, maxX);
							controlX++ ;
						} else if (controlX == 2) {
							temp.x = Random.Range (-1.0f, minX);
							controlX++ ;
						} else if (controlX == 3) {
							temp.x = Random.Range (1.0f, maxX);
							controlX = 0;
						}

						temp.y -= distance;

						lastCloudPositionY = temp.y;

						cloud.transform.position = temp;
						cloud.SetActive (true);

						int random = Random.Range (0, collectables.Length);

						if (cloud.tag != "Deadly") {

							if (!collectables [random].activeInHierarchy) {

								Vector3 temp2 = cloud.transform.position;
								temp2.y += 0.7f;

								if (collectables [random].tag == "Live") {

									if (PlayerScore.liveScore < 2) {
										collectables [random].transform.position = temp2;
										collectables [random].SetActive (true);
									}

								} else {
									collectables [random].transform.position = temp2;
									collectables [random].SetActive (true);
								}
							}

						}
					}
				}
			}
		}

	}

}
