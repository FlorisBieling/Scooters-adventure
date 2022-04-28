using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTree : MonoBehaviour
{
    public GameObject player;

    public MeshRenderer meshRenderer;

    public BoxCollider treeCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        treeCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("ingo is een tering dikkie");
        if (other.gameObject.tag == "Player" && player.GetComponent<Player>().AmountOfAxes > 0)
        {
            RemoveTree();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        print("ingo is een tering dikkie");
        if (other.gameObject.tag == "Player" && player.GetComponent<Player>().AmountOfAxes > 0)
        {
            RemoveTree();
        }
    }
    public void RemoveTree()
    {
        player.GetComponent<Player>().AmountOfAxes--;
        meshRenderer.enabled = false;
        treeCollider.enabled = false;
    }
}
