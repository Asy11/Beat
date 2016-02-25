using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Ground").SendMessage("GameOver");
        }
    }
}
