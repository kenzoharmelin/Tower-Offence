using UnityEngine;
using System.Collections;

public class OffenseAI : MonoBehaviour {

	public Transform[] pathing;

	private Hashtable pathInfo = new Hashtable();

	private Object deathFX;

	public float speed, curHealth, maxHealth;

	OffensiveUnitSpawner _unitSpawner;
	public GameObject _offensiveManager;
	public string pathSpawnPointName;
	
	void OnEnable()
	{
		// this needs to be changed to basically change what its acquiring, path 1/2/3
		// so just have it build the string based on what the player has chosen 
		// as <Pathing> has three accessible paths in it
		_offensiveManager = GameObject.FindGameObjectWithTag("OffenceInventoryManager");
		_unitSpawner = _offensiveManager.GetComponent<OffensiveUnitSpawner>();

		if(pathSpawnPointName == "Path_1")
		{
			pathing = GameObject.Find ("Path_Container").GetComponent<Pathing> ().path1;
		}
		if(pathSpawnPointName == "Path_2")
		{
			pathing = GameObject.Find ("Path_Container").GetComponent<Pathing> ().path2;
		}
		if(pathSpawnPointName == "Path_3")
		{
			pathing = GameObject.Find ("Path_Container").GetComponent<Pathing> ().path3;
		}

	}

	void Start ()
	{
		pathInfo.Add ("path", pathing);
		pathInfo.Add ("orienttopath", true);
		pathInfo.Add ("speed", speed * Time.deltaTime);
		pathInfo.Add ("easetype", iTween.EaseType.linear);

		iTween.MoveTo (gameObject, pathInfo);
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
}
