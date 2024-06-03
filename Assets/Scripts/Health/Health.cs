using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    // [Header ("Health")]
    public float startingHealth { get; private set; } = 3;
    public float currentHealth { get; private set; }
    private Animator animasi;
    private bool dead;

    [Header("Iframe")]
    [SerializeField] private float iframesDuration;
    [SerializeField] private float numberOfSlashed;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = startingHealth;
        animasi = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void takeDamage(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
        if(currentHealth > 0 ){
            // Player Hurt
            animasi.SetTrigger("hurt");
            StartCoroutine(Invunerability());
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
        if(currentHealth > 0){
        currentHealth = Mathf.Clamp(currentHealth + _healthValue, 0, startingHealth);
    }
    }
    // Iframes
    private IEnumerator Invunerability(){
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfSlashed; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iframesDuration / (numberOfSlashed * 2) );
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iframesDuration / (numberOfSlashed * 2) );
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);

    }
}
