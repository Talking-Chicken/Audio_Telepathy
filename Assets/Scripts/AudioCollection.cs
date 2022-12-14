using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;

[Serializable]
public class AudioSet {
    [SerializeField] private string audioName;
    [SerializeField] private EventReference audioKey = default;
    private bool hasPlayedOnce = false;
    [SerializeField] private string nextSetName, yesSetName, noSetName;
    [SerializeField] private Stage workingStage;

    // getters & setters
    public string AudioName {get=>audioName; set=>audioName=value;}
    public EventReference AudioKey {get=>audioKey; set=>audioKey=value;}
    public bool HasPlayedOnce {get=>hasPlayedOnce; set=>hasPlayedOnce=value;}
    public string NextSet {get=>nextSetName; set=>nextSetName=value;}
    public string YesSet {get=>yesSetName; set=>yesSetName=value;}
    public string NoSet {get=>noSetName; set=>noSetName=value;}
    public Stage WorkingStage {get=>workingStage;}
}

[CreateAssetMenu(fileName = "Audio Collection", menuName = "ScriptableObjects/Audio Collection", order = 1)]
public class AudioCollection : ScriptableObject
{
    [SerializeField] List<AudioSet> audioSets;
    
    // getters & setters
    public List<AudioSet> AudioSets {get=>audioSets;}

    public AudioSet getAudioSetByName(string audioName) {
        foreach (AudioSet audioSet in audioSets) {
            if (audioSet.AudioName.ToLower().Trim().Equals(audioName.ToLower().Trim()))
                return audioSet;
        }
        Debug.LogWarning("cannot find " + audioName);
        return null;
    }
}
