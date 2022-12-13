using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AsistanceManager : MonoBehaviour
{
    [SerializeField] private AudioCollection audioCollect;
    [SerializeField] private GameObject playerGO;
    private EventInstance eventInstance = new EventInstance();
    void Start()
    {
    }

    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(eventInstance, playerGO.transform, playerGO.GetComponent<Rigidbody>());
        if (Input.GetKeyDown(KeyCode.A)) {
            FMOD.ATTRIBUTES_3D attribute = new FMOD.ATTRIBUTES_3D();
            FMOD.VECTOR position = new FMOD.VECTOR();
            position.x = transform.position.x;
            position.y = transform.position.y;
            position.z = transform.position.z;
            attribute.position = position;
            eventInstance.set3DAttributes(attribute);
            eventInstance = RuntimeManager.CreateInstance(audioCollect.getAudioKeyByName("Greeting").AudioKey);
            eventInstance.start();
            eventInstance.release();
        }
    }

    public void PlayAudio (AudioSet audioSet) {
        EventInstance eventInstance = RuntimeManager.CreateInstance(audioSet.AudioKey);
        eventInstance.start();
        eventInstance.release();
    }

    public void Play3DAudio (AudioSet audioSet) {
        EventInstance eventInstance = RuntimeManager.CreateInstance(audioSet.AudioKey);
        eventInstance.set3DAttributes(new FMOD.ATTRIBUTES_3D());
        eventInstance.start();
        eventInstance.release();
    }
}
