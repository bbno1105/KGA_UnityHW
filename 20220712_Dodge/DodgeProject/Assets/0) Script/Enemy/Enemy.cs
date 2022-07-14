using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject bulletPrefabs;
    public Transform target;

    [SerializeField]
    GameObject _enemyChar;
    Animator _animator;
    float _spawnTime = 0;
    float _rand = 0;

    public bool isAttack = false;

    void Start()
    {
        _animator = this.transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {
        _spawnTime += Time.deltaTime;
        if(isAttack && !gameManager._isGameOver)
        {
            Attack();
        }

    }

    void Attack()
    {
        _enemyChar.transform.LookAt(target);

        if (_spawnTime >= _rand)
        {
            _animator.SetTrigger("isAttack");
            _rand = Random.Range(0f, 2.5f);
            GameObject bullets = Instantiate(bulletPrefabs, this.transform.position, this.transform.rotation);
            Vector3 bulletLookPos = new Vector3(target.transform.position.x, this.transform.position.y + 0.5f, target.transform.position.z);
            bullets.transform.LookAt(bulletLookPos);
            _spawnTime = 0;
        }
    }


}
