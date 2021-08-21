using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Item들의 공통 특징
public class Item : MonoBehaviour
{
	// 아이템 획득 설명 텍스트
    [SerializeField]
    Text pickUpText;

	ItemStatus itemstatus;

	void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    void Update()
    {

	}


	// 플레이어와 아이템이 enter일 때
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
		{
			//Debug.Log(collision.name + "enter");
            //pickUpText.gameObject.SetActive(true);
		}
	}

	public bool pickupActivated = false; //습득 가능할 시 true

	// 플레이어와 아이템이 stay일 때
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
		{
			pickupActivated = true;
			Debug.Log(pickupActivated);
			//Debug.Log(collision.name + "stay");
			pickUpText.gameObject.SetActive(true);
		}
	}

	// 플레이어와 아이템이 exit일 때
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
		{
			pickupActivated = false;
			Debug.Log(pickupActivated);
			//Debug.Log(collision.name + "exit");
			pickUpText.gameObject.SetActive(false);
		}
	}

	//private ItemList GetInfo()
	//{

	//	return this.gameObject.transform.GetComponent<ItemPickUp>().item;
	//}

	
}
