using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float hInput;
    private float vInput;

    public float speed;

    private Rigidbody2D rb;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        References.player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        InputHandeler();
        
    }

    private void FixedUpdate()
    {
        MovementHandeler();
        LookToMouse();  
    }

    private void MovementHandeler()
    {
        Vector3 direction = new Vector3(hInput, vInput);

        direction = direction.normalized;

        transform.position += direction * speed * Time.deltaTime;
    }

    private void InputHandeler()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
    }

    private void LookToMouse()
    {
      var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rot = mousePosition - transform.position;

        float rotate = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;

        rb.rotation = rotate -90;
    }
}
