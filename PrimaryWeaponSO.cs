using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Primary weapons are created from this script
[CreateAssetMenu(fileName = "NewGun", menuName = "SO//New Primary Gun")]
public class PrimaryWeaponSO : BaseGunSO
{

// Reduce the accuracy/recoil other parameters here  bullet shooting and animation part handled in firebullet
    public override void Shoot(FireBullet fireBullet)
    {
        
        if (fireBullet.gunScript.currentShootMode == ShootModes.Burst)
            fireBullet.gunScript.burstCounter++;

        fireBullet.gunScript.currentAcc -= fireBullet.gunScript.currentGun.accuracyDropPerShot;
        
        if(fireBullet.gunScript.currentAcc <= 0)
            fireBullet.gunScript.currentAcc = 10;
        
        fireBullet.Shoot(fireBullet.centrePoint);
        
        if(fireBullet.useRecoil)
            AddGunRecoil(fireBullet.gunObject);
    }

// For Meele / rocket launcher / custom attack behavior
    public override void Hit(FireBullet fireBullet)
    {
    }

// Add recoil anim
    public override void AddGunRecoil(GameObject gunModel)
    {     
    }
}
