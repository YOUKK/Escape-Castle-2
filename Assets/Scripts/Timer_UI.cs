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
        if (min != 0)
        {
            --min;
            if (sec == 0)
            {
                sec += 60;
            }
            sec -= Time.deltaTime;
        }
        else if(min == 0 && sec == 0)
        {
            min = 0;
            sec = 0;
        }

        minute.text = min.ToString();
        second.text = Mathf.Ceil(sec).ToString();
    }
}
