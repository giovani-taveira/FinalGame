using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LookMonsterSentence : MonoBehaviour
{
    public bool firstTimeLookMonster;
    public AudioSource sourcePlayerHouse;
    public Animator textHouse;
    public TextMeshProUGUI textHouseText;

    private void Start()
    {
        firstTimeLookMonster = false;
    }

    public void OnTriggerEnter(Collider other)
    {
w        if (other.gameObject.CompareTag("LookMonster") && !firstTimeLookMonster)
            StartCoroutine(WaitAudioHouse(sourcePlayerHouse));
    }

    private IEnumerator WaitAudioHouse(AudioSource sourcePlayerHouse)
    {
        firstTimeLookMonster = true;
        textHouseText.text = "''Meu Deus! Que coisa é essa! Ele tava me perseguindo? Eu não o ouvi chegando''";
        yield return new WaitForSeconds(0.2f);
        sourcePlayerHouse.Play();
        textHouse.Play("PlayerForestTextIn");
        StartCoroutine(WaitUntilEndOfSentenceHouse(sourcePlayerHouse));
    }

    private IEnumerator WaitUntilEndOfSentenceHouse(AudioSource sourcePlayerHouse)
    {
        yield return new WaitForSeconds(sourcePlayerHouse.clip.length);
        textHouse.Play("PlayerForestTextOut");
    }
}
