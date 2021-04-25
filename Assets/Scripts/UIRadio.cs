using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIRadio : MonoBehaviour
{
    public TextMeshProUGUI volumne;
    public TextMeshProUGUI songName;

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float v = (FindObjectOfType<AudioManager>().getVolumne() / 1) * 100;
        volumne.text =  "Volumne: " + v.ToString("F0") + "%";
        songName.text = FindObjectOfType<AudioManager>().getName();
    }
}
