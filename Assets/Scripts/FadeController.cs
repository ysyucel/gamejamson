using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 1f;

    public void FadeIn()
    {
        fadePanel.CrossFadeAlpha(1f, fadeDuration, false);
    }

    public void FadeOut()
    {
        fadePanel.CrossFadeAlpha(0f, fadeDuration, false);
    }
}