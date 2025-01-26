using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource[] audioSource = new AudioSource[4];
    public static MusicManager instance;

    private float fadeDuration = 2f; 

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
        }
    }

    void Start() {
        foreach (AudioSource source in audioSource) {
            source.Play();
            source.volume = 0;
        }

        
        audioSource[0].volume = 0.5f;
    }

    
    public void ChangeMusic(int index) {
        StartCoroutine(FadeOutOtherTracks(index)); 
        StartCoroutine(FadeIn(audioSource[index]));  
    }

    private IEnumerator FadeOutOtherTracks(int activeIndex) {
        foreach (AudioSource source in audioSource) {
            if (source != audioSource[activeIndex]) {
                float startVolume = source.volume;

                while (source.volume > 0) {
                    source.volume -= startVolume * Time.deltaTime / fadeDuration;
                    yield return null;
                }

                source.volume = 0;
            }
        }
    }

    private IEnumerator FadeIn(AudioSource newSource) {
        float targetVolume = 0.5f;  
        newSource.volume = 0; 

        while (newSource.volume < targetVolume) {
            newSource.volume += Time.deltaTime / fadeDuration;
            yield return null;
        }

        newSource.volume = targetVolume; 
    }
}