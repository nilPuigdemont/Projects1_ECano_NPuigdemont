using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private float hInput;
    private float vInput;

    public float speed;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputHandeler();
        

    }

 

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void InputHandeler()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
    }

    private void PlayerMovement()
    {
        Vector3 direction = new Vector3(hInput, vInput, 0) * speed;
        direction = direction.normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
