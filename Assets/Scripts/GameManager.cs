using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersManager : MonoBehaviour
{
    public GameObject healthSystem;  // Reference to the player prefab
    private List<GameObject> players = new List<GameObject>();  // List to store player instances

    private void OnPlayerJoined(PlayerInput playerInput)
    {
        AddPlayer(playerInput.gameObject);
    }

    void AddPlayer(GameObject newPlayer)
    {
        //GameObject newPlayer = Instantiate(healthSystem, new Vector3(0, 0, 0), Quaternion.identity);
        players.Add(newPlayer);
        Debug.Log("Player joined");
    }

    void OnPlayerFed(GameObject player)
    {
        players.Remove(player);
        Destroy(player);  // Optionally destroy the player object
    }

    void Update()
    {
        // Example usage: Check for incapacitated players
        for (int i = players.Count - 1; i >= 0; i--)
        {
            if (players[i].GetComponent<HealthSystem>().IsDead)
            {
                OnPlayerFed(players[i]);
            }
        }
    }
    //// Array to store player input information
    //public PlayerInput[] players;

    //void Update()
    //{
    //    foreach (PlayerInput player in players)
    //    {
    //        HandlePlayerInput(player);
    //    }
    //}

    //void HandlePlayerInput(PlayerInput player)
    //{
    //    float horizontal = Input.GetAxis("Horizontal" + player.playerNumber);
    //    float vertical = Input.GetAxis("Vertical" + player.playerNumber);

    //    // Move player
    //    player.transform.Translate(Vector3.right * horizontal * Time.deltaTime);
    //    player.transform.Translate(Vector3.forward * vertical * Time.deltaTime);

    //    // Jump action
    //    if (Input.GetButtonDown("Jump" + player.playerNumber))
    //    {
    //        player.Jump();
    //    }
    //}

    //// PlayerInput class to manage player-specific inputs
    //public class PlayerInput
    //{
    //    public int playerNumber;
    //    public Transform transform;

    //    public void Jump()
    //    {
    //        // Implement jumping logic here
    //        Debug.Log("Player " + playerNumber + " jumped");
    //    }
    //}
}
