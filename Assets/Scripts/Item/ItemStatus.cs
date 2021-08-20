using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemStatus : MonoBehaviour
{

	//   void Start()
	//   {

	//   }

	//   void Update()
	//   {

	//   }

	//   public void ViewItem(string _itemName)
	//{
	//       for(int i = 0; i < items.Length; i++)
	//	{
	//           if(items[i].itemName == _itemName)
	//		{
	//               itemUI.AddItem(items[i]);
	//		}
	//	}
	//}

	//   public void AcquireItem(ItemList _item)
	//   {
	//       itemUI.AddItem(_item);
	//   }

	private ItemStatus_UI itemUI;
	private ItemList[] items;
	public Image itemImage;

	public void ViewItem(GameObject item)
	{
		for(int i = 0; i < items.Length; i++)
		{
			if(item.name == items[i].itemName)
			{
				itemUI.AddItem(items[i]);
			}
		}
	}


}
