using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public AudioSource Scream;
    //public GameObject Player;
    public GameObject JumpCam;
    //public GameObject FlashImg;

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
        //Player.SetActive(true);
        //FlashImg.SetActive(false);
    }

}
