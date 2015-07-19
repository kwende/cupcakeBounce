using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

	void Awake(){
		Rigidbody2D[] allRigidBodies = FindObjectsOfType<Rigidbody2D> (); 

		foreach (Rigidbody2D rigidBody in allRigidBodies) {
			rigidBody.isKinematic = true; 
		}
	}

	// Use this for initialization
	void Start () {
		Button button = this.gameObject.GetComponent<Button> (); 
		button.onClick.AddListener (OnClickHandler); 
	}

	private void OnClickHandler(){
		Rigidbody2D[] allRigidBodies = GameObject.FindObjectsOfType<Rigidbody2D> (); 

		foreach (Rigidbody2D rigidBody in allRigidBodies) {
			rigidBody.isKinematic = false; 
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
