using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    Vector3 tempPos;

    [SerializeField]
    private float minX,maxX;

    string PLAYER_TAG = "Player";
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!player){
            return;
        }
        tempPos = transform.position;    
        tempPos.x = player.position.x;
        if(tempPos.x >= minX && tempPos.x <=maxX){
        transform.position = tempPos;
        }

    }
}
