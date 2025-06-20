using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    public AudioClip sound6;

    [Header("Audio Source assigned to the SFX Audio Mixer group")]
    public AudioSource sfxSource;

    private HashSet<string> triggeredTags = new HashSet<string>();
    private Queue<AudioClip> clipQueue = new Queue<AudioClip>();
    private bool isPlaying = false;

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        if (triggeredTags.Contains(tag))
            return;

        triggeredTags.Add(tag);

        AudioClip clipToQueue = null;

        switch (tag)
        {
            case "Trigger1":
                clipToQueue = sound1;
                break;
            case "Trigger2":
                clipToQueue = sound2;
                break;
            case "Trigger3":
                clipToQueue = sound3;
                break;
            case "Trigger4":
                clipToQueue = sound4;
                break;
            case "Trigger5":
                clipToQueue = sound5;
                break;
            case "Trigger6":
                clipToQueue = sound6;
                break;
        }

        if (clipToQueue != null)
        {
            clipQueue.Enqueue(clipToQueue);

            if (!isPlaying)
                StartCoroutine(PlayQueuedClips());
        }
    }

    private IEnumerator PlayQueuedClips()
    {
        isPlaying = true;

        while (clipQueue.Count > 0)
        {
            AudioClip nextClip = clipQueue.Dequeue();
            sfxSource.clip = nextClip;
            sfxSource.Play();
            yield return new WaitForSeconds(nextClip.length);
        }

        isPlaying = false;
    }
}
