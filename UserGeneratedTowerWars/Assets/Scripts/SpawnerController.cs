using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {
	
    [SerializeField]
    private float spawnDuration = 2f;
    
    [SerializeField]
    private float spawnStart = 2f;
    	
    [SerializeField]
    private GameObject enemy;
    
 	void LaunchEnemy() {
        
        enemy.transform.position = transform.position;
        
        Instantiate(enemy);
    }
	
    void Start() {
        InvokeRepeating("LaunchEnemy", spawnStart, spawnDuration);
        
    }
}
