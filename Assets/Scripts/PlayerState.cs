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

    /// <summary>
    /// Heal the player.
    /// </summary>
    /// <param name="hp">The amount of health points to heal.</param>
    public void Heal(int hp = 1)
    {
        hp += hp;
    }

    /// <summary>
    /// Damage player and respawn if needed
    /// </summary>
    /// <param name="damage">The amount of damage to deal.</param>
    public void Harm(int damage = 1)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Spawn();
        }
    }

    /// <summary>
    /// Teleport player to predefined spawning location and fill HP
    /// </summary>
    public void Spawn()
    {
        hp = maxHP;
        transform.position = respawnPosition;
    }
}