using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    GameObject bullet;
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
        bullet = weaponBase.GetBulletType();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject bulletShooted;
        Rigidbody bulletRB = GetComponent<Rigidbody>();

        bulletShooted = Instantiate(bullet, spawnBulletPoint.transform.position, Quaternion.identity);

        bulletRB = bulletShooted.GetComponent<Rigidbody>();
        bulletRB.velocity = gameObject.transform.forward * 10;


    }
    private int GetCountReload()
    {
        return countReload;
    }
    private void SetCountReload(int countReload)
    {
        this.countReload = countReload;
    }
}
