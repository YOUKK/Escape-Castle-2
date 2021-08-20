using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : ScriptableObject
{
	public string itemName;
	public ItemType itemtype;
	public Sprite itemImage;

	public enum ItemType
	{
		LongBoard,
		ShortBoard,
		Cape,
		Key
	}
}
