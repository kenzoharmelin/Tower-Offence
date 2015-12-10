using UnityEngine;
using System.Collections;

public class Pathing : MonoBehaviour {

	public Transform[] pathPoints1;

	public GameObject test;

	public float percentsPerSecond = 0.02f; // %2 of the path moved per second
	public float currentPathPercent = 0.0f; //min 0, max 1
	
	void OnDrawGizmos() 
	{
		iTween.DrawPath (pathPoints1, Color.yellow);
	}
	
	// Use this for initialization
	void Start () 
	{	

	}
	
	// Update is called once per frame
	void Update () 
	{
		currentPathPercent += percentsPerSecond * Time.deltaTime;
		iTween.PutOnPath(test, pathPoints1, currentPathPercent);
	}
}
