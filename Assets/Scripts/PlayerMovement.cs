using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject PlayerMainGameObject;
    public float MovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalMovement, verticalMovement);
        transform.position += movementDirection.normalized * MovementSpeed * Time.deltaTime;
    }
}
