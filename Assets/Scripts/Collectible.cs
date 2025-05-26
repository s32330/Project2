using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if collision is Player
        if(!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        //send info to player
        Inventory playerInventory = null;
        playerInventory = collision.gameObject.GetComponent<Inventory>();

        //playerInventory. zrobic zmienna w Inventory i przypisac wrtosc tutaj
        //delete collectible
        Destroy(gameObject);
    }
}
