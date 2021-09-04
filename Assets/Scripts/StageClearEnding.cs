using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClearEnding : MonoBehaviour
{
    [SerializeField]
    private KeyStatus_UI keyUI;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
		{
			if (keyUI.isHaveKey)
			{
				SceneManager.LoadScene("Ending");
			}
		}
	}
}
