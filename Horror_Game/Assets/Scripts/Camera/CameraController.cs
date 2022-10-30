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
            camAnim.SetTrigger("Walk");
        else
            camAnim.SetTrigger("Idle");
    }
}
