using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball_Control : MonoBehaviour
{

    public GameObject Ball_In;
    public GameObject Ball_Out;

    SpriteRenderer rend_In;
    SpriteRenderer rend_Out;

    CircleCollider2D colider_In;
    CircleCollider2D colider_Out;

    public Text clearText;
    float clearTime = 0f;

    public bool Game_over = false;
    internal static int count=0;

    // Use this for initialization
    void Start()
    {
        if (Menu.Level == 2)
            Time.timeScale = 1f;

        rend_In = Ball_In.GetComponent<SpriteRenderer>();
        rend_Out = Ball_Out.GetComponent<SpriteRenderer>();

        colider_In = Ball_In.GetComponent<CircleCollider2D>();
        colider_Out = Ball_Out.GetComponent<CircleCollider2D>();

        Ball_In.GetComponent<iTweenEvent>().Start();
        Ball_Out.GetComponent<iTweenEvent>().Start();

    }

    // Update is called once per frame
    void Update()
    {
        if (Game_over) {
            return;
        }
        if (Input.GetMouseButtonDown(0))
            OnMouseDown();

        clearTime += Time.deltaTime;

        if (Menu.Level == 2)
            SetText();
    }
    public void GameOver()      //GameOver 표시
    {
        clearText.text = "Game Over!";
        Ball_In.GetComponent<iTweenEvent>().Stop();
        Ball_Out.GetComponent<iTweenEvent>().Stop();
        Game_over = true;
    }

    public void OnMouseDown()       //화면 터치시 작동됨
    {
        if (rend_In.enabled)     //안쪽 공이 활성화 상태라면 비활성화 후 바깥쪽 공 활성화.
        {
            rend_In.enabled = false;
            colider_In.enabled = false;

            rend_Out.enabled = true;
            colider_Out.enabled = true;
        }
        else if (rend_Out.enabled)       //바깥쪽 공이 활성화 상태라면 비활성화 후 안쪽 공 활성화.
        {
            rend_In.enabled = true;
            colider_In.enabled = true;

            rend_Out.enabled = false;
            colider_Out.enabled = false;
        }

        count++;
    }
    public void Exit()      //첫 시작화면으로 돌아감
    {
        Ball_Control.count = 0;
        Application.LoadLevel("Start");
    }

    public void SetText()       //ClearText를 조정함
    {
        if (clearTime < 1f)
            clearText.text = "4";
        else if (clearTime < 2f)
            clearText.text = "3";
        else if (clearTime < 3f)
            clearText.text = "2";
        else if (clearTime < 4f)
            clearText.text = "1";
        else if (clearTime < 5f)
            clearText.text = " ";

        if (clearTime > 120f)
            clearText.text = "Clear!";
    }
}
