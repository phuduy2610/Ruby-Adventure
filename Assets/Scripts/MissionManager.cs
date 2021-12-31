using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MissionManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text RobotTxt;
    private int robotCount;
    private GameObject[] robots;
    bool isComplete = false;
    public event System.Action OnMissionComplete;

    // Start is called before the first frame update
    void Start()
    {
        if (robots == null)
        {
            robots = GameObject.FindGameObjectsWithTag("Enemy");
            robotCount = robots.Length;
            RobotTxt.text = robotCount.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (robotCount <= 0 && !isComplete)
        {
            if (OnMissionComplete != null)
            {
                isComplete = true;
                OnMissionComplete();
            }

        }
    }

    public void ChangeRobotNum(int value)
    {
        robotCount--;
        RobotTxt.text = robotCount.ToString();

    }
}
