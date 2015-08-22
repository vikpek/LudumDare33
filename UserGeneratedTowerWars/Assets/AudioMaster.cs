using UnityEngine;
using System.Collections;

public class AudioMaster : ExtendedMonoBehaviour {
	 
    private static AudioMaster _instance;
    public  AudioSource audioSource;
    
    public static AudioMaster instance
    {
        get
        {   
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<AudioMaster>();
            return _instance;
        }
    }
	
	public void playEnemyDestruction(){
        audioSource.PlayOneShot((AudioClip) Resources.Load(ResourcePaths.ENEMY_DESTRUCTION_CLIP_PATH));
	}
    
    public void playTowerShot(){
        audioSource.PlayOneShot((AudioClip) Resources.Load(ResourcePaths.TOWER_SHOT_CLIP_PATH));
    }
    
    public void playEnemyHit(){
        audioSource.PlayOneShot((AudioClip) Resources.Load(ResourcePaths.ENEMY_HIT_CLIP_PATH));
    }
}
