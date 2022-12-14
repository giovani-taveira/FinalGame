using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralManager : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;

    float volumePrincipal;
    [SerializeField] Slider sliderMaster;
    [SerializeField] AudioSource[] audios;

    // Start is called before the first frame update
    void Start()
    {
        //sliderMaster.value = 0.5f;
        //audioManager.volume = sliderMaster.value;
    }

    // Update is called once per frame
    void Update()
    {
        ControlPauseMenu();
    }

    void ControlPauseMenu(){
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(!pauseUI.active)
            {
                foreach (var audio in audios)
                    audio.mute = true;

                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pauseUI.SetActive(true); 
            } 
            else {

                foreach (var audio in audios)
                    audio.mute = false;

                Time.timeScale = 1;
                pauseUI.SetActive(false); 
                Cursor.visible = false;
            }            
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false); 
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;

        foreach (var audio in audios)
            audio.mute = false;
    }

    //public void VolumeControl(float volume)
    //{
    //    volumePrincipal = volume;
    //    audioManager.volume = sliderMaster.value;
    //}
}
