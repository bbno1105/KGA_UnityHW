using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchArea : MonoBehaviour
{
    Enemy enemy;

    void Start()
    {
        enemy = this.transform.parent.GetComponent<Enemy>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.isAttack = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.isAttack = false;
        }
    }
}
