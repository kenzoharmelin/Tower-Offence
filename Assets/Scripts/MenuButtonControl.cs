using UnityEngine;
using System.Collections;

public class MenuButtonControl : MonoBehaviour {

	public void GoToScene(string SceneName)
	{
		Application.LoadLevel(SceneName);
	}

	public void QuitGame()
	{
		Application.Quit();
	}


}
