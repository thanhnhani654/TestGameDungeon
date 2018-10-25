using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPauseGame : MonoBehaviour {

    bool bPauseGame = false;
    Button button;

	// Use this for initialization
	void Start () {
        button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(TaskOnClick);
	}

    void TaskOnClick()
    {
        if (!bPauseGame)
        {
            Time.timeScale = 0;
            bPauseGame = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            bPauseGame = false;
        }
    }
}
