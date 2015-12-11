using UnityEngine;
using System.Collections;

public class Explosion_Destructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DestroySelf", 2.0f);
	}

	void DestroySelf () {
		Destroy(gameObject);
	}

}
