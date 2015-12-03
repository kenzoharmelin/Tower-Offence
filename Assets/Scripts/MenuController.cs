using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public void GotoInstructions()
	{
		Application.LoadLevel("Instructions");
	}

	public void GotoSettings()
	{
		Application.LoadLevel("Settings");
	}

	public void GotoPlay()
	{
		Application.LoadLevel(1);
	}

	public void GoBack()
	{
		Application.LoadLevel("Main menu");
	}
}
