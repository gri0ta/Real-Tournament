using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text magazineText;
    public Health health;
    public Weapon weapon;

    void Start()
    {
        UpdateUI();
        health.onDamage.AddListener(UpdateUI);
        weapon.onShoot.AddListener(UpdateUI);
        weapon.onReload.AddListener((ended)=>UpdateUI()); //anonimine funkcija
    }

    void UpdateUI()
    {
        magazineText.text = weapon.ammo.ToString();
        healthText.text = health.health.ToString();
    }
}
