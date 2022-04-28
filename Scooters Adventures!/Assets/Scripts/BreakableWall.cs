using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
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
            //if (player.GetComponent<Player>().movementDirectionInsideOfBall != Vector3.zero) player.GetComponent<Player>().transform.position += player.GetComponent<Player>().movementDirectionInsideOfBall * 0.1f;
            //if (player.GetComponent<Player>().movementDirectionOutOfBall != Vector3.zero) player.GetComponent<Player>().transform.position += player.GetComponent<Player>().movementDirectionOutOfBall * 0.1f;

            player.GetComponent<Player>().BreakPlayerBall();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //if (player.GetComponent<Player>().movementDirectionInsideOfBall != Vector3.zero) player.GetComponent<Player>().transform.position += player.GetComponent<Player>().movementDirectionInsideOfBall * 0.1f;
            //if (player.GetComponent<Player>().movementDirectionOutOfBall != Vector3.zero) player.GetComponent<Player>().transform.position += player.GetComponent<Player>().movementDirectionOutOfBall * 0.1f;

            player.GetComponent<Player>().BreakPlayerBall();
        }
    }
}
