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
    public GameObject HorusModel, BastetModel, OsirisModel, AnubisModel, button, IndexObject;
    public TextMeshProUGUI groupText, topText, loadingText;
    string fullText, loadingfullText, trackingStatus, imageTargetname, groupName;
    public AudioClip egypt1, egypt2;
    AudioSource source;

    void Start()
    {
        source = this.GetComponent<AudioSource>();
        source.clip = egypt1;
        source.Play();
        fullText = "you belong to the followers of";
        loadingfullText = " 0 0 0 0 0";
        imageTargetname = "ImageTarget";
        GroupID = GameManager.getGroupID();
        if (GroupID > 0)
        {
            myGod = GameManager.getGodInfo(GroupID);
        }
        IndexObject.SetActive(true);
        IndexObject.GetComponentInChildren<TextMeshProUGUI>().text = "Chamika Nandasiri\n" + GameManager.getIndexNo();
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("IndexPart");
        }
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

    IEnumerator showText(string text, TextMeshProUGUI positionText)
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
            source.clip = egypt1;
            source.Play();
            StartCoroutine(showLoader());
        }
        else
        {
            loadingText.gameObject.SetActive(false);
            source.clip = egypt2;
            source.Play();
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
