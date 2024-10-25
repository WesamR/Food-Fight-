using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersManager : MonoBehaviour
{
    //public GameObject healthSystem;  // Reference to the player prefab
    private List<GameObject> players = new List<GameObject>();  // List to store player instances
    // we want to keep track of score of each controller
    private Dictionary<int, int> playersFedCount = new Dictionary<int, int>();

    private void OnEnable()
    {
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
    }

    private void OnDisable()
    {
        PlayerInputManager.instance.onPlayerJoined -= OnPlayerJoined;
    }


    private void OnPlayerJoined(PlayerInput playerInput)
    {
        AddPlayer(playerInput.gameObject);

        int inputId = playerInput.devices[0].deviceId;

        // when mouse and keyboard is connected, there will be two input devices
        // we will keep the ID for the keyboard
        if (playerInput.devices.Count == 2)
        {
            inputId = 1;
        }

        if (!playersFedCount.ContainsKey(inputId))
        {
            playersFedCount.Add(inputId, 0);
            Debug.Log("Player joined with input id: " + inputId);
        }
    }

    void AddPlayer(GameObject newPlayer)
    {
        //GameObject newPlayer = Instantiate(healthSystem, new Vector3(0, 0, 0), Quaternion.identity);
        players.Add(newPlayer);
        //Debug.Log("Player joined");
    }

    void OnPlayerFed(GameObject player)
    {
        // increase the fed count of the player
        int inputId = player.GetComponent<PlayerInput>().devices[0].deviceId;
        if (player.GetComponent<PlayerInput>().devices.Count == 2)
        {
            inputId = 1;
        }
        playersFedCount[inputId]++;
        //Debug.Log("Player " + inputId + " fed: " + playersFedCount[inputId]);
        players.Remove(player);
        Destroy(player);  // Optionally destroy the player object
    }

    /// <summary>
    /// Check the score of each player and update the store
    /// The one with the lowest score will be the leader
    /// The player with the lowest score will have its DisplayLeader.isLeader set to true
    /// while others will have it set to false
    /// </summary>
    void UpdateScore()
    {
        //int minScore = int.MaxValue;
        //int leaderInputId = -1;
        //foreach (var player in playersFedCount)
        //{
        //    if (player.Value < minScore)
        //    {
        //        minScore = player.Value;
        //        leaderInputId = player.Key;
        //    }
        //}
        // use dictionary's method to find the key with the minimum value
        // if there are two players with the same score, set to -1
        int leaderInputId = playersFedCount.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;

        if (leaderInputId == -1)
        {
            // no leader
            // set all to false
            foreach (var player in players)
            {
                player.GetComponent<DisplayLeader>().IsLeader(false);
            }
        }
        else
        {
            foreach (var player in players)
            {
                if (player.GetComponent<PlayerInput>().devices[0].deviceId == leaderInputId)
                {
                    player.GetComponent<DisplayLeader>().IsLeader(true);
                }
                else
                {
                    player.GetComponent<DisplayLeader>().IsLeader(false);
                }
            }
        }
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
            UpdateScore();
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
