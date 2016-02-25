using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TTTTTT : MonoBehaviour {

    public Text timeText;
    float time = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Ground").GetComponent<Ball_Control>().Game_over)
            return;
        time += Time.deltaTime;
        timeText.text = time.ToString();
    }
}
