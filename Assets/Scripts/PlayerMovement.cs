using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject playerMainGameObject;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SpriteRenderer playerSprite;

    [Header("Movement")]
    public float WalkSpeed;
    public float RunSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        Vector3 movementDirection = new Vector3(horizontalMovement, verticalMovement);
        Vector3 movementToAdd;

        // Set Movement
        if(Input.GetKey(KeyCode.Space))
        {
            movementToAdd = movementDirection.normalized * RunSpeed * Time.deltaTime;
            playerAnimator.speed = 2f;
            
        }
        else
        {
            movementToAdd = movementDirection.normalized * WalkSpeed * Time.deltaTime;
            playerAnimator.speed = 1f;
        }

        // Set Idle
        if(movementToAdd.magnitude <= 0)
        {
            playerAnimator.SetBool("Idle", true);
            playerAnimator.SetBool("IsWalking", false);
        }
        else
        {
            playerAnimator.SetBool("Idle", false);
            playerAnimator.SetBool("IsWalking", true);
        }
            
        // Flip sprite
        if (horizontalMovement < 0)
        {
            playerSprite.flipX = true;
        }
        if(horizontalMovement > 0)
        {
            playerSprite.flipX = false;
        }
       
        transform.position += movementToAdd;
    }
    
}
