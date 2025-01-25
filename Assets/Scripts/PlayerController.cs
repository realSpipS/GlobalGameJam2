using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bubblePrefab;
    [SerializeField] Transform firePos;
    [SerializeField] int speed = 1;
    [SerializeField] float gunRange = 1;
    [SerializeField] float pushForce = 1;
    float gravity = 0.5f;
    float fire1 = 0;

    //sound
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip blowBubble;
    [SerializeField] AudioClip growBubble;
    private bool blowing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h_mov = Input.GetAxis("Horizontal") * Time.deltaTime;
        float v_mov = Input.GetAxis("Vertical") * Time.deltaTime;

        fire1 = Input.GetAxis("Fire1");

        transform.Translate(h_mov * speed, v_mov * speed, 0);

        if(Input.GetMouseButtonDown(1)){
            Instantiate(bubblePrefab, firePos.position, Quaternion.identity, transform.parent);
            source.clip = growBubble;
            source.Play();
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
        
    }

    private void FixedUpdate() {
        transform.position += Vector3.down * Time.deltaTime * gravity;
        if(fire1 > 0){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 dir = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, gunRange);
            if (hit){
                if (hit.collider.TryGetComponent(out Bubble bubble)){
                    hit.rigidbody.AddForce(dir * pushForce);
                }
            }
        }
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
