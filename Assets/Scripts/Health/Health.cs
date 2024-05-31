using UnityEngine;

public class Health : MonoBehaviour
{   
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
   private Animator animasi;

    private void Awake()
    {
        currentHealth = startingHealth;
        animasi = GetComponent<Animator>();
    }
    private void takeDamage(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
        if(currentHealth > 0 ){
            // Player Hurt

        }else{
            // Player Dead
            
        }
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            takeDamage(1);
        }
    }

    
}
