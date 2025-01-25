using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource[] audioSource = new AudioSource[4];
    public static MusicManager instance;

    private void Awake() {
        if (instance != null && instance != this){
            Destroy(gameObject);
        }
        else{
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(AudioSource source in audioSource){
            source.Play();
            source.volume = 0;
        }

        audioSource[0].volume = 0.5f;
    }

    public void ChangeMusic(int index){
        foreach(AudioSource source in audioSource){
            source.volume = 0;
        }
        audioSource[index].volume = 0.5f;
    }
}
