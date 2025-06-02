using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


    public class Collectible : MonoBehaviour
{
    public object item;
    public InventoryManager Inventory;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //check if collision is Player
        if(!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        else
        {

            ItemsDatabase.Instance.PlayerItems.Add(ItemsDatabase.Instance.Items[0]);
            Destroy(gameObject);
            


        }
        //send info to player
        //Inventory playerInventory = null;
       // playerInventory = collision.gameObject.GetComponent<Inventory>();

        //playerInventory. zrobic zmienna w Inventory i przypisac wrtosc tutaj
        //delete collectible
       
    }


}
