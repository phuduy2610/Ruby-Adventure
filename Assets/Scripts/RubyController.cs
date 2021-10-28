using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RubyController : MonoBehaviour
{
    public int maxHealth = 5;
    public float speed = 10.0f;
    int _health;
    public int Health{
        get{return _health;}
        set{_health = value;}
    }

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigid_body;
    float horizontal;
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    public GameObject projectilePrefab;

    public ParticleSystem getHitEffect;
    public ParticleSystem pickHealthEffect;
    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        _health = maxHealth;
        animator = GetComponent<Animator>();
        Debug.Log(_health);
    }

    // Update is called once per frame
    private void Update() {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal"); // Lấy input  trái phải

        Vector2 move = new Vector2(horizontal,vertical);
        if(!Mathf.Approximately(move.x,0.0f)||!Mathf.Approximately(move.y,0.0f)){
            lookDirection.Set(move.x,move.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("Look X",lookDirection.x);
        animator.SetFloat("Look Y",lookDirection.y);
        animator.SetFloat("Speed",move.magnitude);
        if(isInvincible){
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer < 0){
                isInvincible = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.C)){
            Launch();
        }

        if(Input.GetKeyDown(KeyCode.X)){
            RaycastHit2D hit = Physics2D.Raycast(rigid_body.position + Vector2.up*0.2f,lookDirection,1.5f,LayerMask.GetMask("NPC"));
            if(hit.collider != null){
                NPC character = hit.collider.GetComponent<NPC>();
                if(character!=null){
                    character.DisplayDialog();
                }
            }
        }

    }
    void FixedUpdate()
    {
        Vector2 position = rigid_body.position;
        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;
        rigid_body.MovePosition(position);
    }

    public void ChangeHealth(int amount){
        if(amount<0){
            animator.SetTrigger("Hit");
            
            if(isInvincible){
                return;
            }
            isInvincible = true;
            invincibleTimer = timeInvincible;
            Instantiate(getHitEffect,rigid_body.position + Vector2.up*0.5f,Quaternion.identity);
        }
        else if (amount>0){
            Instantiate(pickHealthEffect,rigid_body.position + Vector2.up*0.5f,Quaternion.identity);
        }
        _health = Mathf.Clamp(_health + amount,0,maxHealth);
        Debug.Log(_health);
        UIHealthBar.instance.SetValue(_health/(float)maxHealth);
    }

    void Launch(){
        GameObject projectileObject = Instantiate(projectilePrefab,rigid_body.position + Vector2.up*0.5f,Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection,300);
        animator.SetTrigger("Launch");
    }
}
