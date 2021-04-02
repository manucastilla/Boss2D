using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource sfxSource = default;
    private static AudioManager _instance;

    void Awake()
    {
        _instance = this;
    }

    public static void PlaySFX(AudioClip audioClip)
    {
        _instance.sfxSource.PlayOneShot(audioClip);
    }
}