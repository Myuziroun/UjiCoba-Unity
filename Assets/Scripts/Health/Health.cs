using UnityEngine;

public class Health : MonoBehaviour
{   [SerializeField] private float startingHealth;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    private void takeDamage(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
        if(currentHealth > 0 ){
            // Player Hurt

        }else{
            // Player Dead
            
        }
    }
    

    
}
