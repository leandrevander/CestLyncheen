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

	void Start()
	{
		MusicVolSliderValue = PlayerPrefs.GetFloat("musicVol", 0.20f);
		SFXVolSliderValue   = PlayerPrefs.GetFloat("sfxVol",   0.20f);
		
		MusicVolSlider.value = MusicVolSliderValue;
		SFXVolSlider.value   = SFXVolSliderValue;
		
		UpdateMixerVolumes();

	}

	void Update()
	{
		if (MusicVolSliderValue != MusicVolSlider.value || SFXVolSliderValue != SFXVolSlider.value)
		{
			MusicVolSliderValue = MusicVolSlider.value;
			SFXVolSliderValue   = SFXVolSlider.value;
		
			UpdateMixerVolumes();
		}
		
	}

	
	void UpdateMixerVolumes()
	{
		mixerAudioPrincipale.SetFloat("MusicVol", Mathf.Lerp(-80f, 0f, Mathf.Pow(MusicVolSliderValue, 0.25f)));
		PlayerPrefs.SetFloat("musicVol", MusicVolSliderValue);

		environementMixer.SetFloat("SFXVol", Mathf.Lerp(-80f, 0f, Mathf.Pow(SFXVolSliderValue, 0.25f)));
		PlayerPrefs.SetFloat("sfxVol", SFXVolSliderValue);
		
		PlayerPrefs.Save();

	}

	public void PlaySoundTest()
	{
		select.Play();
	}
}