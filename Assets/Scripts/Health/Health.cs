using UnityEngine;

public class Health : MonoBehaviour
{   
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator animasi;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        animasi = GetComponent<Animator>();
    }

    public void takeDamage(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
        if(currentHealth > 0 ){
            // Player Hurt
            animasi.SetTrigger("hurt");
            // iframes

        }else{
            // Player Dead
            if(!dead){
                animasi.SetTrigger("died");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            
            }

            
        }
    }
    public void GetHealth(float _healthValue){
        currentHealth = Mathf.Clamp(currentHealth + _healthValue, 0, startingHealth);
        
    }
    
    // private void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.E)){
    //         takeDamage(1);
    //     }
    // }

    
}
