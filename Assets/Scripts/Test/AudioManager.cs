using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    private void PauseAllSounds()
        {
            AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
            foreach (AudioSource audioSource in allAudioSources)
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Pause();
                }
            }
        }

        
        private void ResumeAllSounds()
        {
            AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
            foreach (AudioSource audioSource in allAudioSources)
            {
                
                if (!audioSource.isPlaying && audioSource.time > 0f)
                {
                    audioSource.UnPause();
                }
            }
        }

        public void Update()
        {
            if (Time.timeScale == 0f)
            {
                Debug.Log("temps = 0");
                PauseAllSounds();
            }
            else if (Time.timeScale == 1f)
            {
                Debug.Log("temps = 1");
                ResumeAllSounds();
            }
        }
    }  // Start is called once before the first execution of Update after the MonoBehaviour is created

