using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    private bool isPlayerInSight;
    public bool isWearCape;

    SpriteRenderer SP;

    Vector2 lastPos;

    int currentWaypoint = 0;

    [SerializeField] Animator anim;

    [SerializeField] float attackDistance;

    //View
    [SerializeField] private float viewDistance; //시야거리
    [SerializeField] private LayerMask layerMask;

    public Transform[] waypoints;
    [SerializeField] Transform playerTf;
    [SerializeField] private int chasingTime;

    private NavMeshAgent navMeshAgent;
    private Vector3 dir;

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
        dir = playerTf.position - transform.position;
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

        //좌우 반전
        if (lastPos.x > transform.position.x) SP.flipX = true;
        else if (lastPos.x < transform.position.x) SP.flipX = false;
        lastPos = transform.position;
    }

    //플레이어를 따라감
    void FollowPlayer()
    {
        navMeshAgent.SetDestination(playerTf.position + dir.normalized);

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
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, dir.normalized, viewDistance, layerMask);
        if (rayHit.collider != null && rayHit.collider.name == "Player" && !isWearCape)
        {
            StopAllCoroutines();
            Debug.DrawRay(transform.position, dir, Color.green);
            isPlayerInSight = true;
        }
        else StartCoroutine(ChaseCoroutine());
    }

    IEnumerator ChaseCoroutine() // n초간 플레이어 추적 코루틴
    {
        if (!isWearCape)
        {
            yield return new WaitForSeconds(chasingTime);
        }
        isPlayerInSight = false;
    }
}
