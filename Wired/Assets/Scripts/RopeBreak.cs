using UnityEngine;
using System.Collections;

public class RopeBreak : MonoBehaviour
{
    public UltimateRope rope;

    bool broken;

    void Start()
    {
        broken = false;
    }

    void OnRopeBreak(UltimateRope.RopeBreakEventInfo breakInfo)
    {
        if (breakInfo.rope == rope)
        {
            broken = true;
            Debug.Log("Rope Broken!");
            
        }

    }

    void Update()
    {
    }
}
