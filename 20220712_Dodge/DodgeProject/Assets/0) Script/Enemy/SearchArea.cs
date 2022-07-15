using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchArea : MonoBehaviour
{
    public GameObject enemyObj;

    Enemy _enemy;

    bool isTriggerOn = false;

    void Start()
    {
        _enemy = enemyObj.GetComponent<Enemy>();
    }

    void Update()
    {
        if (isTriggerOn && FindAttackRangeArea())
        {
            _enemy.isAttack = true;
            
        }
        else
        {
            _enemy.isAttack = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isTriggerOn = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isTriggerOn = false;
        }
    }

    bool FindAttackRangeArea()
    {
        Vector3 directionVector = (_enemy.target.position - enemyObj.transform.position).normalized;
        float dir = Vector3.Dot(enemyObj.transform.forward, directionVector);
        Vector3 normalVector = Vector3.Cross(enemyObj.transform.forward, directionVector);

        UnityEngine.Debug.Log(Mathf.Cos(Mathf.Deg2Rad * 30));

        if (dir <= Mathf.Cos(Mathf.Deg2Rad * 30) && dir >= 0 && normalVector.y < 0)
        {
            return true;
        }
        return false;
    }
}
