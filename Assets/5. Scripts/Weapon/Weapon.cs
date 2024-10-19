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
    float spreadAngle;


    int countShoot;
    int pellets;
    int countReload;
    [SerializeField] GameObject spawnBulletPoint;
    GameObject bullet;
    WeaponType typeWeapon;
    Coroutine shootCoroutine, reloadCoroutine;
    GameObject soundEffect;
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
        spreadAngle = weaponBase.GetSpreadAngle();

        countReload = weaponBase.GetCountReload();
        countShoot = weaponBase.GetCountShoot();
        bullet = weaponBase.GetBulletType();
        pellets = weaponBase.GetPellets();
        soundEffect = weaponBase.GetSoundShoot();
        typeWeapon = weaponBase.GetWeaponType();
        
    }

    private void Update()
    {
        if(countShoot > 0)
        {
            EventBus.Shoot?.Invoke(countShoot);
        }
        if(Input.GetMouseButton(0) == true && Time.timeScale > 0f)
        {
            
            switch (typeWeapon)
            {
                case WeaponType.Pistol:
                    ShootRifle();
                    break;

                case WeaponType.Rifle:
                    
                    ShootRifle();
                    break;

                case WeaponType.Shotgun:
                    ShootShootgun();
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
            
            shootCoroutine = StartCoroutine(ShootRifleCorutine());
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
    IEnumerator ShootRifleCorutine()
    {
        GameObject bulletShooted;
        Rigidbody bulletRB;
        float timeCooldownShoot = cooldownShoot;
        while (countShoot > 0)
        {
            Instantiate(soundEffect, Camera.main.transform.position, Quaternion.identity);
            bulletShooted = Instantiate(bullet, spawnBulletPoint.transform.position, Quaternion.identity);
            bulletShooted.GetComponent<Bullet>().SetDamagePerBullet(damagePerBullet);
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
    IEnumerator ShootShotgunCorutine()
    {
        // Цикл для создания дробинок (пуль) при каждом выстреле
        float timeCooldownShoot = cooldownShoot;
        while (countShoot > 0)
        {
            for (int i = 0; i < pellets; i++)
            {
                // Создаём пулю
                Instantiate(soundEffect, Camera.main.transform.position, Quaternion.identity);
                GameObject bullet = Instantiate(this.bullet, spawnBulletPoint.transform.position, spawnBulletPoint.transform.rotation);
                bullet.GetComponent<Bullet>().SetDamagePerBullet(damagePerBullet);
                // Вычисляем случайный угол разброса в пределах указанного угла spreadAngle
                float randomX = Random.Range(-spreadAngle, spreadAngle);
                float randomY = Random.Range(-spreadAngle, spreadAngle);
                Quaternion randomRotation = Quaternion.Euler(randomX, randomY, 0);

                // Направляем пулю с учётом разброса
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.velocity = randomRotation * spawnBulletPoint.transform.forward * 10;
                
                // Можно добавить разрушение пули через некоторое время
                Destroy(bullet, 2f); // Удаляем пулю через 2 секунды
                
            }
            countShoot--;
            EventBus.Shoot?.Invoke(countShoot);
            yield return new WaitForSeconds(timeCooldownShoot);
        }
        if (countShoot <= 0)
        {
            StopShoot();
            if (countReload > 0)
            {
                StartReload();
            }

        }
        yield return null;
    }
    void ShootShootgun()
    {
        if (shootCoroutine == null && countShoot > 0)
        {
            shootCoroutine = StartCoroutine(ShootShotgunCorutine());
        }
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
    public WeaponType GetTypeWeapon()
    {
        return typeWeapon;
    }
}
