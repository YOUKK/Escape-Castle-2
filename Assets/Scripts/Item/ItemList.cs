using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class ItemList : ScriptableObject
{
	public string itemName;
	public ItemType itemtype;
	public Sprite itemImage;
	public GameObject itemPrefab;
	

	public enum ItemType
	{
		LongBoard,
		ShortBoard,
		Cape,
		Key
	}
}
