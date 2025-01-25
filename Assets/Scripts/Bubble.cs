using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] float speed = 1;
    GameObject relic = null;
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
                relic.GetComponent<Collider2D>().enabled = false;
            }  
            else{
                Destroy(gameObject);
            } 
        }
    }
}
