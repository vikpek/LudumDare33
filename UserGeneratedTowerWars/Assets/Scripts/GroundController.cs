using UnityEngine;
using System.Collections;

public class GroundController : ExtendedMonoBehaviour {

	void OnMouseUpAsButton() {
		
		
        int currentTower = GameObject.FindGameObjectWithTag(Tags.GAME_CONTROLLER).GetComponent<TowerSelection>().GetCurrentTower();
		
		GameObject tower = null;
		switch (currentTower)
		{
			case 1 : 
				tower = (GameObject)Resources.Load(ResourcePaths.T1_INJECTOR);
				break;
			case 2 : 
				tower = (GameObject)Resources.Load(ResourcePaths.T2_SMASHER);
				break;
			case 3 : 
				tower = (GameObject)Resources.Load(ResourcePaths.T3_CHAINSAW);
				break;
		}
		
		if(tower){
			Vector3 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			tmp.z = 0;
			tower.transform.position = gameObject.transform.position;
			
			Instantiate(tower);
			
			GameObject.FindGameObjectWithTag(Tags.GAME_CONTROLLER).GetComponent<GameController>().DecreaseCash(currentTower);
		}
    }
}
