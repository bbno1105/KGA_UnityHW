using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public bool isTrigger;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().velocity = this.transform.forward * speed;

        Destroy(this.gameObject, 3);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().Die();
            // other.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    // ?. ������
    // (expression) ?.~ : expression�� null�� �ƴϸ� ����� ������
    // A ?. Die();
    // if(A != null) Die(); �� ����
    // A�� null�� �ƴϸ� Die() ȣ��
}
