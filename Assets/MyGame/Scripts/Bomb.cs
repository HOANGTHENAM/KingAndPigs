using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Vector2 speed = new Vector2(3f, 0);
    public Vector2 knockback = new Vector2(0, 0);
    public int damage = 10;
    Rigidbody2D rb;
    Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        rb.velocity = new Vector2(speed.x * transform.localScale.x, speed.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable != null)
        {
            Vector2 deliveredKnockback = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
            bool gotHit = damageable.Hit(damage, deliveredKnockback);
            if (gotHit)
            {
                Debug.Log(collision.name + "hit " + damage);
                StartCoroutine(BombBoom());
            }
        }
    }
    IEnumerator BombBoom()
    {

        animator.SetTrigger(AnimationStrings.boomTrigger);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
   
}
