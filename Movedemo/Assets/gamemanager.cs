using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour {
    public Camera mainCamera;
    public Camera firstCamera;
    public float timer = 0;
	// Use this for initialization
	void Start () {
        cameraStart();
    }
	
	// Update is called once per frame
	void Update () {
        CameraChange();

    }

    void CameraChange()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Q)&&timer>0.5f)
        {
            if (mainCamera.enabled && !firstCamera.enabled)
            {
                firstCamera.enabled = true;
                firstCamera.GetComponent<FPcontrol>().enabled = true;
                mainCamera.enabled = false;
                mainCamera.GetComponent<CameraControl>().enabled = false;
                Cursor.visible = false;//显示光标
            }
            else if (!mainCamera.enabled && firstCamera.enabled)
            {
                Cursor.visible = true;
                firstCamera.enabled = false;
                firstCamera.GetComponent<FPcontrol>().enabled=false;
                mainCamera.enabled = true;
                mainCamera.GetComponent<CameraControl>().enabled = true;
            }
            timer = 0;
               
            
        }

    }
    void cameraStart()
    {
        firstCamera.enabled = false;
        firstCamera.GetComponent<FPcontrol>().enabled = false;
        mainCamera.enabled = true;
        mainCamera.GetComponent<CameraControl>().enabled = true;
        Cursor.visible = true;

    }
}
