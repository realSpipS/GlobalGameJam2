using UnityEngine;
using System.Collections;

public class SfxDestroyer : MonoBehaviour
{
    private GameObject obj;
    // Update is called once per frame
    void Update()
    {
        obj = GameObject.FindWithTag("EmptySoundObj");
        StartCoroutine(DestroyThis(obj));
    }

    private IEnumerator DestroyThis(GameObject obj){
        yield return new WaitForSeconds(1.5f);
        Destroy(obj);
    }
}
