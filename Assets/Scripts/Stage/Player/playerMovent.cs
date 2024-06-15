using UnityEngine;

public class playerMovent : MonoBehaviour
{
    private float speed = 5;
    private float jumpPower = 6;
    private float moveHorizontal;
    private float moveVertikal;
    private Rigidbody2D badan;
    private Animator animasi;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    private float wallJumpCooldown;

    private  void Awake()
    {
        badan = GetComponent<Rigidbody2D>();
        animasi = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        playerGerak();
    }
    private void playerGerak(){
        moveHorizontal = Input.GetAxis("Horizontal");
        badan.velocity = new Vector2(moveHorizontal * speed, badan.velocity.y);

        // player berputar arah pada karakter
        if(moveHorizontal > 0.01f){
            transform.localScale = Vector3.one;
        }else if(moveHorizontal < -0.01f){
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // animasi bergerak
        animasi.SetBool("walk", moveHorizontal != 0);
        // animasi pada waktu jatuh?
        animasi.SetBool("grounded", isGrounded());
        // logic lompat
        if(wallJumpCooldown < 0.2f){
            if(Input.GetKey(KeyCode.Space)){
                playerLompat();            
            }
        }else{
            wallJumpCooldown += Time.deltaTime;
        }

    }
    private void playerLompat(){
        if(isGrounded()){
            badan.velocity = new Vector2(badan.velocity.x, jumpPower);
            animasi.SetTrigger("jump");
        }
        // wallJumpCooldown += Time.deltaTime;
    }

    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null; 
    }
}