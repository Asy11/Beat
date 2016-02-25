using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    internal static int Level = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoStart()
    {
        Level = 2;
        Application.LoadLevel("Path Test");
    }

    public void GoTutorial()
    {
        Level = 1;
        Application.LoadLevel("Tutorial");
    }
}
