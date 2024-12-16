
using System;
using UnityEngine;

public class ClueController : MonoBehaviour
{
    private bool clue1Found;
    private bool clue2Found;
    public Sprite clue1Icon;
    public Sprite clue2Icon;
    
    // referencia al inventario del jugador
    private Inventory playerInventory;

    private void Start()
    {
        // Obtener el componente del inventario del jugador
        // GetComponent
        playerInventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Clue1":
                clue1Found = true;
                Debug.Log("C1 collected");
                // Crear un nuevo ítem para la pista 1
                Item clue1Item = new Item("Clue1", "Primera Pista", clue1Icon);
                // Agregar el ítem al inventario
                playerInventory.AddItem(clue1Item);
                // Destruir el objecto coleccionado de la escena
                Destroy(other.gameObject);
                break;
            case "Clue2":
                clue2Found = true;
                Debug.Log("C2 collected");
                // Crear un nuevo ítem para la pista 1
                Item clue2Item = new Item("Clue2", "Segunda Pista", clue2Icon);
                // Agregar el ítem al inventario
                playerInventory.AddItem(clue2Item);
                // Destruir el objecto coleccionado de la escena
                Destroy(other.gameObject);
                break;
        }
    }
    
    // Método público que nos retorne si todas las pistas son verdaderas

    public bool AllCluesCollect()
    {
        bool hasClue1 = playerInventory.HasItem("Clue1");
        bool hasClue2 = playerInventory.HasItem("Clue2");
        return clue1Found && clue2Found;

    }
}
