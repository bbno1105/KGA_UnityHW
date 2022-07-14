using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject bulletPrefabs;
    public GameObject player;
    public Animator animator;
    float _spawnTime = 0;
    float _rand = 0;
    public bool isAttack = false;

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
        this.transform.LookAt(player.transform);

        if (_spawnTime >= _rand)
        {
            animator.SetTrigger("isAttack");
            _rand = Random.Range(0f, 2.5f);
            GameObject bullets = Instantiate(bulletPrefabs, this.transform.position, this.transform.rotation);
            Vector3 bulletLookPos = new Vector3(player.transform.position.x, this.transform.position.y + 0.5f, player.transform.position.z);
            bullets.transform.LookAt(bulletLookPos);
            _spawnTime = 0;
        }
    }


}
