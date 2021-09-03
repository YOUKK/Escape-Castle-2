using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortBoardUseText : MonoBehaviour
{
	public bool isActive = false;

	[SerializeField]
	private Text itemUseText;

	[SerializeField]
	private KeyStatus_UI keyUI;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
		{
			if (!keyUI.isHaveKey)
			{
				itemUseText.gameObject.SetActive(true);
				isActive = true;
			}
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
		{
			if (!keyUI.isHaveKey)
			{
				itemUseText.gameObject.SetActive(true);
				isActive = true;
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
		{
			if (!keyUI.isHaveKey)
			{
				itemUseText.gameObject.SetActive(false);
				isActive = false;
			}
		}
	}
}
