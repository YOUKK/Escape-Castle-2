using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Inventory
public class ItemStatus : MonoBehaviour
{
	[SerializeField]
	private ItemStatus_UI itemUI;
	private ItemList[] items;
	public Image itemImage;

	public void AcquireItem(ItemList _item)
	{
		if (itemUI.item == null)
		{
			itemUI.AddItem(_item);
		}
		
	}
}
