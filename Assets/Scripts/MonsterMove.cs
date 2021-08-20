using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    static public bool isPlayerInSight;

    SpriteRenderer SP;

    Vector2 lastPos;

    int currentWaypoint;

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private Transform playerWaypoint;

    [SerializeField]
    private float monsterSpeed;

    void Start()
    {
        SP = GetComponent<SpriteRenderer>();
        lastPos = transform.position;
    }

    void Update()
    {
        if (!isPlayerInSight)
            Move();
        else FollowPlayer();
    }

    void Move()
    {
        if (Vector2.Distance(waypoints[currentWaypoint].position, transform.position) < 0.02f)
        {
            //waypoint 설정
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }

        //목표 지점까지의 방향 벡터
        Vector2 waypointDir = (waypoints[currentWaypoint].position - transform.position).normalized;
        //이동
        transform.Translate(waypointDir * monsterSpeed * Time.deltaTime);

        //좌우 반전
        if (lastPos.x > transform.position.x) SP.flipX = true;
        else if (lastPos.x < transform.position.x) SP.flipX = false;
        lastPos = transform.position;
    }

    void FollowPlayer()
    {
        Vector2 waypointDir = (playerWaypoint.position - transform.position).normalized;
        transform.Translate(waypointDir * monsterSpeed * Time.deltaTime);

        //좌우 반전
        if (lastPos.x > transform.position.x) SP.flipX = true;
        else if (lastPos.x < transform.position.x) SP.flipX = false;
        lastPos = transform.position;
    }
}
