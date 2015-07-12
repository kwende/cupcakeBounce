using UnityEngine;
using System.Collections;

public class DestroyBear : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (transform.position.y) > 20) {
			Destroy (gameObject); 
		}
	}
}
