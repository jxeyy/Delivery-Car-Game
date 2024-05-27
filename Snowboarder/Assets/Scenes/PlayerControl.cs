using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE TO SELF: Snowboard can slide on ground due to "Edge Collider 2D" & "Surface Effector 2D" in Level Sprite Shape
//But means "Capsule Collider 2D" and "Circle Collider 2D" cannot have Trigger if not will sink into ground



public class PlayerControl : MonoBehaviour
{
//VARIABLES

    Rigidbody2D rb2d; //renaming the component/type Rigidbody2D & putting it here so that all methods (eg. Start & Update can use)
    SurfaceEffector2D surfaceEffector2D; //renaming the component/type SurfaceEffector2D & putting it here so that all methods (eg. Start & Update can use)
    bool canMove=true;

    [SerializeField] float torqueAmount=10f;
    [SerializeField] float boostSpeed=25f;
    [SerializeField] float moveSpeed=15f;


//START
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        surfaceEffector2D=FindObjectOfType<SurfaceEffector2D>(); 
    }

//UPDATE
    void Update()
    {
        if(canMove)
        {
            RotatePlayer(); //ReloadScene command is below, this is just to make script less messy
            RespondToBoost();  
        }     
    }  


//
    public void DisableControls() 
    //PUBLIC METHOD to be called in CrashDetector
    //As added loaddelay so need this if not player can move a bit after crashing
    {
        canMove=false;
    }

       
//REFERENCES    
    void RotatePlayer() //can just put under UPDATE but this is for less messy
    {
        if(Input.GetKey(KeyCode.LeftArrow)) //IF push left arrow key
        {
            rb2d.AddTorque(torqueAmount);
        } 

        else if(Input.GetKey(KeyCode.RightArrow)) //Cannot push right arrow at same time as left arrow
        {
            rb2d.AddTorque(-torqueAmount);
        } 
    }

    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed=boostSpeed;
        }

        else
        {
            surfaceEffector2D.speed=moveSpeed;
        }
    }

    
}
