using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public GameObject cameraArm;
    public GameObject broom;

    GameObject _playerChar;
    Animator _animator;

    void Start()
    {
        _playerChar = this.transform.GetChild(0).gameObject;
        _animator = _playerChar.GetComponent<Animator>();
    }

    public void Move()
    {
        if (playerInfo.isMove)
        {
            _animator.SetBool("isMove", true);

            Vector3 lookForward = new Vector3(cameraArm.transform.forward.x, 0f, cameraArm.transform.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.transform.right.x, 0f, cameraArm.transform.right.z).normalized;

            Vector3 moveDir = lookForward * playerInfo.inputKey.y + lookRight * playerInfo.inputKey.x;

            _playerChar.transform.forward = moveDir;
            this.transform.position += moveDir * Time.deltaTime * playerInfo.moveSpeed;
        }
        else
        {
            _animator.SetBool("isMove", false);
        }
    }

    public void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("isAttack");
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            broom.GetComponent<CapsuleCollider>().enabled = true;
        }
        else
        {
            broom.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}