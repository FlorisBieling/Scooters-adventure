using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public Enemy enemy;

    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !enemy.GetComponent<Enemy>().hasDied)
        {
            enemy.GetComponent<Enemy>().LookAtPlayer();

        }

    }
}
