using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
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
        if(Input.GetKey(KeyCode.I) || Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack()){
            buttonAttack();
        }
        cooldownTimer += Time.deltaTime;
    }
    private void buttonAttack(){
        animasi.SetTrigger("attack");
        cooldownTimer = 0;
    }

}
