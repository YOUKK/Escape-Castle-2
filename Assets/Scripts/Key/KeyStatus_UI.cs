using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyStatus_UI : MonoBehaviour
{
	public KeyInfo key;
	public Image keyImage;

	void Start()
	{
		SetColor(0);
	}

	private void SetColor(float alpha)
	{
		Color color = keyImage.color;
		color.a = alpha;
		keyImage.color = color;
	}

	public void AddItem(KeyInfo _key)
	{
		key = _key;
		keyImage.sprite = key.itemImage;
		SetColor(1);
	}
}
