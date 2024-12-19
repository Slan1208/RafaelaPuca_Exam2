using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<Item> inventory = new List<Item>();
    public GameObject inventoryUI;
    public GameObject itemSlotPrefab;
    public TMP_Text inventoryText;

    private bool isInventoryOpen = false;
    private List<GameObject> displayedSlots = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInventoryOpen = !isInventoryOpen;
            if (isInventoryOpen) {
                inventoryUI.SetActive(true);
                inventoryText.gameObject.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            } else {
                inventoryUI.SetActive(false);
                inventoryText.gameObject.SetActive(false);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            
            if (isInventoryOpen)
                UpdateInventoryUI();
        }
    }

    public void AddItem(Item newItem)
    {
        inventory.Add(newItem);
        Debug.Log("Added item: " + newItem.itemName);
    }

    void UpdateInventoryUI()
    {
        // Clear previous slots
        foreach (GameObject slot in displayedSlots)
        {
            Destroy(slot);
        }
        displayedSlots.Clear();

        foreach (Item item in inventory)
        {
            GameObject slot = Instantiate(itemSlotPrefab, inventoryUI.transform);

            Image icon = slot.GetComponentInChildren<Image>();
            TextMeshProUGUI itemName = slot.GetComponentInChildren<TextMeshProUGUI>();
            Button button = slot.GetComponentInChildren<Button>(); // Get the Button component

            if (icon != null) icon.sprite = item.icon;
            if (itemName != null) itemName.text = item.itemName;

            button.onClick.AddListener(() => {
                Debug.Log("event listener added");
                UseItem(item);
            });

            displayedSlots.Add(slot);
        }
    }

    void UseItem(Item item)
    {
        Debug.Log("Clicked on item: " + item.itemName);
        item.Use();
        inventory.Remove(item);
        UpdateInventoryUI();
    }
}
