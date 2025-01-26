using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bubblePrefab;
    [SerializeField] Transform firePos;
    //[SerializeField] Sprite sprite;
    [SerializeField] int speed = 1;
    [SerializeField] float gunRange = 1;
    [SerializeField] float pushForce = 1;
    float gravity = 0.5f;
    float fire1 = 0;
    float fire2 = 0;
    GameObject currentBubble;
    Rigidbody2D rb;

    //sound
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip blowBubble;
    [SerializeField] AudioClip growBubble;
    private bool blowing = false;
    private bool fire2Pressed = false;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h_mov = Input.GetAxis("Horizontal") * Time.deltaTime;
        float v_mov = Input.GetAxis("Vertical") * Time.deltaTime;

        fire1 = Input.GetAxis("Fire1");
        fire2 = Input.GetAxis("Fire2");

        Vector3 direction = new Vector3(h_mov, v_mov, 0).normalized * speed;

        transform.Translate(direction * Time.deltaTime, Space.World);

        if (currentBubble.IsDestroyed()){
            currentBubble = null;
            blowing = false;
        }
        
        if(Input.GetButtonDown("Fire1")){
            if(!blowing){
                source.loop = true;
                source.clip = blowBubble;
                source.Play();
                blowing = true;
            }
        }

        if(Input.GetButtonUp("Fire1")){
            if(blowing){
                source.loop = false;
                blowing = false;
                source.Stop();
                source.clip = blowBubble;
                PlaySoundAtTime(19.300f);
            }            
        }

        if(Input.GetButtonUp("Fire2")){
            if(blowing){
                ReleaseBubble();
            }        
            fire2Pressed = false;    
        }
        
    }

    private void FixedUpdate() {
        transform.position += Vector3.down * Time.deltaTime * gravity;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 dir = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;

        if (dir.x < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        else transform.rotation = Quaternion.Euler(0, 0, 0);

        if(fire1 > 0 && fire2 == 0){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, gunRange);
            if (hit){
                if (hit.collider.TryGetComponent(out Bubble bubble)){
                    hit.rigidbody.AddForce(dir * pushForce);
                }
            }

            rb.AddForce(-dir * (pushForce/2));
        }

        if(fire2 > 0 && fire1 == 0){
            if (!blowing && !fire2Pressed){          
                currentBubble = Instantiate(bubblePrefab, firePos.position, Quaternion.identity, transform.parent);
                float currentSize = currentBubble.transform.localScale.x;
                float angle = Mathf.Atan2(dir.y, dir.x);

                currentBubble.transform.position = new Vector2(firePos.position.x + (currentSize / 2 * Mathf.Cos(angle)),
                    firePos.position.y + (currentSize / 2 * Mathf.Sin(angle)));

                blowing = true;
                fire2Pressed = true;
            } 
            else if (blowing){
                if (currentBubble.transform.localScale.x < 1.6f) 
                    currentBubble.transform.localScale += Vector3.one * 0.01f;

                float angle = Mathf.Atan2(dir.y, dir.x);

                currentBubble.transform.position = new Vector2(
                    firePos.position.x + (currentBubble.transform.localScale.x / 2 * Mathf.Cos(angle)),
                    firePos.position.y + (currentBubble.transform.localScale.x / 2 * Mathf.Sin(angle))
                );

                
            } 
        }
    }

    void ReleaseBubble(){
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 dir = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
        currentBubble.GetComponent<Rigidbody2D>().AddForce(dir * 50);
        currentBubble.GetComponent<Bubble>().enabled = true;
        currentBubble.GetComponent<Collider2D>().enabled = true;
        currentBubble = null;
        blowing = false;
    }

    private void OnDrawGizmos() {
        if(fire1 > 0){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 dir = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;

            Gizmos.DrawRay(transform.position, dir * gunRange);
        }
    }

    void PlaySoundAtTime(float timeWanted){
        if(timeWanted > source.clip.length)
            return;
        else{
            source.time = timeWanted;
            source.Play();
        }
    }
}
