using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    GameObject spawnPosition;

    Animator animator;

    static public int currentScene;

    float hSpeed = 5, hBallSpeed, hRotationSpeed = 540, hBallRotationSpeed = 1080, amountOfAxes;

    public bool isInBall = false, isMoving = false, hasDied = false, startInBall, canMove, resetAnimatioansagnasTemp = true;

    public Vector3 movementDirectionOutOfBall, movementDirectionInsideOfBall, lastDirectionOutOfBall, lastDirectionInsideOfBall;


    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        spawnPosition = GameObject.FindGameObjectWithTag("SpawnPosition");
        animator = GetComponent<Animator>();
        ResetPlayer();
        //ResetLevel();   
        Scoring.UpdateScoreText(currentScene);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (resetAnimatioansagnasTemp)
        {
            //animator.Rebind();
            //animator.Update(0f);
            resetAnimatioansagnasTemp = false;
        }
        print(currentScene + " --- " + Scoring.scoresAllLevels[currentScene]);

        if (Input.GetKeyDown(KeyCode.X)) ResetLevel();
    }

    private void ResetPlayer()
    {
        transform.position = spawnPosition.transform.position;
        ResetMovement();
        ResetAnimation();
        if (startInBall) EnablePlayerBall();
        else if (!startInBall) BreakPlayerBall();
        canMove = true;
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene(currentScene);
        Scoring.ResetScore(currentScene);
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (canMove)
        {
            switch (isInBall)
            {

                case true:
                    if (movementDirectionInsideOfBall == Vector3.zero)
                    {
                        hBallSpeed = 0;
                        if (horizontalInput == 0) movementDirectionInsideOfBall = new Vector3(-verticalInput, 0, 0);
                        else if (horizontalInput > 0 || horizontalInput < 0) movementDirectionInsideOfBall = new Vector3(0, 0, horizontalInput);
                        else movementDirectionInsideOfBall = new Vector3(-verticalInput, 0, horizontalInput);
                        movementDirectionInsideOfBall.Normalize();
                        lastDirectionInsideOfBall = movementDirectionInsideOfBall;
                    }

                    if (movementDirectionInsideOfBall != Vector3.zero)
                    {
                        Quaternion toRotation = Quaternion.LookRotation(movementDirectionInsideOfBall, Vector3.up);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, hBallRotationSpeed * Time.deltaTime);
                        
                        isMoving = true;
                        animator.SetBool("isMoving", true);
                    }
                    else
                    {
                        isMoving = false;
                        animator.SetBool("isMoving", false);
                    }
                    transform.Translate(movementDirectionInsideOfBall * hBallSpeed * Time.deltaTime, Space.World);

                    break;

                case false:
                    movementDirectionOutOfBall = new Vector3(-verticalInput, 0, horizontalInput);
                    movementDirectionOutOfBall.Normalize();

                    if (movementDirectionOutOfBall != Vector3.zero)
                    {
                        Quaternion toRotation = Quaternion.LookRotation(movementDirectionOutOfBall, Vector3.up);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, hRotationSpeed * Time.deltaTime);
                        
                        isMoving = true;
                        animator.SetBool("isMoving", true);
                        lastDirectionOutOfBall = movementDirectionOutOfBall;
                    }
                    else
                    {
                        isMoving = false;
                        animator.SetBool("isMoving", false);
                    }
                    transform.Translate(movementDirectionOutOfBall * hSpeed * Time.deltaTime, Space.World);

                    break;
            }
        }
        if (Input.GetKey(KeyCode.Space) && transform.position.y < 3) gameObject.GetComponent<Rigidbody>().AddForce(0, 10, 0);
    }
    private void FixedUpdate()
    {
        hBallSpeed += 1;
        hBallSpeed *= 0.9f;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wall" || isInBall && other.gameObject.tag == "Pushable")
        {
            print("inside of wall (OnTriggerStay)");
            ResetMovement();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall" || isInBall && other.gameObject.tag == "Pushable")
        {
            ResetMovement();
            //canMove = true;
        }
    }

    public void EnablePlayerBall()
    {
        isInBall = true;
        animator.SetBool("isInBall", true);
        ResetMovement();
    }
    public void BreakPlayerBall()
    {
        isInBall = false;
        animator.SetBool("isInBall", false);
        ResetMovement();
    }

    public void ResetMovement()
    {
        movementDirectionInsideOfBall = Vector3.zero;
        movementDirectionOutOfBall = Vector3.zero;
    }

    void ResetAnimation()
    {
        animator.SetBool("hasDied", false);
        animator.SetBool("isMoving", false);
        animator.SetBool("isInBall", false);
        //animator.Rebind();
        //animator.Update(0f);
    }
    public void KillPlayer()
    {
        animator.SetBool("hasDied", true);
        canMove = false;
        Scoring.ResetScore(currentScene);
        StartCoroutine("Deathscreen");
    }

    IEnumerator Deathscreen()
    {
        yield return new WaitForSeconds(3);
        //ResetPlayer();
        //ResetLevel();
        GoToDeathscreen();
    }
    void GoToDeathscreen()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Deathscreen");
    }

    public void GoToNextLevel()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("BetweenLevels");
        Scoring.UpdateScoreText(currentScene);
    }


    public bool IsInBall
    {
        get { return isInBall; }
    }

    public float AmountOfAxes
    {
        get { return amountOfAxes; }
        set { amountOfAxes = value; }
    }
}
