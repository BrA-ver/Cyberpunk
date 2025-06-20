using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudioManager : MonoBehaviour
{
    [Header("Mixer Reference")]
    public AudioMixer audioMixer; // Assign this in the Inspector

    [Header("Volume Defaults")]
    [Range(0f, 1f)] public float defaultMusicVolume = 0.8f;
    [Range(0f, 1f)] public float defaultSFXVolume = 1.0f;

    private void Start()
    {
        // Set to default at startup
        SetMusicVolume(defaultMusicVolume);
        SetSFXVolume(defaultSFXVolume);
    }

    // Set volume where 1.0 = full volume, 0.0 = silent
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", LinearToDecibel(volume));
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", LinearToDecibel(volume));
    }

    // Converts 0–1 linear slider value to decibels for the mixer
    private float LinearToDecibel(float linear)
    {
        return Mathf.Approximately(linear, 0f) ? -80f : Mathf.Log10(linear) * 20f;
    }
}
