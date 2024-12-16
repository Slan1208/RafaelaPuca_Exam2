using System;
using UnityEngine;

public class HealthZoneController : MonoBehaviour
{
    [SerializeField] private GameObject healthZoneUI;
    [SerializeField] private Light directionalLight;
    private Animator sunAnimator;
    [SerializeField] private int healthAmount = 5;

    private void Start()
    {
        sunAnimator = directionalLight.GetComponent<Animator>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        // si chocamos contra el Player
        if (other.CompareTag("Player"))
        {
            healthZoneUI.SetActive(true); //Activa la UI
            /*Ingresamos al GameManager, a través de su método
             IncreaseHealth. Y entramos a su Amount de tipo Int
             con el healthAmount*/
            GameManager.instance.IncreaseHealth(healthAmount);
            sunAnimator.SetBool("DayNight", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthZoneUI.SetActive(false);
            sunAnimator.SetBool("DayNight", false);
        }
    }
}
