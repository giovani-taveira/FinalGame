using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLigth : MonoBehaviour
{
    Light ligth;
    bool isOn;
    float timeToStart = 1;
    float timeToFail;

    void Start()
    {
        timeToFail = Random.Range(2, 5);
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

        timeToStart += timeToStart * Time.deltaTime * 0.1f;
        Debug.Log("timeToStart: " + timeToStart);

        if (timeToStart >= timeToFail)
        {
            ligth.intensity = 0;
            timeToFail = Random.Range(1.5f, 15);
            StartCoroutine(BlinkFlashlight());
            timeToStart = 1;
        }
    }

    public IEnumerator BlinkFlashlight()
    {
        yield return new WaitForSeconds(0.1f);
        ligth.intensity = 1;
        yield return new WaitForSeconds(0.13f);
        ligth.intensity = 0;
        yield return new WaitForSeconds(0.01f);
        ligth.intensity = 1;
    }
}
