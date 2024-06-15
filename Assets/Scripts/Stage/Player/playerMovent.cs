using UnityEngine;

public class playerMovent : MonoBehaviour
{
    private float speed = 5;
    private float moveHorizontal;
    private float moveVertikal;
    private Rigidbody2D badan;

    private  void Awake()
    {
        badan = GetComponent<Rigidbody2D>();
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
    }
}