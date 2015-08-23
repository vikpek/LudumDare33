using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {
	
    [SerializeField]
    private float spawnDuration = 2f;
    
 	void LaunchEnemy() {
        GameObject enemy = (GameObject)Resources.Load(ResourcePaths.ENEMY_PATH);
        enemy.transform.position = transform.position;
        
        Instantiate(enemy);
    }
	
    void Start() {
        InvokeRepeating("LaunchEnemy", 0, spawnDuration);
    }
}
