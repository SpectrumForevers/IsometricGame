using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponBase weaponBase;
    [HideInInspector] public PlayerInvenory playerInvenory;
    string nameWeapon;

    float damagePerBullet;
    float reloadTime;
    float cooldownShoot;
    public int countShoot;
    
    int countReload;
    [SerializeField] GameObject spawnBulletPoint;
    GameObject bullet;
    WeaponType type;
    Coroutine shootCoroutine, reloadCoroutine;
    
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
        cooldownShoot = weaponBase.GetCooldownShoot();

        countReload = weaponBase.GetCountReload();
        countShoot = weaponBase.GetCountShoot();
        bullet = weaponBase.GetBulletType();

        type = weaponBase.GetWeaponType();
        
    }

    private void Update()
    {
        if(countShoot > 0)
        {
            EventBus.Shoot?.Invoke(countShoot);
        }
        if(Input.GetMouseButton(0) == true)
        {
            
            switch (type)
            {
                case WeaponType.Pistol:

                    break;

                case WeaponType.Rifle:
                    
                    ShootRifle();
                    break;

                case WeaponType.Shotgun:
                    
                    break;

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopShoot();
        }
        if (Input.GetKey(KeyCode.R))
        {
            if (reloadCoroutine != null)
            {
                reloadCoroutine = StartCoroutine(StartReloadCorutine());
            }
            
        }
    }
    private void ShootRifle()
    {
        if (shootCoroutine == null && countShoot > 0)
        {
            
            shootCoroutine = StartCoroutine(ShootCorutine());
        }
    }
    private void StopShoot()
    {
        if (shootCoroutine != null)
        {
            StopCoroutine(shootCoroutine);
            shootCoroutine = null;
        }
        
    }
    IEnumerator ShootCorutine()
    {
        GameObject bulletShooted;
        Rigidbody bulletRB;
        float timeCooldownShoot = cooldownShoot;
        while (countShoot > 0)
        {
            bulletShooted = Instantiate(bullet, spawnBulletPoint.transform.position, Quaternion.identity);
            countShoot--;
            EventBus.Shoot?.Invoke(countShoot);
            bulletRB = bulletShooted.GetComponent<Rigidbody>();
            bulletRB.velocity = gameObject.transform.forward * 10;

            yield return new WaitForSeconds(timeCooldownShoot);
        }
        if (countShoot <= 0)
        {
            StopShoot();
            if(countReload > 0)
            {
                StartReload();
            }
            
        }
        yield return null;
    }
    private void StartReload()
    {
        reloadCoroutine = StartCoroutine(StartReloadCorutine());
    }
    IEnumerator StartReloadCorutine()
    {
        //sound
        EventBus.StartReload?.Invoke();
        yield return new WaitForSeconds(reloadTime);
        countReload--;
        countShoot = weaponBase.GetCountShoot();
        reloadCoroutine = null;
        yield return null;
    }
    public int GetCountAmmo()
    {
        return countShoot;
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
