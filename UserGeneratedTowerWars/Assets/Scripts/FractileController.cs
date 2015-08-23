using UnityEngine;
using System.Collections;

public class FractileController : MonoBehaviour
{

    private float lifeTime = 100f;
    Vector3 destination;
	
    void Start()
    {
        float randomRange = 0f;
        ConstantForce[] constantForces = GetComponentsInChildren<ConstantForce>();
        foreach (ConstantForce constantForce in constantForces)
        {
            //  constantForce.relativeTorque
            randomRange = Random.Range(100f, 500f);
            constantForce.relativeTorque = new Vector3(randomRange, randomRange, randomRange);
            constantForce.relativeForce = new Vector3(randomRange, randomRange, randomRange);
        }
        
        destination = new Vector3(5.92f, 1.5f, -1.6f);
    }
	
	void Update()
	{
		calculateLifetime();
        Transform[] transforms = GetComponentsInChildren<Transform>();
        foreach (Transform transform in transforms)
        {
            transform.position = Vector3.Lerp(transform.position, destination, 0.009f);
        }
	}


    void calculateLifetime()
    {
        if (lifeTime > 0f)
        {
            lifeTime--;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
