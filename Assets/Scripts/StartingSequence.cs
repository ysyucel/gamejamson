using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
public class StartingSequence : MonoBehaviour
{
    public bool isRescueRun = false;
    public GameObject shakeObject;
    public GameObject rumbleObject;
    public UIController uiController;
    public GameObject startingMessage;
    public List<GameObject> dustParticle;
    public GameObject coverText;
    public GameObject findyourfamilyText;
    bool isQuake = false;
    public TMP_Text textMeshPro;
    public float earthquakeTime;
    public GameObject clicktoproceedButton;
    public AudioClip soundClipEarth;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.delayedCall(8f,() => {
            CloseStartingMessage();
        });

        if (isRescueRun)
        {
            LeanTween.delayedCall(180, () => {
                StartEarthQuake();
            });
        }
    }
    public void StartEarthQuake()
    {
        if (isQuake) { return; }

        CloseStartingMessage();
        if(!isRescueRun)
        coverText.SetActive(true);
        isQuake = true;
        LeanTween.delayedCall(3f, () => {
            SoundPlayer.instance.soundClip = soundClipEarth;
            SoundPlayer.instance.PlaySound(soundClipEarth);
            Debug.Log("EarthQuake");
            shakeObject.GetComponent<CameraShake>().shakeDuration= earthquakeTime;
            shakeObject.GetComponent<ShakeSample>().shakeDuration=earthquakeTime;
            shakeObject.GetComponent<CameraShake>().Shake();
            rumbleObject.GetComponent<Rumble>().enabled = true;
            shakeObject.GetComponent<ShakeSample>().StartEarthQuake();
            foreach(GameObject item in dustParticle) { item.SetActive(true); }
            LeanTween.delayedCall(earthquakeTime+1f, () => {

                if (!isRescueRun)
                    coverText.SetActive(false);
                rumbleObject.GetComponent<Rumble>().enabled = false;
                uiController.FadeIn();

                if (!isRescueRun)
                    ChangeStartingMessageToOk();
                LeanTween.delayedCall(7f, () => {

                    if (!isRescueRun)
                        CloseStartingMessage();

                    if (!isRescueRun)
                        OpenFamilyText();
                });
            });
        });
    }
    public void CloseStartingMessage()
    {
        startingMessage.SetActive(false);
    }
    public void ChangeStartingMessageToOk()
    {
        textMeshPro.text = "It's over for now, check for injuries!";
        startingMessage.SetActive(true);
    }
    public void OpenFamilyText()
    {
        
        findyourfamilyText.SetActive(true);
       // LeanTween.delayedCall(8f, () => {
           // CloseFamilyText();
        //});
    }
    public void CloseFamilyText()
    {
        findyourfamilyText.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Finishapp()
    {
        LeanTween.delayedCall(3f, () => {
            clicktoproceedButton.SetActive(true);
        });
    }
    public void LoadIsekai()
    {
            SceneManager.LoadScene("gameSceneDeneme2");
        
    }
}
