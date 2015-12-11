using UnityEngine;
using System.Collections;

public class Damage_Monitor : MonoBehaviour {
	public Object dmgFX;

	private GameObject dmgEffect;

	private bool curFX = false;

	// Use this for initialization
	void Start () {
		int rndDFX = Random.Range (1, 4);

		dmgFX = Resources.Load("Smoke/Damaged_" + rndDFX);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<TowerAI> ().curHealth <= gameObject.GetComponent<TowerAI> ().maxHealth / 2) {
			if (curFX == false) {
				curFX = true;

				dmgEffect = Instantiate (dmgFX, new Vector3(transform.position.x + 0.3f, transform.position.y + 0.1f, transform.position.z - 0.3f), Quaternion.Euler(-90f, 130f, 0f)) as GameObject;
				dmgEffect.transform.parent = gameObject.transform;
			}
		}

		if (gameObject.GetComponent<TowerAI> ().curHealth > gameObject.GetComponent<TowerAI> ().maxHealth / 2) {
			Destroy(dmgEffect);
		}

	}
}
