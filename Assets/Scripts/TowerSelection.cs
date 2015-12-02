using UnityEngine;
using System.Collections;

public class TowerSelection : MonoBehaviour {

	public GameObject inputManager;

	TowerPlacement towerPlacementScript;

	void Start()
	{
		if(inputManager == null)
		{
			inputManager = GameObject.FindGameObjectWithTag("InputManager");
		}
		towerPlacementScript = inputManager.GetComponent<TowerPlacement>();
	}
	void Update()
	{
		if(Input.GetMouseButtonDown(1))
		{
			Debug.Log("Selected" + gameObject.name);

		}

	}
}
