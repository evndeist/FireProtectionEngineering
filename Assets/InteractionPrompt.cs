using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InteractionPrompt : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image image;

    public void Set(string s) {
        text.text = s;
    }


}
