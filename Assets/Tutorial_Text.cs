using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial_Text : MonoBehaviour {

    public Text explain;
    public Text count;

    public GameObject Ball_In;
    public GameObject Ball_Out;

    float passtime = 0f;

    // Use this for initialization
    void Awake () {

        explain.text = "화면 터치를 통해 볼을 움직여 ";
        explain.text += "\n장애물을 피하는 게임 입니다.";
        explain.text += "\n\n볼을 움직여 보세요!";
        Time.timeScale = 0f;

    }

    // Update is called once per frame
    void Update () {
        if (Ball_Control.count == 6)
        {
            Time.timeScale = 1f;
        }

        if (Ball_Control.count == 5)
        {
            count.enabled = false;
            explain.text = "장애물을 피해보세요 !";
        }

        passtime += Time.deltaTime;
        if (passtime >= 10f)
        {
            Time.timeScale = 0f;
            explain.text = "Clear!";
        }

        count.text = "   " + Ball_Control.count + " / 5";
    }

    public void Exit()
    {
        Ball_Control.count = 0;
        Application.LoadLevel("Start");
    }

}
