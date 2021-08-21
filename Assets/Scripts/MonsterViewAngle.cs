using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterViewAngle : MonoBehaviour
{
    [SerializeField] private float viewAngle; //시야각
    [SerializeField] private float viewDistance; //시야거리
    [SerializeField] private LayerMask layerMask;

    [SerializeField] public GameObject playerTf;
    [SerializeField] private int chasingTime;

    void Start()
    {
        
    }

    void Update()
    {
        View();
    }

    /*private Vector2 BoundaryAngle(float angle)
    {
        angle += transform.eulerAngles.y;
        return new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle*Mathf.Deg2Rad));
    }*/

    void View()
    {
        /*Collider2D[] t_cols = Physics2D.OverlapCircleAll(transform.position, viewDistance, targetLayer);

        if(t_cols.Length > 0)
        {
            Debug.Log("ddd");
            Transform t_tfPlayer = t_cols[0].transform;

            Vector2 t_direction = (t_tfPlayer.position - transform.position).normalized;
            float t_angle = Vector2.Angle(t_direction, transform.right);
            if (t_angle < viewAngle * 0.5f)
            {
                if (Physics.Raycast(transform.position, t_direction, out RaycastHit t_hit, viewDistance))
                {
                    if (t_hit.transform.name == "Player")
                    {
                        Debug.Log("DKDKDKDK");
                        Debug.DrawRay(transform.position, t_direction, Color.yellow);
                    }
                }
            }
        }*/

        /*Vector2 _dir = (playerTf.position - transform.position).normalized;

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, _dir, viewDistance);
        if (hit.transform.CompareTag("Player"))
        {
            Debug.Log("In Sight");
            Debug.DrawRay(transform.position, playerTf.position, Color.yellow);
        }*/

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
