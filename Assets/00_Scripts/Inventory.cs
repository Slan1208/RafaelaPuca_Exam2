using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();
    public GameObject inventoryPanel;
    public GameObject inventoryItemPrefab;
    private bool inventoryVisible;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryVisible = !inventoryVisible;
            inventoryPanel.SetActive(inventoryVisible);
        }
    }

    // Método para agregar un pitem al inventario
    public void AddItem(Item item)
    {
        itemList.Add(item);
        Debug.Log("Item Agregado: " + item.itemName);
        
        UpdateInventoryUI();
    }

    public bool HasItem(string itemName)
    {
        foreach (Item item in itemList)
        {
            return true;
        }

        return false;
    }

    public void UpdateInventoryUI()
    {
        //Limpiar lo items actuales en el panel
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in itemList)
        {
            GameObject ItemUI = Instantiate(inventoryItemPrefab, inventoryPanel.transform);
            TextMeshProUGUI nameText = ItemUI.transform.Find("ItemNameText").GetComponent<TextMeshProUGUI>();
            nameText.text = item.itemName;
            
            Image iconImage = ItemUI.GetComponent<Image>();
            iconImage.sprite = item.icon;
        }
    }

}

