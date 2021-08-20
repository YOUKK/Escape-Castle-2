using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    static public bool isPlayerInSight;

    SpriteRenderer SP;
    
    Vector2 lastPos;

    int currentWaypoint;

    [SerializeField] Animator anim;

    [SerializeField] float attackDistance;

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
        Attack();
        if (!isPlayerInSight)
            Move();
        else FollowPlayer();
    }

    //waypoint를 따라감
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

    //플레이어를 따라감
    void FollowPlayer()
    {
        Vector2 waypointDir = (playerWaypoint.position - transform.position).normalized;
        transform.Translate(waypointDir * monsterSpeed * Time.deltaTime);

        //좌우 반전
        if (lastPos.x > transform.position.x) SP.flipX = true;
        else if (lastPos.x < transform.position.x) SP.flipX = false;
        lastPos = transform.position;
    }

    void Attack()
    {
        if(isPlayerInSight && Vector2.Distance(playerWaypoint.position, transform.position) <= attackDistance)
        {
            anim.SetTrigger("Attack");
        }
    }
}
