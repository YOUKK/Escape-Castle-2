using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickupAction : MonoBehaviour
{
	// 아이템 획득 설명 텍스트
	[SerializeField]
	private Text pickUpText;

	public bool pickupActivated = false; //습득 가능할 시 true

	private RaycastHit2D hitInfo;

	[SerializeField]
	private float range;
	// 키 레이어에만 반응할 수 있게 설정
	[SerializeField]
	private LayerMask layerMask;
	[SerializeField]
	KeyStatus keystatus;

	void Start()
	{
		pickUpText.gameObject.SetActive(false);
	}

	void Update()
	{
		TryPickUp();
	}

	// 아이템 줍기 시도
	private void TryPickUp()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			PickUp();
		}
	}

	// 아이템 줍기
	private void PickUp()
	{
		if (pickupActivated)
		{
			hitInfo = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), range, layerMask);

			if (hitInfo.transform != null)
			{
				Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up), Color.blue, 0.3f);
				Debug.Log(hitInfo.transform.GetComponent<KeyPickUp>().key.itemName + "획득했습니다");
				keystatus.AcquireItem(hitInfo.transform.GetComponent<KeyPickUp>().key);
				Destroy(hitInfo.transform.gameObject);
			}
		}
	}

	// 플레이어와 아이템이 enter일 때
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Key"))
		{
			pickupActivated = true;
			//Debug.Log(collision.name + "enter");
			pickUpText.gameObject.SetActive(true);
		}
	}

	// 플레이어와 아이템이 stay일 때
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("key"))
		{
			pickupActivated = true;
			//Debug.Log(pickupActivated);
			//Debug.Log(collision.name + "stay");
			pickUpText.gameObject.SetActive(true);
		}
	}

	// 플레이어와 아이템이 exit일 때
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Key"))
		{
			pickupActivated = false;
			//Debug.Log(pickupActivated);
			//Debug.Log(collision.name + "exit");
			pickUpText.gameObject.SetActive(false);
		}
	}
}
