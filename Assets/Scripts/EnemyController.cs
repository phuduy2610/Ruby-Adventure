using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 2.0f;

    Rigidbody2D rigid_body;
    float timer;
    int direction = 1;

    bool isBroken = true;
    Animator animator;

    public ParticleSystem smokeEffect;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(!isBroken){
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }


    }
    
    void FixedUpdate()
    {
        if(!isBroken){
            return;
        }

        Vector2 position = rigid_body.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X",0);
            animator.SetFloat("Move Y",direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X",direction);
            animator.SetFloat("Move Y",0);
        }
        


        rigid_body.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        RubyController rubyController = other.gameObject.GetComponent<RubyController>();
        if(rubyController != null){
            rubyController.ChangeHealth(-1);
        }
    }

    public void FixRobot(){
        isBroken = false;
        rigid_body.simulated = false;
        animator.SetTrigger("Fixed");
        smokeEffect.Stop();
        audioSource.Stop();
    }

    public void PlayAudio(AudioClip audioClip){
        audioSource.PlayOneShot(audioClip);
    }
}

