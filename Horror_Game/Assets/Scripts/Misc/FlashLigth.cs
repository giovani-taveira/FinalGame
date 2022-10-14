using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLigth : MonoBehaviour
{
    Light ligth;
    bool isOn;
    void Start()
    {
        ligth = GetComponent<Light>();
        isOn = true;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && isOn)
        {
            ligth.intensity = 0;
            isOn = false;
            Debug.Log("Apagou");
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) && !isOn)
        {
            ligth.intensity = 1;
            isOn = true;
            Debug.Log("Acendeu");
        }   
    }
}
