using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    [SerializeField] AudioSource Scream;
    [SerializeField] GameObject JumpCam;
    [SerializeField] GameObject GameOverInterface;

    [SerializeField] GameObject lookMonster;
    [SerializeField] GameObject soundMonster;
    [SerializeField] GameObject spiderMonster;

    [SerializeField] PlayerController playerScript;
    [SerializeField] Rigidbody playerRb;
    [SerializeField] AudioSource[] audios;

    private void Start()
    {
        lookMonster.SetActive(false);
        soundMonster.SetActive(false);
        spiderMonster.SetActive(false);
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("LookMonster"))
        {
            var monster = GameObject.FindWithTag("LookMonster");
            monster.SetActive(false);
            Scream.Play();
            JumpCam.SetActive(true);

            lookMonster.SetActive(true);
            soundMonster.SetActive(false);
            spiderMonster.SetActive(false);

            foreach (var audio in audios)
                audio.mute = true;

            playerScript.cantMove = true;
            playerRb.constraints = RigidbodyConstraints.FreezePosition;

            StartCoroutine(EndJump());
        }
        else if (other.gameObject.CompareTag("SoundMonster"))
        {
            var monster = GameObject.FindWithTag("SoundMonster");
            monster.SetActive(false);
            Scream.Play();
            JumpCam.SetActive(true);

            soundMonster.SetActive(true);
            lookMonster.SetActive(false);
            spiderMonster.SetActive(false);

            foreach (var audio in audios)
                audio.mute = true;

            playerScript.cantMove = true;
            playerRb.constraints = RigidbodyConstraints.FreezePosition;

            StartCoroutine(EndJump());
        }
        else if (other.gameObject.CompareTag("SpiderMonster"))
        {
            var monster = GameObject.FindWithTag("SpiderMonster");
            monster.SetActive(false);
            Scream.Play();
            JumpCam.SetActive(true);

            soundMonster.SetActive(false);
            lookMonster.SetActive(false);
            spiderMonster.SetActive(true);

            foreach (var audio in audios)
                audio.mute = true;

            playerScript.cantMove = true;
            playerRb.constraints = RigidbodyConstraints.FreezePosition;

            StartCoroutine(EndJump());
        }
    }

    IEnumerator EndJump(){
        yield return new WaitForSeconds(5);
        JumpCam.SetActive(false);
        Time.timeScale = 0;
        GameOverInterface.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //Player.SetActive(true);
        //FlashImg.SetActive(false);
    }

}
