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

    // getters & setters
    public string AudioName {get=>audioName; set=>audioName=value;}
    public EventReference AudioKey {get=>audioKey; set=>audioKey=value;}
    public bool HasPlayedOnce {get=>hasPlayedOnce; set=>hasPlayedOnce=value;}
}

[CreateAssetMenu(fileName = "Audio Collection", menuName = "ScriptableObjects/Audio Collection", order = 1)]
public class AudioCollection : ScriptableObject
{
    [SerializeField] List<AudioSet> audioSets;

    public AudioSet getAudioKeyByName(string audioName) {
        foreach (AudioSet audioSet in audioSets) {
            if (audioSet.AudioName.ToLower().Trim().Equals(audioName.ToLower().Trim()))
                return audioSet;
        }
        Debug.LogWarning("cannot find " + audioName);
        return null;
    }
}
