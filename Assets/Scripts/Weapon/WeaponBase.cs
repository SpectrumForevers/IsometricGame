using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]

public class WeaponBase : MonoBehaviour
{
    [SerializeField] string nameWeapon;
    [SerializeField] float damagePerBullet;
    [SerializeField] int countShoot;
    [SerializeField] int countReload;

    public string GetNameWeapon()
    {
        return nameWeapon;
    }
    public float GetDamagePerBullet()
    {
        return damagePerBullet;
    }
    public int GetCountShoot()
    {
        return countShoot;
    }
    public int GetCountReload()
    {
        return countReload;
    }
}

public enum WeaponType
{
    Shotgun,
    Pistol,
    Rifle
}