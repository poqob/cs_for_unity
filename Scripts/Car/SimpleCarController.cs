using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;
    private bool m_break;
    

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float maxSteerAngle = 30;
    public float motorForce = 2000;
    public float maxMotorTorque = 4000;

    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
        m_break = Input.GetKey(KeyCode.Space);
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steeringAngle;
        frontPassengerW.steerAngle = m_steeringAngle;


    }
    
    private void Accelerate()
    {
        if (frontPassengerW.motorTorque < maxMotorTorque & frontDriverW.motorTorque < maxMotorTorque)
        {
            frontPassengerW.motorTorque = m_verticalInput * motorForce;
            frontDriverW.motorTorque = m_verticalInput * motorForce ;
        }
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);

    }

    private void HandBreak()
    {
        
       
        if (m_break)
        {
            frontPassengerW.brakeTorque = 3000;
            frontDriverW.brakeTorque = 3000;
            rearDriverW.brakeTorque = 3000;
            rearPassengerW.brakeTorque = 3000;
        }
        else
        {
            frontPassengerW.brakeTorque = 0;
            frontDriverW.brakeTorque = 0;
            rearDriverW.brakeTorque = 0;
            rearPassengerW.brakeTorque = 0;

        }

       
        
    }

   



    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = transform.position;
        Quaternion _quat = transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;

    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
        HandBreak();
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
