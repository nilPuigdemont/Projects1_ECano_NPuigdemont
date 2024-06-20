using System;
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

    private bool CanCastSpell = true;
    private float currentTimeToCast = 0;
    private float timeToCast = 2f;


    bool isReloading = false;

    private float currentTimeOfReload = 0;
    private float timeToReload = 1f;
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

        currentTimeToCast += Time.deltaTime;

        if (CanCastSpell == false) Cooldown(timeToCast);
        if(isReloading) currentTimeOfReload += Time.deltaTime;
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

        
        if (weaponBehavior.currentBullets <= 0)
        {
            isReloading = true;
            

            if (currentTimeOfReload >= timeToReload)
            {
                weaponBehavior.Reload();
                isReloading = false;
                currentTimeOfReload = 0;
             
            }

        }


        if (Input.GetKey(KeyCode.Mouse0)) 
        {
            if (weaponBehavior.currentBullets > 0) 
            {
                weaponBehavior.Fire();

            }

        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && CanCastSpell)
        {
            CanCastSpell = false;
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

    private void Cooldown (float waitTime)
    {
        if(currentTimeToCast >= waitTime)
        {
            CanCastSpell = true;
            currentTimeToCast = 0;
        }
    }

        
}
