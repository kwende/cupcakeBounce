using UnityEngine;
using System.Collections;

public class PipeScript : MonoBehaviour 
{
	void Start(){
		this.gameObject.tag = "pipe"; 
	}

	void OnTriggerEnter2D(Collider2D collisionObject)
	{
		Destroy (collisionObject.gameObject); 

		GameObject[] allPipes = GameObject.FindGameObjectsWithTag ("pipe"); 
	}
}
