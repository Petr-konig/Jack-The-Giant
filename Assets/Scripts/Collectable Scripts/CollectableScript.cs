using UnityEngine;
using System.Collections;

public class CollectableScript : MonoBehaviour {

	void OnEnable(){
		Invoke ("Inactivate", 6f);
	}

	void Inactivate(){
		gameObject.SetActive (false);
	}
}
