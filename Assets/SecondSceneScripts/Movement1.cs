using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    //player for Test
    public Transform player;

    public Rigidbody rigid;
    public float speed = 5f;
    public float moveSpped = 10f;
    public float turnSpeed = 50f;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        { 
            rigid.AddForce(transform.forward * speed); 
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(transform.forward * -1 * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.down, turnSpeed * Time.deltaTime);
        }
    }
}