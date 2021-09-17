using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public int count;
    public float currentTime;
    public Text timeScore;
    public bool end;
    public GameObject dropBox;


    void Start()
    {
        timeScore = GameObject.Find("TimeScore").GetComponent<Text>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            count += 1;
            Debug.Log(count);
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        InGame();
        StopGame();
    }   

    void InGame()
    {
        if (end == false)
        {
            currentTime += Time.deltaTime;
            timeScore.text = "Score: " + ((int)currentTime % 60).ToString();
        }
    }

    void StopGame()
    {
        if (count >= 10)
        {
            end = true;
            Debug.Log(end);
            dropBox.SetActive(false);
        }
    }
}
