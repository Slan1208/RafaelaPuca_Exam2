using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RedFlash : MonoBehaviour
{
    [SerializeField] private Image redFlashImage;
    [SerializeField] private float flashDuration = 0.5f;

    private void Awake()
    {
        if (redFlashImage != null)
        {
            Color color = redFlashImage.color;
            color.a = 0;
            redFlashImage.color = color;
        }
    }

    public void StartFlash()
    {
        if (redFlashImage != null)
        {
            StartCoroutine(Flash());
        }
    }

    private IEnumerator Flash()
    {
        float elapsedTime = 0f;
        while (elapsedTime < flashDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.PingPong(elapsedTime, flashDuration / 2) / (flashDuration / 2);
            Color color = redFlashImage.color;
            color.a = alpha;
            redFlashImage.color = color;
            yield return null;
        }

        Color finalColor = redFlashImage.color;
        finalColor.a = 0;
        redFlashImage.color = finalColor;
    }
}
