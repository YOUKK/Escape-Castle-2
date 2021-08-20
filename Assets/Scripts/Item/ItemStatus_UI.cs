using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Slot
public class ItemStatus_UI : MonoBehaviour
{
	public ItemList item;
	public Image itemImage;

	void Start()
	{
		SetColor(0);
	}

	private void SetColor(float alpha)
	{
		Color color = itemImage.color;
		color.a = alpha;
		itemImage.color = color;
	}

	public void AddItem(ItemList _item)
	{
		item = _item;
		itemImage.sprite = item.itemImage;
		SetColor(1);
	}

}
