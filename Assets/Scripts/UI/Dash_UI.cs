using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash_UI : MonoBehaviour
{
    // dash
    [SerializeField]
    private int dash; // dash 총량
    private int currentDash; // 현재 dash량

    // dash바 증가량
    [SerializeField]
    private int dashIncrease;

    // dash바 재회복 딜레이
    [SerializeField]
    private int dashRechargeTime; // dash바가 회복되는데 걸리는 시간(dash를 사용하지 말아야하는 총 시간)
    private int currentDashRechargeTime; // dash를 사용하지 않은 시간

    // dash바 감소 여부
    private bool dashUsed = false;

    // 필요한 이미지
    [SerializeField]
    private Image dashBarImage;

    void Start()
    {
        currentDash = dash;
    }

    void Update()
    {
        DashRecover();
        DashRechargeTime();
        GaugeUpdate();
    }

    public void DecreaseDash(int count)
	{
        dashUsed = true;
        currentDashRechargeTime = 0;

        if(currentDash - count > 0)
		{
            currentDash -= count;
		}
		else
		{
            currentDash = 0;
		}
	}

    private void DashRecover()
	{
        if(!dashUsed && (currentDash < dash))
		{
            currentDash += dashIncrease;
		}
	}

    private void DashRechargeTime()
	{
		if (dashUsed)
		{
            if(currentDashRechargeTime < dashRechargeTime)
			{
                currentDashRechargeTime++;
			}
			else
			{
                dashUsed = false;
			}
		}
	}

    private void GaugeUpdate()
	{
        dashBarImage.fillAmount = (float)currentDash / dash;
	}

    public int GetCurrentDash()
	{
        return currentDash;
	}
}
