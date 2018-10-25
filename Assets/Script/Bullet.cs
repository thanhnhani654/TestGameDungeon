using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    GameObject target = null;
    public float speed = 2.0f;
    public GameObject textPrefap;
    float damage;
    Camera camera;

	// Use this for initialization
	void Start () {
        camera = Camera.current;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, speed);
        }
	}


    public void GetTarget(GameObject target, float damage)
    {
        this.target = target;
        this.damage = damage;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boss")
        {
            GameObject damageText = (GameObject)Instantiate(textPrefap, transform.position, transform.rotation);
            damageText.transform.LookAt(camera.transform);
            damageText.GetComponent<TextDisplay>().SetText(damage.ToString());
            Destroy(this.gameObject);
        }
    }
}
