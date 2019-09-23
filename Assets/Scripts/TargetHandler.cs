using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text;

public class TargetHandler : MonoBehaviour
{
    int GroupID,artifacts;
    public Text artifactText;
    public GameObject progressPanel, welcomePanel;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI welcomeText;
    string welcomePhrase,startString,finalString;
    //int[] integerSet;
    //ArrayList intSet;

    void Start()
    {
        welcomePanel.SetActive(true);
        welcomePhrase = "when the stars begin to shine, pharaohs rise from the underworld\n....... ";
        StartCoroutine(showText(welcomePhrase,welcomeText));
        GroupID = PlayerPrefs.GetInt("Group ID");
        artifacts = 0;
        artifactText.text = "ARTIFACTS   0";
        progressPanel.SetActive(false);
        startString = "____ __ ________";
        finalString = "RISE OF PHARAOHS";
        NameText.text = startString;
        //integerSet = new int[13];
        //intSet = new ArrayList();
        //AssignInts();
        //Debug.Log(intSet.ToString());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,1<<8))
            {
                if(hit.collider.name == "Pharaoh")
                {
                    Destroy(hit.collider.gameObject);
                    collectArtifact();
                }
            }
        }

        if (artifacts >= 8)
        {
            StartCoroutine(progressPanelEnable());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("IndexPart");
        }
    }

    public void collectArtifact()
    {
        letterReveal(2*artifacts);
        letterReveal((2*artifacts)+1);
        artifacts += 1;
        artifactText.text = "ARTIFACTS   " + artifacts;
    }

    void letterReveal(int interger){
        //int rand = newRandomInt();
        StringBuilder sb = new StringBuilder(startString);
        sb[interger] = finalString[interger];
        startString = sb.ToString();
        NameText.text = startString;
    }

    /*void AssignInts(){
        while(intSet.Count == 13){
            int randomInt = Mathf.RoundToInt(Random.Range(-0.45f, 12.45f));
            if(!(intSet.Contains(randomInt))){
                intSet.Add(randomInt);
            }
        }
    }

    int newRandomInt()
    {
        int randomInt = Mathf.RoundToInt(Random.Range(-0.45f, 12.45f));
        while(System.Array.IndexOf(integerSet,randomInt) >= 0 ){
            randomInt = Mathf.RoundToInt(Random.Range(-0.45f, 12.45f));
        }
        integerSet[randomInt] = randomInt;
        Debug.Log("now " + randomInt);
        return randomInt;
    }*/

    public void progressFaction()
    {
        SceneManager.LoadScene("ChoosingPart");
    }

     IEnumerator welcomePanelDisable()
    {
        yield return new WaitForSecondsRealtime(3f);
        welcomePanel.SetActive(false);
    }

    IEnumerator progressPanelEnable()
    {
        yield return new WaitForSecondsRealtime(2f);
        progressPanel.SetActive(true);
    }

    IEnumerator showText(string text, TextMeshProUGUI positionText)
    {
        for (int k = 0; k < text.Length; k++)
        {
            positionText.text = text.Substring(0, k + 1);
            yield return new WaitForSeconds(0.2f);
        }
        StartCoroutine(welcomePanelDisable());
    }
}
