using UnityEngine;

public class Arrival : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("TRIGGERANDO CON " + other.gameObject);
        if(other.gameObject.CompareTag("Relic")){
            Relic relic = other.gameObject.GetComponent<Relic>();
            Globals.score += relic.GetValue();
            Destroy(relic.gameObject);
        }
    }
}
