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
            PlayerPrefs.DeleteKey("clue1");
            PlayerPrefs.DeleteKey("clue2");
            PlayerPrefs.DeleteKey("clue3");
            PlayerPrefs.DeleteKey("clue4");
            PlayerPrefs.DeleteKey("clue5");
            PlayerPrefs.DeleteKey("clue6");
            PlayerPrefs.DeleteKey("clue7");
            PlayerPrefs.DeleteKey("clue8");
        }
    }

    IEnumerator EndJump(){
        yield return new WaitForSeconds(5);
        JumpCam.SetActive(false);
        //Player.SetActive(true);
        //FlashImg.SetActive(false);
    }

}
