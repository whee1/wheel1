using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPcontrol : MonoBehaviour {

    public Transform target;

    //距离
    public float distance = 5f;

    //右键旋转控制部分
    //旋转速度
    private float speedX = 120;
    private float speedY = 60;
    //Y轴旋转的角度限制
    private float minLimitY = 5;
    private float maxLimitY = 45;
    //旋转角度
    private float mX = 0.0f;
    private float mY = 0.0f;

    //鼠标缩放控制部分
    //鼠标缩放距离最值
    private float maxDistance = 10;
    private float minDistance = 1.5f;
    //鼠标缩放速度
    private float zoomSpeed = 2f;

    //差值控制部分
    //是否启用差值计算
    public bool isNeedDamping = false;
    //差值速度
    public float dampingSpeed = 10f;

    private Quaternion mRotation;
    private Vector3 mPosition;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    private void LateUpdate()
    {
        mX += Input.GetAxis("Mouse X") * speedX * 0.02f;
        mY -= Input.GetAxis("Mouse Y") * speedY * 0.02f;

        //1.1Y轴角度范围限制
        //mY = ClampAngle(mY,minLimitY,maxLimitY);
        mY = Mathf.Clamp(mY, minLimitY, maxLimitY);

        //1.2计算旋转，转化成欧拉角
        mRotation = Quaternion.Euler(mY, mX, 0);

        //2.旋转相机
        //根据是否差值采取不同的角度计算方式,角度旋转的时候不用差值更自然
        //if(isNeedDamping)
        //transform.rotation = Quaternion.Lerp(transform.rotation,mRotation,Time.deltaTime*dampingSpeed);
        //else 
        transform.rotation = mRotation;

        target.rotation = Quaternion.Euler(new Vector3(0, mX, 0));//让角色面朝我们摄像机方向

        mPosition = mRotation * new Vector3(0.0f, 0.5f, 0.0f)+ target.position;
        //if (isNeedDamping)
        //{
        //    transform.position = Vector3.Lerp(transform.position, mPosition, Time.deltaTime * dampingSpeed);
        //}
        //else
        //{
            transform.position = mPosition;
        

    }



}
