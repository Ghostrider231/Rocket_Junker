using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondScene : MonoBehaviour
{

    public TMP_Text NameBox;

    // Start is called before the first frame update
    void Start()
    {
        NameBox.text = PlayerPrefs.GetString("name");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
