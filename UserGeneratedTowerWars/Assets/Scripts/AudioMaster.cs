using UnityEngine;
using System.Collections;

public class AudioMaster : ExtendedMonoBehaviour {
	 
    private static AudioMaster _instance;
    public  AudioSource audioSource;
    
    private Object[] enemyDeathClips;
    
    public static AudioMaster instance
    {
        get
        {   
            if(_instance == null){
                _instance = GameObject.FindObjectOfType<AudioMaster>();
            }
            return _instance;
        }
    }
    
    
    void Start(){
        enemyDeathClips = Resources.LoadAll(ResourcePaths.ENEMY_DEATH_CLIPS);
    }
    
	
	public void playEnemyDestruction(){
        int rnd = Random.Range(0, enemyDeathClips.Length);
        
        if(Random.Range(0,100) > 50){
            audioSource.PlayOneShot((AudioClip) enemyDeathClips[rnd]);
        }
	}
    
    public void playTowerShot(){
        audioSource.PlayOneShot((AudioClip) Resources.Load(ResourcePaths.TOWER_SHOT_CLIP_PATH));
    }
    
    public void playEnemyHit(){
        audioSource.PlayOneShot((AudioClip) Resources.Load(ResourcePaths.ENEMY_HIT_CLIP_PATH));
    }
    
     public void playTowerSelection(){
        audioSource.PlayOneShot((AudioClip) Resources.Load("Sounds/enemy_hit"));
    }
}
