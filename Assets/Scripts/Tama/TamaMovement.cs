using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaMovement : MonoBehaviour
{
    [SerializeField] private float _moveY, _moveX;
    [SerializeField] private Vector2 _newPosition;
    [SerializeField] private float _timeTillMove;
    [SerializeField] private float _moveTimer = 0;
    [SerializeField] private float moveSpeed = 5.0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        RandomTimeToMove();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Moves to the next point
        MoveToPoint();
        
        //Waits for the time to move to be reached, at which point selects a new point to move to and a new timer.
        if (Vector2.Distance(rb.position, _newPosition) < 0.2f)
        {
            if (_moveTimer < _timeTillMove)
            {
                _moveTimer += Time.deltaTime;
            }
            if (_moveTimer >= _timeTillMove)
            {
                NewPointOnScreen();
                RandomTimeToMove();
            }
        }
       
    }

    // Finds a random point to move to next
    private void NewPointOnScreen()
    {
        //_moveY = Random.Range
        //    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        //_moveX = Random.Range
        //    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        _moveY = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y + 2, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y - 2);
        _moveX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + 2, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - 2);

        _newPosition = new Vector2(_moveX, _moveY);



    }

    // Finds random time between movements and resets the timer
    private void RandomTimeToMove()
    {
        _timeTillMove = Random.Range(1 , 1);
        _moveTimer = 0;
    }

    //Moves the position to the new point
    private void MoveToPoint()
    {
        rb.position = Vector2.MoveTowards(rb.position, _newPosition, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Border"))
        {
            NewPointOnScreen();
            MoveToPoint();
        }
    }


}
