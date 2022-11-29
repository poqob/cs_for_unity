using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower1 : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;
    public float followSpeed=10;
    public float lookSpeed = 10;
    public Vector3 adjustment;
   
   
    public void LookAtTarget()
    {
        Vector3 _lookDirection = objectToFollow.position - transform.position+adjustment;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
    }
    //olum vektörler dersi al m* iki vektör çrplýyor mþ toplamak içn
    public void MoveToTarget()
    {
        Vector3 _targetPos = objectToFollow.position +
                             objectToFollow.forward * offset.z +
                             objectToFollow.right * offset.x +
                             objectToFollow.up * offset.y;
        transform.position = _targetPos;
    }

    public void WanderAroundTarget()
    {
        if (Input.GetKey(KeyCode.L))
            offset.x += 10 * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.K))
            offset.x -= 10*Time.deltaTime;
     

    }
    
    
    
    private void LateUpdate()
    {
        LookAtTarget();
        MoveToTarget();
        WanderAroundTarget();
    }




}
