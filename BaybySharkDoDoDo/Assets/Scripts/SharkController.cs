using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SharkController : MonoBehaviour
{
    

    Rigidbody rb;

    [SerializeField] GameObject blood;

    [SerializeField] float frontSpeed = -20f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float jumpSpeed = 2f;
    public VariableJoystick joystick;

    public bool left, right,jumpup,jumpdown;

    public int hp,point;

    public bool isFinish;
    void Start()
    {
        
        point = 0;
        hp = 0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //For Rotate Shark 
        rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.AngleAxis(joystick.Horizontal / 2 * 25, Vector3.up), 7*Time.deltaTime);

        //For Direct Movement
        transform.Translate(frontSpeed * Time.deltaTime, 0, 0);

        
        //Movement With Joystick
        if (joystick.Horizontal < 0)
        {
            
            right = true;
            left = false;
        }
        if (joystick.Horizontal > 0)
        {
            
            left = true;
            right = false;
        }
        if (right == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed* joystick.Horizontal), 5f*Time.deltaTime);
            right = false;
        }
        if (left == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed * joystick.Horizontal), 5f*Time.deltaTime);
            left = false;
        }


        //Jump With Joystick
        if (joystick.Vertical > 0.8f)
        {
            Debug.Log(joystick.Vertical);
            GetComponent<Animator>().SetBool("jump", true);
        }
        if (jumpup)
        {
            
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 10, transform.position.z), 5f * Time.deltaTime);
            jumpdown = false;
        }
        if (jumpdown)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 0, transform.position.z), 5f * Time.deltaTime);
            jumpup = false;

        }
       
    }

    //Jump Events
    public void JumpUp()
    {
        jumpup = true;
        jumpdown = false;
        
    }
    public void JumpDown()
    {
        jumpdown = true;
        jumpup = false;
        GetComponent<Animator>().SetBool("jump",false);
        
    }
    public void JumpFinish()
    {
        
        jumpdown = false;
        jumpup = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Torus")
        {
            var go = Instantiate(blood,collision.transform.position,Quaternion.identity);
            Destroy(go, 2f);
            Destroy(collision.gameObject);
            point++;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            
            hp++;

        }
        if (collision.gameObject.tag == "Finish")
        {
            isFinish = true;
        }
    }
}
