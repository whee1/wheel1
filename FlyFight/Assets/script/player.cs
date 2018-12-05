using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private gamemanager Gamemanager;
    public Transform startPoint;
    private Rigidbody2D rigidbody;
    public float HP = 100;

    // Use this for initialization
    void Start()
    {
        Gamemanager = GameObject.Find("Gamemanager").GetComponent<gamemanager>();
        startPoint = GameObject.Find("playerStartPoint").GetComponent<Transform>();
        this.transform.position = startPoint.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamemanager.isStart)
        {
            playerMove();
            if (HP <= 0)
            {
                Gamemanager.isOver = true;
                Destroy(this.gameObject);
            }
        }
    }

    void playerMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.MovePosition((Vector2)transform.position + new Vector2(0, 0.05f));
            //to do 

        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.MovePosition((Vector2)transform.position + new Vector2(0, -0.05f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.MovePosition((Vector2)transform.position + new Vector2(0.05f, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.MovePosition((Vector2)transform.position + new Vector2(-0.05f, 0));
        }
    }

    void resetScene()
    {
        SceneManager.LoadScene(0);

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "bullet")
        {
            HP -= 10;
        }
    }
    /*bool canMove(Vector2 dir)
    {

        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        


        return (hit.collider==GetComponent<BoxCollider2D>());
    }*/


}
