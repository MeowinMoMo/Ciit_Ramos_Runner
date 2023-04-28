using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlay : MonoBehaviour
{
    [SerializeField] GameObject Player;
     public float moveSpeed = 5f; // The speed at which the player moves
    public Transform[] waypoints; // An array of transforms representing the spaces on the board
    private int currentPosition = 0; // The player's current position on the board
    public static MovingPlay instance;

    public void Move(int diceRoll)
    {
        int newPosition = currentPosition + diceRoll; // Calculate the new position based on the dice roll
        if (newPosition >= waypoints.Length) // If the new position is greater than or equal to the number of spaces on the board
        {
            newPosition -= waypoints.Length; // Wrap around to the start of the board
        }

        // Move the player to the new position
        transform.position = Vector3.MoveTowards(transform.position, waypoints[newPosition].position, moveSpeed * Time.deltaTime);
        currentPosition = newPosition; // Update the player's current position
    }

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        /*waypoints = GameObject.FindGameObjectsWithTag("WayPoints");*/
    }

    public void MovePlayerFromDiceNumber(int Number)
    {
        Debug.Log("Is now Processing");
        for (int i = 0; i < Number; i++)
        {
            if (i < Number)
            {
                StartCoroutine(MovePlayerOneSlabToAnother(Number));
            }
        }
    }

    IEnumerator MovePlayerOneSlabToAnother(int number)
    {
        Vector3 destination = waypoints[number].transform.position;
        while (Vector3.Distance(Player.transform.position, destination) > 0.1f)
        {
            Player.transform.position = Vector3.Lerp(Player.transform.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
