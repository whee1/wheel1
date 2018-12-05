using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public GameObject bullet;
    public float timer = 0;
    public float timeLimit = 1;
    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > timeLimit)
        {
            GameObject temp = GameObject.Instantiate(bullet);
            temp.GetComponent<EnemyBullet>().start = this.transform;



            timer = 0;
        }
    }
}
