using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour
{
    public Renderer redLightRenderer;
    public Renderer yellowLightRenderer;
    public Renderer greenLightRenderer;

    public Material redOn;
    public Material yellowOn;
    public Material greenOn;
    public Material baseMaterial; // Used when a light is off

    public float redDuration = 5f;
    public float greenDuration = 5f;
    public float yellowDuration = 2f;

    void Start()
    {
        StartCoroutine(TrafficLightCycle());
    }

    IEnumerator TrafficLightCycle()
    {
        while (true)
        {
            // Red Light ON
            SetLight(redLightRenderer, redOn);
            SetLight(yellowLightRenderer, baseMaterial);
            SetLight(greenLightRenderer, baseMaterial);
            yield return new WaitForSeconds(redDuration);

            // Yellow Light ON
            SetLight(redLightRenderer, baseMaterial);
            SetLight(yellowLightRenderer, yellowOn);
            SetLight(greenLightRenderer, baseMaterial);
            yield return new WaitForSeconds(yellowDuration);

            // Green Light ON
            SetLight(redLightRenderer, baseMaterial);
            SetLight(yellowLightRenderer, baseMaterial);
            SetLight(greenLightRenderer, greenOn);
            yield return new WaitForSeconds(greenDuration);

           
        }
    }

    void SetLight(Renderer lightRenderer, Material mat)
    {
        if (lightRenderer != null && mat != null)
        {
            lightRenderer.material = mat;
        }
    }
}
