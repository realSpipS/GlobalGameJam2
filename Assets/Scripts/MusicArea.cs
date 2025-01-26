using UnityEngine;

public class MusicArea : MonoBehaviour
{
    [SerializeField] int index = 0; 
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) MusicManager.instance.ChangeMusic(index);
    }
}
