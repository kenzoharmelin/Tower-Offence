using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class OffensiveUnitSpawner : MonoBehaviour {

	public GameObject Unit1, Unit2, Unit3, chosenPath;
	public int maxUnit1Number, maxUnit2Number, maxUnit3Number;
	public int curAvailableUnit1s, curAvailableUnit2s, curAvailableUnit3s, unit1sInWave, unit2sInWave, unit3sInWave;
	public Text unit1availableText, unit2availableText, unit3availableText, curUnits1inwaveText, curUnits2inwaveText, curUnits3inwaveText;
	public bool stagingPhase;
	public float spawnTime,waitTime;
	
	GameObject curSpawnedUnit;
	public GameObject path1SpawnPoint, path2SpawnPoint, path3SpawnPoint;
	//int spawnedUnitID;
	List<GameObject> waveArray;
	float spawnWait;
	GameObject spawnPoint;
	
	// Use this for initialization
	void Awake () {

		waveArray = new List<GameObject>();

		chosenPath = path1SpawnPoint;
		stagingPhase = true;
		spawnWait = 0;
		unit1sInWave = 0;
		unit2sInWave = 0;
		unit3sInWave = 0;


		curAvailableUnit1s = maxUnit1Number;
		curAvailableUnit2s = maxUnit2Number;
		curAvailableUnit3s = maxUnit3Number;
		
		unit1availableText.text = curAvailableUnit1s + " Unit 1 available";
		unit2availableText.text = curAvailableUnit2s + " Unit 2 available";
		unit3availableText.text = curAvailableUnit3s + " Unit 3 available";

		path1SpawnPoint = GameObject.FindGameObjectWithTag("Path1SpawnPoint");
		path2SpawnPoint = GameObject.FindGameObjectWithTag("Path2SpawnPoint");
		path3SpawnPoint = GameObject.FindGameObjectWithTag("Path3SpawnPoint");

		curUnits1inwaveText.text = "X " + unit1sInWave.ToString();
		curUnits2inwaveText.text = "X " + unit2sInWave.ToString();
		curUnits3inwaveText.text = "X " + unit3sInWave.ToString();

		
	}
	
	// Update is called once per frame
	void Update () {
		if(stagingPhase == false && Time.time >= spawnWait)
		{
			SpawnOffensiveUnit();
			spawnWait = Time.time + spawnTime;
		}
	}
	
	//called from the Canvas button events
	public void SpawnOffensiveUnit()
	{
		for(int i = 0; i < waveArray.Count; ++i)
		{
			if(!waveArray[i].activeInHierarchy)
			{
					
				waveArray[i].transform.position = spawnPoint.transform.position;
				waveArray[i].transform.rotation = spawnPoint.transform.rotation;
				waveArray[i].SetActive(true);
				return;
			}
		}
	}

	public void AddUnit1ToWave()
	{
		if(curAvailableUnit1s > 0)
		{
			GameObject unt = (GameObject)Instantiate(Unit1);
			unt.gameObject.GetComponent<OffenseAI>().pathSpawnPointName = chosenPath.name;
			unt.SetActive(false);
			waveArray.Add(unt);
			unit1sInWave++;
			curAvailableUnit1s--;
			curUnits1inwaveText.text = "X " + unit1sInWave.ToString();
			unit1availableText.text = curAvailableUnit1s + " Unit 1 available";
		}

	}
	public void AddUnit2ToWave()
	{
		if(curAvailableUnit2s > 0)
		{
			GameObject unt = (GameObject)Instantiate(Unit2);
			unt.gameObject.GetComponent<OffenseAI>().pathSpawnPointName = chosenPath.name;
			unt.SetActive(false);
			waveArray.Add(unt);
			unit2sInWave++;
			curAvailableUnit2s--;
			curUnits2inwaveText.text = "X " + unit2sInWave.ToString();
			unit2availableText.text = curAvailableUnit2s + " Unit 2 available";
		}
	}
	public void AddUnit3ToWave()
	{
		if(curAvailableUnit3s > 0)
		{
			GameObject unt = (GameObject)Instantiate(Unit3);
			unt.gameObject.GetComponent<OffenseAI>().pathSpawnPointName = chosenPath.name;
			unt.SetActive(false);
			waveArray.Add(unt);
			unit3sInWave++;
			curAvailableUnit3s--;
			curUnits3inwaveText.text = "X " + unit3sInWave.ToString();
			unit3availableText.text = curAvailableUnit3s + " Unit 3 available";
		}
	}

	public void SetPath(GameObject playersPath)
	{
		chosenPath = playersPath;
		if(playersPath.name == "Path_1")
		{
			spawnPoint = path1SpawnPoint;
		}
		if(playersPath.name == "Path_2")
		{
			spawnPoint = path2SpawnPoint;
		}
		if(playersPath.name == "Path_3")
		{
			spawnPoint = path3SpawnPoint;
		}
	}

}
