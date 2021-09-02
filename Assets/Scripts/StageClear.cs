using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    [SerializeField]
    private KeyStatus_UI keyUI;

	[SerializeField]
	private GameObject Stageclear;

	void Start()
    {
        
    }

    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
		{
			if (keyUI.isHaveKey)
			{
				Stageclear.SetActive(true);
			}
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
		{
			if (keyUI.isHaveKey)
			{
				Stageclear.SetActive(true);
			}
		}
	}
}
