using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        //목표 지점까지의 방향 벡터
        Vector2 waypointDir = (waypoints[0].position - transform.position).normalized;
        
    }
}
