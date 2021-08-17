using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    int currentWaypoint;

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float monsterSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Vector2.Distance(waypoints[currentWaypoint].position, transform.position) < 0.05f)
        {
            //waypoint 설정
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
        //목표 지점까지의 방향 벡터
        Vector2 waypointDir = (waypoints[currentWaypoint].position - transform.position).normalized;
        //이동
        transform.Translate(waypointDir * monsterSpeed * Time.deltaTime);
        //test
    }
}
