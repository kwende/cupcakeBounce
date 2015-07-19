using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HandleObjectAddClick : MonoBehaviour {

	public GameObject ObjectToAdd; 

	void ClickHandler(){
		Debug.Log ("Button clicked."); 

		GameObject go = Instantiate (ObjectToAdd, 
		                             new Vector3(0, 0, 0), 
		                             new Quaternion(0, 0, 0, 0)) as GameObject; 
		go.GetComponent<Rigidbody2D> ().isKinematic = true; 

		ShowGUI guiWindow = ScriptableObject.FindObjectOfType<ShowGUI> (); 
		guiWindow.CloseWindow (); 
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("Setting up event..."); 

		Button btn = this.GetComponent<Button> (); 
		btn.onClick.AddListener (ClickHandler); 

		Debug.Log ("...done"); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
