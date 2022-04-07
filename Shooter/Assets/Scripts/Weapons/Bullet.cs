using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private int damage;

    public void Setup(int damage)
    {
        this.damage = damage;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other != null)
        {
            // Destroy(this); will destroy the Bullet component, which is not what we want here
            Destroy(gameObject); // will destroy the bullet itself - could be called with this.gameObject - same thing
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(25);
            }
        
        }   
    }
}
