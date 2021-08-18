using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterViewAngle : MonoBehaviour
{
    [SerializeField] private float viewAngle; //시야각
    [SerializeField] private float viewDistance; //시야거리
    [SerializeField] private LayerMask targetLayer; // 플레이어 레이어를 감지

    void Start()
    {
        
    }

    void Update()
    {
        View();
    }

    private Vector2 BoundaryAngle(float angle)
    {
        angle += transform.eulerAngles.y;
        return new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle*Mathf.Deg2Rad));
    }

    void View()
    {
        Vector2 leftMBound = BoundaryAngle(-viewAngle * 0.5f);
        Vector2 rightBound = BoundaryAngle(viewAngle * 0.5f);

        Debug.DrawRay(transform.position, leftMBound, Color.green);
        Debug.DrawRay(transform.position, rightBound, Color.green);

        Collider[] _target = Physics.OverlapSphere(transform.position, viewDistance, targetLayer);

        for (int i = 0; i < _target.Length; i++)
        {
            Transform _targetTf = _target[i].transform;
            if(_targetTf.name == "Player")
            {
                Vector2 _dir = (_targetTf.position - transform.position).normalized; //타겟쪽으로의 방향벡터
                float _angle = Vector2.Angle(_dir, transform.right);

                if(_angle < viewAngle * 0.5f)
                {
                    RaycastHit hit;
                    if(Physics.Raycast(transform.position, _dir, out hit, viewDistance))
                    {
                        if (hit.transform.name == "Player")
                        {
                            Debug.Log("In Sight");
                            Debug.DrawRay(transform.position, _dir, Color.yellow);
                        }
                    }
                }
            }
        }
    }
}
