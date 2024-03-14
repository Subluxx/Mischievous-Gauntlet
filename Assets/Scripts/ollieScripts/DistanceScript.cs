using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceScript : MonoBehaviour
{
    public Text text;
    public string displayText = "-";
    // Start is called before the first frame update
    void Start()
    {
        text.text = "0" + "m";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = displayText;
    }
}
