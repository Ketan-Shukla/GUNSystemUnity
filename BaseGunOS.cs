using System;
using System.Collections.Generic;
using UnityEngine;


/* 
    Planned but not completed having separate enums file and adding attachments as below 
    Sight:
    -Holo
    -Tactical
    -Red Dot

    Grips: 
    - Foregrip
    - Thumbgrip
    - Halfgrip
    - Angledgrip
    - Lightgrip

    Muzzle:
    -Suppressor
    -Compensator
    -Flash hider  
*/
/*Base class has methods for add, reload, and different attributes */
[CreateAssetMenu(fileName = "Weapon", menuName = "SO/Weapon", order = 1)]
public abstract class BaseGunSO : ScriptableObject, IRecoilable
{
    public string weaponName;
    public float reloadTime;
    public int shotsPerRound
    public Sprite weaponThumbnail;
    public WeaponType weaponType = WeaponType.primary;
    public SightType sightType;
    public SightType availableSightTypes;
    public ShootModes defaultShootMode;
    public ShootModes currentShootMode;


    public AvailableShootModes availableShootModes;
    public Attachments availableAttachments;
    
    public BurstFireDetails burstFireDetails;
    public AutoFireDetails autoFireDetails;

    public int currentAmmo;
    public int totalAmmo;

    [SerializeField] private int clipSize;
    [SerializeField] private int maxAmmo;


    public int fireRate;
    public float accuracyDropPerShot;
    public float accuracyGainPerSec;
    public float maxAccuracy;
    public float scopeInTime;  
    public float scopeOutTime;
    public float burstPause;
    public float burstRate;
    public float burstTimer;
    public int burstCounter;
    [Range(10, 250)] public float currentAcc;


    
    // Base shooting method for all guns
    public abstract void Shoot(FireBullet fireBullet);
    // For melee weapons/differ weapon behavior
    public abstract void Hit(FireBullet fireBullet);
    // For adding weapon recoil
    public abstract void AddGunRecoil(GameObject gunModel);

    public void Init()
    {
        currentAmmo = clipSize;
        totalAmmo = maxAmmo - clipSize;
    }

    public void ReloadAmmo()
    {
        if (totalAmmo > 0 && currentAmmo < clipSize)
        {
            var ammoReq = clipSize - currentAmmo;
            if (ammoReq < totalAmmo)
            {
                totalAmmo -= ammoReq;
                currentAmmo += ammoReq;
            }
            else
            {
                totalAmmo -= totalAmmo;
                currentAmmo += totalAmmo;
            }
            HUD.instance.UpdateAmmo(currentAmmo, totalAmmo);
        }
    }

    public void PickupAmmo()
    {
        if (totalAmmo < (maxAmmo - clipSize))
        {
            if (currentAmmo > 0)
            {
                totalAmmo = Mathf.Clamp(totalAmmo + clipSize, 0, maxAmmo - clipSize);
            }
            else
            {
                totalAmmo = Mathf.Clamp(totalAmmo + clipSize, 0, maxAmmo);
            }
            HUD.instance.UpdateAmmo(currentAmmo, totalAmmo);
        }
    }

    public void UseAmmo(int count)
    {
        currentAmmo = Mathf.Clamp(currentAmmo - count, 0, clipSize);
        HUD.instance.UpdateAmmo(currentAmmo, totalAmmo);
    }

    
}


// For guns that fire in bursts added these enum
[System.Serializable]
public class BurstFireDetails
{
    [Range(1,10)] public float burstRate; // how often it can fire
    [Range(1,10)] public float burstPause; // time in between two bursts
    [Range(2,5)] public int burstCount; // how many projectiles in a burst
    
}

// Autofire detail for machine gun
[System.Serializable]
public class AutoFireDetails
{
    [Range(1,10)] public float firingRate; // firing rate for autofire guns such as machineguns
}


// Attachables name and attributes related to it
public struct Attachables
{
    public AttachmentName attachmentName;
    public AttachmentModifiers[] attributes;
}

// Attachment name is for showing to the players
// type selected from available type and modifier value is added or multiplied 
public struct AttachmentModifiers
{
    public WeaponAttributes name;
    public ModifierType type ;
    public float modifierValue;
}


