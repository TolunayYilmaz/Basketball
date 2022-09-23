using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]private GameObject ball;

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("takeAble").Length == 0)
        {
            Instantiate(ball, transform.position, ball.transform.rotation);
        }
    }
}
