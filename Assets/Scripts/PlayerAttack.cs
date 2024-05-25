using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator animasi;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        animasi = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.I) && cooldownTimer > attackCooldown && playerMovement.canAttack()){
            buttonAttack();
        }else if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack()){
            buttonAttack();
        }
        cooldownTimer += Time.deltaTime;
    }
    private void buttonAttack(){
        animasi.SetTrigger("attack");
        cooldownTimer = 0;

        fireballs[findProjectile()].transform.position = firepoint.position;
        fireballs[findProjectile()].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));
    }

    private int findProjectile(){

        for(int i = 0; i < fireballs.Length; i ++ ){
            if(!fireballs[i].activeInHierarchy){
                return i;
            }
        }
        return 0;
    }

}
