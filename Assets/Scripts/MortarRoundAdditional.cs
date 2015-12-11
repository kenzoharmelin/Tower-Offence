using UnityEngine;
using System.Collections;

public class MortarRoundAdditional : MonoBehaviour {

	public void Explosion () {
		GameObject.Instantiate ((Resources.Load("Explosions/13")), transform.position, Quaternion.Euler(-90f, 0f, 0f));

		foreach (GameObject OffUnit in GameObject.FindGameObjectsWithTag("OffensiveUnit")) {
			if (Vector3.Distance(OffUnit.transform.position, transform.position) < 5f) {
				OffUnit.GetComponent<OffenseAI>().AdjustCurHealth(-GetComponentInParent<TowerAI>().atkDamage);
			}
		}
	}
}