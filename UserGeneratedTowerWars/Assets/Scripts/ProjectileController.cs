using UnityEngine;

public class ProjectileController : ExtendedMonoBehaviour {

	public float lifeTime = 10f;
	
	public float damage;
	
	public float speed = 0.3f;
	
	public GameObject origin;
	
	public Vector3 destination;
	
	

	delegate void Calculations();
	Calculations calculations;


	void Start () {
		calculations += calculateLifetime;
		calculations += calculateMovement;
		//  calculations += calculationPrintOut;
	}

	void Update () {
		calculations();
	}

	void calculateMovement(){
		transform.position = Vector2.MoveTowards(transform.position, destination, speed);
	}

	void calculateLifetime(){
		if(lifeTime > 0f){
			lifeTime --;
		}else{
			Destroy(this.gameObject);
		}
	}

	void calculationPrintOut(){
		print("Life time: " + lifeTime);
	}
	
	void OnTriggerEnter(Collider col)
	{
		Destroy(gameObject);
	}
}
