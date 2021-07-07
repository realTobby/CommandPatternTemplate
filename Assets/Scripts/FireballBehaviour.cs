using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;

    public Vector2 movement;
    public float moveSpeed = 0f;
    public int _sentDamage = 0;
    public void InitFireball(Vector2 direction, int damageValue)
    {
        movement = (direction - (Vector2)transform.position).normalized;
        _sentDamage = damageValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
            move();
    }

    void move()
    {
        rb.MovePosition((Vector2)transform.position + (movement * moveSpeed * Time.deltaTime));
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag != "Player" && collision.transform.tag != "Damage")
            Destroy(this.gameObject);
        else
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), collision.collider);
        }
    }
}
