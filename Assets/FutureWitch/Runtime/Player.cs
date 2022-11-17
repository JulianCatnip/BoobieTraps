using UnityEngine;
using System.Collections;

public class Player : Character
{
    //public HealthBar healthBarPrefab;
    //HealthBar healthBar;
    //public HitPoints hitPoints;

    public ItemInventory inventoryPrefab;
    ItemInventory inventory;

    private void OnEnable()
    {
        //ResetCharacter();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            ItemObject hitObject = collision.gameObject.GetComponent<ItemObject>();
            collision.gameObject.SetActive(false);

            /*if(hitObject != null)
            {
                switch (hitObject.type)
                {
                    case ItemObject.Type.GEM:
                        inventory.AddItem(hitObject);
                        break;
                    case ItemObject.Type.NATURE_CATALYST:
                        inventory.AddItem(hitObject);
                        break;
                    case ItemObject.Type.POTION:
                        inventory.AddItem(hitObject);
                        break;
                    case ItemObject.Type.REMAINS:
                        inventory.AddItem(hitObject);
                        break;
                    default:
                        break;
                }*/
        }
    }

    /*public bool AdjustHitPoints(int amount)
    {
        if(hitPoints.value < maxHitPoints)
        {
            hitPoints.value = hitPoints.value + amount;
            print("Adjusted hitpoints by: " + amount + ". New value: " + hitPoints.value);

            return true;
        }

        return false;
    }*/

    /*public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            hitPoints.value = hitPoints.value - damage;

            if (hitPoints.value <= float.Epsilon)
            {
                KillCharacter();
                break;
            }

            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }*/

    /*public override void KillCharacter()
    {
        base.KillCharacter();

        //Destroy(healthBar.gameObject);
        Destroy(inventory.gameObject);
    }*/

    /*public override void ResetCharacter()
    {
        //inventory = Instantiate(inventoryPrefab);
        //healthBar = Instantiate(healthBarPrefab);
        //healthBar.character = this;

        //hitPoints.value = startingHitPoints;
    }*/
}