using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    [SerializeField] AudioSource Scream;
    [SerializeField] GameObject JumpCam;
    [SerializeField] GameObject GameOverInterface;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("LookMonster"))
        {
            var monster = GameObject.FindWithTag("LookMonster");
            monster.SetActive(false);
            Scream.Play();
            JumpCam.SetActive(true);
            //Player.SetActive(false);
            //FlashImg.SetActive(true);
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
