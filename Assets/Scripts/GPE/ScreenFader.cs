using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScreenFader : MonoBehaviour
{
    public static ScreenFader instance;
    public Image fadeImage;
    public float fadeDuration = 0.5f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        if (fadeImage != null)
        {
            fadeImage.color = new Color(0f, 0f, 0f, 1f);
            fadeImage.DOFade(0f, fadeDuration);
        }
    }

    public Tween FadeOut()
    {
        return fadeImage.DOFade(1f, fadeDuration);
    }

    public Tween FadeIn()
    {
        return fadeImage.DOFade(0f, fadeDuration);
    }
}
