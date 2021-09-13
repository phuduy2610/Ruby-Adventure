using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciever : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable() {
        Sender.playerDiedInfo += PlayerDiedListener;
    }

    private void OnDisable() {
        Sender.playerDiedInfo -= PlayerDiedListener;
    }

    void PlayerDiedListener(bool alive){
        Debug.Log("Alive");
    }
}
