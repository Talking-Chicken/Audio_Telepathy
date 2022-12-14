using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.UI;
using TMPro;

public class UIControl : MonoBehaviour
{
    [SerializeField] GameObject delimmaUI, answerUI, audioFileUI, audioFile1, audioFile2, audioFile3, audioAnswer1, audioAnswer2, audioAnswer3;
    [SerializeField] TMP_Dropdown answer1, answer2, answer3;
    [SerializeField] TextMeshProUGUI des1, des2, des3, audioDes1, audioDes2, audioDes3;
    [SerializeField] private AudioCollection audioCollect;
    [SerializeField] private List<AudioSet> audioSets;
    private AsistanceManager manager;
    private EventInstance eventInstance = new EventInstance();

    //getters & setters
    public GameObject DelimmaUI {get=>delimmaUI; set=>delimmaUI=value;}
    public GameObject AnswerUI {get=>answerUI; set=>answerUI=value;}
    public GameObject AudioFileUI {get=>audioFileUI; set=>audioFileUI=value;}
    public GameObject AudioFile1 {get=>audioFile1;}
    public GameObject AudioFile2 {get=>audioFile2;}
    public GameObject AudioFile3 {get=>audioFile3;}
    public GameObject AudioAnswer1 {get=>audioAnswer1;}
    public GameObject AudioAnswer2 {get=>audioAnswer2;}
    public GameObject AudioAnswer3 {get=>audioAnswer3;}
    public List<AudioSet> AudioSets {get=>audioSets; set=>audioSets=value;}
    public TMP_Dropdown Answer1 {get=>answer1;}
    public TMP_Dropdown Answer2 {get=>answer2;}
    public TMP_Dropdown Answer3 {get=>answer3;}
    public TextMeshProUGUI Des1 {get=>des1; set=>des1=value;}
    public TextMeshProUGUI Des2 {get=>des2; set=>des2=value;}
    public TextMeshProUGUI Des3 {get=>des3; set=>des3=value;}
    public TextMeshProUGUI AudioDes1 {get=>audioDes1; set=>audioDes1=value;}
    public TextMeshProUGUI AudioDes2 {get=>audioDes2; set=>audioDes2=value;}
    public TextMeshProUGUI AudioDes3 {get=>audioDes3; set=>audioDes3=value;}

    void Start()
    {
        manager = FindObjectOfType<AsistanceManager>();
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(eventInstance, manager.PlayerGO.transform, manager.PlayerGO.GetComponent<Rigidbody>());
    }

    void Update()
    {
    }

    public void PlayAudio (int index) {
        eventInstance = RuntimeManager.CreateInstance(audioSets[index].AudioKey);
        eventInstance.start();
        eventInstance.release();
        manager.CurrentSet = AudioSets[index];
        manager.CurrentStage = audioSets[index].WorkingStage;
        manager.Hearth.SetActive(false);
    }

    public void playAudioByName (string audioName) { 
        eventInstance = RuntimeManager.CreateInstance(audioCollect.getAudioSetByName(audioName).AudioKey);
        eventInstance.start();
        eventInstance.release();
        // manager.CurrentStage = audioCollect.getAudioSetByName(audioName).WorkingStage;
        manager.ChangeStage(audioCollect.getAudioSetByName(audioName).WorkingStage);
    }

    public void Yes () {
        playAudioByName(manager.CurrentSet.YesSet);
        manager.CurrentSet = audioCollect.getAudioSetByName(manager.CurrentSet.YesSet);
    }

    public void No () {
        playAudioByName(manager.CurrentSet.NoSet);
        manager.CurrentSet = audioCollect.getAudioSetByName(manager.CurrentSet.NoSet);
    }

    public string GetDropdownString (TMP_Dropdown dropdown) {
        return dropdown.options[dropdown.value].text;
    }

    public void Submit () {
        switch (manager.CurrentStage) {
            case Stage.Q1:
                if (GetDropdownString(Answer1).ToLower().Trim().Equals("BoxB".ToLower().Trim())
                    &&
                    GetDropdownString(Answer2).ToLower().Trim().Equals("BoxA".ToLower().Trim()))
                {
                    Yes();
                } else {
                    No();
                }
            break;

            case Stage.Q2:

                break;
        }
    }

}
