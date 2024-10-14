using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject currentWeapon;


    public void SetCurrentWeapon(GameObject currentWeapon)
    {
        this.currentWeapon = currentWeapon;
    }
}
