using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acceleration : MonoBehaviour
{
    public float speed;
    public float input;
    public float input1;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxis("Vertical");
        input1 = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward*speed*Time.deltaTime*input);
        transform.Rotate(Vector3.up,10f*input1*Time.deltaTime*rotationSpeed);
        
        
    }
}
