using UnityEngine;
using System.Collections;

public class BackgroundSpawner : MonoBehaviour {

	private GameObject[] backgrounds;

	private float lastY;

	// Use this for initialization
	void Start () {
		getBackgroundsAndSetLastY ();
	
	}
	
	void getBackgroundsAndSetLastY() {
		backgrounds = GameObject.FindGameObjectsWithTag ("Background");

		lastY = backgrounds [0].transform.position.y;

		for (int i = 1; i < backgrounds.Length; i++) {
			if (lastY > backgrounds [i].transform.position.y) {
				lastY = backgrounds [i].transform.position.y;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D target){
		if (target.tag == "Background") {
			if (target.transform.position.y == lastY) {
				Vector3 temp = target.transform.position;
				float height = target.bounds.size.y;

				foreach (GameObject bg in backgrounds) {
					if (!bg.activeInHierarchy) {

						temp.y -= height;
						lastY = temp.y;

						bg.transform.position = temp;
						bg.SetActive (true);
					}
				}
			}
		}
	}
}
