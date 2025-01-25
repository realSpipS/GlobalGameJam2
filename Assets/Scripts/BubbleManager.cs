using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    List<GameObject> contacts;
    public static BubbleManager instance;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip mergeSound;

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
        mergeSound.LoadAudioData();
        contacts = new List<GameObject>();
    }

    public void AddContact(GameObject bubble){
        contacts.Add(bubble);
        if(contacts.Count >= 2) BubbleCollision();
    }

    void BubbleCollision(){
        audioSource.clip = mergeSound;
        audioSource.Play();
        
        Debug.Log("Contact between " + contacts[0] + " and " + contacts[1]);
        Vector3 fstScale = contacts[0].transform.localScale;
        Vector3 scdScale = contacts[1].transform.localScale;
        if(fstScale.x == scdScale.x){
            contacts[0].transform.localScale += contacts[1].transform.localScale/2;
            contacts[0].transform.position = (contacts[0].transform.position + contacts[1].transform.position)/2;
            Destroy(contacts[1].gameObject);
        }
        else if(fstScale.x > scdScale.x){
            contacts[0].transform.localScale += contacts[1].transform.localScale/2;
            Destroy(contacts[1].gameObject);
        }
        else {
            contacts[1].transform.localScale += contacts[0].transform.localScale/2;
            Destroy(contacts[0].gameObject);
        }

        contacts.Clear();
    }
}
