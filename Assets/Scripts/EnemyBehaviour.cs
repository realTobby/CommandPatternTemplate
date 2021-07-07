using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject playerReference;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 2.5f;

    public int CurrentHP = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player").gameObject;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 direction = playerReference.transform.position - transform.position;
        direction.z = 10f;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;


        direction.Normalize();

        movement = direction;

        if (CurrentHP <= 0)
            Destroy(this.gameObject);

    }
    
    void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Damage")
        {
            // get damage!
            CurrentHP -= collision.gameObject.GetComponent<FireballBehaviour>()._sentDamage;
        }

    }

}
