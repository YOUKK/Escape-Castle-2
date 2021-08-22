using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Key", menuName = "New Key/key")]
public class KeyInfo : ScriptableObject
{
	public string itemName;
	public ItemType itemtype;
	public Sprite itemImage;
	public GameObject itemPrefab;


	public enum ItemType
	{
		Key
	}
}
