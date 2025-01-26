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
