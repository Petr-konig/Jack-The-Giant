using UnityEngine;
using System.Collections;

public class BackgroundScaler : MonoBehaviour {

	void Start () {
		SpriteRenderer sp = GetComponent<SpriteRenderer> ();
		Vector3 tempScale = transform.localScale;

		float bgWidth = sp.sprite.bounds.size.x;

		float worldHeight = Camera.main.orthographicSize * 2.0f;
		float worldWidth = worldHeight / Screen.height * Screen.width;

		tempScale.x = worldWidth / bgWidth;

		transform.localScale = tempScale;
	}
		
}
