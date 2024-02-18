using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public GameObject bulletPrefab;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Shoot();
		}
	}


	void Shoot()
	{
		var cam = Camera.main.transform;
		Instantiate(bulletPrefab,cam.position,cam.rotation);
	}
}