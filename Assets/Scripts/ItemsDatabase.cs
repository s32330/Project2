using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDatabase : MonoBehaviour
{
    public List<Item> Items= new List<Item>();
    public List<Item> PlayerItems = new List<Item>();

    public static ItemsDatabase Instance;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        Instance = this;
    }

    public void Add(Item item)
    {
       PlayerItems.Add(item);
        InventoryManager.Instance.UpdateSlots();
    }

    
}
//zeby lista sie wyswietlala v
[System.Serializable]
public class Item
{
    public enum ItemType
    {
        Weapon, Food
    }

    public string Name;
    public string Description;
    public int ID;
    public ItemType Type;
    public Sprite Icon;

    // po to zeby od razu przy dodawaniu itemu napisac wszystkie zmienne
    public Item(string Name, string Description, int ID, ItemType Type, Sprite Icon)
    {
        this.Name = Name;
        this.Description = Description;
        this.ID = ID;
        this.Icon = Icon;
        this.Type=Type;
    }
}