using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplay : MonoBehaviour {

    TextMesh textMesh;
    public float timeLife = 2;
    float timeLifeCount;

	// Use this for initialization
	void Start () {
        textMesh = gameObject.GetComponent<TextMesh>();

        if (textMesh == null)
            Debug.Log("textMesh = NULL");
        timeLifeCount = timeLife;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeLife > 0)
        {
            timeLife -= Time.deltaTime;
            Vector3 pos = transform.position;
            pos.y += 0.2f * Time.timeScale;
            transform.position = pos;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}

    public void SetText(string text)
    {
        if (textMesh == null)
            textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.text = text;
    }
}
