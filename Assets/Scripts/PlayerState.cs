using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int hp = 3;

    public void Harm(int damage = 1)
    {
        hp -= damage;

        if (hp <= 0)
        {
            // die
        }
    }
}