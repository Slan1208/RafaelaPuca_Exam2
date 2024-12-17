using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<Item> inventory = new List<Item>(); // List to hold inventory items
    public GameObject inventoryUI; // Main Inventory UI panel
    public GameObject itemSlotPrefab; // Prefab for item slots
    public TMP_Text inventoryText; // Reference to the TextMeshPro UI element

    private bool isInventoryOpen = false;
    private List<GameObject> displayedSlots = new List<GameObject>(); // To track displayed slots

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        // Toggle Inventory with 'I'
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInventoryOpen = !isInventoryOpen;
            if (isInventoryOpen) {
                inventoryUI.SetActive(true);
                inventoryText.gameObject.SetActive(true);
                Time.timeScale = 0f; // Pause game time
                Cursor.lockState = CursorLockMode.None; // Unlock the cursor
                Cursor.visible = true; // Make the cursor visible
            } else {
                inventoryUI.SetActive(false);
                inventoryText.gameObject.SetActive(false);
                Time.timeScale = 1f; // Resume game time
                Cursor.lockState = CursorLockMode.Locked; // Lock the cursor back to the center
                Cursor.visible = false; // Hide the cursor
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

        // Populate inventory UI
        foreach (Item item in inventory)
        {
            // Create a new slot and parent it to the InventoryUI
            GameObject slot = Instantiate(itemSlotPrefab, inventoryUI.transform);

            // Find the Image and TextMeshProUGUI components
            Image icon = slot.GetComponentInChildren<Image>();
            TextMeshProUGUI itemName = slot.GetComponentInChildren<TextMeshProUGUI>();
            Button button = slot.GetComponentInChildren<Button>(); // Get the Button component

            // Assign values from the item
            if (icon != null) icon.sprite = item.icon;
            if (itemName != null) itemName.text = item.itemName;

            // Add a click listener to use the item
            button.onClick.AddListener(() => {
                Debug.Log("event listener added");
                UseItem(item);
            });

            // Keep track of displayed slots
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
