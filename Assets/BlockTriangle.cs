using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlockTriangle : MonoBehaviour
{

    SpriteRenderer spriteRend;
    CircleCollider2D childcollider;
    bool delete = false;
    float interval = 0f;
    float passTime = 0f;

    float In_Distance;
    float Out_Distance;
    public GameObject In_Ball;
    public GameObject Out_Ball;
    SpriteRenderer rend_In;
    SpriteRenderer rend_Out;


    Animator animator;

    void Start()
    {
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
        childcollider = gameObject.transform.FindChild("DeadColider").GetComponent<CircleCollider2D>();
        animator = gameObject.GetComponent<Animator>();
        rend_In = In_Ball.GetComponent<SpriteRenderer>();
        rend_Out = Out_Ball.GetComponent<SpriteRenderer>();
    }

    public void OnComponent()       //컴포넌트를 비활성화 시켜 장애물을 해제함
    {
        spriteRend.enabled = true;
        childcollider.enabled = true;
    }

    void OffComponent()     //컴포넌트를 활성화 시켜 장애물을 설정함
    {
        spriteRend.enabled = false;
        childcollider.enabled = false;
    }

    public void SetBoolfunc()       //
    {
        gameObject.GetComponent<Animator>().SetBool("On", false);
        delete = true;

    }

    void deactiveBlock()        //장애물을 생성한 후 0.5f의 시간이 지나면 제거함
    {
        interval += Time.deltaTime;
        if (interval > 0.5f)
        {
            OffComponent();
            interval = 0f;
            delete = false;
        }
    }

    void activeRandomBlock_In()     //게임 진행과는 직접적인 상관은 없지만 단조로움을 피하기 위해 안쪽 장애물을 생성시킨다.
    {
        int j = Random.Range(1, 21);
        In_Distance = Vector2.Distance(gameObject.transform.position, In_Ball.transform.position);

        if (In_Distance > 17)
        {
            if (animator.CompareTag("In" + j))
                animator.SetTrigger("On");
        }

    }

    void activeRandomBlock_Out()        //위의 함수와 기능이 같으나 바깥쪽 장애물을 생성시킨다.
    {
        int i = Random.Range(1, 21);
        Out_Distance = Vector2.Distance(gameObject.transform.position, Out_Ball.transform.position);

        if (Out_Distance > 17)
        {
            if (animator.CompareTag("Out" + i))
                animator.SetTrigger("On");
        }

    }

    void Update()
    {
        passTime += Time.deltaTime;

        //if(Menu.Level == 2)
        if (passTime > 4f)
        {
            ActiveLevle1(passTime);
        }
        if (passTime >= 4)
        {
            for (int i = 0; i < 220; i++)       //시간의 지남에 따라 랜덤블럭을 활성화 시킨다.
            {
                if (passTime > i + 1f && passTime < i + 1.1f)
                {
                    activeRandomBlock_Out();
                    activeRandomBlock_In();
                }
            }

            Time.timeScale = 0.8f;
        }
        if(passTime >=20)
            Time.timeScale = 0.9f;
        if (passTime >= 40)
            Time.timeScale = 1f;
        if (passTime >= 60)
            Time.timeScale = 1.1f;
        if (passTime >= 80)
            Time.timeScale = 1.2f;

        if (delete == false)
        {
            return;
        }

        deactiveBlock();
    }

    void ActiveLevle1(float passTime)
    {
        int time = (int)passTime;

        int block1 = Random.Range(3, 5);
        int block2 = Random.Range(7, 10);
        int block3 = Random.Range(12, 15);
        int block4 = Random.Range(17, 20);


        if (passTime % 4f > 3f && passTime % 4f < 3.017f)
        {
            if (rend_In.enabled && animator.CompareTag("In"+block4))
                animator.SetTrigger("On");
            else if (rend_Out.enabled && animator.CompareTag("Out" + block4))
                animator.SetTrigger("On");
        }

        else if (passTime % 4f > 2f && passTime % 4f < 2.017f)
        {
            if (rend_In.enabled && animator.CompareTag("In" + block3))
                animator.SetTrigger("On");
            else if (rend_Out.enabled && animator.CompareTag("Out" + block3))
                animator.SetTrigger("On");
        }
        else if (passTime % 4f > 1f && passTime < 1.017f)
        {
            if (rend_In.enabled && animator.CompareTag("In" + block2))
                animator.SetTrigger("On");
            else if (rend_Out.enabled && animator.CompareTag("Out" + block2))
                animator.SetTrigger("On");
        }

        else if (passTime % 4f > 0f && passTime % 4f < 0.017f)
        {
            if (rend_In.enabled && animator.CompareTag("In" +block1))
                animator.SetTrigger("On");
            else if (rend_Out.enabled && animator.CompareTag("Out" + block1))
                animator.SetTrigger("On");
        }

    }
}
