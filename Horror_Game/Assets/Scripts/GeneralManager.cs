using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralManager : MonoBehaviour
{
    [SerializeField] GameObject? pauseUI;
    [SerializeField] GameObject? audio;

    float volumePrincipal;
    [SerializeField] Slider sliderMaster;
    [SerializeField] AudioSource audioManager;

    // Start is called before the first frame update
    void Start()
    {
        sliderMaster.value = 0.5f;
        audioManager.volume = sliderMaster.value;
    }

    // Update is called once per frame
    void Update()
    {
        ControlPauseMenu();
    }

    void ControlPauseMenu(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!pauseUI.active)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                audio.SetActive(false);
                pauseUI.SetActive(true); 
            } 
            else{
                Time.timeScale = 1;
                pauseUI.SetActive(false); 
                audio.SetActive(true);
                Cursor.visible = false;
            }            
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false); 
        audio.SetActive(true);
        Cursor.visible = false;
    }

    public void VolumeControl(float volume)
    {
        volumePrincipal = volume;
        audioManager.volume = sliderMaster.value;
    }
}
