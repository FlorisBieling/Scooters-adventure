using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    MeshRenderer meshRenderer;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().IsInBall) meshRenderer.enabled = true;
        else if (!player.GetComponent<Player>().IsInBall) meshRenderer.enabled = false;
    }
}
