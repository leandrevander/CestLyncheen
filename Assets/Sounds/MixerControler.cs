using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerControler : MonoBehaviour
{
	[SerializeField] private AudioMixer mixerAudioPrincipale;
	[SerializeField] private AudioMixer environementMixer;
    
	public Slider MusicVolSlider;
	public Slider SFXVolSlider;

	
	public float MusicVolSliderValue;
	public float SFXVolSliderValue;

	public AudioSource select;

	void Update()
	{
		MusicVolSliderValue = MusicVolSlider.value;
		SFXVolSliderValue   = SFXVolSlider.value;
		
		UpdateMixerVolumes();
	}

	
	void UpdateMixerVolumes()
	{
		mixerAudioPrincipale.SetFloat("MusicVol", Mathf.Lerp(-80f, 0f, Mathf.Pow(MusicVolSliderValue, 0.25f)));

		environementMixer.SetFloat("SFXVol", Mathf.Lerp(-80f, 0f, Mathf.Pow(SFXVolSliderValue, 0.25f)));
	}

	public void PlaySoundTest()
	{
		select.Play();
	}
}