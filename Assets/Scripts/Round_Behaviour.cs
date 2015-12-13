using UnityEngine;
using System.Collections;

public class Round_Behaviour : MonoBehaviour {

	public GameObject target;

	private Hashtable characteristics = new Hashtable();

	private Transform targ;

	public float speed;

	public string type;

	void Awake () 
	{
		//target = GetComponentInParent<TowerAI>().target;
	}

	// Use this for initialization
	void Start () {
		target = GetComponentInParent<TowerAI>().target;
		targ = target.transform;

		characteristics.Add ("position", targ);
		characteristics.Add ("orienttopath", false);
		characteristics.Add ("speed", speed * Time.deltaTime);
		characteristics.Add ("easetype", iTween.EaseType.linear);
	}
	
	// Update is called once per frame
	void Update () {
		targ = target.transform;

		iTween.MoveUpdate (gameObject, characteristics);

		if (targ == null) {
			Destroy (gameObject);
		}

		if (Vector3.Distance(targ.transform.position, transform.position) < 0.5f) {
			Damage();
		}
	}

	void Damage ()
	{
		target.GetComponent<OffenseAI> ().AdjustCurHealth (-GetComponentInParent<TowerAI>().atkDamage);
		if (type == "Mortar") {
			GetComponent<MortarRoundAdditional>().Explosion();
		}
		Destroy (gameObject);
	}
}
