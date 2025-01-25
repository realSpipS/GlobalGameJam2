using System.Collections;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] Sprite popSprite;
    GameObject relic = null;

    [SerializeField] AudioClip popSfx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        //Vector3 newPos = Vector3(transform.position.x, transform.position.y, 0);
        transform.position += Vector3.up * speed * Time.deltaTime;

        if(relic){
            relic.transform.position = transform.position;
            relic.transform.rotation = transform.rotation;
        }
    }

    public void Pop(){
        GetComponentInChildren<SpriteRenderer>().sprite = popSprite;
        GetComponent<Collider2D>().isTrigger = true;
        if(relic) relic.GetComponent<Collider2D>().isTrigger = false;
        StartCoroutine(WaitForDestroy());
    }

    IEnumerator WaitForDestroy(){
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    public bool HasRelic(){
        if(relic) return true;
        else return false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.TryGetComponent(out Bubble bubble)){
            BubbleManager.instance.AddContact(gameObject);
        }

        if(other.gameObject.CompareTag("Relic")){
            Collider2D myCollider = GetComponent<CircleCollider2D>();
            if (other.collider.bounds.size.x + 0.5f < myCollider.bounds.size.x){
                Debug.Log(other.collider.bounds.size.x);
                Debug.Log(myCollider.bounds.size.x);
                relic = other.gameObject;
                relic.GetComponent<Collider2D>().isTrigger = true;
                relic.GetComponent<Relic>().SetBubble(gameObject);
            } 
            else{
                Pop();
            } 
        }
    }

    private void OnDestroy(){
        StartDyingSFX();
    }

    private void StartDyingSFX(){
        GameObject aud = new GameObject();
        aud.gameObject.tag = "EmptySoundObj";
        aud.AddComponent<AudioSource>();
        //in base alla profondità cambia la clip del suono
        aud.GetComponent<AudioSource>().clip = popSfx;
        aud.GetComponent<AudioSource>().volume = 0.2f;
        aud.GetComponent<AudioSource>().Play();
    }
}
