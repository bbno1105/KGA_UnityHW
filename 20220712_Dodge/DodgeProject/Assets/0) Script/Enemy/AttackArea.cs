using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public GameObject enemyObj;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Broom")
        {
            UnityEngine.Debug.Log("���Դ�");
            enemyObj.GetComponent<Rigidbody>().AddForce(0, 1000, 0);
        }
    }
}
