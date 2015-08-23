using UnityEngine;
using System.Collections.Generic;

public class TowerController : ExtendedMonoBehaviour
{

    private Vector2 destinationVector;

    private float nextFireTime = 0.0f;

    [SerializeField]
    private float fireDamage = 1;

    [SerializeField]
    private float fireRange = 1;

    [SerializeField]
    private float fireRate = 1f;
    
    private float lifeTime = 100f;

    private TextMesh[] textIntels;
    private int textIntelCount = 3;
    [SerializeField]
    private bool showIntelActivated = false;

    void Start()
    {
        textIntels = InitiateIntel(textIntelCount, textIntels);
    }

    void Update()
    {
        if(showIntelActivated){
            showIntel();
        }
        if (enemyInRange())
        {
            shoot();
        }
    }

    void shoot()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
    
            GameObject projectile = (GameObject)Resources.Load(ResourcePaths.PROJECTILE_PATH);
            projectile.GetSafeComponent<ProjectileController>().destination = destinationVector;
            projectile.GetSafeComponent<ProjectileController>().damage = fireDamage;
            projectile.transform.position = gameObject.transform.position;
            Instantiate(projectile);
            
            AudioMaster.instance.playTowerShot();
        }
    }


    private void showIntel()
    {
        
        textIntels[0].text = "RT" + fireRate;
        textIntels[1].text = "RG" + fireRange;
        textIntels[2].text = "DG" + fireDamage;
    }

    private bool enemyInRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, fireRange);

        List<Collider> creepColliders = new List<Collider>();

        foreach (Collider col in hitColliders)
        {
            if (col.tag == Tags.ENEMY)
            {
                creepColliders.Add(col);
            }
        }
        if (creepColliders.Count > 0)
        {
            destinationVector = creepColliders[0].transform.position;
            return true;
        }
        else
        {
            return false;
        }


    }
}
