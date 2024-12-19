using UnityEngine;
using TMPro; 

public class DoorController : MonoBehaviour
{
    public float openAngle = 90f;
    public float openSpeed = 2f;
    public int requiredLevel = 2;

    private bool isOpening = false;
    private bool isClosing = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    public TMP_Text doorMessageText;
    float displayDuration = 2f;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    void Update()
    {
        if (isOpening)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);
            if (Quaternion.Angle(transform.rotation, openRotation) < 0.1f)
            {
                transform.rotation = openRotation;
                isOpening = false;
            }
        }
        else if (isClosing)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, closedRotation, Time.deltaTime * openSpeed);
            if (Quaternion.Angle(transform.rotation, closedRotation) < 0.1f)
            {
                transform.rotation = closedRotation;
                isClosing = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance.level < requiredLevel) 
            {
                doorMessageText.gameObject.SetActive(true);
            } else {
                isOpening = true;
                isClosing = false;
            }
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isClosing = true;
            isOpening = false;
            doorMessageText.gameObject.SetActive(false);
        }
    }
}
