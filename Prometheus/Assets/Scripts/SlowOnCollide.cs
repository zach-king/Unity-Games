using UnityEngine;
using System.Collections;
using Chronos;

public class SlowOnCollide : MonoBehaviour
{
    public float magnitude = 0.1f;

    void OnCollisionEnter(Collision other)
    {
        Timekeeper.instance.Clock("Blocks").localTimeScale = magnitude; // slow time for block
    }
}
