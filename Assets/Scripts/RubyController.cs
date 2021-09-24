using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    Rigidbody2D rigid_body;
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update() {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal"); // Lấy input  trái phải
    }
    void FixedUpdate()
    {
        Vector2 position = rigid_body.position;
        position.x += 10.0f * horizontal * Time.deltaTime;
        position.y += 10.0f * vertical * Time.deltaTime;
        rigid_body.MovePosition(position);
    }
}
