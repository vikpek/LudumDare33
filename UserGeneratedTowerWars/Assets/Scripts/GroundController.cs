using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnMouseUpAsButton() {
       
		GameObject tower = (GameObject)Resources.Load(ResourcePaths.TOWER_PATH);
		Vector3 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		tmp.z = 0;
		tower.transform.position = tmp; 
		Instantiate(tower);
    }
}
