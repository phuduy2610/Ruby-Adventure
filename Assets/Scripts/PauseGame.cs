using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseGame : MonoBehaviour
{
    [SerializeField]
    GameObject PauseGameObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseGameObject.SetActive(false);

    }

    public void Pause()
    {
        Time.timeScale = 0f;
        PauseGameObject.SetActive(true);
    }

    public void MainMenu(){
        Resume();
        SceneManager.LoadScene("Title");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
