using UnityEngine;
using System.Collections;

public class TowerPlacement : MonoBehaviour {

	public GameObject selectedTower;
	public LayerMask blockingLayer, towerMask;
	public string selectableTag;
	public GameObject placementIndicator;
	public Vector3 oldPos, newPos, followPos;

	RaycastHit rayHit;
	public bool canPlaceTower = true, towerSelected = false;
	[Header("Debug Indicator")]
	[SerializeField]
	string canPlace = "False", isTowerSelected = "False";
	PlacementIndicator indicator;

	void Awake()
	{
		indicator = placementIndicator.GetComponent<PlacementIndicator>();
	}
		
	// Update is called once per frame
	void Update () {
	

		//if(Input.GetMouseButtonDown(0))
		if(selectedTower != null)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray, out rayHit, 50))
			{
				if(rayHit.collider.gameObject.CompareTag(selectableTag))
				{
					towerSelected = true;
										
					selectedTower = rayHit.collider.gameObject;

					//turn off selectedTower's collider so we can raycast to the colliders below
					selectedTower.GetComponent<BoxCollider>().enabled = false;
					oldPos = selectedTower.transform.position;
					
					selectedTower.transform.position = new Vector3( rayHit.point.x, oldPos.y, rayHit.point.z);

				}
			}

						
		}

		if(Input.GetMouseButtonUp(0))
		{
			if(selectedTower != null)
			{
			
				if(!canPlaceTower)
				{
					selectedTower.transform.position = oldPos;
				}
				else
				{
					selectedTower.transform.position = newPos;
				}
				towerSelected = false;

				//turn selectedTower's collider back on so it again becomes selectable
				selectedTower.GetComponent<BoxCollider>().enabled = true;
			}
		}
		
		if(towerSelected)
		{
			//debug "can place" and "tower selected" bools
			DebugPlacement();
			
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out rayHit, 100))
			{
				if (rayHit.collider.CompareTag("Path") || rayHit.collider.CompareTag("DefensiveUnit") || Vector3.Distance(selectedTower.transform.position, oldPos) < 2.0f)
				{
					canPlaceTower = false;
					indicator.canNotPlaceIndicator.SetActive(true);
					indicator.canPlaceIndicator.SetActive(false);
				}
				else
				{
					canPlaceTower = true;
					indicator.canNotPlaceIndicator.SetActive(false);
					indicator.canPlaceIndicator.SetActive(true);
				}

				//float mouseX = rayHit.point.x;
				//float mouseZ = rayHit.point.z;
				//followPos = new Vector3(mouseX, selectedTower.transform.position.y, mouseZ);
				
				selectedTower.transform.position = followPos;
				placementIndicator.transform.position = followPos;
				newPos = followPos;

				//Debug.DrawRay(followPos,ray.direction * 50, Color.red); //used for debug
				//Debug.Log(rayHit.collider.name);
				
			}
		}
		else
		{
			indicator.canNotPlaceIndicator.SetActive(false);
			indicator.canPlaceIndicator.SetActive(false);
		}

	}

	void DebugPlacement()
	{
		if(canPlaceTower == true)
		{
			canPlace = "True";
		}
		else
		{
			canPlace = "False";
		}
		if(towerSelected == true)
		{
			isTowerSelected = "True";
		}
		else
		{
			isTowerSelected = "False";
		}
	}
}
