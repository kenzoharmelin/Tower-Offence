using UnityEngine;
using System.Collections;

public class TowerAI : MonoBehaviour {
	public string tag;

	public float processTick, atkDamage, range, attackCooldown, attackTime, curHealth, maxHealth;

	public GameObject target;

	private Object deathFX;

	public Object round;

	public GameObject roundGO, turret, firepoint;

	// Use this for initialization
	void Start () 
	{
		ScanForEnemy ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("space")) {
			AdjustCurHealth (-40);
		}

		if (attackTime > 0) { // should we count down
			attackTime -= Time.deltaTime; // count down
			if (attackTime < 0) { 
				attackTime = 0; // floor at 0 (ready to attack)
			}
		}

		if (target != null) {
			if (Vector3.Distance(target.transform.position, transform.position) < range) {
				if (attackTime == 0) {
					attackTime = attackCooldown;
					Engage ();
				}
			}
		}

		if (target != null) {
			ApplyRotation ();
		}
	}

	void ScanForEnemy ()
	{		
		float tRange = range;
		GameObject targ = null;
		
		// check all loaded objects of tag
		foreach(GameObject _targ in GameObject.FindGameObjectsWithTag(tag)) {
			// are they close enough?
			if (Vector3.Distance(_targ.transform.position, transform.position) < tRange) {
				//Vector3 _dir = (targ.transform.position - transform.position).normalized;
				tRange = Vector3.Distance (_targ.transform.position, transform.position);
				targ = _targ;
			}
		}
		
		if (targ != null) {
			target = targ;
		}
		Invoke ("ScanForEnemy", processTick);
	}

	void Engage ()
	{
		roundGO = Instantiate (round, (firepoint.transform.position), Quaternion.Euler(-90f, turret.transform.rotation.y, 0f)) as GameObject;
		roundGO.transform.parent = gameObject.transform;
	}

	public void AdjustCurHealth (float val)
	{
		curHealth += val; //POSITIVE means heal, negative means damage
		
		if(curHealth > maxHealth) { // do I have more health than I should?
			curHealth = maxHealth;
		}
		
		if (curHealth <= 0) {
			curHealth = 0; // DIE
			Debug.Log (gameObject.name + " " + gameObject.GetInstanceID() + " has gone deadie-byes");

			CallDeath();
		}
	}

	public void CallDeath()
	{
		int rndDFX = Random.Range (1, 13);

		deathFX = Resources.Load("Explosions/" + rndDFX);

		GameObject.Instantiate (deathFX, transform.position, Quaternion.Euler(-90f, 0f, 0f));
		Destroy(gameObject);
	}
	
	public void ApplyRotation () 
	{
		float _curRot = transform.eulerAngles.y; //my y rotation
		Quaternion _wantRot = Quaternion.LookRotation((target.transform.position - transform.position)); //apply rotation to new var
		
		turret.transform.rotation = Quaternion.Euler(0f,_wantRot.eulerAngles.y, 0f); //rotation
	}
}
