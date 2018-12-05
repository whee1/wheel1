using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int HP;
    public float speed = 0.01f;
    public Enemy enemyType;
    public Rigidbody2D rigidbody;
    public Animator breakController;
    public gamemanager Gamemanager;
    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        breakController = GetComponent<Animator>();
        Gamemanager = GameObject.Find("Gamemanager").GetComponent<gamemanager>();
        //设定HP
        if (enemyType== Gamemanager.Lv1_Enemy)
        {
            HP = 50;
        }
        else if (enemyType == Gamemanager.Lv2_Enemy)
        {
           HP = 70;
        }
        else if (enemyType == Gamemanager.Lv3_Enemy)
        {
            HP = 100;
        }

        this.gameObject.transform.position = new Vector2(Random.Range(-1.4f, 1.4f), 2.8f);
        //敌人的生成 主要是生成位置 y固定2.8 x 从-1.4~1.4随机位置
    }
	
	// Update is called once per frame
	void Update () {

        breakController.SetInteger("HP", HP);
        if (HP>0)
        {
            enemyMove();
        }
        if (Gamemanager.isOver==true)
        {
            this.gameObject.SetActive(false);
         }
        if (HP<=0)
        {
            Invoke("breakThis", 1.5f);
            return;
        }                                           
        
        
	}
    void enemyMove()
    {
        rigidbody.MovePosition((Vector2)transform.position + new Vector2(0, -speed));
        //敌人移动
        //在一定坐标范围内随机移动
    }

    private void OnCollisionEnter2D(Collision2D collision)//碰到下墙销毁
    {
        if (collision.gameObject.name== "bounddown")
        {
            Destroy(this.gameObject);
        }
       
    }

    void breakThis()
    {
        if (enemyType == Gamemanager.Lv1_Enemy)
        {
            Gamemanager.Score += 10;
            Gamemanager.smBreakCount++;
        }
        if (enemyType == Gamemanager.Lv2_Enemy)
        {
            Gamemanager.Score += 20;
            Gamemanager.midBreakCount++;
        }
        if (enemyType == Gamemanager.Lv3_Enemy)
        {
            Gamemanager.Score += 50;

        }
        Destroy(this.gameObject);

    }
}
