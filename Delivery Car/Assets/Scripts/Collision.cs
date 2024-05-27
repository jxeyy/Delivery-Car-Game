using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{

//VARIABLES
    bool hasPackage=false;

    [SerializeField]float destroyDelay=0.5f;


    [SerializeField]Color32 hasPackageColor=new Color32(1,1,1,1);
    [SerializeField]Color32 noPackageColor=new Color32(1,1,1,1);
    SpriteRenderer spriteRenderer;


//START
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>(); //Must have this code for color change to work

        Debug.Log("Instructions: Drive along the road and collect all 6 purple packages and deliver them to the blue mailboxes around the neighbourhood.");
        Debug.Log("Driving pass pink blocks will speed you up but bumping into houses, trees or rocks will slow you down... Let's go!");
    }


//MESSAGE ON PACKAGES
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="Package"&&hasPackage==false)
        {
            Debug.Log("Package picked up"); 
            hasPackage=true;
            spriteRenderer.color=hasPackageColor;
            Destroy(other.gameObject,destroyDelay);
        }

        if(other.tag=="Customer"&&hasPackage==true) //Customer will only comment when package was picked up
        {
            Debug.Log("Package delivered");
            hasPackage=false; 
            spriteRenderer.color=noPackageColor;
            Destroy(other.gameObject,destroyDelay);
        }
    }

}
