using UnityEngine;
using System.Collections;

public class EelController : EnemyController
{
    
    private Rigidbody2D rb;
    //private Transform currentPoint;
    private Vector3 currentPosition;
    [SerializeField] float attackCooldown;
    [SerializeField] float attackDuration;

    //sprite change
    [SerializeField] GameObject SpriteObject;
    private SpriteRenderer renderer;
    [SerializeField] Sprite baseSprite;
    [SerializeField] Sprite attackingSprite;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = SpriteObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //currentPoint = pointB.transform;
        currentPosition = gameObject.transform.position;
        StartCoroutine(Patroll());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform){
            rb.linearVelocity = new Vector2(speed, 0);
        }else{
            rb.linearVelocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            Flip();
            currentPoint = pointA.transform;
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform){
            currentPoint = pointB.transform;
        }*/
        
        /*
        if(isAttacking){
            renderer.sprite = attackingSprite;
        }else{
            renderer.sprite = baseSprite;
        }*/

        /*
        float step = speed * Time.deltaTime;
        currentPosition = gameObject.transform.position;
        if (currentPosition == pointB.transform.position)
            transform.position = Vector3.MoveTowards(transform.position, pointA.transform.position, step);
        else if(currentPosition == pointA.transform.position)
            transform.position = Vector3.MoveTowards(transform.position, pointA.transform.position, step);
        */
        /*
        StartCoroutine(isAttacking(attackCooldown));
        StartCoroutine(isNotAttacking(attackDuration));*/
    }

    private void Flip(){
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    /*
    IEnumerator attackLoop(float cooldown, float attackTime){
        yield return new WaitForSeconds(cooldown);
        renderer.sprite = attackingSprite;
        yield return new WaitForSeconds(attackTime);
        renderer.sprite = baseSprite;
    }*/

    /*
    private void attackLoop(float cooldown, float attackTime){
        StartCoroutine(isAttacking(cooldown));
        StartCoroutine(isNotAttacking(attackTime));
    }*/


    IEnumerator isAttacking(float cooldown){
        Debug.Log("ISATTACKING");
        SpriteObject.GetComponent<SpriteRenderer>().sprite = baseSprite;
        yield return new WaitForSeconds(cooldown);
        
        
    }

    IEnumerator isNotAttacking(float attackTime){
        Debug.Log("ISNOTATTACKING");
        SpriteObject.GetComponent<SpriteRenderer>().sprite = attackingSprite;
        yield return new WaitForSeconds(attackTime);
    }
    

}
