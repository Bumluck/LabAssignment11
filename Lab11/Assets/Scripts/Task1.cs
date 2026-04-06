using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


public class Task1 : MonoBehaviour
{

    #region VARIABLES

    public bool toggleTask;

    public static string[] firstNames = {"Carol", "Adam", "Maria", "John", "Leia", "Andrew", "Toby", "Holly", "Stephanie",
        "Sze", "Corinne", "Miguel", "Kim", "Mitchell", "Andres", "Mark", "Sercan", "Nicholas", "Kenneth", "Banana", "Randy", "Brennan"};

    public static string[] lastNames = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    StringBuilder sb = new StringBuilder("");
    Queue<string> loginQueue;

    public int initialPlayers;

    public float addPlayerMinTime;
    public float addPlayerMaxTime;

    public float loginPlayerMinTime;
    public float loginPlayerMaxTime;

    public List<string> readableList;

    #endregion

    public string GetRandomPlayerName()
    {
        string playerName = "";

        sb.Clear();

        sb.Append(firstNames[Random.Range(0, firstNames.Length)] + " ");

        sb.Append(lastNames[Random.Range(0, lastNames.Length)] + ".");

        playerName = sb.ToString();

        sb.Clear();

        return playerName;
    }

    private void Start()
    {
        //toggleTask turns this task on and off for easier readability
        if (toggleTask)
        {
            loginQueue = new Queue<string>();

            for (int i = 0; i < initialPlayers; i++)
            {
                loginQueue.Enqueue(GetRandomPlayerName());
            }

            readableList = new List<string>(loginQueue);

            sb.Clear();

            foreach (string s in readableList)
            {
                sb.Append(s + ", ");
            }

            string initialList = sb.ToString();

            Debug.Log("Initial login queue created. There are " + initialPlayers + " players in the queue: " + initialList);

            InvokeRepeating("AddPlayer", Random.Range(addPlayerMinTime, addPlayerMaxTime), Random.Range(addPlayerMinTime, addPlayerMaxTime));
            InvokeRepeating("LoginPlayer", Random.Range(loginPlayerMinTime, loginPlayerMaxTime), Random.Range(loginPlayerMinTime, loginPlayerMaxTime));
        }
    }

    public void AddPlayer()
    {
        string newPlayer = GetRandomPlayerName();
        loginQueue.Enqueue(newPlayer);
        Debug.Log(newPlayer + " is trying to log in and added to the login queue.");
        readableList = new List<string>(loginQueue);
    }

    public void LoginPlayer()
    {
        if (loginQueue.Count() == 0)
        {
            Debug.Log("Login server is idle. No players are waiting.");
        } 
        else
        {
            string loggedInPlayer = loginQueue.Dequeue();
            Debug.Log(loggedInPlayer + " is now inside the game.");
            readableList = new List<string>(loginQueue);
        }
    }

}
