using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public Transform start;
    public float speed = -0.05f;
    public int damage = 10;
    private BoxCollider2D collider2D;
    private Rigidbody2D rigidbody;
    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        transform.position = start.position;


    }

    // Update is called once per frame
    void Update()
    {

        rigidbody.MovePosition((Vector2)transform.position + new Vector2(0, speed));



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall" || collision.tag == "Player")
        {
            if (collision.tag == "Player")
            {
                collision.gameObject.GetComponent<player>().HP -= damage;
                
            }
            Destroy(this.gameObject);
        }


    }
}
