using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class Lathe : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Player2;
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;
    public float ForceZ = 0.35f;
    public float ForceX = 0.2f;
    public float ForceBock = 0.15f;
    public float minX = -5f;
    public float maxX = 5f;
    public float minZ = -5f;
    public float maxZ = 5f;
    public float bockMinZ = 3.82f;
    public float bocMaxZ = 4.46f;

    private bool _isMoveRight = false, _isBockMoveRight = false, _isBockMoveLeft = false, _isMoveLeft = false, _isMoveXplus = false, _isMoveXminus = false;
    Animator spindleAnimator;
    public void Start()
    {
        spindleAnimator = GameObject.Find("SpindleCodeHolder").GetComponent<Animator>();
        //spindleAnimator.SetBool("SpindleRotate", true);
        
    }
    public UnityEvent onPressed, onReleased, myEvent;
    // Update is called once per frame
    public void Update()
    {
       
        if (_isMoveRight)
        {

            float movementZ = ForceZ * Time.deltaTime;

            // Calculate the desired new position
            Vector3 newPosition = Player.transform.position + new Vector3(0f, 0f, movementZ);

            // Clamp the position within the specified range

            newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

            // Apply the clamped position
            Player.transform.position = newPosition;
            //onPressed.Invoke();
            rotate._shouldRotate = 1;
            
            //Debug.Log(newPosition.z);

            if (newPosition.z == maxZ)
            {
                //Debug.Log("Working");
                //onPressed.Invoke();
                rotate._shouldRotate = 0;
            }



        }
        else if (_isMoveLeft)
        {

            float movementZ = ForceZ * Time.deltaTime;

            // Calculate the desired new position
            Vector3 newPosition = Player.transform.position - new Vector3(0f, 0f, movementZ);

            // Clamp the position within the specified range

            newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

            // Apply the clamped position
            Player.transform.position = newPosition;
            rotate._shouldRotate = -1;
            if (newPosition.z == minZ)
            {
                //Debug.Log("Working");
                //onPressed.Invoke();
                rotate._shouldRotate = 0;
            }

        }
        if (_isMoveXplus)
        {
            float movementX = ForceX * Time.deltaTime;


            // Calculate the desired new position
            Vector3 newPosition = Player.transform.position + new Vector3(movementX, 0f, 0f);

            // Clamp the position within the specified range
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            // Apply the clamped position
            Player.transform.position = newPosition;
        }
        if (_isMoveXminus)
        {
            float movementX = ForceX * Time.deltaTime;


            // Calculate the desired new position
            Vector3 newPosition = Player.transform.position - new Vector3(movementX, 0f, 0f);

            // Clamp the position within the specified range
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);


            // Apply the clamped position
            Player.transform.position = newPosition;
        }
        if (_isBockMoveRight)
        {

            float movementZ = ForceBock * Time.deltaTime;

            // Calculate the desired new position
            Vector3 newPosition = Player.transform.position + new Vector3(0f, 0f, movementZ);

            // Clamp the position within the specified range

            newPosition.z = Mathf.Clamp(newPosition.z, bockMinZ, bocMaxZ);

            // Apply the clamped position
            Player.transform.position = newPosition;
            
        }

        if (_isBockMoveLeft)
        {

            float movementZ = ForceBock * Time.deltaTime;

            // Calculate the desired new position
            Vector3 newPosition = Player.transform.position - new Vector3(0f, 0f, movementZ);

            // Clamp the position within the specified range

            newPosition.z = Mathf.Clamp(newPosition.z, bockMinZ, bocMaxZ);

            // Apply the clamped position
            Player.transform.position = newPosition;


        }
    }

    public void EmergencyStop()
    {
        spindleAnimator.SetBool("SpindleRotate", false);
        _isMoveLeft = false;
        _isMoveRight = false;
        _isMoveXminus = false;
        _isMoveXplus = false;
        _isBockMoveLeft = false;
        _isBockMoveRight = false;
    }
    public void SpindleRotateForward()

    {
        spindleAnimator.SetBool("SpindleRotate", true);
    }

    public void SpindleRotateStop()

    {
        spindleAnimator.SetBool("SpindleRotate", false);
    }
    

    public void MoveRight()

    {
        _isMoveLeft = false;
        _isMoveRight = !_isMoveRight;
    }
    public void MoveLeft()

    {
        _isMoveRight = false;
        _isMoveLeft = !_isMoveLeft;
    }
    public void MoveXplus()

    {
        _isMoveXminus = false;
        _isMoveXplus = !_isMoveXplus;
    }
    public void MoveXminus()

    {
        _isMoveXplus = false;
        _isMoveXminus = !_isMoveXminus;
    }

    public void BockMoveRight()

    {
        _isBockMoveLeft = false;
        _isBockMoveRight = !_isBockMoveRight;
    }
    public void BockMoveLeft()

    {
        _isBockMoveRight = false;
        _isBockMoveLeft = !_isBockMoveLeft;
    }


}