using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    public InGameManager gameManager;

    //Movement
    public float forwardSpeed = 25f;
    private float initialSpeed;
    public float strafeSpeed = 7.5f;
    public float hoverSpeed = 5f;

    private float activeForwardSpeed;
    private float activeStrafeSpeed;
    private float activeHoverSpeed;

    private float forwardAcceleration = 2.5f;
    private float strafeAcceleration = 2f;
    private float hoverAcceleration = 2f;

    //Rotation
    public float lookRotateSpeed = 90f;

    private Vector2 lookInput;
    private Vector2 screenCenter;
    private Vector2 mouseDistance;

    //Keep rolling rolling what? Keep rolling rolling come on!
    public float rollSpeed = 90f;
    public float rollAcceleration = 3.5f;

    private float rollInput;

    //Colors of boosters
    public GameObject boosterRedLeft;
    public GameObject boosterRedRight;
    public GameObject boosterBlueLeft;
    public GameObject boosterBlueRight;

    private float boostTimer;
    private bool isBoost;
    private bool isSpin;
    private float spinTimer;

    void Start()
    {
        //Is here just incase.
        boosterRedLeft.SetActive(true);
        boosterRedRight.SetActive(true);
        boosterBlueLeft.SetActive(false);
        boosterBlueRight.SetActive(false);

        FindObjectOfType<AudioManager>().PlayTrackAtIndex(0);
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;

        Cursor.lockState = CursorLockMode.Confined;
        initialSpeed = forwardSpeed;
    }

    void Update()
    {
        //Mouse rotation
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRotateSpeed * Time.deltaTime, mouseDistance.x * lookRotateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        //Movement with acceleration for good feeling
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += transform.right * activeStrafeSpeed * Time.deltaTime;
        transform.position += transform.up * activeHoverSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            FindObjectOfType<AudioManager>().VolumnUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            FindObjectOfType<AudioManager>().VolumnDown();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            FindObjectOfType<AudioManager>().PlayPrevious();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            FindObjectOfType<AudioManager>().PlayNext();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.EndGame();
        }

        if (isBoost)
        {
            if(boostTimer > 0)
            {
                boostTimer -= Time.deltaTime;
                boosterRedLeft.SetActive(false);
                boosterRedRight.SetActive(false);
                boosterBlueLeft.SetActive(true);
                boosterBlueRight.SetActive(true);
            }
            else
            {
                isBoost = false;
                forwardSpeed = initialSpeed;
                boosterRedLeft.SetActive(true);
                boosterRedRight.SetActive(true);
                boosterBlueLeft.SetActive(false);
                boosterBlueRight.SetActive(false);
            }
        }

        if (isSpin)
        {
            if (spinTimer > 0)
            {
                spinTimer -= Time.deltaTime;
                this.transform.Rotate(180 * Time.deltaTime, 0, 0, Space.Self);
            }
            else
            {
                isSpin = false;
            }
            
        }

    }

    public void boost()
    {
        forwardSpeed *= 1.5f;
        boostTimer += 5;
        if(boostTimer > 15)
        {
            boostTimer = 15;
        }
        isBoost = true;
    }

    public void spin()
    {
        spinTimer = 2;
        isSpin = true;
    }
   
}
