using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerState : MonoBehaviour
{
    [HideInInspector] public int hp;
    private int coins = 0;
    public int maxHP = 3;
    private Vector3 _respawnPosition;
    public SpriteRenderer sprite;

    [HideInInspector]
    public Vector3 respawnPosition
    {
        set
        {
            value.z = 0;
            _respawnPosition = value;
        }
        get
        {
            return _respawnPosition;
        }
    }

    private void Start()
    {
        respawnPosition = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        Spawn();

        gameObject.AddComponent<MusicManager>();
    }

    private void Update()
    {
        UIManager.Instance.HP.fillAmount = (float)hp / maxHP;
        UIManager.Instance.Coins.text = coins.ToString();
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
        StartCoroutine(FlashRed());

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

    public void PickCoin(int amount = 1)
    {
        coins += amount;
        Quest.Increase("collect_coins", amount);
        Statistics.Increase(Statistics.Keys.Coins, amount);
    }
    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        sprite.color = Color.white;
    }


}