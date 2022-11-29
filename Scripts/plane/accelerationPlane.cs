using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerationPlane : MonoBehaviour
{
    public float input3;
    public float input4;
    public float speed=10;
    public float boost=1;
    private float boost1 = 1;
    public float gravity = 1;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input3 = Input.GetAxis("Horizontal");
        input4 = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward*speed*Time.deltaTime*boost);
        transform.Rotate(Vector3.forward*input3*Time.deltaTime*-50);
        transform.Rotate(Vector3.left * input4 * Time.deltaTime * -4*speed);
        //transform.Translate(Vector3.left*input3*Time.deltaTime*-3);
        Boost();
        RightLeft();
        Gravity();
        DecelerateVelocity();
        IncreaseVelocity();



    }
    void Boost()
    {


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            boost = 3;

        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) { boost = boost1; }


    }


    void RightLeft()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(-1*Time.deltaTime*speed/10, 0, 0);
            transform.Rotate(0, -30 * Time.deltaTime*speed / 10, 0);
        }


        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(1 * Time.deltaTime * speed/10, 0, 0);
            transform.Rotate(0, +30 * Time.deltaTime * speed / 10, 0);
        }
    }

    void Gravity()
    {
        if (Input.GetKey(KeyCode.S) == false)
        {
            transform.Translate(Vector3.down * Time.deltaTime * gravity * 2, Space.World);
            transform.Rotate(Time.deltaTime*1.2f, 0, 0);

        }

    }

    void DecelerateVelocity()
    {
        if (speed > 1 & Input.GetKey(KeyCode.F))
        speed -= 1.5f * Time.deltaTime;
        
    }

    void IncreaseVelocity()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            speed += 1.5f * Time.deltaTime;
        }
    }

    void StartStop()
    {

    }

}
