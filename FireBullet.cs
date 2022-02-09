using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class responsible for animations/bullet effects/ aiming 
public class FireBullet
{
    public readonly GameObject gunObject; // GunMesh
    public readonly BaseGunSO gunScript; // currentScipt
    public readonly bool useRecoil; // use recoil or not 
    public readonly Vector2 centrePoint; // where the aim is
    private readonly Camera fpsCamera; // scope/fps camera

    public FireBullet(GameObject gunObject, EquippedGun gunScript, bool useRecoil, Vector2 centrePoint, Camera fpsCamera)
    {
        this.gunObject = gunObject;
        this.gunScript = gunScript;
        this.useRecoil = useRecoil;
        this.centrePoint = centrePoint;
        this.fpsCamera = fpsCamera;
    }

// Use raycast to find target reduce ammo etc
    public void Shoot(Vector2 pointToFire)
    {
        var goalPoint = Vector3.zero;
        Ray ray = fpsCamera.ScreenPointToRay(pointToFire);
        RaycastHit[] hits = Physics.RaycastAll(ray, 100f);
        if (hits.Length != 0)
        {
            goalPoint = hits[hits.Length - 1].point;
        }
        gunScript.UseAmmo(1);
        /*To be done Add Shooting related stuff 
        animation
        events
        detect enemy collision 
        Alert multiplayer*/
    }
}