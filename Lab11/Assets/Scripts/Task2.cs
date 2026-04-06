using UnityEngine;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public class Task2 : MonoBehaviour
{

    #region VARIABLES

    public bool toggleTask;

    public static string[] firstNames = {"Carol", "Adam", "Maria", "John", "Leia", "Andrew", "Toby", "Holly", "Stephanie",
        "Sze", "Corinne", "Miguel", "Kim", "Mitchell", "Andres", "Mark", "Sercan", "Nicholas", "Kenneth", "Banana", "Randy", "Brennan"};

    string[] nameArray;

    StringBuilder sb = new StringBuilder();

    public int initialNames;

    HashSet<string> seen = new HashSet<string>();
    HashSet<string> duplicates = new HashSet<string>();

    #endregion

    void Start()
    {
        if (toggleTask)
        {
            nameArray = new string[initialNames];

            for (int i = 0; i < initialNames; i++)
            {
                nameArray[i] = firstNames[Random.Range(0, firstNames.Length)];
            }

            foreach (string s in nameArray)
            {
                sb.Append(s + ", ");
            }

            string initialArray = sb.ToString();

            Debug.Log("Created the name array: " + initialArray);

            foreach (string s in nameArray)
            {
                bool boolean = seen.Add(s);
                if (!boolean)
                {
                    duplicates.Add(s);
                }
            }

            if (duplicates.Count == 0)
            {
                Debug.Log("The array has no duplicate names.");
            } 
            else
            {
                string duplicateNames = string.Join(", ", duplicates) + ".";
                Debug.Log("The array has duplicate names: " + duplicateNames);
            }

        }
    }

}
