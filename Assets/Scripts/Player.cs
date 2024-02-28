using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Health health;
    public Weapon weapon;

    void Start()
    {
        health = GetComponent<Health>();

    }

    public void Update()
    {
        //manual
        if (!weapon.isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }
        //automatic
        if (weapon.isAutoFire && Input.GetKey(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            weapon.onrightClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R) && weapon.ammo < weapon.maxAmmo)
        {
            weapon.Reload();
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health.Damage(10);
        }
    }
}

    

