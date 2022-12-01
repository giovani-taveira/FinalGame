using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public AudioSource sourceWalkForest;
    public AudioSource sourceWalkHouse;
    public AudioSource sourceWalkMines;
    public AudioSource sourceSoundMonster;
    
    public AudioSource sourcePlayerForest;
    public AudioSource sourcePlayerHouse;
    public AudioSource sourcePlayerMines;
    public AudioSource sourcePaper;

    public ChaseController chaseScript;

    //Pistas:
    [SerializeField] Clues clue1;
    [SerializeField] Clues clue2;
    [SerializeField] Clues clue3;
    [SerializeField] Clues clue4;
    [SerializeField] Clues clue5;
    [SerializeField] Clues clue6;
    [SerializeField] Clues clue7;
    [SerializeField] Clues clue8;

    private bool clue1Bool;
    private bool clue2Bool;
    private bool clue3Bool;
    private bool clue4Bool;
    private bool clue5Bool;
    private bool clue6Bool;
    private bool clue7Bool;
    private bool clue8Bool;

    [SerializeField] GameObject paper;
    [SerializeField] TextMeshProUGUI clueText;
    [SerializeField] Image clueImage;

    private bool clueTag;
    private bool firstTimeSoundGrowl;
    private bool cantMove = false;
    public bool isRunning = false;
    private bool startedRunning = false;

    public Animator textForest;

    public bool inForest;

    public LookMonsterMove lookMonsterMoveScript;
    float fadeSpeed = 0.055f;

    [SerializeField] AudioSource sourceAmbienceForest;

    void Start()
    {
        stamina = 100;
        rb = GetComponent<Rigidbody>();
        clueTag = false;
        clue1Bool = false;
        clue2Bool = false;
        clue3Bool = false;
        clue4Bool = false;
        clue5Bool = false;
        clue6Bool = false;
        clue7Bool = false;
        clue8Bool = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (paper.gameObject.activeInHierarchy)
            paper.SetActive(false);

        sourceWalkForest.enabled = false;
        firstTimeSoundGrowl = false;
        inForest = true;

        sourceWalkHouse.volume = 0;
        sourceWalkMines.volume = 0;
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
                    cantMove = true;
                    sourcePaper.Play();

                    if (clue1Bool)
                    {
                        clueText.text = clue1.Text;
                        clueImage.sprite = clue1.Image;
                        PlayerPrefs.SetInt("clue1", 1);
                    }
                    else if (clue2Bool)
                    {
                        clueText.text = clue2.Text;
                        clueImage.sprite = clue2.Image;
                        PlayerPrefs.SetInt("clue2", 1);
                    }
                        
                    else if (clue3Bool)
                    {
                        clueText.text = clue3.Text;
                        clueImage.sprite = clue3.Image;
                        PlayerPrefs.SetInt("clue3", 1);
                    }
                    else if (clue4Bool)
                    {
                        clueText.text = clue4.Text;
                        clueImage.sprite = clue4.Image;
                        PlayerPrefs.SetInt("clue4", 1);
                    }
                    else if (clue5Bool)
                    {
                        clueText.text = clue5.Text;
                        clueImage.sprite = clue5.Image;
                        PlayerPrefs.SetInt("clue5", 1);
                    }
                    else if (clue6Bool)
                    {
                        clueText.text = clue6.Text;
                        clueImage.sprite = clue6.Image;
                        PlayerPrefs.SetInt("clue6", 1);
                    }
                    else if (clue7Bool)
                    {
                        clueText.text = clue7.Text;
                        clueImage.sprite = clue7.Image;
                        PlayerPrefs.SetInt("clue7", 1);
                    }
                    else if (clue8Bool)
                    {
                        clueText.text = clue8.Text;
                        clueImage.sprite = clue8.Image;
                        PlayerPrefs.SetInt("clue8", 1);
                    }
                }
                else
                {
                    paper.SetActive(false);
                    clueText.text = string.Empty;
                    cantMove = false;
                    sourcePaper.Play(); 
                }                
            }
        }

        if (!cantMove)
        {
            if (Input.GetKey(KeyCode.A) ||
                Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.D))
            {
                sourceWalkForest.enabled = true;
                sourceWalkHouse.enabled = true;
                sourceWalkMines.enabled = true;
            }
            else
            {
                sourceWalkForest.enabled = false;
                sourceWalkHouse.enabled = false;
                sourceWalkMines.enabled = false;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir * force * Time.fixedDeltaTime);
    }

    private void MovePlayer()
    {
        if (!cantMove)
        {
            stamninaBar.fillAmount = stamina / 100;

            dir = player.TransformVector(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized);

            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
            {
                force = 10f;
                stamina -= 0.5f;
                //stamninaBar.enabled = true;
                isRunning = true;
                if (sourceWalkForest.pitch == 1f)
                    sourceWalkForest.pitch = 2f;

                if (sourceWalkHouse.pitch == 1f)
                    sourceWalkHouse.pitch = 2f;

                if (sourceWalkMines.pitch == 1f)
                    sourceWalkMines.pitch = 2f;

                if (!startedRunning && inForest)
                {
                    chaseScript.soundWalkPoint = this.transform.position;
                    chaseScript.soundTriggered = true;
                    startedRunning = true;
                    StartCoroutine(WaitAudioForest(sourceWalkForest));
                }
            }
            else
            {
                force = 5f;
                if (stamina < 100.0f && !Input.GetKey(KeyCode.LeftShift)) stamina += 0.5f;

                isRunning = false;
                if (sourceWalkForest.pitch == 2f)
                    sourceWalkForest.pitch = 1f;

                if (sourceWalkHouse.pitch == 2f)
                    sourceWalkHouse.pitch = 1f;

                if (sourceWalkMines.pitch == 2f)
                    sourceWalkMines.pitch = 1f;

                if (startedRunning)
                    startedRunning = false;
            }

            rX = Mathf.Lerp(rX, Input.GetAxisRaw("Mouse X") * 2, 100 * Time.deltaTime);
            rY = Mathf.Clamp((rY - Input.GetAxisRaw("Mouse Y") * 2 * 100 * Time.deltaTime), -15, 15);

            player.Rotate(0, rX, 0, Space.World);
            cam.rotation = Quaternion.Lerp(cam.rotation, Quaternion.Euler(rY * 2, player.eulerAngles.y, 0), 100 * Time.deltaTime);
            camPivot.position = Vector3.Lerp(camPivot.position, player.position, 10 * Time.deltaTime);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CanAudio"))
        {
            sourceCan.Play();
            StartCoroutine(WaitAudioForest(sourceCan));
            chaseScript.soundWalkPoint = other.transform.position;
            chaseScript.soundTriggered = true;
        }

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

                case "Pista5":
                    clue5Bool = true;
                    break;

                case "Pista6":
                    clue6Bool = true;
                    break;

                case "Pista7":
                    clue7Bool = true;
                    break;

                case "Pista8":
                    clue8Bool = true;
                    break;
            }
        }

        if (other.gameObject.CompareTag("House"))
        {
            sourceWalkForest.volume = 0;
            sourceWalkHouse.volume = 0.65f;
            sourceWalkMines.volume = 0;
            chaseScript.soundTriggered = false;
            startedRunning = false;
            inForest = false;
            lookMonsterMoveScript.onTheHouse = true;
            StartCoroutine(FadeOut(sourceAmbienceForest));
            Debug.Log("Entrou na casa");
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
            clue5Bool = false;
            clue6Bool = false;
            clue7Bool = false;
            clue8Bool = false;
        }

        if (other.gameObject.CompareTag("House"))
        {
            sourceWalkForest.volume = 0.65f;
            sourceWalkHouse.volume = 0;
            sourceWalkMines.volume = 0;
            lookMonsterMoveScript.onTheHouse = false;
            inForest = true;
            StartCoroutine(FadeIn(sourceAmbienceForest));
            Debug.Log("Saiu da casa");
        }       
            
    }

    public IEnumerator WaitAudioForest(AudioSource source)
    {
        yield return new WaitForSeconds(source.clip.length);
        sourceSoundMonster.Play();
        if (!firstTimeSoundGrowl)
        {
            firstTimeSoundGrowl = true;
            yield return new WaitForSeconds(2f);
            sourcePlayerForest.Play();
            textForest.Play("PlayerForestTextIn");
            StartCoroutine(WaitUntilEndOfSentenceForest(sourcePlayerForest));
        }
    }

    public IEnumerator WaitUntilEndOfSentenceForest(AudioSource audioSource)
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        textForest.Play("PlayerForestTextOut");
    }

    public IEnumerator FadeOut(AudioSource song)
    {
        while (song.volume > 0.08f)
        {
            song.volume -= fadeSpeed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator FadeIn(AudioSource song)
    {
        while (song.volume < 0.3f)
        {
            song.volume += fadeSpeed;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
