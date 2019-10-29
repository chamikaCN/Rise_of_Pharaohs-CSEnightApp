using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text;
using Assets.Scripts;

public class TargetHandler : MonoBehaviour
{
    int GroupID,artifacts;
    public Text artifactText;
    public GameObject progressPanel, welcomePanel,IndexObject;
    public TextMeshProUGUI NameText1, NameText2;
    public TextMeshProUGUI welcomeText;
    string welcomePhrase,startString,finalString,startStringUp,finalStringUp;
    AudioSource typing,Egypt,letter,vanish;
    public UnityEngine.UI.Image profPic;
    public Sprite MaleProfPic,FemaleProfPic;
    List<int> randomNumbers; 

    void Start()
    {
        audioSetup();
        welcomePanel.SetActive(true);
        welcomePhrase = "when the stars begin to shine, pharaohs breathe from the underworld\n....... ";
        StartCoroutine(showText(welcomePhrase,welcomeText));
        GroupID = GameManager.getGroupID();
        artifacts = 0;
        artifactText.text = "ARTIFACTS   0";
        progressPanel.SetActive(false);
        startStringUp = "____ __ ";
        finalStringUp = "rise of ";
        startString = "________";
        finalString = "PHARAOHS";
        NameText2.text = startString;
        NameText1.text = startStringUp;
        IndexObject.SetActive(true);
        IndexObject.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.getName(int.Parse(GameManager.getIndexNo())) + "\n" + GameManager.getIndexNo();
        if(GameManager.getGender(int.Parse(GameManager.getIndexNo())) == 'F')
            {
                profPic.sprite = FemaleProfPic;
            }else{
                profPic.sprite = MaleProfPic;
            }
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
                    letter.Play();
                    collectArtifact();
                }
            }
        }

        if (artifacts >= 8)
        {
            NameText2.gameObject.transform.Translate(0f, 0f, 0f);
            NameText1.gameObject.transform.Translate(0f, 0f, 0f);
            NameText2.gameObject.transform.localScale.Scale(new Vector3(0.5f, 0.5f));
            NameText1.gameObject.transform.localScale.Scale(new Vector3(0.5f, 0.5f));
            StartCoroutine(clearText(NameText2));
            StartCoroutine(clearText(NameText1));
            StartCoroutine(progressPanelEnable());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("IndexPart");
        }
    }

    void audioSetup()
    {
        typing = welcomePanel.GetComponent<AudioSource>();
        Egypt = this.GetComponent<AudioSource>();
        letter = NameText2.GetComponent<AudioSource>();
        vanish = artifactText.GetComponent<AudioSource>();
    }

    public void collectArtifact()
    {
        letterReveal1(artifacts);
        letterReveal2(artifacts);
        artifacts += 1;
        artifactText.text = "ARTIFACTS   " + artifacts;
    }

    void letterReveal(int interger,string start,string end, TextMeshProUGUI texty){
        //int rand = newRandomInt();
        StringBuilder sb = new StringBuilder(start);
        sb[interger] = end[interger];
        start = sb.ToString();
        texty.text = start;
    }

    void letterReveal1(int interger){
        //int rand = newRandomInt();
        StringBuilder sb = new StringBuilder(startStringUp);
        sb[interger] = finalStringUp[interger];
        startStringUp = sb.ToString();
        NameText1.text = startStringUp;
    }

    void letterReveal2(int interger){
        //int rand = newRandomInt();
        StringBuilder sb = new StringBuilder(startString);
        sb[interger] = finalString[interger];
        startString = sb.ToString();
        NameText2.text = startString;
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
        Egypt.Play();
    }

    IEnumerator progressPanelEnable()
    {
        yield return new WaitForSecondsRealtime(5f);
        progressPanel.SetActive(true);
    }

    IEnumerator showText(string text, TextMeshProUGUI positionText)
    {
        typing.Play();
        for (int k = 0; k < text.Length; k++)
        {
            positionText.text = text.Substring(0, k + 1);
            yield return new WaitForSeconds(0.2f);
        }
        typing.Stop();
        StartCoroutine(welcomePanelDisable());
    }

    IEnumerator clearText(TextMeshProUGUI positionText)
    {
        vanish.Play();
        string text = positionText.text;
        for (int k = 0; k < text.Length; k++)
        {
            StringBuilder sb = new StringBuilder(text);
            sb[k] = ' ';
            text = sb.ToString();
            positionText.text = text;
            yield return new WaitForSeconds(0.35f);
        }
        vanish.Stop();
    }
}
