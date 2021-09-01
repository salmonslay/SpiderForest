using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int hp = 3;

    private void Start()
    {
        UIManager.Instance.HP.maxValue = hp;
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
            // die
        }
    }
}