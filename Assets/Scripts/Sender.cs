using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour
{
    // public delegate void PlayerDied();
    // public static event PlayerDied playerDiedInfo;
    public delegate void PlayerDied(bool isAlive);
    public static event PlayerDied playerDiedInfo;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ExecuteEvent",3f);
    }

    void ExecuteEvent()
    {
        if (playerDiedInfo != null)
        {
            playerDiedInfo(true);
        }
    }

}
