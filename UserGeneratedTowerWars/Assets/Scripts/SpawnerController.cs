using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {
	
 	void LaunchEnemy() {
        GameObject enemy = (GameObject)Resources.Load(ResourcePaths.ENEMY_PATH);
        enemy.transform.position = transform.position;
        
        Instantiate(enemy);
    }
	
    void Start() {
        InvokeRepeating("LaunchEnemy", 0, 2f);
    }
}
