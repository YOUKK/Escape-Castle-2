using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemStatus_UI : MonoBehaviour
{
	// 다른 스크립트 사용
	public ItemList item;

	// 필요한 컴포넌트
	public Image itemImage;

	void Start()
	{
		SetColor(0);
	}

	// 이미지의 알파값 조정
	private void SetColor(float alpha)
	{
		Color color = itemImage.color;
		color.a = alpha;
		itemImage.color = color;
	}

	// 획득한 아이템의 이미지를 띄움
	public void AddItem(ItemList _item)
	{
		item = _item;
		itemImage.sprite = item.itemImage;
		SetColor(1);
	}

}
