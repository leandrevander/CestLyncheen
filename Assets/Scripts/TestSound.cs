using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class TestSound : MonoBehaviour
{
    

    public AudioSource select;

    

    public void PlaySoundTest()
    {
        select.Play();
    }
}
