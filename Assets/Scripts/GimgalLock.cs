using UnityEngine;
using System.Collections;

public class GimgalLock : MonoBehaviour {

	public GameObject gimbal;

	Quaternion rot;
	// Use this for initialization
	void Awake () {
	
		rot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
		rot.y = gimbal.transform.rotation.y;
		transform.rotation = rot;
	}
}
