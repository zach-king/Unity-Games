using UnityEngine;
using System.Collections;
using Chronos;

public class TimeColor : MonoBehaviour {
    public Color pauseColor, slowColor, fastColor;
    Color oldColor;

    void OnStartPause()
    {
        Renderer renderer = GetComponent<Renderer>();
        oldColor = renderer.material.color;
        renderer.material.color = pauseColor;
    }

    void OnStartSlowDown()
    {
        Renderer renderer = GetComponent<Renderer>();
        oldColor = renderer.material.color;
        renderer.material.color = slowColor;
    }

    void OnStartFastForward()
    {
        Renderer renderer = GetComponent<Renderer>();
        oldColor = renderer.material.color;
        renderer.material.color = fastColor;
    }

    void OnStopPause()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = oldColor;
    }

    void OnStopSlowDown()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = oldColor;
    }

    void OnStopFastForward()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = oldColor;
    }
}