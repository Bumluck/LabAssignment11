using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


public class Task1 : MonoBehaviour
{

    #region VARIABLES

    public static string[] firstNames = {"Carol", "Adam", "Maria", "John", "Leia", "Andrew", "Toby", "Holly", "Stephanie",
        "Sze", "Corinne", "Miguel", "Kim", "Mitchell", "Andres", "Mark", "Sercan", "Nicholas", "Kenneth", "Banana", "Randy", "Brennan"};

    public static string[] lastNames = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    StringBuilder sb = new StringBuilder("");

    #endregion

    public string GetRandomPlayerName()
    {
        string playerName = "";

        sb.Append(firstNames[Random.Range(0, firstNames.Length)] + " ");

        sb.Append(lastNames[Random.Range(0, lastNames.Length)]);

        playerName = sb.ToString();

        return playerName;
    }

}
