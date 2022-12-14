using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class UIControl : MonoBehaviour
{
    [SerializeField] GameObject delimmaUI, answerUI, audioFileUI, audioFile1, audioFile2, audioFile3;
    [SerializeField] private AudioCollection audioCollect;
    [SerializeField] private List<AudioSet> audioSet;
    private AsistanceManager manager;

    //getters & setters
    public GameObject DelimmaUI {get=>delimmaUI; set=>delimmaUI=value;}
    public GameObject AnswerUI {get=>answerUI; set=>answerUI=value;}
    public GameObject AudioFileUI {get=>audioFileUI; set=>audioFileUI=value;}

    void Start()
    {
        manager = FindObjectOfType<AsistanceManager>();
    }

    void Update()
    {
        
    }

    public void PlayAudio (int index) {
        EventInstance eventInstance = RuntimeManager.CreateInstance(audioSet[index].AudioKey);
        eventInstance.start();
        eventInstance.release();
    }

    public void playAudioByName (string audioName) { 
        EventInstance eventInstance = RuntimeManager.CreateInstance(audioCollect.getAudioKeyByName(audioName).AudioKey);
        eventInstance.start();
        eventInstance.release();
    }

    public void Yes () {
        playAudioByName(manager.CurrentSet.YesSet);
        manager.CurrentSet = audioCollect.getAudioKeyByName(manager.CurrentSet.YesSet);
    }

    public void No () {
        playAudioByName(manager.CurrentSet.NoSet);
        manager.CurrentSet = audioCollect.getAudioKeyByName(manager.CurrentSet.NoSet);
    }
}
