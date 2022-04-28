using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPickup : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().EnablePlayerBall();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().EnablePlayerBall();
            gameObject.SetActive(false);
        }
    }
}
