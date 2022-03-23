using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] Bullet bullet;

    public override void Shoot()
    {
        // Time.time - moment in time when the game started
        if (Time.time - timeOfLastShot > rateOfFire)
        {
            // print("pew pew");
            // creates an object on the scene - specifically a bullet at  the tip of the gun
            Bullet blt = Instantiate(bullet, tipOfTheWeapon.position, tipOfTheWeapon.rotation);
            blt.Setup(damage);
            timeOfLastShot = Time.time;
        }
    }
}
