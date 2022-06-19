using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    GameObject player;

    public GameObject splash;

    public GameObject parent;

    public Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.Rotate(transform.rotation.x, transform.rotation.y + 1, transform.rotation.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!player.GetComponent<Player>().IsInBall)
            {
                HitPickUpNotInBall();
            }
            else if (player.GetComponent<Player>().IsInBall)
            {
                HitPickUpInBall();
            }
        }
    }
    void HitPickUpNotInBall()
    {
        DestroyMyself();
        Scoring.IncreaseScore(100, this.transform.position, Player.currentScene);
    }

    void HitPickUpInBall()
    {
        DestroyMyself();
        Instantiate(splash, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));
    }

    void DestroyMyself()
    {
        collider.enabled = false;
        gameObject.SetActive(false);
    }
}
