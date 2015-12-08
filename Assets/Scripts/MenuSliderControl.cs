using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuSliderControl : MonoBehaviour {

	public Slider brightnessSlider, volumeSlider;
	public Text brightnessValueText, VolumeValueText;
	public Light[] Scenelights;

	float brightnessValue, volumeValue;

	// Use this for initialization
	void Start () {
	
		brightnessValueText.text = brightnessSlider.value.ToString();
		VolumeValueText.text = volumeSlider.value.ToString();

	}
	
	public void BrightnessValueChange()
	{
		brightnessValueText.text = brightnessSlider.value.ToString();

		foreach(Light lte in Scenelights)
		{
			lte.intensity = brightnessSlider.value / 10;
		}
	}

	public void VolumeValueChange()
	{
		VolumeValueText.text = volumeSlider.value.ToString();
	}
}
