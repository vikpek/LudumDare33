using UnityEngine;
using SplineTool;

public class EnemyController : ExtendedMonoBehaviour
{


    [SerializeField]
    private float healthPoints = 10f;
    
    [SerializeField]
    private float movementSpeed = 0.1f;

    private TextMesh[] textIntels;
    private int textIntelCount = 1;

    void Start()
    {
        textIntels = InitiateIntel(textIntelCount, textIntels);
        //  GetComponent<FollowSpline>().SetSpline(GameObject.FindGameObjectWithTag("Spline").GetComponent<SplineWindow>()); 

    }

    // Update is called once per frame
    void Update()
    {
        textIntels[0].text = "HP" + healthPoints;
        move();
    }

    void TakeDamageSubstraction(float damage)
    {
        healthPoints -= damage;
        if (healthPoints < 0)
        {
            SelfDesctructionProcedure();
        }
    }

    void move()
    {
         transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, movementSpeed);
    }

    void SelfDesctructionProcedure()
    {
        print("Enemy destroyed");
        Destroy(gameObject);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.PROJECTILE)
        {
            TakeDamageSubstraction(other.GetComponent<ProjectileController>().damage);
        }
    }
}
