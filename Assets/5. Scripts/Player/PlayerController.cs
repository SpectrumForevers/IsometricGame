using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject currentWeapon;
    public Camera mainCamera; // —сылка на основную камеру
    public float rotationSpeed = 5f; // —корость поворота персонажа
    [SerializeField] Animator animator;
    [HideInInspector] public bool run = false;
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
            if (hit.transform.gameObject.tag != Tags.player)
            {
                Vector3 targetPosition = hit.point;

            
                Vector3 direction = targetPosition - transform.position;
                direction.y = 0; 

            
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
        CheckStateAnimation();


    }
    public void SetCurrentWeapon(GameObject currentWeapon)
    {
        this.currentWeapon = currentWeapon;
    }

    private void CheckStateAnimation()
    {
        if (run == true)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        if (currentWeapon.GetComponent<Weapon>().GetTypeWeapon() == WeaponType.Pistol)
        {
            animator.SetBool("Pistol", true);
        }
        else
        {
            animator.SetBool("Pistol", false);
        }
    }
}
