using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 8f;
	public float maxVelocity = 4f;

	private Rigidbody2D giantBody;
	private Animator anim;

	void Awake() {
		giantBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		playerMoveKeyborad ();
	
	}

	void playerMoveKeyborad() {
		float forceX = 0f;
		float vel = Mathf.Abs (giantBody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0) {

			if (vel < maxVelocity) {
				forceX = speed;
				Vector2 temp = transform.localScale;
				temp.x = 1.3f;
				transform.localScale = temp;
				anim.SetBool ("Walk", true);
			}

		} else if (h < 0) {

			if (vel < maxVelocity) {
				forceX = -speed;
				Vector3 temp = transform.localScale;
				temp.x = -1.3f;
				transform.localScale = temp;
				anim.SetBool ("Walk", true);

			}

		} else {

			anim.SetBool ("Walk", false);
		}

		giantBody.AddForce (new Vector2 (forceX, 0));
	}
}
