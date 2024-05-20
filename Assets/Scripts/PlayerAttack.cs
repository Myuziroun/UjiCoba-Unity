using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float attackCooldown;
    private Animator animasi;
    private PlayerMovement playerMovement;
    private float cooldownTimer;

    private void Awake()
    {
        animasi = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack()){
            buttonAttack();
        }
    }
    private void buttonAttack(){
        animasi.SetTrigger("attack");
        cooldownTimer = 0;
    }

}
