using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IndexHandler : MonoBehaviour
{
    public InputField indexInput;
    public Button submitButton;
    public GameObject revealPanel,factionButton, infoButton;
    public Text messagetext, infotext;
    public int primeDivider;
    int indexNumber;
    int groupID;

    private void Start()
    {
        //PlayerPrefs.SetInt("Initial", 0);
        revealPanel.SetActive(false);
        if (PlayerPrefs.GetInt("Initial") == 0)
        {
            factionButton.SetActive(false);
            infoButton.SetActive(false);
        }
        else
        {
            factionButton.SetActive(true);
            infoButton.SetActive(true);
        }
    }
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void loadFaction()
    {
        SceneManager.LoadScene("ChoosingPart");
    }

    public void openPanel()
    {
        revealPanel.SetActive(true);
        infotext.text = "on 29th october\n@ night\nin the " + PlayerPrefs.GetString("Gatherplace");
    }

    public void closePanel()
    {
        revealPanel.SetActive(false);
    }



    public void Submit()
    {
        primeDivider = 13;
        string indexer = indexInput.text;

        if(indexer.Length == 6)
        {
            //string processedindexer = indexer.Substring(0, 10);
            indexNumber = int.Parse(indexer);
            calculateGroup(indexNumber);
            if (groupID == 1 | groupID == 2 | groupID == 3 | groupID == 4)
            {
                PlayerPrefs.SetInt("Group ID", groupID);
                PlayerPrefs.SetInt("Initial", 1);
                SceneManager.LoadScene("ARpart");
            }
            else
            {
                messagetext.text = "invalid index";
                StartCoroutine(textClearer());
            }
        }
        else
        {
            messagetext.text = "index should include 6 digits";
            StartCoroutine(textClearer());
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
        }
        
    }

    IEnumerator textClearer()
    {
        yield return new WaitForSeconds(2f);
        messagetext.text = "";
    }

    
}
