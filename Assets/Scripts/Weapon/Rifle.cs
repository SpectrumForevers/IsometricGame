using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] WeaponBase weaponBase;
    string nameWeapon;

    float damagePerBullet;
    float reloadTime;

    int countShoot;
    int countReload;
    [SerializeField] GameObject spawnBulletPoint;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (weaponBase == null)
        {
            Debug.LogError("Weapon without SO");
            return;
        }
        nameWeapon = weaponBase.GetNameWeapon();

        damagePerBullet = weaponBase.GetDamagePerBullet();
        reloadTime = weaponBase.GetReloadTime();

        countReload = weaponBase.GetCountReload();
        countShoot = weaponBase.GetCountShoot();
    }


}
