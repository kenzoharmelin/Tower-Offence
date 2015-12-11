using UnityEngine;
using System.Collections;

public class OffenseAI : MonoBehaviour {

	public Transform[] pathing;

	private Hashtable pathInfo = new Hashtable();

	private Object deathFX;

	public float speed, curHealth, maxHealth;
	
	void Awake ()
	{
		pathing = GameObject.Find ("Path_Container").GetComponent<Pathing> ().path1;
	}

	void Start ()
	{
		pathInfo.Add ("path", pathing);
		pathInfo.Add ("orienttopath", true);
		pathInfo.Add ("speed", speed * Time.deltaTime);
		pathInfo.Add ("easetype", iTween.EaseType.linear);

		iTween.MoveTo (gameObject, pathInfo);
	}

	void AdjustCurHealth (float val)
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
}
