using System;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    [SerializeField] private GameObject doorTriggerGameObject;
    private Animator doorAnimator;
    private Collider doorCollider;
    [SerializeField] private ClueController _clueController; 

    private void Start()
    {
        
       doorAnimator = doorGameObject.GetComponent<Animator>();
       doorCollider = doorTriggerGameObject.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_clueController.AllCluesCollect()) // Si son verdaderas
        {
            doorAnimator.SetBool("AnimDoor", true); // abrir puerta
        }
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimator.SetBool("AnimDoor", false); // Cerrar puerta
        doorCollider.enabled = false; // Desactivar el Collider
    }
}
