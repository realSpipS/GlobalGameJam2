using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int lifes;
    private bool isDead;
    protected bool isAttacking;
    [SerializeField] protected GameObject pointA;
    [SerializeField] protected GameObject pointB;
    [SerializeField] float speed;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.TryGetComponent(out Bubble bubble)){
            bubble.Pop();
        }
        
        if(other.collider.TryGetComponent(out Player player)){
            player.gotHit = true;
        }
    }


    protected IEnumerator Patroll()
    {
        Transform target = pointA.transform;
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target.position) <= 0)
            {
                target = target == pointA.transform ? pointB.transform : pointA.transform;
                yield return new WaitForSeconds(0.5f);
            }
            yield return null;
        }

    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }*/
}
