using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    enum Directions
    {
        Up,
        Down,
        Left,
        Right
    }

    private Directions direction = Directions.Up;

    [SerializeField] private float movementSpeed = 3f;
    private float speedMofidier = 100;

    [SerializeField] private Vector2 directionIntervalRange = new Vector2(3, 5);
    private float directionInterval;
    private float directionCounter;

    void Start()
    {
        ChangeDirection();
    }

    void Update()
    {
        directionCounter += Time.deltaTime;
        if (directionCounter > directionInterval)
        {
            ChangeDirection();
            directionCounter = 0;
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void ChangeDirection()
    {
        int currentDir = (int)direction;
        int chosenDir = Random.Range(0, 4);

        directionInterval = Random.Range(directionIntervalRange.x,directionIntervalRange.y);
        while (chosenDir == currentDir)
        {
            chosenDir = Random.Range(0, 4);
        }
        direction = (Directions)chosenDir;
    }

    private void Movement()
    {
        switch (direction)
        {
            case Directions.Up:
                gameObject.transform.Translate(Vector3.up * movementSpeed / speedMofidier);
                break;
            case Directions.Down:
                gameObject.transform.Translate(Vector3.down * movementSpeed / speedMofidier);
                break;
            case Directions.Left:
                gameObject.transform.Translate(Vector3.left * movementSpeed / speedMofidier);
                GetComponent<SpriteRenderer>().flipX = true;
                break;
            case Directions.Right:
                gameObject.transform.Translate(Vector3.right * movementSpeed / speedMofidier);
                GetComponent<SpriteRenderer>().flipX = false;
                break;
            default:
                break;
        }
    }
}
