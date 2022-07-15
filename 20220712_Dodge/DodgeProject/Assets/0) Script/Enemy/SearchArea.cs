using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SearchArea : MonoBehaviour
{
    public GameObject enemyObj;

    Enemy _enemy;

    bool isTriggerOn = false;

    Vector3 _arcStartVector;

    void Start()
    {
        _enemy = enemyObj.GetComponent<Enemy>();
        _arcStartVector = new Vector3(Mathf.Cos(-120f * Mathf.Deg2Rad), 0f, Mathf.Sin(-120f * Mathf.Deg2Rad));
    }

    void Update()
    {
        if (isTriggerOn && FindAttackRangeArea())
        {
            _enemy.isAttack = true;
            isGizmosOn = true;

        }
        else
        {
            _enemy.isAttack = false;
            isGizmosOn = false;
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

    bool isGizmosOn = false;
    Color red = new Color( 1f, 0f, 0f, 0.1f );
    Color green = new Color( 0f, 1f, 0f, 0.1f );

    void OnDrawGizmos()
    {
        Handles.color = isGizmosOn ? red : green;
        Handles.DrawSolidArc(transform.position, transform.up, -enemyObj.transform.right, 60f, 10f);
        //Handles.DrawSolidArc(transform.position, transform.up, _arcStartVector, 30f, 20f);
    }
}
