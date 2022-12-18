using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using TMPro;

public enum Stage {Intro, Q1, Q2, End}

public class AsistanceManager : MonoBehaviour
{
    [SerializeField] private AudioCollection audioCollect;
    [SerializeField] private GameObject playerGO, hearth;
    private EventInstance eventInstance = new EventInstance();
    private AudioSet currentSet;
    private Stage currentStage;
    private UIControl uiControl;

    //getters & setters
    public AudioSet CurrentSet {get=>currentSet; set=>currentSet=value;}
    public Stage CurrentStage {get=>currentStage; set=>currentStage=value;}
    public GameObject Hearth {get=>hearth;}
    public GameObject PlayerGO {get=>playerGO;}

    void Start()
    {
        currentSet = audioCollect.AudioSets[0];
        currentStage = Stage.Intro;
        uiControl = FindObjectOfType<UIControl>();

        
    }

    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(eventInstance, playerGO.transform, playerGO.GetComponent<Rigidbody>());
        if (Input.GetKeyDown(KeyCode.A)) {
            // FMOD.ATTRIBUTES_3D attribute = new FMOD.ATTRIBUTES_3D();
            // FMOD.VECTOR position = new FMOD.VECTOR();
            // position.x = transform.position.x;
            // position.y = transform.position.y;
            // position.z = transform.position.z;
            // attribute.position = position;
            // eventInstance.set3DAttributes(attribute);
            eventInstance = RuntimeManager.CreateInstance(audioCollect.getAudioSetByName("Greeting").AudioKey);
            eventInstance.start();
            eventInstance.release();
        }

        switch (currentStage) {
            case Stage.Intro:
                uiControl.DelimmaUI.SetActive(true);
                uiControl.AudioFileUI.SetActive(false);
                uiControl.AnswerUI.SetActive(false);
                break;
            case Stage.Q1:
                uiControl.DelimmaUI.SetActive(false);
                uiControl.AudioFileUI.SetActive(true);
                uiControl.AnswerUI.SetActive(true);
                uiControl.AudioFile3.SetActive(false);
                uiControl.AudioAnswer3.SetActive(false);
                hearth.SetActive(false);
                
                break;
            case Stage.Q2:
                uiControl.DelimmaUI.SetActive(false);
                uiControl.AudioFileUI.SetActive(true);
                uiControl.AnswerUI.SetActive(true);
                uiControl.AudioFile3.SetActive(false);
                uiControl.AudioAnswer3.SetActive(false);
                hearth.SetActive(false);
                break;
            
            case Stage.End:
                uiControl.AudioFileUI.SetActive(false);
                uiControl.DelimmaUI.SetActive(false);
                uiControl.AnswerUI.SetActive(false);
                break;
        }
    }

    public void PlayAudio (AudioSet audioSet) {
        EventInstance eventInstance = RuntimeManager.CreateInstance(audioSet.AudioKey);
        eventInstance.start();
        eventInstance.release();
        ChangeStage(CurrentSet.WorkingStage);
    }

    public void Play3DAudio (AudioSet audioSet) {
        EventInstance eventInstance = RuntimeManager.CreateInstance(audioSet.AudioKey);
        eventInstance.set3DAttributes(new FMOD.ATTRIBUTES_3D());
        eventInstance.start();
        eventInstance.release();
        ChangeStage(CurrentSet.WorkingStage);
    }

    public bool ChangeStage (Stage nextStage) {
        if (CurrentStage != nextStage) {
            CurrentStage = nextStage;
            switch (CurrentStage) {
                case Stage.Q1:
                    uiControl.AudioSets.Clear();
                    uiControl.AudioSets.Add(audioCollect.getAudioSetByName("BoxA"));
                    uiControl.AudioSets.Add(audioCollect.getAudioSetByName("BoxB"));
                    uiControl.AudioDes1.text = "BoxA";
                    uiControl.AudioDes2.text = "BoxB";

                    uiControl.Des1.text = " is the murder";
                    uiControl.Des2.text = " is the victim";

                    uiControl.Answer1.ClearOptions();
                    uiControl.Answer1.options.Add(new TMP_Dropdown.OptionData() {text = "BoxA"});
                    uiControl.Answer1.options.Add(new TMP_Dropdown.OptionData() {text = "BoxB"});
                    uiControl.Answer2.ClearOptions();
                    uiControl.Answer2.options.Add(new TMP_Dropdown.OptionData() {text = "BoxA"});
                    uiControl.Answer2.options.Add(new TMP_Dropdown.OptionData() {text = "BoxB"});
                    break;

                case Stage.Q2:
                    uiControl.AudioSets.Clear();
                    uiControl.AudioSets.Add(audioCollect.getAudioSetByName("FileA"));
                    uiControl.AudioSets.Add(audioCollect.getAudioSetByName("FileB"));
                    uiControl.AudioDes1.text = "FileA";
                    uiControl.AudioDes2.text = "FileB";

                    uiControl.Des1.text = " is the murder of the friend";
                    uiControl.Des2.text = " got the key";

                    uiControl.Answer1.ClearOptions();
                    uiControl.Answer1.options.Add(new TMP_Dropdown.OptionData() {text = "FileA"});
                    uiControl.Answer1.options.Add(new TMP_Dropdown.OptionData() {text = "FileB"});
                    uiControl.Answer2.ClearOptions();
                    uiControl.Answer2.options.Add(new TMP_Dropdown.OptionData() {text = "FileA"});
                    uiControl.Answer2.options.Add(new TMP_Dropdown.OptionData() {text = "FileB"});
                    break;
                
                case Stage.End:
                    uiControl.AudioFileUI.SetActive(false);
                    uiControl.DelimmaUI.SetActive(false);
                    uiControl.AnswerUI.SetActive(false);
                    break;
            }


        }
        return false;
    }
}
