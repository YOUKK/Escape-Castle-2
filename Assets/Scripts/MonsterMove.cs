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

    //View
    [SerializeField] private float viewDistance; //시야거리
    [SerializeField] private LayerMask layerMask;

    [SerializeField] public GameObject playerTf;
    [SerializeField] private int chasingTime;

    void Start()
    {
        SP = GetComponent<SpriteRenderer>();
        lastPos = transform.position;
    }

    void Update()
    {
        View();
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

    void View()
    {
        Vector2 dir = playerTf.transform.position - transform.position;
        //Debug.DrawRay(transform.position, dir, Color.yellow);
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, dir.normalized, viewDistance, layerMask);
        if (rayHit.collider != null && rayHit.collider.name == "Player")
        {
            StopAllCoroutines();
            Debug.DrawRay(transform.position, dir, Color.green);
            MonsterMove.isPlayerInSight = true;
        }
        else StartCoroutine(ChaseCoroutine());
    }

    IEnumerator ChaseCoroutine() // n초간 플레이어 추적 코루틴
    {
        yield return new WaitForSeconds(chasingTime);
        MonsterMove.isPlayerInSight = false;
    }
}
