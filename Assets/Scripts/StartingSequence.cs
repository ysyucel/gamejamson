using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSequence : MonoBehaviour
{
    public GameObject shakeObject;
    public UIController uiController;
    public GameObject startingMessage;
    public List<GameObject> dustParticle;
    bool isQuake = false;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.delayedCall(2f,() => {
            CloseStartingMessage();
            StartEarthQuake();
        });
    }
    public void StartEarthQuake()
    {
        if (isQuake) { return; }
        isQuake = true;
        Debug.Log("EarthQuake");
        shakeObject.GetComponent<CameraShake>().Shake();
        shakeObject.GetComponent<ShakeSample>().StartEarthQuake();
        foreach(GameObject item in dustParticle) { item.SetActive(true); }
        LeanTween.delayedCall(8f, () => {
            uiController.FadeIn();
        });
    }
    public void CloseStartingMessage()
    {
        startingMessage.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
