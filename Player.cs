using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private List<PrimaryWeaponSO> primaryWeapons;
    [SerializeField] private List<SecondaryWeaponSO> secondaryWeapons;

    private PrimaryWeaponSO primaryWeapon1;
    private PrimaryWeaponSO primaryWeapon2;
    private SecondaryWeaponSO secondaryWeapon; 
    private BaseGunSO currentWeapon;     
    private float weaponFired = 0.0f;  

    private void Awake()
    {
        primaryWeapons = new List<Weapon>();
        secondaryWeapons = new List<Weapon>();
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].Init();
            if (weapons[i].weaponType == WeaponType.primary)
            {
                primaryWeapons.Add(weapons[i]);
            }
            if (weapons[i].weaponType == WeaponType.secondary)
            {
                secondaryWeapons.Add(weapons[i]);
            }
        } 
        weapons.Clear(); 

        if (secondaryWeapons.Count > 0)
        {
            secondaryWeapon = secondaryWeapons[0];
            secondaryWeapons.RemoveAt(0);
        }

        if (primaryWeapons.Count > 0)
        {
            primaryWeapon1 = primaryWeapons[0];
            primaryWeapons.RemoveAt(0);
        }

        if (primaryWeapons.Count > 0)
        {
            primaryWeapon2 = primaryWeapons[0];
            primaryWeapons.RemoveAt(0);
        }
    }

    private void Start()
    {
        ChangeCurrentWeapon(primaryWeapon1);    
        ResetFire();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeCurrentWeapon(primaryWeapon1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeCurrentWeapon(primaryWeapon2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeCurrentWeapon(secondaryWeapon);
        }

        // Fire bullet
        if(Input.GetButton("Fire"))
        {
            Fire();
        }

        // Reload Gun
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        // Pickup Ammo
        if(Input.GetKeyDown(KeyCode.E))
        {
            PickupAmmo();
        }

        // Pickup Gun
        if(Input.GetKeyDown(KeyCode.F))
        {
            PickupWeapon();
        }
    }

    private void Fire()
    {
            if (weaponFired + (1.0f / currentWeapon.fireRate) < Time.time && currentWeapon.currentAmmo > 0)
            {
                FireBullet bullet = new FireBullet(this.gameObject,this,true, centerPoint, fpsCamera);
                currentWeapon.Shoot(bullet);
                weaponFired = Time.time;
            }
    }

    private void Reload()
    {
        Debug.Log("reload");
        currentWeapon.ReloadAmmo();
    }

    private void PickupAmmo()
    {
        Debug.Log("pickup");
        currentWeapon.PickupAmmo();
    }

    /*Todo move this logic to a separate class*/
    // Pickup weapon
    private void PickupWeapon()
    {
        Debug.Log("pickup weapon");
        var tempWeapon = new Weapon();
        if (currentWeapon == primaryWeapon1 && primaryWeapons.Count > 0)
        {
            tempWeapon = primaryWeapon1;
            primaryWeapon1 = primaryWeapons[0];
            primaryWeapons.RemoveAt(0);
            primaryWeapons.Add(tempWeapon);
            ChangeCurrentWeapon(primaryWeapon1);
        }
        else if (currentWeapon == primaryWeapon2 && primaryWeapons.Count > 0)
        {
            tempWeapon = primaryWeapon2;
            primaryWeapon2 = primaryWeapons[0];
            primaryWeapons.RemoveAt(0);
            primaryWeapons.Add(tempWeapon);
            ChangeCurrentWeapon(primaryWeapon2);
        }
        else if (currentWeapon == secondaryWeapon && secondaryWeapons.Count > 0)
        {
            tempWeapon = secondaryWeapon;
            secondaryWeapon = secondaryWeapons[0];
            secondaryWeapons.RemoveAt(0);
            secondaryWeapons.Add(tempWeapon);
            ChangeCurrentWeapon(secondaryWeapon);
        }
    }

    private void ResetFire()
    {
        weaponFired = Time.time - (1.0f / currentWeapon.fireRate);
    }

    private void ChangeCurrentWeapon(Weapon _weapon)
    {
        currentWeapon = _weapon;
        HUD.instance.UpdateWeaponHUD(_weapon);
        weaponFired = Time.time;
    }
}
