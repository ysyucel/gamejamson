using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSequence : MonoBehaviour
{
    public GameObject shakeObject;
    public UIController uiController;
    public GameObject startingMessage;
    public GameObject dustParticle;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.delayedCall(3f,() => {
            CloseStartingMessage();
        });
    }
    public void StartEarthQuake()
    {
        Debug.Log("EarthQuake");
        shakeObject.SetActive(true);
        dustParticle.SetActive(true);
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
