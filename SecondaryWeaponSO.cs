using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Secondary Weapon can be a meele weapon 
[CreateAssetMenu(fileName = "newSecondaryWeapon", menuName = "SO/GUN/New Secondary Gun")]
public class SecondaryWeaponSO : BaseGunSO
{
    /* To do ability to enable and disable certain attachements for secondary weapons */
    public override void Shoot(FireBullet fireBullet)
    {
        AddGunRecoil(fireBullet.gunObject);
    }
    // For pans/ baseball bats
    public override void Hit(FireBullet fireBullet)
    {
    }

    public override void AddGunRecoil(GameObject gunModel)
    {     
    }
}
