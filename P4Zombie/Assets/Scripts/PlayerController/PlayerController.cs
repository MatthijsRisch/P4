using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stamina")]
    public float maxStamina;
    public float stamina;
    public float timeTillStaminaRegen;
    public float staminaRegenRate;

    [Header("Jumping")]
    public float jumpHeight;
    public float jumpStaminaDrain;
    bool canJump = false;

    [Header("Sprinting")]
    public float sprintMultiplier;
    public float sprintStaminaDrain;
    bool canSprint = false;

    [Header("Movement")]
    Vector3 movementVector;
    public float moveSpeed;
    float moveSpeedReset;

    WeaponBase equippedWeapon;


    float timeSinceStaminaUse;

    private void Start()
    {
        stamina = maxStamina;
        moveSpeedReset = moveSpeed;
    }

    void Update ()
    {
        timeSinceStaminaUse += Time.deltaTime;

        if(timeSinceStaminaUse >= timeTillStaminaRegen && stamina <= maxStamina)
        {
            StaminaRegen();
        }

        if(Input.GetButton("Sprint") == true && stamina > 0 && canSprint == true)
        {
            Sprint();
        }
        if(Input.GetButtonUp("Sprint") == true)
        {
            moveSpeed = moveSpeedReset;
        }

        //canSprint is false while walking backwards
        if(Input.GetAxis("Vertical") < 0)
        {
            canSprint = false;
        }
        else
        {
            canSprint = true;
        }
	}

    private void FixedUpdate()
    {
        Move();

        if (Input.GetButtonDown("Jump") == true && canJump == true && stamina >= jumpStaminaDrain)
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    void Jump()
    {
        Vector3 x = Vector3.zero;
        x.y = jumpHeight;
        gameObject.GetComponent<Rigidbody>().AddForce(x);
        canJump = false;

        stamina -= jumpStaminaDrain;
        timeSinceStaminaUse = 0;
    }

    void StaminaRegen()
    {
        stamina += staminaRegenRate * Time.deltaTime;
    }

    void Sprint()
    {
        moveSpeed = moveSpeedReset * sprintMultiplier;
        stamina -= sprintStaminaDrain * Time.deltaTime;
        timeSinceStaminaUse = 0;
    }

    private void Move()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");
        transform.Translate(movementVector * moveSpeed * Time.deltaTime);
    }
}
