using UnityEngine;
using System.Collections;

public class MortarShellMover : MonoBehaviour {

	public float travelTime, speed;
	public GameObject explosionFX;

	bool scaleUp;
	// Use this for initialization
	void OnEnable () {
	
		scaleUp = true;
		explosionFX.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate(Vector3.forward * speed * Time.deltaTime);

		if(transform.localScale.x >= (travelTime / 2))
		{
			scaleUp = false;
		}
		if(scaleUp == true)
		{
			transform.localScale += new Vector3(0.05f,0.05f,0.05f);
		}
		if(scaleUp == false && transform.localScale.x >= 0.05f)
		{
			transform.localScale -= new Vector3(0.05f,0.05f,0.05f);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		explosionFX.SetActive(true);
		Invoke("CancelFX", 1.0f);
	}

	void Detonate()
	{
		gameObject.SetActive(false);
	}
	void CancelFX()
	{
		explosionFX.SetActive(false);
	}
}
