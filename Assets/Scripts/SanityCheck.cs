using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SanityCheck : MonoBehaviour {

	public GameObject ObjectToAdd; 

	void DoSomethingCool(){
		Debug.Log ("Button clicked."); 

		GameObject go = Instantiate (ObjectToAdd, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)) as GameObject; 
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("Setting up event..."); 

		Button btn = this.GetComponent<Button> (); 
		btn.onClick.AddListener (DoSomethingCool); 

		Debug.Log ("...done"); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
