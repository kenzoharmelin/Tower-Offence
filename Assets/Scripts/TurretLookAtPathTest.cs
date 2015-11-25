using UnityEngine;
using System.Collections;

public class TurretLookAtPathTest : MonoBehaviour {

	public GameObject defenceInventoryManager;
	DefensiveInventoryManager placementManager;

	public float pointX, pointZ;
	public Transform[] lookTestPoints;

	RaycastHit hit;
	float distToHit = 1000.0f, dist, checkTime = 0.1f, curTime;

	// Use this for initialization
	void Start () {
	
		curTime = 0f;
		placementManager = defenceInventoryManager.GetComponent<DefensiveInventoryManager>();
	}
	
	void Update()
	{
		if(transform.position != Vector3.zero)
		{
			if(Time.time > curTime)
			{
				for(int i = 0; i < lookTestPoints.Length; i++)
				{
					if(Physics.Raycast(transform.position, lookTestPoints[i].position - transform.position, out hit, 5.0f))
					{
						if(hit.collider.gameObject.CompareTag("Path"))
						{
							dist = Vector3.Distance(transform.position, hit.point);
							if(dist < distToHit)
							{
								distToHit = dist;
								placementManager.lookAtPathPoint = hit.point;
							}
						}
					}
				}

				distToHit = 1000.0f;
				curTime = Time.time + checkTime;
			}
		}
	}
}
