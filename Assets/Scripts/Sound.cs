using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    public AudioClip sound6;

    private AudioSource audioSource;

    private void Awake()
    {        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Trigger1":
                PlayClip(sound1);
                break;
            case "Trigger2":
                PlayClip(sound2);
                break;
            case "Trigger3":
                PlayClip(sound3);
                break;
            case "Trigger4":
                PlayClip(sound4);
                break;
            case "Trigger5":
                PlayClip(sound5);
                break;
            case "Trigger6":
                PlayClip(sound6);
                break;
        }
    }

    private void PlayClip(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
