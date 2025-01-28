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
            int currScene = SceneManager.GetActiveScene().buildIndex;
            if(currScene == 4){
                UIManager.instance.EndGame();
            }
            else{
                UIManager.instance.ShowEndText();
            }
            
            if(!ending) StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame(){
        yield return new WaitForSeconds(4);
        int currScene = SceneManager.GetActiveScene().buildIndex;
        if(currScene == 4){
            SceneManager.LoadScene(0);
        }
        else{
            SceneManager.LoadScene(currScene + 1);
        }
        
    }
}
