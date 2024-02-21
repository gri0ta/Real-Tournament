using UnityEngine;
using UnityEngine.Events;


public class Weapon : MonoBehaviour
{
	public UnityEvent onrightClick;

	public GameObject bulletPrefab;
	public int ammo;
	public int maxAmmo = 10;
	public bool isReloading;
	public bool isAutoFire;
	public float fireInterval = 0.5f;
	public float fireCooldown;
	public float recoilAngle;
	public int bulletsPerShot = 1;
	

	void Update()
	{
		//manual
		if (!isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
		{
			Shoot();
		}
		//automatic
        if (isAutoFire && Input.GetKey(KeyCode.Mouse0))
        {
			Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
			onrightClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R) && ammo<maxAmmo)
        {
			Reload();
        }
		fireCooldown -= Time.deltaTime;
	}

	public void Shoot()
	{
		if (isReloading) return;
		if (ammo <= 0)
		{
			Reload();
			return;
		}
		if (fireCooldown > 0) return;
		ammo--;
		
		fireCooldown = fireInterval;
		for (int i = 0; i < bulletsPerShot; i++)
		{ 
		var bulletShot = Instantiate(bulletPrefab, transform.position, transform.rotation);
		var offsetX = Random.Range(-recoilAngle, recoilAngle);
		var offsetY = Random.Range(-recoilAngle, recoilAngle);
		bulletShot.transform.eulerAngles += new Vector3(offsetX, offsetY, 0);
		}
	}
	async void Reload()
    {
		if (isReloading) return;
		isReloading = true;

		await new WaitForSeconds(2f);

		ammo = maxAmmo;
		isReloading = false;
		
    }
}