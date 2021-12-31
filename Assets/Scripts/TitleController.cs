using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleController : MonoBehaviour
{
    [SerializeField]
    GameObject startTxt;
    bool blinking = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GameStartBlink");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            blinking = false;
            SceneManager.LoadScene("Gameplay");
        }
    }

    IEnumerator GameStartBlink()
    {
        while (blinking)
        {
            if (startTxt.activeInHierarchy)
            {
                startTxt.SetActive(false);
            }
            else
            {
                startTxt.SetActive(true);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
