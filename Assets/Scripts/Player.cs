using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;
    // Start is called before the first frame update
    private float movementX;

    private bool isGrounded = true ;

    private Rigidbody2D myBody;

    private Animator anim;

    private SpriteRenderer sr;

    private string ENEMY_TAG ="Enemy";

    private string WALK_ANIMATION ="Walk";
    private string GROUND_TAG ="Ground";

    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }
    private void FixedUpdate() {
    }

    void PlayerMoveKeyboard(){
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX,0f,0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer(){
        if(movementX>0)
        {
        anim.SetBool(WALK_ANIMATION,true);
            sr.flipX = false;
        }else if(movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION,true);
            sr.flipX = true;
        }else
        {
            anim.SetBool(WALK_ANIMATION,false);
        }
    }

    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            myBody.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(GROUND_TAG)){
            isGrounded = true;
        }
        if(other.gameObject.CompareTag(ENEMY_TAG)){
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(ENEMY_TAG)){
            Destroy(gameObject);
        }
    }
    
}
