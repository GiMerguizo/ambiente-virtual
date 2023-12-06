using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform aimTarget;
    float speed = 3f;
    float force = 10;
    bool hitting;
    void Start()
    {
        
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        float v = Input.GetAxisRaw("Vertical"); 

        if(Input.GetKeyDown(KeyCode.F))
        {
            hitting = true;
        } else if(Input.GetKeyUp(KeyCode.F))
        {
            hitting = false;
        }

        if(hitting)
        {
            aimTarget.Translate(new Vector3(h, 0, 0) * speed * Time.deltaTime);
        }

        if ((h != 0 || v != 0) && !hitting) // if we want to move and we are not hitting the ball
        {
            transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime); // move on the court
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
        Vector3 dir = aimTarget.position - transform.position;
        other.GetComponent<Rigidbody>().velocity = dir.normalized * force;
        }
    }
}