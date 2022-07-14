using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchArea : MonoBehaviour
{
    public GameObject enemyObj;

    Enemy _enemy;

    bool isTrigger = false;

    private void Update()
    {
        if (isTrigger)
        {
            LookArea();
        }
        else
        {
            _enemy.isAttack = false;
        }
    }

    void Start()
    {
        _enemy = enemyObj.GetComponent<Enemy>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigger = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrigger = false;
        }
    }

    void LookArea()
    {
        Vector3 directionVector = (_enemy.target.position - enemyObj.transform.position).normalized;
        float dir = Vector3.Dot(enemyObj.transform.forward, directionVector);
        Vector3 normalVector = Vector3.Cross(enemyObj.transform.forward, directionVector);

        if (dir <= Mathf.Cos(Mathf.Deg2Rad * 30) && dir >= 0 && normalVector.y < 0)
        {
            _enemy.isAttack = true;
        }
    }
}
