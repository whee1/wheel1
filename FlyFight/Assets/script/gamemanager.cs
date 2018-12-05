using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour {
    public GameObject plane;
    private GameObject player;
    public Enemy Lv1_Enemy;
    public Enemy Lv2_Enemy;
    public Enemy Lv3_Enemy;
    public int Score=0;
    public int level = 1;
    public int smBreakCount = 0;
    public int midBreakCount = 0;
    public int smCount = 0;
    public int midCount = 0;
    private float timer = 0;
    public bool isOver = false;
    public bool isStart = false;
    public Button startButton;
    public Text title;
    public Text scoreText;
    public Text HPText;
    public Text FinalText;
    void Start () {
        scoreText.gameObject.SetActive(false);
        HPText.gameObject.SetActive(false);
        FinalText.gameObject.SetActive(false);
        isStart = false;
        player = GameObject.Instantiate(plane);//实例化主角
        player.SetActive(false);
	}
    private void Update()
    {
        if (isStart)
        {
            
            if (isOver)
            {
                FinalText.text = "你的分数为：" + Score.ToString();
                FinalText.gameObject.SetActive(true);
                Invoke("resetScene", 2);
            }
            UIupdate();
            Levelup();
            enemyCreate();
        }
       
    }
    void enemyCreate()
    {
        timer += Time.deltaTime;
        if (timer>2)
        {

            if (level==1)
            {
                Enemy templv1 = GameObject.Instantiate(Lv1_Enemy.gameObject).GetComponent<Enemy>();
                templv1.enemyType = Lv1_Enemy;
               
                
            }
            else if (level==2)
            {
                Enemy templv1 = GameObject.Instantiate(Lv1_Enemy.gameObject).GetComponent<Enemy>();
                templv1.enemyType = Lv1_Enemy;
                
                smCount++;
                if (smCount>=3)
                {
                    Enemy templv2 = GameObject.Instantiate(Lv2_Enemy.gameObject).GetComponent<Enemy>();
                    templv2.enemyType = Lv2_Enemy;
                    midCount++;
                   
                    smCount = 0;
                }
            }
            else if (level==3)
            {
                Enemy templv1 = GameObject.Instantiate(Lv1_Enemy.gameObject).GetComponent<Enemy>();
                templv1.enemyType = Lv1_Enemy;
               
                smCount++;
                
                if (smCount >= 2)
                {
                    Enemy templv2 = GameObject.Instantiate(Lv2_Enemy.gameObject).GetComponent<Enemy>();
                    templv2.enemyType = Lv2_Enemy;
                    midCount++;


                    if (midCount==2)
                    {
                        Enemy templv3 = GameObject.Instantiate(Lv3_Enemy.gameObject).GetComponent<Enemy>();
                        templv3.enemyType = Lv3_Enemy;
                        midCount = 0;
                        smCount = 0;
                    }
                  
                }
            }
            timer = 0;
        }
        //敌人的创建逻辑
        //lv1 只创建小敌机
        //lv2 每三只小敌机 一只中敌机
        //lv3 每两只小 两只中 一只大


    }


    void UIupdate()
    {
        if (!isOver)
        {
            HPText.text = "HP：" + player.GetComponent<player>().HP.ToString();
            scoreText.text = "当前分数：" + this.Score.ToString();
        }
    }

    public void gameStart()
    {
        isStart = true;
        scoreText.gameObject.SetActive(true);
        HPText.gameObject.SetActive(true);
        title.gameObject.SetActive(false);       
        player.SetActive(true);
        startButton.gameObject.SetActive(false);
    }

    void Levelup()
    {
        if (smBreakCount==15)
        {
            level = 2;
        }
        if (smBreakCount >=30&&midCount>=5)
        {
            level = 3;
        }
    }
    void resetScene()
    {
        SceneManager.LoadScene(0);
    }    
}
