using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private CharacterController controller; 

    void Start()
    {

        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");     
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
            
        }
        if(moveDirection != Vector3.zero)
        {
            gameObject.GetComponent<PlayerController>().run = true;
        }
        else
        {
            gameObject.GetComponent<PlayerController>().run = false;
        }
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

}
