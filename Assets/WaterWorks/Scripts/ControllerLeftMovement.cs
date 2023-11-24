using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using Valve.VR;

public class ControllerLeftMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 joystickInput;
    private float xAxis;
    private float zAxis;
    private GameObject paddle;
    private float xPaddle;
    private float zPaddle;
    //private SteamVR_Behaviour_Pose trackedObject;
    private Vector3 controllerVelocity;
    private float controllerForce;
    public SteamVR_Input_Sources inputSource;
    public SteamVR_Action_Pose poseAction = SteamVR_Input.GetAction<SteamVR_Action_Pose>("Pose");
    private void Start()
    {
        paddle = GameObject.Find("Paddle");
        //trackedObject = GetComponent<SteamVR_Behaviour_Pose>();
    }

    
    void Update()
    {
        /*
        xAxis = Input.GetAxis("Horizontal");
        // 获取垂直（Y轴）方向的轴输入值
        zAxis=Input.GetAxis("Vertical");
        xPaddle=paddle.transform.position.x;
        zPaddle=paddle.transform.position.z;
        Vector2 vector2 = new Vector2(xAxis, zAxis);
        Vector2 vectorPaddle= new Vector2(xPaddle, zPaddle);
        */

        //controllerVelocity = trackedObject.GetVelocity();

        // 获取速度的大小（即力的大小）
        controllerVelocity=GetVelocity();
        controllerForce = controllerVelocity.magnitude;

        // 计算手柄力的大小
        //float controllerForce = controllerVelocity.magnitude;
        // 输出力的大小
        //Debug.Log("Controller Left Force: " + controllerForce);

        /*
        if (Input.GetButtonDown("Jump"))
        {
            
            if (Vector2.Distance(vector2, vectorPaddle)<10)
            {
                paddle.GetComponent<Rigidbody>().isKinematic = true;
                //paddle = null;
            }
        }

        //3.手柄某一个按键抬起
        if (Input.GetButtonUp("Jump"))
        {
            paddle.GetComponent<Rigidbody>().isKinematic = false;
        }
        */
           // 获取手柄输入
        //joystickInput = GetJoystickInput();

        // 根据手柄输入来移动物体
        //MoveObject();

    }
    /*
    Vector2 GetJoystickInput()
    {
        // 获取手柄输入
        Gamepad gamepad = Gamepad.current;

        if (gamepad != null)
        {
            return gamepad.rightStick.ReadValue();
        }

        return Vector2.zero;
    }
    */
    /*
    void MoveObject()
    {
        // 根据手柄输入来计算移动向量
        
        Vector3 moveDirection = new Vector3(0f, 0f, -controllerForce);

        // 使用手柄输入作为移动距离的比例因子，并乘以移动速度
        Vector3 moveDistance = moveDirection * moveSpeed * Time.deltaTime;

        // 应用移动
        transform.Translate(moveDistance);
    }
    */
    public Vector3 GetVelocity()
    {
        return poseAction[inputSource].velocity;
    }
}
