using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]

public class WeaponBase : ScriptableObject
{
    [SerializeField] WeaponType type;

    [SerializeField] string nameWeapon;

    [SerializeField] float damagePerBullet;
    [SerializeField] float reloadTime;
    [SerializeField] float cooldownShoot;

    [SerializeField] int countShoot;
    [SerializeField] int countReload;
    [SerializeField] GameObject bulletType;
    
    public string GetNameWeapon()
    {
        return nameWeapon;
    }
    public float GetDamagePerBullet()
    {
        return damagePerBullet;
    }
    public float GetReloadTime()
    {
        return reloadTime;
    }
    public int GetCountShoot()
    {
        return countShoot;
    }
    public int GetCountReload()
    {
        return countReload;
    }
    public GameObject GetBulletType()
    {
        return bulletType;
    }
    public WeaponType GetWeaponType()
    {
        return type;
    }
    public float GetCooldownShoot()
    {
        return cooldownShoot;
    }
}

public enum WeaponType
{
    Shotgun,
    Pistol,
    Rifle
}