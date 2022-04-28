using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    GameObject player;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().IsInBall)
            rigidbody.mass = 10000;
        else rigidbody.mass = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !player.GetComponent<Player>().IsInBall)
        {
            print("woop");
            Vector3 directionToPlayer = new Vector3(transform.position.x - player.transform.position.x, 0, transform.position.y - player.transform.position.y);
            transform.Translate(directionToPlayer.normalized/100, Space.World);
        }
        if (other.gameObject.tag == "Water")
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !player.GetComponent<Player>().IsInBall)
        {
            print("woop");
            Vector3 directionToPlayer = new Vector3(transform.position.x - player.transform.position.x, 0, transform.position.y - player.transform.position.y);
            transform.Translate(directionToPlayer.normalized / 100, Space.World);
        }
    }
}
