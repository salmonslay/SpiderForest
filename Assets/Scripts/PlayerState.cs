using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [HideInInspector]
    public int hp;

    public int maxHP = 3;
    private Vector3 respawnPosition;

    private void Start()
    {
        respawnPosition = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        UIManager.Instance.HP.maxValue = maxHP;
        Spawn();
    }

    private void Update()
    {
        UIManager.Instance.HP.value = hp;
    }

    public void Heal(int hp = 1)
    {
        hp += hp;
    }

    public void Harm(int damage = 1)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        hp = maxHP;
        transform.position = respawnPosition;
    }
}