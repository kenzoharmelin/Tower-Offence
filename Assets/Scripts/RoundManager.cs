using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour {

	public Text countdownText;
	public GameObject offensiveHUD, defensiveHUD;
	public float offenceRoundSetUpTime, defenceRoundSetUpTime;
	public bool roundStart, defenceSetUp, OffenceSetUp;

	float timer;

	// Use this for initialization
	void OnEnable () {
	
		OffenceSetUp = true;
		defenceSetUp = false;
		roundStart = false;

		timer = offenceRoundSetUpTime;
	}
	
	// Update is called once per frame
	void Update () {
	

		if(timer >= 0)
		{
			if(OffenceSetUp == true)
			{
				countdownText.text = "Offence Setup time " + timer.ToString("0.00");
			}
			if(defenceSetUp == true)
			{
				countdownText.text = "Defence Setup time " + timer.ToString("0.00");
			}

			timer -= Time.deltaTime;
		}
		if(timer <= 0 && OffenceSetUp == true)
		{
			OffenceSetUp = false;
			defenceSetUp = true;
			offensiveHUD.SetActive(false);
			defensiveHUD.SetActive(true);
			timer = defenceRoundSetUpTime;
		}
		if(timer <= 0 && defenceSetUp == true)
		{
			defensiveHUD.SetActive(false);
			countdownText.enabled = false;
		}

	}


	
}
