using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LightBehaviour : MonoBehaviour
{
    private float updateStep = 0.1f;
    private float currentUpdateTime = 0f;
 
    private float clipLoudness;
    private float[] clipSampleData;

    Material material;
    // Start is called before the first frame update
    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep) {
            currentUpdateTime = 0f;
            clipLoudness = OutputVolume.GetRMS(256, 0);
            material.SetColor("_EmissionColor", new Color(1.91f,0.58f,0.0f,0.0f) * clipLoudness);
            GetComponent<Light>().intensity = clipLoudness * 2.0f;
        }
    }
}
