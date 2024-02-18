using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public GameObject bulletPrefab;

	public int maxAmmo;
	public int ammo;
	public bool isReloading;
	public bool isAutoFire;
	public float shootInterval;
	float waitTimeLeft;

	void Update()
	{
		if (!isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
		{
			Shoot();
		}

		if (isAutoFire && Input.GetKey(KeyCode.Mouse0))
		{
			Shoot();
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			Reload();
		}

		waitTimeLeft -= Time.deltaTime;
	}

	async void Reload()
	{
		if (isReloading) return;
		isReloading = true;

		await new WaitForSeconds(2f);

		ammo = maxAmmo;
		isReloading = false;
	}

	void Shoot()
	{
		if (isReloading) return;

		if (ammo <= 0)
		{
			Reload();
			return;
		}

		if (waitTimeLeft > 0) return;


		ammo--;
		waitTimeLeft = shootInterval;

		var cam = Camera.main.transform;
		Instantiate(bulletPrefab,cam.position,cam.rotation);

	}
}