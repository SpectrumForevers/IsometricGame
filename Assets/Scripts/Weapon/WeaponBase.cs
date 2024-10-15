using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]

public class WeaponBase : ScriptableObject
{
    [SerializeField] WeaponType type;

    [SerializeField] string nameWeapon;

    [SerializeField] float damagePerBullet;
    [SerializeField] float reloadTime;
    [SerializeField] float cooldownShoot;
    [SerializeField] float spreadAngle;

    [SerializeField] int countShoot;
    [SerializeField] int countReload;
    [SerializeField] int pellets;
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
    public int GetPellets()
    {
        return pellets;
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
    public float GetSpreadAngle()
    {
        return spreadAngle;
    }
}

public enum WeaponType
{
    Shotgun,
    Pistol,
    Rifle
}