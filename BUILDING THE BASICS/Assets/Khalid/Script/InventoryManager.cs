using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; 
    public List<Item> Items = new();
    public Transform ItemContent;
    public GameObject InventoryItem;
    

    public void Awake()
    {
        Instance = this; 
    }
    public void Add(Item item)
    {
        Items.Add(item);
   

 
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        //Destroy(item);
    }

    public void ListItem()
    {
       /* foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        } */ 
    
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            Text itemName = obj.transform.Find("itemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("itemIcon").GetComponent<Image>();


        itemName.text = item.itemName;
        itemIcon.sprite = item.icon;
        }

    }



}

