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

    private void Update()
    {
        magazineText.text = weapon.ammo.ToString();
        healthText.text = health.health.ToString();
    }
}
