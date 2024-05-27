using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
//VARIABLES
    [SerializeField] ParticleSystem finishEffect;


//TRIGGER - MESSAGE ON FINISH LINE
    private void OnTriggerEnter2D(Collider2D other) //note: if finish line hit player
    {
        if(other.tag=="Player")
        {
            finishEffect.Play();
            Debug.Log("Finish!");
            GetComponent<AudioSource>().Play(); //TYPE 1 AUDIOSOURCE (IS ON FINISHLINE)
        }
    }
    
}
