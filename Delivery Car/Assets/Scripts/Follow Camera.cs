using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

//VARIABLES
    [SerializeField] GameObject thingToFollow;

//LATEUPDATE
    void LateUpdate()
    {
        transform.position=thingToFollow.transform.position+new Vector3 (0,0,-10);
    }
}


//FOLLOW CAMERA ALTERNATIVE
//Download Cinemachine: "Window" > "Package Manager" > Change "In Project" to "Unity Registry" > Install Cinemachine
//Go to Hierarchy and right click > "Virtual Camera" > Go to Inspector > Go to Body and click "Framing Tansposer" > Go to Follow and click the sprite
//Ajust frame: Go to Inspector > Go to Body > Adjust Screen X 