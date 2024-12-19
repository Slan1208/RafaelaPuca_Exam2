using UnityEngine;

public class Debris : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }
}