using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // this class represents the base class for any weapon
    [SerializeField] protected float rateOfFire;
    [SerializeField] protected Transform tipOfTheWeapon;
    [SerializeField] protected int damage;

    [SerializeField] protected float timeOfLastShot;

    public virtual void Shoot()
    {

    }
}
