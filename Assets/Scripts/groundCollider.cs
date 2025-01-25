using UnityEngine;

public class groundCollider : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip groundEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        groundEffect.LoadAudioData();
    }

    void OnCollisionEnter2D(Collision2D col){
        source.clip = groundEffect;
        source.Play();
    }
}
