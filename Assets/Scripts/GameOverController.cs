using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverController : MonoBehaviour
{
    bool isDead = false;
    bool isWin = false;
    [SerializeField]
    private GameObject gameOverScene;

    [SerializeField]
    private GameObject gameVictoryScene;
    [SerializeField]
    private GameObject BackGround;
    [SerializeField]
    private AudioClip gameOverSound;
    private RubyController ruby;
    private AudioSource bgAudioSource;
    private MissionManager mM;
    [SerializeField]
    private AudioClip gameVictorySound;
    [SerializeField]
    private TMP_Text TimeTxt;
    // Start is called before the first frame update
    void Start()
    {
        //Đăng ký vào sự kiện
        ruby = FindObjectOfType<RubyController>();
        mM = FindObjectOfType<MissionManager>();
        ruby.OnPlayerDeath += OnGameOver;
        mM.OnMissionComplete += OnGameWin;
        bgAudioSource = BackGround.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //Check Space để chơi lại
        if (isDead || isWin)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if(Input.GetKeyDown(KeyCode.Escape)){

                SceneManager.LoadScene("Title");

            }
        }
    }

    private void OnGameOver()
    {
        isDead = true;
        //Bật GameOver lên
        gameOverScene.SetActive(true);
        bgAudioSource.Stop();
        bgAudioSource.PlayOneShot(gameOverSound);
    }

    private void OnGameWin(){
        isWin = true;
        gameVictoryScene.SetActive(true);
        bgAudioSource.Stop();
        bgAudioSource.PlayOneShot(gameVictorySound);
        TimeTxt.text = Mathf.RoundToInt(Time.timeSinceLevelLoad) + "s";
    } 
}