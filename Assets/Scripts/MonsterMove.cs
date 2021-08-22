﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    bool isPlayerInSight;

    SpriteRenderer SP;

    Vector2 lastPos;

    int currentWaypoint;

    [SerializeField] Animator anim;

    [SerializeField] float attackDistance;

    //View
    [SerializeField] private float viewDistance; //시야거리
    [SerializeField] private LayerMask layerMask;

    public Transform[] waypoints;
    [SerializeField] Transform playerTf;
    [SerializeField] private int chasingTime;

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        SP = GetComponent<SpriteRenderer>();
        lastPos = transform.position;

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        View();
        Attack();
        if (!isPlayerInSight) Move();
        else FollowPlayer();
    }

    //waypoint를 따라감
    void Move()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
        }

        /*if (Vector2.Distance(waypoints[currentWaypoint].position, transform.position) < 0.02f)
        {
            //waypoint 설정
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }

        //목표 지점까지의 방향 벡터
        Vector2 waypointDir = (waypoints[currentWaypoint].position - transform.position).normalized;
        //이동
        transform.Translate(waypointDir * monsterSpeed * Time.deltaTime);*/

        //좌우 반전
        if (lastPos.x > transform.position.x) SP.flipX = true;
        else if (lastPos.x < transform.position.x) SP.flipX = false;
        lastPos = transform.position;
    }

    //플레이어를 따라감
    void FollowPlayer()
    {
        /*Vector2 waypointDir = (playerTf.position - transform.position).normalized;
        transform.Translate(waypointDir * monsterSpeed * Time.deltaTime);*/

        navMeshAgent.SetDestination(playerTf.position);

        //좌우 반전
        if (lastPos.x > transform.position.x) SP.flipX = true;
        else if (lastPos.x < transform.position.x) SP.flipX = false;
        lastPos = transform.position;
    }

    void Attack()
    {
        if (isPlayerInSight && Vector2.Distance(playerTf.position, transform.position) <= attackDistance)
        {
            anim.SetTrigger("Attack");
        }
    }

    void View()
    {
        Vector2 dir = playerTf.position - transform.position;
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, dir.normalized, viewDistance, layerMask);
        if (rayHit.collider != null && rayHit.collider.name == "Player")
        {
            StopAllCoroutines();
            Debug.DrawRay(transform.position, dir, Color.green);
            isPlayerInSight = true;
        }
        else StartCoroutine(ChaseCoroutine());
    }

    IEnumerator ChaseCoroutine() // n초간 플레이어 추적 코루틴
    {
        yield return new WaitForSeconds(chasingTime);
        isPlayerInSight = false;
    }
}
