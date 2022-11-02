using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float attackCooldown;
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject[] fireballs;
    Animator anim;
    PlayerMovement playerMovement;
    float cooldownTimer;

    // Start is called before the first frame update
    void Start()
    {
        cooldownTimer = attackCooldown;
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P) && cooldownTimer >= attackCooldown && playerMovement.canAttack())
        {
            Attack();   
        }

        cooldownTimer += Time.deltaTime;
    }

    void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        fireballs[FindFireball()].transform.position = spawnPoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
