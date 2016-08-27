using UnityEngine;
using System.Collections;

public class IgnoreCollision : MonoBehaviour {

    public Collider ignoredCollider;
    public string ignoreLayer1, ignoreLayer2;

	// Use this for initialization
	void Start () {
        //Physics.IgnoreCollision(GetComponent<Collider>(), ignoredCollider);
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer(ignoreLayer1), LayerMask.NameToLayer(ignoreLayer2));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
