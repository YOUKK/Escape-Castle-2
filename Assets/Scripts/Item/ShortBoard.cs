using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShortBoard : MonoBehaviour
{
    // 필요한 컴포넌트
    private TilemapCollider2D tileCollider;

    void Start()
    {
        tileCollider = GetComponent<TilemapCollider2D>();
    }

    void Update()
    {
        
    }

    public void ItemUse()
	{
        tileCollider.enabled = false;
	}
}
