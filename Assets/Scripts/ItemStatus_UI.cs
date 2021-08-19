using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStatus_UI : MonoBehaviour
{
	private List<ItemList> itemList;

	void Start()
	{
		itemList = new List<ItemList>();
	}

	public void AddItem(ItemList item)
	{
		itemList.Add(item);
	}
}
