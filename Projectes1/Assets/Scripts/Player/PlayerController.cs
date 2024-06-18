using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float hInput;
    private float vInput;

    public float speed;

    private Rigidbody2D rb;

    private WeaponBehavior weaponBehavior;
    private ManaSystem manaSystem;
    public Animator playerAnimator;
    

    [SerializeField] private PowerHolder powerHolder;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        weaponBehavior = GetComponent<WeaponBehavior>();
        References.player = gameObject;
        manaSystem = GetComponent<ManaSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenuBehaviour.isPaused) return;
        InputHandeler();
        PlayerAnimator();
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

        


        if (Input.GetKey(KeyCode.Mouse0)) 
        {
            weaponBehavior.Fire();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            manaSystem.CastAttack(powerHolder);
        }

    }

    private void LookToMouse()
    {
      var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rot = mousePosition - transform.position;

        float rotate = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;

        rb.rotation = rotate -90;
    }


    void PlayerAnimator()
    {
        playerAnimator.SetBool("Shoot", Input.GetKey(KeyCode.Mouse0));
        playerAnimator.SetBool("Walking", hInput > 0 || hInput < 0 || vInput < 0 || vInput > 0);
    }
}
