using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private Vector3 dir;
    private Rigidbody rb;
    //private float velocity;
    private float force = 5f;

    [SerializeField]
    private float rY;

    [SerializeField]
    private float rX;

    [SerializeField] private Transform camPivot;
    [SerializeField] private Transform cam;
    [SerializeField] private float stamina;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        stamina = 100.0f;
    }

    void Update()
    {

        dir = player.TransformVector(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized);
        
        if(Input.GetKey(KeyCode.LeftShift) && stamina > 0){
            force = 10f; 
            stamina -= 0.5f;
        }else{
            force = 5f;
            if(stamina < 100.0f) stamina += 0.5f;
        }

        rX = Mathf.Lerp(rX, Input.GetAxisRaw("Mouse X") * 2, 100 * Time.deltaTime);
        rY = Mathf.Clamp((rY - Input.GetAxisRaw("Mouse Y") * 2 * 100 * Time.deltaTime), -30, 30);

        player.Rotate(0, rX, 0, Space.World);
        cam.rotation = Quaternion.Lerp(cam.rotation, Quaternion.Euler(rY * 2, player.eulerAngles.y, 0), 100 * Time.deltaTime);
        camPivot.position = Vector3.Lerp(camPivot.position, player.position, 10 * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir * force  * Time.fixedDeltaTime);
    }
}
