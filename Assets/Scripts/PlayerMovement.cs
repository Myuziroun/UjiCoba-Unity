using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 10f;
    private float jump = 5f;
    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private LayerMask wallLayer;
    private Rigidbody2D badan;
    private Animator animasi;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    
    private void Awake(){
        // Untuk mendapatkan preference pada Rigidbody2D, Animator, BoxCollider2D dari objek
        badan = GetComponent<Rigidbody2D>();
        animasi = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    private void Update(){
        // Logic untuk berjalan pada kekanan dan kekiri
        float moveHorizontal = Input.GetAxis("Horizontal");
       
        // Untuk berubah arah pada karakter.
        if(moveHorizontal > 0.01f) {
            transform.localScale = Vector3.one;
        }else if (moveHorizontal < -0.01f) {
            transform.localScale = new Vector3(-1,1,1);
        }

        // Animasi pada saat mau diam atau bergerak
        animasi.SetBool("run", moveHorizontal !=0);

        // Animasi pada saat lompat
        animasi.SetBool("grounded", isGrounded());

        if(wallJumpCooldown < 0.2f){
            // Logic Unutk  melompat
            if(Input.GetKey(KeyCode.Space) && isGrounded()){
                JumpButton();
            }
            if(Input.GetKey(KeyCode.UpArrow) && isGrounded()){
                JumpButton();
            }
            if(Input.GetKey(KeyCode.W) && isGrounded()){
                JumpButton();
            }
             badan.velocity = new Vector2(moveHorizontal * speed, badan.velocity.y);
        }
    }

    // untuk melakukan lompatan
    private void JumpButton(){
        badan.velocity = new Vector2(badan.velocity.x, jump);
        animasi.SetTrigger("jump");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}

            // if(Input.GetKey(KeyCode.Space)){
            //     moveVertical = 1;
            // }
            // else if(Input.GetKey(KeyCode.W)){
            //     moveVertical = 1;
            // }   