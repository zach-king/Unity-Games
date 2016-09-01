using UnityEngine;
using System.Collections;
using Chronos;

public class EnforceTimeline : MonoBehaviour {
    void Awake()
    {
        Timeline time = GetComponent<Timeline>();

        if (time == null)
        {
            time = gameObject.AddComponent<Timeline>();
            time.mode = TimelineMode.Global;
            time.globalClockKey = Timekeeper.instance.Clock("Monsters").key;
        }
    }
}
