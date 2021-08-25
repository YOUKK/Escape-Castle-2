﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    [SerializeField]
    private ItemStatus_UI itemUI;
    [SerializeField]
    private MonsterMove flight;
    [SerializeField]
    private MonsterMove skeleton;
    [SerializeField]
    private KeyPickupAction theKeyPickupAction;

    private SpriteRenderer theSpriteRenderer;
    public Image itemImage;

    [SerializeField]
    private float waitTime;

    void Start()
    {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckItem();
    }

    private void CheckItem()
	{
        if(itemUI.item != null)
		{
            // key랑 겹쳐져 있지 않을 때
            if (Input.GetKeyDown(KeyCode.E) && !theKeyPickupAction.pickupActivated)
            {
                itemImage.gameObject.SetActive(false);

                if (itemUI.item.itemName == "Cape")
                {
                    Debug.Log("Cape를 사용했습니다");
                    Cape();
                }
                else if (itemUI.item.itemName == "Long Board")
                {
                    Debug.Log("Long Board를 사용했습니다");
                }
                else if (itemUI.item.itemName == "Short Board")
                {
                    Debug.Log("Short Board를 사용했습니다");
                }
            }
		}
	}

    private void Cape()
	{
        StartCoroutine("WaitTime");
    }

    IEnumerator WaitTime()
    {
        Color color = theSpriteRenderer.color;
        color.a = 0.7f;
        theSpriteRenderer.color = color;
        flight.isWearCape = true;
        skeleton.isWearCape = true;

        yield return new WaitForSeconds(waitTime);

        Debug.Log("cape사용이 끝났습니다");
        color.a = 1f;
        theSpriteRenderer.color = color;
        flight.isWearCape = false;
        skeleton.isWearCape = false;
    }
}