using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Animator camAnim;
    //Animation walkAnim;

    void Start()
    {
        camAnim = GetComponent<Animator>();
        //walkAnim = GetComponent<Animation>();

    }

    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            camAnim.SetTrigger("Walk");

            //if (Input.GetKey("f"))
            //    walkAnim.clip.frameRate = 120;
            //else
            //    walkAnim.clip.frameRate = 60;

            //Debug.Log(walkAnim.clip.frameRate);
        }
        else
        {
            camAnim.SetTrigger("Idle");
        }
    }
}
