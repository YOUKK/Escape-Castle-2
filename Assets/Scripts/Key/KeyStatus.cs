using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyStatus : MonoBehaviour
{
	[SerializeField]
	private KeyStatus_UI keyUI;
	private KeyInfo key;
	public Image itemImage;

	public void AcquireItem(KeyInfo _key)
	{
		if (keyUI.key == null)
		{
			keyUI.AddItem(_key);
		}
	}
}
