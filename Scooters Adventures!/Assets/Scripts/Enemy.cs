using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    
    GameObject player;

    public Collider tiggerBox;

    public Collider collider;

    public bool hitPlayer = false, hasDied = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
            if (!player.GetComponent<Player>().IsInBall)
            {
                HitEnemyNotInBall();
                hitPlayer = true;
                animator.SetBool("hitPlayer", true);
            }
            else if (player.GetComponent<Player>().IsInBall)
            {
                HitEnemyInBall();
                hasDied = true;
                animator.SetBool("hasDied", true);
            }
        }
        else if(other.gameObject.tag == "Pushable")
        {
            other.gameObject.GetComponent<Pushable>().BreakPushable();
            StartCoroutine("HitAnimation");
        }
    }
    IEnumerator DestroyMyself()
    {
        collider.enabled = false;
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
    IEnumerator HitAnimation()
    {
        animator.SetBool("hitPlayer", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("hitPlayer", false);
    }

    public void LookAtPlayer()
    {
        transform.LookAt(player.transform.position);
    }

    void HitEnemyNotInBall()
    {
        print("hit enemy without ball, i die now");
        player.GetComponent<Player>().KillPlayer();
    }
    
    void HitEnemyInBall()
    {
        print("kill that son of a bitch roll over his head");
        StartCoroutine("DestroyMyself");
        Scoring.IncreaseScore(100, this.transform.position, Player.currentScene);
    }

}
