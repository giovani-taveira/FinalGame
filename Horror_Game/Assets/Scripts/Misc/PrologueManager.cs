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

        //Implantação da legenda dinâmica para o prólogo:
        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: Alô?''";
        yield return new WaitForSeconds(1.5f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Desconhecida: Alô? É o detetive Fonseca?''";
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
            "floresta afastada da vila vizinha e disse que voltava em quatro dias, mas já faz uma semana que ele não dá notícias.''";
        yield return new WaitForSeconds(10f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: Calma, senhora. Respira...''";
        yield return new WaitForSeconds(2.5f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: A senhora não acha que ele decidiu ficar mais alguns dias e só esqueceu de avisar?''";
        yield return new WaitForSeconds(4.7f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Desconhecida: Não! Meu filho nunca faria isso! Ele sempre me mantém informada se houver " +
            "mudanças de planos!''";
        yield return new WaitForSeconds(5.5f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Desconhecida: Você tem que me ajudar, por favor!''";
        yield return new WaitForSeconds(2.8f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: Olha, senhora, eu...''";
        yield return new WaitForSeconds(1f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Desconhecida: Eu pago o que você precisar! Eu sei que você não tem um caso há muito tempo, você está falido, precisa de dinheiro!''";
        yield return new WaitForSeconds(7.5f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: Hahaha... E por qual motivo você contrataria um detetive falido? Se eu não tenho casos há um tempo, quer dizer " +
            "que eu não presto, certo?''";
        yield return new WaitForSeconds(7f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Desconhecida: Eu não sei se o senhor é bom, senhor Fonseca. Mas, como disse antes, o senhor precisa de dinheiro, e eu alguém que encontre " +
            "o meu filho, então, sei que vai aceitar minha proposta.''";
        yield return new WaitForSeconds(10f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: Certo... Eu irei ajudar a senhora...''";
        yield return new WaitForSeconds(2.3f);
        subtitles.SetActive(false);
        yield return new WaitForSeconds(0.05f);

        subtitles.SetActive(true);
        subtitlesText.text = "''Detetive Fonseca: Mas a senhora terá que me pagar! Encontrando-o ou não!''";
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
