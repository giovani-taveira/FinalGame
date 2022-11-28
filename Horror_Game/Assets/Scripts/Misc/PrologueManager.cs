using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrologueManager : MonoBehaviour
{
    [SerializeField] Animator fadeAnim;
    [SerializeField] AudioSource sourcePrologue;
    [SerializeField] GameObject subtitles;
    [SerializeField] TextMeshProUGUI subtitlesText; 

    void Start()
    {
        subtitles.SetActive(false);
        StartCoroutine(WaitForAudioAndAnim());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForAudioAndAnim()
    {
        yield return new WaitForSeconds(2f);
        sourcePrologue.Play();
        yield return new WaitForSeconds(7f);
        fadeAnim.Play("FadeToBlackPrologue");

        //Implanta��o da legenda din�mica para o pr�logo:
        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: Al�?''";
        yield return new WaitForSeconds(1.5f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Desconhecida: Al�? � o detetive Fonseca?''";
        yield return new WaitForSeconds(2.5f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: Sim, sou eu mesmo.''";
        yield return new WaitForSeconds(1.6f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Desconhecida: Eu preciso de ajuda! Meu filho sumiu! Ele foi acampar em uma " +
            "floresta afastada da vila vizinha e disse que voltava em quatro dias, mas j� faz uma semana que ele n�o d� not�cias.''";
        yield return new WaitForSeconds(10f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: Calma, senhora. Respira...''";
        yield return new WaitForSeconds(2.5f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: A senhora n�o acha que ele decidiu ficar mais alguns dias e s� esqueceu de avisar?''";
        yield return new WaitForSeconds(4.7f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Desconhecida: N�o! Meu filho nunca faria isso! Ele sempre me mant�m informada se houver " +
            "mudan�as de planos!''";
        yield return new WaitForSeconds(5.5f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Desconhecida: Voc� tem que me ajudar, por favor!''";
        yield return new WaitForSeconds(2.8f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: Olha, senhora, eu...''";
        yield return new WaitForSeconds(1f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Desconhecida: Eu pago o que voc� precisar! Eu sei que voc� n�o tem um caso h� muito tempo, voc� est� falido, precisa de dinheiro!''";
        yield return new WaitForSeconds(7.5f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: Hahaha... E por qual motivo voc� contrataria um detetive falido? Se eu n�o tenho casos h� um tempo, quer dizer " +
            "que eu n�o presto, certo?''";
        yield return new WaitForSeconds(7f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Desconhecida: Eu n�o sei se o senhor � bom, senhor Fonseca. Mas, como disse antes, o senhor precisa de dinheiro, e eu algu�m que encontre " +
            "o meu filho, ent�o, sei que vai aceitar minha proposta.''";
        yield return new WaitForSeconds(10f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: Certo... Eu irei ajudar a senhora...''";
        yield return new WaitForSeconds(2.3f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: Mas a senhora ter� que me pagar! Encontrando-o ou n�o!''";
        yield return new WaitForSeconds(4f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: Me passa o local em que ele foi acampar...''";
        yield return new WaitForSeconds(2f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        yield return new WaitForSeconds(2f);
        LevelLoaderScript.Instance.LoadNextLevel(1); //Depois tem que mudar quando o resto das cenas forem adicionadas.
    }
}
