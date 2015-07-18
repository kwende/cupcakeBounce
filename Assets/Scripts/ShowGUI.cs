using UnityEngine;
using System.Collections;

public class ShowGUI : MonoBehaviour {

	public GameObject Cupcake; 
	public GameObject UIPrefab; 
	public GameObject CurrentWindowInstance { get; private set; }

	// Use this for initialization
	void Start () {
	
	}

	public void CloseWindow(){
		if (CurrentWindowInstance != null) {
			Destroy(CurrentWindowInstance); 
			CurrentWindowInstance = null; 
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.T) && CurrentWindowInstance == null) {
			CurrentWindowInstance = Instantiate(UIPrefab); 
			GameObject go = GameObject.Find("TheCanvas"); 
			CurrentWindowInstance.transform.SetParent(go.transform, false); 
		} 
		else if (Input.GetKeyDown(KeyCode.T) && CurrentWindowInstance != null){
			CloseWindow(); 
		}

		if (Input.GetKeyDown (KeyCode.B)) {
			GameObject cupcake = Instantiate(Cupcake, new Vector3(0, 10, 0), new Quaternion(0, 0, 0, 0)) as GameObject; 
		}
	}
}
