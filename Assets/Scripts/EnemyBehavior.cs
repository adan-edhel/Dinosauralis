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

    [SerializeField] private float movementSpeed = .05f;

    [SerializeField] private Vector2 directionIntervalRange = new Vector2(3, 5);
    private float directionInterval;
    private float directionCounter;

    void Start()
    {
        ChangeDirection();
    }

    void Update()
    {
        Movement();

        directionCounter += Time.deltaTime;
        if (directionCounter > directionInterval)
        {
            ChangeDirection();
            directionCounter = 0;
        }
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
                gameObject.transform.Translate(Vector3.up * movementSpeed);
                break;
            case Directions.Down:
                gameObject.transform.Translate(Vector3.down * movementSpeed);
                break;
            case Directions.Left:
                gameObject.transform.Translate(Vector3.left * movementSpeed);
                GetComponent<SpriteRenderer>().flipX = false;
                break;
            case Directions.Right:
                gameObject.transform.Translate(Vector3.right * movementSpeed);
                GetComponent<SpriteRenderer>().flipX = true;
                break;
            default:
                break;
        }
    }
}
