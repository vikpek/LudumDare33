using UnityEngine;
using System.Collections;

public class EnemyController : ExtendedMonoBehaviour
{


    [SerializeField]
    private float healthPoints = 10f;
    
    [SerializeField]
    private float movementSpeed = 0.1f;

    private TextMesh[] textIntels;
    private int textIntelCount = 1;
    
    private ArrayList waypoints;

    private GameObject closestWaypoint;
    [SerializeField]
    private bool showIntelActivated = false;

    void Start()
    {
        textIntels = InitiateIntel(textIntelCount, textIntels);
        //  GetComponent<FollowSpline>().SetSpline(GameObject.FindGameObjectWithTag("Spline").GetComponent<SplineWindow>());
        
         waypoints = new ArrayList();
         foreach(GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint")){
             waypoints.Add(waypoint);
         }
         FindNearestWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(showIntelActivated){
        ShowIntel();
        }
        
        Move();
        //  Rotate();
        FindNearestWaypoint();
        RemoveReachedWaypoint();
    }
    
    void ShowIntel()
    {
        textIntels[0].text = "HP" + healthPoints;
    }

    void TakeDamageSubstraction(float damage)
    {
        healthPoints -= damage;
        if (healthPoints < 0)
        {
            SelfDesctructionProcedure();
        }
        
        AudioMaster.instance.playEnemyHit();
    }

    void Move()
    {
         transform.position = Vector3.MoveTowards(transform.position, closestWaypoint.transform.position, movementSpeed);
    }
    
    void Rotate()
    {
        Vector2 targetDir = closestWaypoint.transform.position - transform.position;
        float step = 1f * Time.deltaTime;
        Vector2 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void SelfDesctructionProcedure()
    {
        print("Enemy destroyed");
        Destroy(gameObject);
        
        spawnFractiles();
        AudioMaster.instance.playEnemyDestruction();
        
        GameObject.FindGameObjectWithTag(Tags.GAME_CONTROLLER).GetComponent<GameController>().IncreaseCash(10);
        GameObject.FindGameObjectWithTag(Tags.GAME_CONTROLLER).GetComponent<GameController>().IncreasePoints(100);
       
    }
    
    void spawnFractiles(){
       
        GameObject fractile = (GameObject)Resources.Load(ResourcePaths.FRACTILE_PATH);
        fractile.transform.position = transform.position;
        
        Instantiate(fractile);
    }


    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == Tags.PROJECTILE)
        {
            TakeDamageSubstraction(other.GetComponent<ProjectileController>().damage);
        }
        
        if(other.tag == Tags.GOAL){
            GameObject.FindGameObjectWithTag(Tags.GAME_CONTROLLER).GetComponent<GameController>().DecreaseLife();
            Destroy(gameObject);
        }
    }
    
    void FindNearestWaypoint(){
        float distance = float.MaxValue;
        foreach(GameObject waypoint in waypoints){
            float tmpDistance = Vector2.Distance(waypoint.transform.position, transform.position);
            if(tmpDistance < distance){
                closestWaypoint = waypoint;
                distance = tmpDistance;
            }
        }
    }
    
    void RemoveReachedWaypoint()
    {
        if(Vector2.Distance(closestWaypoint.transform.position, transform.position) < 0.1){
            waypoints.Remove(closestWaypoint);
        }
    }
}