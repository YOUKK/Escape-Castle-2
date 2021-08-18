using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Item들의 공통 특징
public class Item : MonoBehaviour
{
    [SerializeField]
    Text pickUpText;

    void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    void Update()
    {
        TryPickUp();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//if (collision.gameObject.tag.Equals("Player"))
		//{
			Debug.Log(collision.name + "enter");
            pickUpText.gameObject.SetActive(true);
		//}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Player"))
		{
			Debug.Log(collision.name + "exit");
			pickUpText.gameObject.SetActive(false);
		}
	}

	private void TryPickUp()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
            PickUp();
		}
	}

    private void PickUp()
	{
        Destroy(this.gameObject);
    }
}
