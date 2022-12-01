using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class ControladorMenu : MonoBehaviour
{   
    [Header("Levels to Load")]
    public string _GameLevel;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    public void GameLevelDialogYes()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_GameLevel);
    }

    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            return;
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }

    public void ExitButon()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }


    public void InitialMenu()
    {
        SceneManager.LoadScene("MenuInicial");
        Time.timeScale = 1;
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void RestartScene(){
        string cena = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(cena);
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        LevelLoaderScript.Instance.LoadNextLevel(1); //Carrega o prólogo
    }
}
