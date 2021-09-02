using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_UI : MonoBehaviour
{
    [SerializeField] Text minute;
    [SerializeField] Text second;

    int min = 0;
    float sec = 20f;

    [SerializeField]
    private GameObject Ending_Dead;

    [SerializeField]
    MonsterMove flight1;
    [SerializeField]
    MonsterMove flight2;
    [SerializeField]
    MonsterMove skeleton1;
    [SerializeField]
    MonsterMove skeleton2;

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

                flight1.isWearCape = true;
                //flight2.isWearCape = true;
                skeleton1.isWearCape = true;
                //skeleton2.isWearCape = true;

                Ending_Dead.SetActive(true);
            }
        }
        else if (sec > 0)
            sec -= Time.deltaTime;
        
        //시간 Text로 표시
        minute.text = Mathf.Floor(min).ToString();
        if(sec < 10)
            second.text = "0" + Mathf.Floor(sec).ToString();
        else
            second.text = Mathf.Floor(sec).ToString();

        //시간 임박 경고
        if (min * 60 + sec <= 15)
        {
            if(Mathf.Floor(sec) %2==0)
            {
                minute.color = Color.red;
                second.color = Color.red;
            }
            else
            {
                minute.color = Color.white;
                second.color = Color.white;
            }
        }
    }
}
