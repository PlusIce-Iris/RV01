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
        // ��ȡ��ֱ��Y�ᣩ�����������ֵ
        zAxis=Input.GetAxis("Vertical");
        xPaddle=paddle.transform.position.x;
        zPaddle=paddle.transform.position.z;
        Vector2 vector2 = new Vector2(xAxis, zAxis);
        Vector2 vectorPaddle= new Vector2(xPaddle, zPaddle);
        */

        //controllerVelocity = trackedObject.GetVelocity();

        // ��ȡ�ٶȵĴ�С�������Ĵ�С��
        controllerVelocity=GetVelocity();
        controllerForce = controllerVelocity.magnitude;

        // �����ֱ����Ĵ�С
        //float controllerForce = controllerVelocity.magnitude;
        // ������Ĵ�С
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

        //3.�ֱ�ĳһ������̧��
        if (Input.GetButtonUp("Jump"))
        {
            paddle.GetComponent<Rigidbody>().isKinematic = false;
        }
        */
           // ��ȡ�ֱ�����
        //joystickInput = GetJoystickInput();

        // �����ֱ��������ƶ�����
        //MoveObject();

    }
    /*
    Vector2 GetJoystickInput()
    {
        // ��ȡ�ֱ�����
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
        // �����ֱ������������ƶ�����
        
        Vector3 moveDirection = new Vector3(0f, 0f, -controllerForce);

        // ʹ���ֱ�������Ϊ�ƶ�����ı������ӣ��������ƶ��ٶ�
        Vector3 moveDistance = moveDirection * moveSpeed * Time.deltaTime;

        // Ӧ���ƶ�
        transform.Translate(moveDistance);
    }
    */
    public Vector3 GetVelocity()
    {
        return poseAction[inputSource].velocity;
    }
}
