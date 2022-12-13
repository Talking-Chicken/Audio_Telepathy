using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AsistanceManager : MonoBehaviour
{
    [SerializeField] private AudioCollection audioCollect;
    void Start()
    {
    }

    void Update()
    {
    }

    public void PlayAudio (AudioSet audioSet) {
        EventInstance eventInstance = RuntimeManager.CreateInstance(audioSet.AudioKey);
        eventInstance.start();
        eventInstance.release();
    }
}
