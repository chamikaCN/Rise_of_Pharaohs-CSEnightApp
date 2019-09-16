using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using TMPro;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class factionHandler : MonoBehaviour
{
    int GroupID;
    God myGod;
    public GameObject HorusModel, BastetModel, OsirisModel, AnubisModel, button;
    public Text topText, loadingText;
    public TextMeshProUGUI groupText;
    string fullText, loadingfullText, trackingStatus, imageTargetname, groupName;

    void Start()
    {
        fullText = "you belong to the followers of";
        loadingfullText = " 0 0 0 0 0 0";
        imageTargetname = "ImageTarget";
        GroupID = PlayerPrefs.GetInt("Group ID");
        GodManager.createGods();
        myGod = GodManager.getGodInfo(GroupID);
        allDeactive();
        activateFactions();
        button.gameObject.SetActive(false);
        StartCoroutine(showText(fullText, topText));
        trackingStatus = "TRACKED";
        StatusChanger();
    }

    void Update()
    {
        StatusChanger();
    }

    void allDeactive()
    {
        HorusModel.SetActive(false);
        BastetModel.SetActive(false);
        OsirisModel.SetActive(false);
        AnubisModel.SetActive(false);
    }

    void activateFactions()
    {
        switch (GroupID)
        {
            case 1:
                HorusModel.SetActive(true);
                break;
            case 2:
                BastetModel.SetActive(true);
                break;
            case 3:
                OsirisModel.SetActive(true);
                break;
            case 4:
                AnubisModel.SetActive(true);
                break;
        }
    }

    IEnumerator showText(string text, Text positionText)
    {
        for (int k = 0; k < text.Length; k++)
        {
            positionText.text = text.Substring(0, k + 1);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator showLoader()
    {
        while (trackingStatus == "NO_POSE")
        {
            for (int k = 0; k < loadingfullText.Length; k++)
            {
                loadingText.text = loadingfullText.Substring(0, k + 1);
                yield return new WaitForSeconds(0.2f);
            }
        }

    }

    private string isTrackingMarker(string imageTargetName)
    {
        var imageTarget = GameObject.Find(imageTargetName);
        var trackable = imageTarget.GetComponent<TrackableBehaviour>();
        var status = trackable.CurrentStatus;
        return status.ToString();
    }

    void StatusChanger()
    {
        if (trackingStatus != isTrackingMarker(imageTargetname))
        {
            trackingStatus = isTrackingMarker(imageTargetname);
            changeLoadingText();
        }
    }

    void changeLoadingText()
    {
        if (trackingStatus == "NO_POSE")
        {
            loadingText.gameObject.SetActive(true);
            groupText.gameObject.SetActive(false);
            StartCoroutine(showLoader());
        }
        else
        {
            loadingText.gameObject.SetActive(false);
            groupText.text = myGod.GodName.ToUpper();
            groupText.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
        }
    }

    public void proceedNext()
    {
        SceneManager.LoadScene("InfoPart");
    }

}
