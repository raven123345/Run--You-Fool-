using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpdateMusic : MonoBehaviour
{
    List<AudioSource> music = new List<AudioSource>();
    Slider sl;
    // Start is called before the first frame update
    public void Start()
    {
        AudioSource[] allAS = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();
        music.Add(allAS[0]);
        sl = GetComponent<Slider>();

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            sl.value = PlayerPrefs.GetFloat("MusicVolume");
        }

        UpdateMusicVolume();
    }

    public void UpdateMusicVolume()
    {
        foreach (AudioSource m in music)
        {
            m.volume = sl.value;
        }
        PlayerPrefs.SetFloat("MusicVolume", sl.value);
    }
}
