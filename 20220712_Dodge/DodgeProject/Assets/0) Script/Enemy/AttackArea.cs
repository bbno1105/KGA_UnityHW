using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public GameObject enemyObj;

    void OnTriggerExit(Collider other)
    {
        UnityEngine.Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Broom")
        {
            UnityEngine.Debug.Log("들어왔다");
            enemyObj.GetComponent<Rigidbody>().AddForce(0, 1000, 0);
        }
    }
}
