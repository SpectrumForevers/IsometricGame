using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject currentWeapon;
    public Camera mainCamera; // —сылка на основную камеру
    public float rotationSpeed = 5f; // —корость поворота персонажа

    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit))
        {
            
            Vector3 targetPosition = hit.point;

            
            Vector3 direction = targetPosition - transform.position;
            direction.y = 0; 

            
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
       
    }
    public void SetCurrentWeapon(GameObject currentWeapon)
    {
        this.currentWeapon = currentWeapon;
    }
}
