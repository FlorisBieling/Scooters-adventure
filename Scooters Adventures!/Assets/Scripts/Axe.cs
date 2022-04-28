using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().AmountOfAxes++;
            gameObject.SetActive(false);
            print("ingo is een dikkie");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().AmountOfAxes++;
            gameObject.SetActive(false);
            print("ingo is een dikkie");
        }
    }
}
