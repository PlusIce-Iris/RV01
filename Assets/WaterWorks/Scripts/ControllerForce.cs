using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class ControllerForce : MonoBehaviour
{
    //private ControllerRightMovement rightMovement;
    //private ControllerLeftMovement leftMovement;
    private Vector3 rightVelocity;
    private Vector3 leftVelocity;
    private float rightForce;
    private float leftForce;
    private float horizontalX;
    private float moveSpeed = 5f;
    private float forceZ;
    public SteamVR_Input_Sources leftSource;
    public SteamVR_Action_Pose leftAction = SteamVR_Input.GetAction<SteamVR_Action_Pose>("Pose");
    public SteamVR_Input_Sources rightSource;
    public SteamVR_Action_Pose rightAction = SteamVR_Input.GetAction<SteamVR_Action_Pose>("Pose");
    
    public SteamVR_Input_Sources clickSource;
    public SteamVR_Action_Boolean clickAction;
    //public SteamVR_Input_Sources grableftSource;
   // public SteamVR_Action_Boolean grableftAction;
    //public SteamVR_Input_Sources grabrightSource;
    //public SteamVR_Action_Boolean grabrightAction;
    private float rotationSpeed = 2f;
    private bool isGrab;
    //private GameObject paddleright;
    private void Start()
    {
        //rightMovement=GetComponent<ControllerRightMovement>();
        //paddleright=GameObject.Find("Paddle");

        //leftMovement=GetComponent<ControllerLeftMovement>();
        
    }
    private void Update()
    {
        //Debug.Log(grabAction.GetStateUp(grabSource));
        // ��ȡ�ֱ��ٶ�
        
        rightVelocity=rightAction[rightSource].velocity;
        leftVelocity=leftAction[leftSource].velocity;
        rightForce = rightVelocity.magnitude;
        leftForce=leftVelocity.magnitude;
        MoveObject();
        //Debug.Log("Controller Left Force: " + leftForce);
        //Debug.Log("Controller Right Force: " + rightForce);
        // ���������ʹ�� controllerForce ������������������Ӧ�����������
    }
    void MoveObject()
    {
        


        /*
        if (grabAction.GetStateUp(grabSource))
        {
            // ������ִ���ͷ�ץȡʱ�Ĳ���
            horizontalX=rightForce-leftForce;
            forceZ=(rightForce+leftForce)/2;


            Vector3 moveDirection = new Vector3(0.2f*horizontalX, 0f, -forceZ*0.5f);

            // ʹ���ֱ�������Ϊ�ƶ�����ı������ӣ��������ƶ��ٶ�
            Vector3 moveDistance = moveDirection * moveSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, -horizontalX * rotationSpeed * Time.deltaTime);
            // Ӧ���ƶ�
            transform.Translate(moveDistance);
            Debug.Log("Grab action released.");
        }
        */
        if (clickAction.GetState(clickSource))
        {
            // ������ִ���ͷ�ץȡʱ�Ĳ���
            horizontalX=rightForce-leftForce;
            forceZ=(rightForce+leftForce)/2;


            Vector3 moveDirection = new Vector3(0.1f*horizontalX, 0f, forceZ*0.3f);

            // ʹ���ֱ�������Ϊ�ƶ�����ı������ӣ��������ƶ��ٶ�
            Vector3 moveDistance = moveDirection * moveSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, -horizontalX * rotationSpeed * Time.deltaTime);
            // Ӧ���ƶ�
            transform.Translate(moveDistance);
            Debug.Log("pas avance");
        }
        else { 
            horizontalX=rightForce-leftForce;
            forceZ=(rightForce+leftForce)/2;


            Vector3 moveDirection = new Vector3(0.2f*horizontalX, 0f, -forceZ*0.5f);

            // ʹ���ֱ�������Ϊ�ƶ�����ı������ӣ��������ƶ��ٶ�
            Vector3 moveDistance = moveDirection * moveSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, -horizontalX * rotationSpeed * Time.deltaTime);
            // Ӧ���ƶ�
            transform.Translate(moveDistance);
            // ������ִ��ץȡ�ɹ�ʱ�Ĳ���
            Debug.Log("avance");
        }
        // �����ֱ������������ƶ�����
        /*
        horizontalX=rightForce-leftForce;
        forceZ=(rightForce+leftForce)/2;
   

        Vector3 moveDirection = new Vector3(0.2f*horizontalX, 0f, -forceZ*0.5f);

            // ʹ���ֱ�������Ϊ�ƶ�����ı������ӣ��������ƶ��ٶ�
        Vector3 moveDistance = moveDirection * moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, -horizontalX * rotationSpeed * Time.deltaTime);
        // Ӧ���ƶ�
        transform.Translate(moveDistance);
        */

    }
}