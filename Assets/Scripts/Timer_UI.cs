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
                sec += 59;
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

        minute.text = Mathf.Ceil(min).ToString();
        if(sec <= 9)
            second.text = "0" + Mathf.Ceil(sec).ToString();
        else
            second.text = Mathf.Ceil(sec).ToString();
    }
}
