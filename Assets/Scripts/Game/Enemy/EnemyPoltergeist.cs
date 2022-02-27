using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoltergeist : MonoBehaviour 
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

    //kan vara SerializeField men äsch
    public float attackDistance = 8;
    public float attackCooldown = 2;

    public SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite newSprite;
    public Sprite stretchSprite;
    

    float lastAttack = 0;

    private void Update()
    {
        Vector3 playerPosition = gameObjectPlayer.transform.position;
        Vector3 enemyPosition = gameObject.transform.position;
        //skillnaden mellan poltergeist och player
        float distance = Vector3.Distance(enemyPosition, playerPosition);

        //om lastAttack är på 0, så kan poltergeist attackera igen
        if (distance < attackDistance && lastAttack < 0)
        {
            ChangeSprite(newSprite);
            lastAttack = attackCooldown;
            //kod som attackerar
            //googla!!!! rotationer i unity är djävulen
            GameObject item = Instantiate(throwableItem, enemyPosition, Quaternion.identity);
            item.GetComponent<Rigidbody2D>().AddForce(attackForce * 300);
            
        }
        //deltaTime = tiden sen förra framen
        lastAttack -= Time.deltaTime;

        if (lastAttack < 1.58)
        {
            ChangeSprite(stretchSprite);
        }

        if (lastAttack < 1.5)
        {
            ChangeSprite(idleSprite);
        }
        
    }


    private void Start()
    {
        gameObjectPlayer = GameObject.Find("Player");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }
    internal void OnTriggerEnter2D(Collider2D collision)
    {
        // if enemy hits a player - do harm
        if (collision.gameObject.CompareTag("Player"))
        {
            // do harm if flashlight is enabled or else check a 25% risk
            if (collision.GetComponent<PlayerMovement>().isFlashlightOn || Random.Range(0, 5) == 2)
            {
                PlayerState state = collision.gameObject.GetComponent<PlayerState>();
                state.Harm(2);
            }
        }
    }

}
