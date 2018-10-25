using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroAI : MonoBehaviour {

    public Transform goal;
    public float detectRadius;
    Collider[] enemies;
    LayerMask mask;
    private GameObject target = null;
    NavMeshAgent agent;

    //AttackMethod
    Transform BulletSpawn;          //Chua dung
    public GameObject bulletPrefap;
    public float fireInterval = 0.5f;
    float fireIntervalCount;

    //Attribute
    float damage = 10;


    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        mask = LayerMask.GetMask("MonsterMask");
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            DetectEnemy();
            return;
        }
        //agent.destination = transform.position;

        Fire();
	}

    void DetectEnemy()
    {
        enemies = Physics.OverlapSphere(transform.position, detectRadius, mask);
        for (int i = 0; i< enemies.Length; i++)
        {
            if (enemies[i].tag == "Boss")
            {
                Debug.Log(enemies[i].ToString());
                target = enemies[i].gameObject;
                agent.Stop();
                break;
            }
        }
    }

    void Fire()
    {
        if (fireIntervalCount > 0)
        {
            fireIntervalCount -= Time.deltaTime;
            return;
        }

        fireIntervalCount = fireInterval;

        GameObject bullet = (GameObject)Instantiate(bulletPrefap, transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().GetTarget(target, damage);
    }
}
