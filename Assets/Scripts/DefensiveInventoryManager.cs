using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DefensiveInventoryManager : MonoBehaviour {

	public GameObject Unit1, Unit2, Unit3;
	public int maxUnit1Number, maxUnit2Number, maxUnit3Number;
	public int curAvailableUnit1s, curAvailableUnit2s, curAvailableUnit3s;
	public float positioningLookDist = 3.0f;
	public GameObject lookTestSphere;
	public Vector3 lookAtPathPoint;
	public Text unit1availableText, unit2availableText, unit3availableText;
	
	GameObject curSpawnedUnit;
	RaycastHit hit;
	float unitPosX;
	float unitPosZ;
	Vector3 unitFollowPos;



	// Use this for initialization
	void Awake () {
	
		curAvailableUnit1s = maxUnit1Number;
		curAvailableUnit2s = maxUnit2Number;
		curAvailableUnit3s = maxUnit3Number;

		unit1availableText.text = curAvailableUnit1s + " Unit 1 available";
		unit2availableText.text = curAvailableUnit2s + " Unit 2 available";
		unit3availableText.text = curAvailableUnit3s + " Unit 3 available";

		lookAtPathPoint = Vector3.zero;

	}
	
	// Update is called once per frame
	void Update () {
	
		//check if a unit has been spawned. If so clamp its position to the mouse and release on mouse left click.
		if(curSpawnedUnit != null)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100))
			{
				unitPosX = hit.point.x;
				unitPosZ = hit.point.z;
				unitFollowPos = new Vector3(unitPosX, 0.5f, unitPosZ);
				curSpawnedUnit.transform.position = unitFollowPos;
				lookTestSphere.transform.position = new Vector3(unitPosX, 0.01f, unitPosZ);

				if(lookAtPathPoint != Vector3.zero)
				{
					if(Vector3.Distance(curSpawnedUnit.transform.position, lookAtPathPoint) < positioningLookDist)
					{
						curSpawnedUnit.transform.LookAt(new Vector3(lookAtPathPoint.x, 0.5f, lookAtPathPoint.z));
					}
				}

				unit1availableText.text = curAvailableUnit1s + " Unit 1 available";
				unit2availableText.text = curAvailableUnit2s + " Unit 2 available";
				unit3availableText.text = curAvailableUnit3s + " Unit 3 available";
			}

			if(Input.GetMouseButtonDown(0))
			{
				curSpawnedUnit = null;
				lookTestSphere.transform.position = new Vector3(0,200,0);
				lookAtPathPoint = Vector3.zero;
			}

		}



	}

	//called from the Canvas button events
	public void InstantiateDefensiveUnit_1()
	{
		if(curAvailableUnit1s > 0)
		{
			curSpawnedUnit = Instantiate(Unit1) as GameObject;
			curAvailableUnit1s--;
		}
	}
	public void InstantiateDefensiveUnit_2()
	{
		if(curAvailableUnit2s > 0)
		{
			curSpawnedUnit = Instantiate(Unit2) as GameObject;
			curAvailableUnit2s--;
		}
	}
	public void InstantiateDefensiveUnit_3()
	{
		if(curAvailableUnit3s > 0)
		{
			curSpawnedUnit = Instantiate(Unit3) as GameObject;
			curAvailableUnit3s--;
		}
	}
}
