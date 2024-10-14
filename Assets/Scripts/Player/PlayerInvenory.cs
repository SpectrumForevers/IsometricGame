using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvenory : MonoBehaviour
{
    [SerializeField] GameObject weaponActive;
    [SerializeField] List<GameObject> weapons = new List<GameObject>();
    private PlayerController controller;
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }
    private void Update()
    {
        controller.SetCurrentWeapon(weaponActive);
    }
}
