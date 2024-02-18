using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHp;
    public int hp;

    void Start()
    {
        if (hp == 0) hp = maxHp;
    }

    public void Damage(int value)
    {
        hp -= value;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}