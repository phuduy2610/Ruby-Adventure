using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal"); // Lấy input  trái phải
        Vector2 position = transform.position;
        position.x += 10.0f * horizontal * Time.deltaTime;
        position.y += 10.0f * vertical * Time.deltaTime;
        transform.position = position;

    }
}
