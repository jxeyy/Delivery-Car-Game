using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

//VARIABLES
    [SerializeField]float steerSpeed=0.1f;
    [SerializeField]float moveSpeed=0.1f;
    [SerializeField]float slowSpeed=0.1f;
    [SerializeField]float boostSpeed=0.5f;


//UPDATE
    void Update()
    {
        float steerAmount=Input.GetAxis("Horizontal")*steerSpeed*Time.deltaTime; //VARIABLE
        float moveAmount=Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime; //VARIABLE
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);

    }

//MESSAGE ON DIFFERENT COLLISIONS

    private void OnCollisionEnter2D(Collision2D other)
        {
        Debug.Log("Obstacle!");
        moveSpeed=slowSpeed;
        }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="Boost")
        {
            Debug.Log("Speed up!");
            moveSpeed=boostSpeed;
        }
    }
}
