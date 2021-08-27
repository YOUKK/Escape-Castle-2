using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_UI : MonoBehaviour
{
    [SerializeField] Text minute;
    [SerializeField] Text second;

    [SerializeField] int min;
    [SerializeField] float sec;

    void Start()
    {
        minute.text = min.ToString();
        second.text = sec.ToString();
    }

    void Update()
    {
        if (sec <= 0)
        {
            if (min != 0)
            {
                sec += 60;
                min--;
            }
            else
            {
                sec = 0;
                min = 0;
            }
        }
        else if (sec > 0)
            sec -= Time.deltaTime;

        minute.text = Mathf.Floor(min).ToString();
        if(sec < 10)
            second.text = "0" + Mathf.Floor(sec).ToString();
        else
            second.text = Mathf.Floor(sec).ToString();
        
        StartCoroutine(WarningCoroutine());
    }

    IEnumerator WarningCoroutine()
    {
        if (min * 60 + sec <= 15)
        {
            minute.color = Color.red;
            second.color = Color.red;
            yield return new WaitForSeconds(1f);
            minute.color = Color.white;
            second.color = Color.white;
            yield return new WaitForSeconds(1f);
        }
    }
}
