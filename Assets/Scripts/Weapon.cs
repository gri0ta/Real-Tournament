using UnityEngine;
using UnityEngine.Events;


public class Weapon : MonoBehaviour
{
	public UnityEvent onrightClick;
	public UnityEvent onShoot;
	public UnityEvent<bool> onReload;


	public GameObject bulletPrefab;
	public AudioClip shootSound;
	public AudioClip reloadSound;
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
		
		fireCooldown -= Time.deltaTime;
	}

	public void Shoot()
	{
		var source = GetComponent<AudioSource>();
		if (isReloading) return;
		source.clip = shootSound;
		source.Play();
		if (ammo <= 0)
		{
			Reload();
			return;
		}
		if (fireCooldown > 0) return;
		ammo--;
		fireCooldown = fireInterval;
		onShoot.Invoke();

		for (int i = 0; i < bulletsPerShot; i++)
		{ 
		var bulletShot = Instantiate(bulletPrefab, transform.position, transform.rotation);
		var offsetX = Random.Range(-recoilAngle, recoilAngle);
		var offsetY = Random.Range(-recoilAngle, recoilAngle);
		bulletShot.transform.eulerAngles += new Vector3(offsetX, offsetY, 0);
		}
	}
	public async void Reload()
    {
		if (isReloading) return;
		isReloading = true;
		onReload.Invoke(false);

		var source = GetComponent<AudioSource>();
		source.clip = reloadSound; ;
		source.Play();
		await new WaitForSeconds(2f);

		ammo = maxAmmo;
		isReloading = false;
		onReload.Invoke(true);
	}
}