using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundController : MonoBehaviour
{
    [SerializeField]
    GameObject soundButton;
    [SerializeField]
    private Sprite soundOn;
    [SerializeField]
    private Sprite soundOff;

    bool isOn = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSound()
    {
        if (isOn)
        {
            soundButton.GetComponent<Image>().sprite = soundOff;
            isOn = false;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundOn;
            isOn = true;
        }
    }
}
