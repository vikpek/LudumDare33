using UnityEngine;
using System.Collections;

public class TowerSelection : ExtendedMonoBehaviour {

	private int currentTower = 1;

	// Use this for initialization
	void Start () {
	 currentTower = 0;
	}

	
	public void SetCurrentTower(int _currentTower)
	{
		currentTower = _currentTower;
	}
	
	public int GetCurrentTower()
	{
		return currentTower;
	}
}
