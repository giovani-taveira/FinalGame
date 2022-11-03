using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private Vector3 dir;
    private Rigidbody rb;

    private float force = 10f;

    [SerializeField]
    private float rY;

    [SerializeField]
    private float rX;

    [SerializeField] private Transform camPivot;
    [SerializeField] private Transform cam;
    [SerializeField] private float stamina;
    public Image stamninaBar;

    //AudioSource's dos objetos que terão o som triggado:
    public AudioSource sourceStick;
    public AudioSource sourceRun;
    public AudioSource sourceCan;
    public AudioSource sourceWalk;

    public ChaseController chaseScript;

    //Pistas:
    [SerializeField] Clues clue1;
    [SerializeField] Clues clue2;
    [SerializeField] Clues clue3;
    [SerializeField] Clues clue4;

    private bool clue1Bool;
    private bool clue2Bool;
    private bool clue3Bool;
    private bool clue4Bool;

    [SerializeField] GameObject paper;
    [SerializeField] TextMeshProUGUI clueText;

    private bool clueTag;

    void Start()
    {
        stamina = 100;
        rb = GetComponent<Rigidbody>();
        clueTag = false;
        clue1Bool = false;
        clue2Bool = false;
        clue3Bool = false;
        clue4Bool = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (paper.gameObject.activeInHierarchy)
            paper.SetActive(false);

        sourceWalk.enabled = false;
    }

    void Update()
    {
        MovePlayer();
        if(stamina < 100)
            stamninaBar.enabled = true;
        else
            stamninaBar.enabled = false;

        if (clueTag)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!paper.gameObject.activeInHierarchy)
                {
                    paper.SetActive(true);

                    if (clue1Bool)
                        clueText.text = clue1.Text;
                    else if (clue2Bool)
                        clueText.text = clue2.Text;
                    else if (clue3Bool)
                        clueText.text = clue3.Text;
                    else if (clue4Bool)
                        clueText.text = clue4.Text;
                }
                else
                {
                    paper.SetActive(false);
                    clueText.text = string.Empty;
                }
            }
        }

        if (Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))
        {
            sourceWalk.enabled = true;
        }
        else
        {
            sourceWalk.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir * force * Time.fixedDeltaTime);
    }

    private void MovePlayer()
    {
        stamninaBar.fillAmount = stamina / 100;
        Debug.Log(stamninaBar.fillAmount);

        dir = player.TransformVector(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized);

        if(Input.GetKey(KeyCode.LeftShift) && stamina > 0){
            force = 12f; 
            stamina -= 0.5f;
            //stamninaBar.enabled = true;

        }else{
            force = 6f;
            if(stamina < 100.0f && !Input.GetKey(KeyCode.LeftShift)) stamina += 0.5f;
        }

        rX = Mathf.Lerp(rX, Input.GetAxisRaw("Mouse X") * 2, 100 * Time.deltaTime);
        rY = Mathf.Clamp((rY - Input.GetAxisRaw("Mouse Y") * 2 * 100 * Time.deltaTime), -15, 15);

        player.Rotate(0, rX, 0, Space.World);
        cam.rotation = Quaternion.Lerp(cam.rotation, Quaternion.Euler(rY * 2, player.eulerAngles.y, 0), 100 * Time.deltaTime);
        camPivot.position = Vector3.Lerp(camPivot.position, player.position, 10 * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.CompareTag("CanAudio"))
        // {
        //     sourceCan.Play();
        //     //StartCoroutine(WaitAudio(sourceCan));
        //     chaseScript.soundWalkPoint = other.transform.position;
        //     chaseScript.soundTriggered = true;
        // }

        if (other.gameObject.CompareTag("Clue"))
        {
            clueTag = true;

            switch (other.gameObject.name)
            {
                case "Pista1":
                    clue1Bool = true;
                    break;

                case "Pista2":
                    clue2Bool = true;
                    break;

                case "Pista3":
                    clue3Bool = true;
                    break;

                case "Pista4":
                    clue4Bool = true;
                    break;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Clue"))
        {
            clueTag = false;

            clue1Bool = false;
            clue2Bool = false;
            clue3Bool = false;
            clue4Bool = false;
        }
    }
}
