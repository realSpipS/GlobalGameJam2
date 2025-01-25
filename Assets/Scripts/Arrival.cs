using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrival : MonoBehaviour
{
    IEnumerator endCoroutine;
    bool ending = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endCoroutine = EndGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject);
        if(other.gameObject.CompareTag("Relic")){
            Relic relic = other.gameObject.GetComponent<Relic>();
            Globals.relics += 1;
            Globals.score += relic.GetValue();
            UIManager.instance.SetScoreText(Globals.score);
            Destroy(relic.gameObject);
        }

        if(other.gameObject.TryGetComponent(out Player player)){
            UIManager.instance.ShowEndText();
            if(!ending) StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
