using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item들의 공통 특징
public class Item : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
            Destroy(this.gameObject);
		}
	}
}
