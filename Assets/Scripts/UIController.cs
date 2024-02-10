using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    public GameObject fadeInCanvas;
    public Image fadePanel;
    public float fadeDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void ProceedButtonClicked() {
        SceneManager.LoadScene("gameScene");
    }
    public void QuitButtonClicked() {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void FadeIn()
    {
        fadeInCanvas.SetActive(true);
        LeanTween.value(fadePanel.gameObject, SetImageAlpha, fadePanel.color.a, 1, fadeDuration)
                 .setEase(LeanTweenType.easeInOutQuad);
    }

    public void FadeOut()
    {
        LeanTween.value(fadePanel.gameObject, SetImageAlpha, fadePanel.color.a, 0, fadeDuration)
                 .setEase(LeanTweenType.easeInOutQuad).setOnComplete(() => { fadeInCanvas.SetActive(false); });
    }

    void SetImageAlpha(float alpha)
    {
        Color color = fadePanel.color;
        color.a = alpha;
        fadePanel.color = color;
    }
}
