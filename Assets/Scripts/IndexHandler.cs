using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IndexHandler : MonoBehaviour
{
    public InputField indexInput;
    public Button submitButton;
    public int primeDivider;
    int indexNumber;
    int groupID;

    public void Submit()
    {
        primeDivider = 13;
        string indexer = indexInput.text;
        if(indexer.Length == 6)
        {
            indexNumber = int.Parse(indexer);
            calculateGroup(indexNumber);
            if (groupID == 1 | groupID == 2 | groupID == 3 | groupID == 4)
            {
                PlayerPrefs.SetInt("Group ID", groupID);
                SceneManager.LoadScene("ARpart");
            }
            else
            {
                Debug.LogError("invalid index");
            }
        }
        else
        {
            Debug.LogError("index should include 6 digits");
        }
    }

    void calculateGroup(int index)
    {
        switch (index % primeDivider)
        {
            case 2:
                groupID = 1;
                Debug.Log("you are in team 1");
                break;
            case 5:
                groupID = 2;
                Debug.Log("you are in team 2");
                break;
            case 8:
                groupID = 3;
                Debug.Log("you are in team 3");
                break;
            case 11:
                groupID = 4;
                Debug.Log("you are in team 4");
                break;
            default:
                Debug.Log("invalid pass code");
                break;
        }
    }

    
}
