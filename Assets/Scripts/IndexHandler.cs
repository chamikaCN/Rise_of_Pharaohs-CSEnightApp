﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using TMPro;

public class IndexHandler : MonoBehaviour
{
    public InputField indexInput;
    public Button submitButton;
    public GameObject revealPanel,factionPanel,factionButton, infoButton, welcomePanel,IndexObject;
    public TextMeshProUGUI facName, facDes, welcomeText;
    public TextMeshProUGUI infotext;
    public Text messagetext;
    public int primeDivider;
    public Sprite Anubis, Osiris, Bastet, Horus;
    Sprite godSprite;
    public Image godsprite;
    string indexNumber, welcomePhrase;
    AudioSource typing,Egypt;
    int GroupID;
    God myGod;
 
    private void Start()
    {
        GameManager.sendTesting();
        welcomePhrase = "when the sun sets over the nile, mummies start to roam the land of the pyramids \n.......";
        Egypt = this.GetComponent<AudioSource>();
        if (!GameManager.getIsCompleted())
        {
            GameManager.ReceiveSavedData();
            welcomePanel.SetActive(true);
            typing = welcomePanel.GetComponent<AudioSource>();
            StartCoroutine(showText(welcomePhrase, welcomeText, typing));
        }
        else
        {
            Egypt.Play();
        }
        GroupID = GameManager.getGroupID();
        GameManager.createGods();
        if (GroupID > 0)
        {
            myGod = GameManager.getGodInfo(GroupID);
        }
        revealPanel.SetActive(false);
        factionPanel.SetActive(false);
        
        if (GameManager.getInitial() == 0)
        {
            factionButton.SetActive(false);
            infoButton.SetActive(false);
            IndexObject.SetActive(false);
        }
        else
        {
            factionButton.SetActive(true);
            infoButton.SetActive(true);
            IndexObject.SetActive(true);
            IndexObject.GetComponentInChildren<TextMeshProUGUI>() .text = GameManager.getName(int.Parse(GameManager.getIndexNo())) + "\n" + GameManager.getIndexNo();
            switch (GroupID)
            {
                case 1:
                    godSprite = Horus;
                    break;
                case 2:
                    godSprite = Bastet;
                    break;
                case 3:
                    godSprite = Osiris;
                    break;
                case 4:
                    godSprite = Anubis;
                    break;
            }
        }
    }
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void openPanel()
    {
        revealPanel.SetActive(true);
        infotext.text = "on 29th october\n@ night\nin the " + myGod.GodVenue;
    }

    public void closePanel()
    {
        revealPanel.SetActive(false);
    }

    public void openfacPanel()
    {
        factionPanel.SetActive(true);
        facName.text = myGod.GodName.ToUpper();
        facDes.text = myGod.GodDescription;
        godsprite.sprite = godSprite;
    }

    public void closefacPanel()
    {
        factionPanel.SetActive(false);
    }


    public void Submit()
    {
        primeDivider = 99929;
        string indexer = indexInput.text;

        if(indexer.Length == 15)
        {
            string groupidentification = indexer.Substring(0, 9);
            string indexidentification = indexer.Substring(9, 6);
            calculateGroup(int.Parse(groupidentification));
            calculateIndex(indexidentification);

            if (GroupID == 1 | GroupID == 2 | GroupID == 3 | GroupID == 4)
            {
                GameManager.setGroupID(GroupID);
                GameManager.setIndexNo(indexNumber);
                GameManager.setComplete();
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
            messagetext.text = "index should include 15 digits";
            StartCoroutine(textClearer());
        }
    }

    void calculateGroup(int index)
    {
        switch (index % primeDivider)
        {
            case 11045:
                GroupID = 1;
                break;
            case 47219:
                GroupID = 2;
                break;
            case 30581:
                GroupID = 3;
                break;
            case 68385:
                GroupID = 4;
                break;
            default:
                GroupID = 0;
                break;
        }
        
    }

    void calculateIndex(string indexString)
    {
        string lastnumbers = "";
        for(int i = 0; i < 5; i = i + 2)
        {
            int num = int.Parse(indexString[i].ToString());
            if (num == 0)
            {
                lastnumbers += "9";
            }
            else
            {
                lastnumbers += (num - 1);
            }
        }

        indexNumber = "180" + lastnumbers;
        
    }

    IEnumerator textClearer()
    {
        yield return new WaitForSeconds(2f);
        messagetext.text = "";
    }

    IEnumerator welcomePanelDisable()
    {
        yield return new WaitForSecondsRealtime(3f);
        welcomePanel.SetActive(false);
        
        Egypt.Play();
    }

    IEnumerator showText(string text, TextMeshProUGUI positionText, AudioSource sound)
    {
        sound.Play();
        for (int k = 0; k < text.Length; k++)
        {
            positionText.text = text.Substring(0, k + 1);
            yield return new WaitForSeconds(0.2f);
        }
        sound.Stop();
        StartCoroutine(welcomePanelDisable());
    }
}
