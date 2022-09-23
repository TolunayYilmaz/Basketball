using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private int Count = 0;

    public Text Force;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        int playerScore = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerController>().score;
        Count += 10*playerScore;
        CounterText.text = "Score : " + Count;
        StartCoroutine(ObjectDestroy(other));
    }


    IEnumerator ObjectDestroy(Collider other)
    {
        yield return new WaitForSeconds(1f);
        Destroy(other.gameObject);
    }
}
