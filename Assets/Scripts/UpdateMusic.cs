using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpdateMusic : MonoBehaviour
{
    List<AudioSource> music = new List<AudioSource>();
    Slider sl;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] allAS = GameObject.FindWithTag("GameData").GetComponentsInChildren<AudioSource>();
        music.Add(allAS[0]);
        sl = GetComponent<Slider>();
        UpdateMusicVolume();
    }

    public void UpdateMusicVolume()
    {
        foreach(AudioSource m in music)
        {
            m.volume = sl.value;
        }
    }
}
