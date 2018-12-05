using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject bullet;
    private float timer=0;
    public float timeLimit = 0.5f;
    // Update is called once per frame
    void Update () {
        if (GameObject.Find("Gamemanager").GetComponent<gamemanager>().isStart)
        {
            timer += Time.deltaTime;
            if (timer > timeLimit)
            {
                GameObject temp = GameObject.Instantiate(bullet);
                temp.GetComponent<Bullet>().start = this.transform;
                timer = 0;
            }
        }
      
	}
}
