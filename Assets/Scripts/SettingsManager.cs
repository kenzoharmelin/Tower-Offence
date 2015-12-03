using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

	public Slider brightnessSlider, volumeSlider;
	public Text brightnessText, volumeText;


	// Use this for initialization
	void Start () {
	
		brightnessText.text = brightnessSlider.value.ToString();
		volumeText.text = brightnessSlider.value.ToString();
	}

	public void BrightnessValueChange()
	{
		brightnessText.text = brightnessSlider.value.ToString();
	}

	public void VolumeValueChange()
	{
		volumeText.text = brightnessSlider.value.ToString();
	}
}
