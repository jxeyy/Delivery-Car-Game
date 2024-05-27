using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//On collision between player & jewel, audio will play & jewel will disappear
//I wanted to put this script under the Jewels but only player's head is collision trigger so cannot

public class Jewels : MonoBehaviour
{

//TRIGGER
private void OnTriggerEnter2D(Collider2D other) 
{
    if(other.tag=="Jewel")
    {
        Debug.Log("Jewel collected!");
        Destroy(other.gameObject);
        GetComponent<AudioSource>().Play(); //TYPE 1 AUDIOSOURCE (IS ON PLAYER, I WANTED USE TYPE 2 BUT DK WHY IT WILL CRASH)
    }
    
    if(other.tag=="Glitter")
    {
        Destroy(other.gameObject);
    }
}    

}
