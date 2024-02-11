using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ana : MonoBehaviour
{
    List<GameObject> gameObjectsForce = new List<GameObject>();
    public void Start()
    {
        return;
        Debug.LogError(gameObject.name);
        MeshRenderer[] meshRenderers = FindObjectsOfType<MeshRenderer>();

        // Output the names of GameObjects with MeshRenderer components
        foreach (MeshRenderer renderer in meshRenderers)
        {
            if (renderer.gameObject.tag != "shell") {
                renderer.gameObject.SetActive(false);
                renderer.gameObject.AddComponent<MeshCollider>();
                renderer.gameObject.GetComponent<MeshCollider>().convex = true;
                renderer.gameObject.AddComponent<Rigidbody>();
                renderer.gameObject.SetActive(true);
            }
            // Debug.Log("Found GameObject with MeshRenderer: " + renderer.gameObject.name);
        }
        LeanTween.delayedCall(3f, () => {
            foreach (MeshRenderer renderer in meshRenderers)
            {
               // renderer.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 1);
                // Debug.Log("Found GameObject with MeshRenderer: " + renderer.gameObject.name);
            }
        });
    }
    
}

