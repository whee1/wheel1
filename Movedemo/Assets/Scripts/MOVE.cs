using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVE : MonoBehaviour {

    public GameObject anibody;
    public float speed = 3.0F;//移动速度
    public float jumpSpeed = 8.0F;//跳跃速度
    public float gravity = 20.0F;//重力加速度
    private Vector3 moveDirection = Vector3.zero;//移动方向
    public CharacterController controller;
    Quaternion ed;//四元数 方向
    //public Transform camPivot;
    //public Transform camDir;
    //public Transform forwardstep;
    //public Transform downstep;
    private Transform tr; //本物体transform

    private float h, v;

    private Vector3 currPos = Vector3.zero; //当前位置
    private Quaternion currRot = Quaternion.identity; //当前旋转

    void Awake()
    {
        ed = new Quaternion(0, 0, 0, 0);
        tr = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
        currPos = tr.position;
        currRot = tr.rotation;
    }

    void Update()
    {
        if (controller.isGrounded)//判断人物是否在地面
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));//获取操作方向
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKeyDown(KeyCode.Space))//跳跃
                moveDirection.y = jumpSpeed;
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
        else//跳跃状态
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, moveDirection.y, Input.GetAxis("Vertical") * speed);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }


    }

    }
