using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class InventoryManager : MonoBehaviour
{
    GameObject Inventory;
    public bool IsOpen;
    void Start()
    {
        //by na starcie ekwipunek byl wylaczony
        Inventory = transform.Find("Inventory").gameObject;
        IsOpen = false;
        Inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Inventory.SetActive(!Inventory.activeInHierarchy);
            IsOpen = !IsOpen;

            //Gdy wylaczymy albo wlaczymy ekwipunek to sloty wracaja do NormalColor bo inaczej jest bug
            for (int i = 0; i < Inventory.transform.childCount; i++)
            {
                Slot slot = Inventory.transform.GetChild(i).GetComponent<Slot>();
                slot.Target.color = slot.NormalColor;
            }

            UpdateSlots();
        }

        //proba ekwipunku
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ItemsDatabase.Instance.PlayerItems.Add(ItemsDatabase.Instance.Items[0]);
            UpdateSlots();
        }
    }

    public void UpdateSlots()
    {
        for (int i = 0; i < Inventory.transform.childCount; i++)
        {
            if (i < ItemsDatabase.Instance.PlayerItems.Count)
            {
                Inventory.transform.GetChild(i).Find("Icon").gameObject.SetActive(true);
                Inventory.transform.GetChild(i).Find("Icon").GetComponent<Image>().sprite = ItemsDatabase.Instance.PlayerItems[i].Icon;
            }
            else
            {
                Inventory.transform.GetChild(i).Find("Icon").gameObject.SetActive(false);
                Inventory.transform.GetChild(i).Find("Icon").GetComponent<Image>().sprite = null;
            }
        }
    }
}
