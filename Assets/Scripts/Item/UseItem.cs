using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class UseItem : MonoBehaviour
{
    // 다른 스크립트 사용
    [SerializeField]
    private ItemStatus_UI itemUI;
    [SerializeField]
    private MonsterMove[] monsters;
    [SerializeField]
    private KeyPickupAction theKeyPickupAction;
    [SerializeField]
    private ShortBoardUseText shortBoardUseText;

    // 필요한 컴포넌트
    private SpriteRenderer theSpriteRenderer;
    public Image itemImage;
    [SerializeField]
    private Tilemap itemUseZone_Ob;
    [SerializeField]
    private GameObject shortBoardSprite;
    

    // cape 발동 시간
    //[SerializeField]
    private float waitTime = 10f;

    void Start()
    {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckItem();
    }

    // 아이템 사용
    private void CheckItem()
	{
        if(itemUI.item != null)
		{
            // key랑 겹쳐져 있지 않을 때
            if (Input.GetKeyDown(KeyCode.E) && !theKeyPickupAction.pickupActivated)
            {

                if (itemUI.item.itemName == "Cape")
                {
                    if (itemImage.gameObject.activeInHierarchy)
                    {
                        itemImage.gameObject.SetActive(false);
                        Debug.Log("Cape를 사용했습니다");
                        Cape();
                    }
                }
                else if (itemUI.item.itemName == "Long Board")
                {
                    itemImage.gameObject.SetActive(false);
                    Debug.Log("Long Board를 사용했습니다");
                }
                else if (itemUI.item.itemName == "Short Board")
                {
                    if (shortBoardUseText.isActive)
                    {
                        itemImage.gameObject.SetActive(false);
                        Debug.Log("Short Board를 사용했습니다");
                        ShortBoard();
                    }
                }
            }
		}
	}

    private void ShortBoard()
	{
        itemUseZone_Ob.GetComponent<TilemapCollider2D>().enabled = false;
        shortBoardSprite.SetActive(true);
    }

    // cape 아이템 사용
    private void Cape()
	{
        StartCoroutine("WaitTime");
    }

    // cape 아이템 기능
    IEnumerator WaitTime()
    {
        Color color = theSpriteRenderer.color;
        color.a = 0.5f;
        theSpriteRenderer.color = color;
        for(int i = 0; i < monsters.Length; i++)
		{
            monsters[i].isWearCape = true;
		}

        yield return new WaitForSeconds(waitTime);

        Debug.Log("cape사용이 끝났습니다");
        color.a = 1f;
        theSpriteRenderer.color = color;
        for (int i = 0; i < monsters.Length; i++)
        {
            monsters[i].isWearCape = false;
        }
    }
}
