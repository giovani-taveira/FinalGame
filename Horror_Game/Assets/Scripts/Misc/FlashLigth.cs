using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLigth : MonoBehaviour
{
    [SerializeField] Light ligth1;
    [SerializeField] Light ligth2;
    [SerializeField] Light ligth3;
    bool isOn;
    float timeToStart = 1;
    float timeToFail;

    void Start()
    {
        timeToFail = Random.Range(2, 5);
        isOn = true;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && isOn)
        {
            ligth1.intensity = 0;
            ligth2.intensity = 0;
            ligth3.intensity = 0;
            isOn = false;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) && !isOn)
        {
            ligth1.intensity = 2.1f;
            ligth2.intensity = 2.1f;
            ligth3.intensity = 2.1f;
            isOn = true;
        }

        timeToStart += timeToStart * Time.deltaTime * 0.1f;

        if (timeToStart >= timeToFail)
        {
            ligth1.intensity = 0;
            ligth2.intensity = 0;
            ligth3.intensity = 0;
            timeToFail = Random.Range(1.5f, 15);
            StartCoroutine(BlinkFlashlight());
            timeToStart = 1;
        }
    }

    public IEnumerator BlinkFlashlight()
    {
        yield return new WaitForSeconds(0.1f);
        ligth1.intensity = 2.1f;
        ligth2.intensity = 2.1f;
        ligth3.intensity = 2.1f;
        yield return new WaitForSeconds(0.13f);
        ligth1.intensity = 0;
        ligth2.intensity = 0;
        ligth3.intensity = 0;
        yield return new WaitForSeconds(0.01f);
        ligth1.intensity = 2.1f;
        ligth2.intensity = 2.1f;
        ligth3.intensity = 2.1f;
    }
}
