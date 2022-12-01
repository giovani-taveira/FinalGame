using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InventoryController : MonoBehaviour
{
    [SerializeField] Clues[] _listasPistas;
    [SerializeField] Image ImageCanvas;
    [SerializeField] TextMeshProUGUI textClues;
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject Botao;
    [SerializeField] GameObject Botao1;
    [SerializeField] Clues PistaNaoEncontrada;
    List<Clues> _listasPistasAchadas = new List<Clues>();
    private Clues PistaAtual;
    private int indexPista;

    void Start()
    {
        Canvas.SetActive(false);
        AtualizaListaPistas();
        Button btn = Botao.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

        Button btn1 = Botao1.GetComponent<Button>();
		btn1.onClick.AddListener(TaskOnClick1);     
    }

    void Update()
    {
        ImageCanvas.sprite = PistaAtual.Image;
        textClues.text = PistaAtual.Text;

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (Canvas.gameObject.activeInHierarchy)
            {
                Canvas.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
            else
            {
                AtualizaListaPistas();
                Canvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
        }
    }

    void TaskOnClick(){
		//direita
        if(indexPista == _listasPistasAchadas.Count - 1)
        {
            indexPista = 0;
        }
        else
        {
            indexPista++;
        }
        PistaAtual = _listasPistasAchadas[indexPista];
	}

    void TaskOnClick1(){
		//esquerda
        if(indexPista == 0)
        {
            indexPista = _listasPistasAchadas.Count - 1;
        }
        else
        {
            indexPista--;
        }
        PistaAtual = _listasPistasAchadas[indexPista];
	}

    void AtualizaListaPistas()
    {
        int Pista1 = PlayerPrefs.GetInt("clue1");
        int Pista2 = PlayerPrefs.GetInt("clue2");
        int Pista3 = PlayerPrefs.GetInt("clue3");
        int Pista4 = PlayerPrefs.GetInt("clue4");
        int Pista5 = PlayerPrefs.GetInt("clue5");
        int Pista6 = PlayerPrefs.GetInt("clue6");
        int Pista7 = PlayerPrefs.GetInt("clue7");
        int Pista8 = PlayerPrefs.GetInt("clue8");

        if(Pista1 == 1)
        {
            _listasPistasAchadas.Add(_listasPistas[0]);
        }
        else
        {
            _listasPistasAchadas.Add(PistaNaoEncontrada);
        }

        if(Pista2 == 1)
        {
            _listasPistasAchadas.Add(_listasPistas[1]);
        }
        else
        {
            _listasPistasAchadas.Add(PistaNaoEncontrada);
        }

        if(Pista3 == 1)
        {
            _listasPistasAchadas.Add(_listasPistas[2]);
        }
        else
        {
            _listasPistasAchadas.Add(PistaNaoEncontrada);
        }

        if(Pista4 == 1)
        {
            _listasPistasAchadas.Add(_listasPistas[3]);
        }
        else
        {
            _listasPistasAchadas.Add(PistaNaoEncontrada);
        }

        if(Pista5 == 1)
        {
            _listasPistasAchadas.Add(_listasPistas[4]);
        }
        else
        {
            _listasPistasAchadas.Add(PistaNaoEncontrada);
        }

        if(Pista6 == 1)
        {
            _listasPistasAchadas.Add(_listasPistas[5]);
        }
        else
        {
            _listasPistasAchadas.Add(PistaNaoEncontrada);
        }

        if(Pista7 == 1)
        {
            _listasPistasAchadas.Add(_listasPistas[6]);
        }
        else
        {
            _listasPistasAchadas.Add(PistaNaoEncontrada);
        }

        if(Pista8 == 1)
        {
            _listasPistasAchadas.Add(_listasPistas[7]);
        }
        else
        {
            _listasPistasAchadas.Add(PistaNaoEncontrada);
        }

        PistaAtual = _listasPistasAchadas[0];
        indexPista = 0;
    }
}
