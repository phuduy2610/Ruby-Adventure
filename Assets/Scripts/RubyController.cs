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
    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        _health = 2;
        Debug.Log(_health);
    }

    // Update is called once per frame
    private void Update() {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal"); // Lấy input  trái phải

        if(isInvincible){
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer < 0){
                isInvincible = false;
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
            if(isInvincible){
                return;
            }
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        _health = Mathf.Clamp(_health + amount,0,maxHealth);
        Debug.Log(_health + " / " + maxHealth);
    }
}
