using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Note that there is a double bounce when crashed so there are some codes to stop it

public class CrashDetector : MonoBehaviour
{

//VARIABLES

    [SerializeField] float loadDelay=0.2f; //To delay time for restart
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed=false;


//TRIGGER
    private void OnTriggerEnter2D(Collider2D other) //note: if player's head hit ground
    {
        if(other.tag=="Ground"&&!hasCrashed) //means NOT HAS CRASHED 
        {
            hasCrashed=true;
            FindObjectOfType<PlayerControl>().DisableControls(); //Calling from PlayerControl script (public part)
            crashEffect.Play();
            Debug.Log("Ouch! Restart...");
            GetComponent<AudioSource>().PlayOneShot(crashSFX); //TYPE 2 AUDIOSOURCE (IS ON PLAYER)
            Invoke("ReloadScene",loadDelay); //ReloadScene command is below, this is just to make script less messy
        }
    }
    

//REFERENCES
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
