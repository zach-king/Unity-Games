using UnityEngine;
using System.Collections;

public class IgnoreCollision : MonoBehaviour {

    public string ignoreLayer;

    private UltimateRope rope;

	// Use this for initialization
	void Start () {
        rope = GetComponent<UltimateRope>();

        Physics.IgnoreLayerCollision(LayerMask.NameToLayer(ignoreLayer), LayerMask.NameToLayer(LayerMask.LayerToName(rope.RopeLayer)));
	}
}
