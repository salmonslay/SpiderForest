using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoltergeist : EnemyMovingPoints //samma funktioner som EnemyMovingPoints (som ärver från Enemy), ändrar spriten
{
    //poltergeisten kastar föremål istället för att skada direkt genom att spelaren går in i den
    //försvinner när spelaren kommer för nära
    //statisk enemy
    //kolla så att spelaren är inom x avstånd
    //kolla så att attacken inte är på cooldown
    //attackera

    //hittar spelarens gameobject och sparar den och sätter den nere i Start, aka när spelet har startat
    GameObject gameObjectPlayer;
    [SerializeField] GameObject throwableItem;
    //sätt allting till ett värde här så är det lättare att ändra i unity senare
    public Vector3 attackForce;

    public float attackDistance = 8;
    public float attackCooldown = 2;
    float lastAttack = 0;

    private void Update()
    {
        base.Update();
        Vector3 playerPosition = gameObjectPlayer.transform.position;
        Vector3 enemyPosition = gameObject.transform.position;
        //skillnaden mellan poltergeist och player
        float distance = Vector3.Distance(enemyPosition, playerPosition);

        if (distance < attackDistance && lastAttack < 0)
        {
            //om lastAttack är på 0, så kan poltergeist attackera igen
            lastAttack = attackCooldown;
            //kod som attackerar
            //googla!!!! rotationer i unity är djävulen
            GameObject item = Instantiate(throwableItem, enemyPosition, Quaternion.identity);
            item.GetComponent<Rigidbody2D>().AddForce(attackForce * 300);
        }
        //deltaTime = tiden sen förra framen
        lastAttack -= Time.deltaTime;
    }


    private void Start()
    {
        base.Start();
        gameObjectPlayer = GameObject.Find("Player");
    }


}
