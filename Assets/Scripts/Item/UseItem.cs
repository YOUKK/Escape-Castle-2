using System.Collections;
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
			if (Input.GetKeyDown(KeyCode.E))
			{
                itemImage.gameObject.SetActive(false);

                if(itemUI.item.itemName == "Cape")
				{
                    Debug.Log("Cape를 사용했습니다");
                    Cape();
				}
				else if(itemUI.item.itemName == "Long Board")
                {
                    Debug.Log("Long Board를 사용했습니다");
				}
                else if(itemUI.item.itemName == "Short Board")
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

        color.a = 1f;
        theSpriteRenderer.color = color;
        flight.isWearCape = false;
        skeleton.isWearCape = false;
    }
}
