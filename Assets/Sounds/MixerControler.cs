using UnityEngine;
using UnityEngine.Audio;
public class MixerControler : MonoBehaviour
{
    [SerializeField] private AudioMixer mixerAudioPrincipale;
    [SerializeField] private AudioMixer environementMixer;

    public void SetVolume(float sliderValue)
    {
        mixerAudioPrincipale.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }
    public void SetVolumeEnviro(float sliderValueenviro)
    {
        environementMixer.SetFloat("EnviroMaster", Mathf.Log10(sliderValueenviro) * 20);
    }
}