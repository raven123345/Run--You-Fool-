using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegisterScore : MonoBehaviour
{
    public TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        GameData.instance.scoreText = GetComponent<TextMeshProUGUI>();
    }

}
