﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public Transform start;
    public float speed = 0.05f;
    public int damage = 20;
    private BoxCollider2D collider2D;
    private Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
       // start = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//子弹初始化位置
        transform.position = start.position;
       	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("Gamemanager").GetComponent<gamemanager>().isStart)
        {
            rigidbody.MovePosition((Vector2)transform.position + new Vector2(0, speed));
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="wall"|| collision.tag == "enemy")
        {
            if (collision.tag == "enemy")
            {
                collision.gameObject.GetComponent<Enemy>().HP -= damage;               
            }
            Destroy(this.gameObject);
        }        
    }
}
