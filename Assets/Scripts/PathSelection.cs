using UnityEngine;
using System.Collections;

public class PathSelection : MonoBehaviour {
	
	public GameObject OffenceInstructionsPanel;

	// Update is called once per frame
	public void PickPath (GameObject path) {
	
		gameObject.GetComponent<OffensiveUnitSpawner>().SetPath(path);
		OffenceInstructionsPanel.SetActive(false);
	}
}
