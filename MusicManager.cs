using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] songs;
    public TextMeshProUGUI nowPlayingText;
    public Slider volumeSlider;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        if (songs.Length == 0)
        {
            Debug.LogError("No songs found.");
            return;
        }

        PlayRandomSong();
    }

    void PlayRandomSong()
    {
        AudioClip randomSong = songs[Random.Range(0, songs.Length)];

        audioSource.clip = randomSong;
        audioSource.Play();

        if (nowPlayingText != null)
        {
            nowPlayingText.text = $"Now Playing: {randomSong.name}";
        }

        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        }

    }

    void OnVolumeSliderChanged(float value)
    {
        if (volumeSlider != null)
        {
            audioSource.volume = volumeSlider.value;
        }
    }
}
