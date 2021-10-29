using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid_body;
    public AudioClip fixedClip;
    public AudioClip hitClip;
    void Awake()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 1000){
            Destroy(gameObject);
        }
        
    }

    public void Launch(Vector2 direction, float force){

        rigid_body.AddForce(direction*force);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        EnemyController enemyController = other.collider.GetComponent<EnemyController>();
        if(enemyController!=null){
        enemyController.PlayAudio(hitClip);
        enemyController.FixRobot();
        enemyController.PlayAudio(fixedClip);
        }
        Destroy(gameObject);
    }


}
