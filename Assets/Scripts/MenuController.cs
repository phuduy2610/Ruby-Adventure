using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public void PlayGame(){
        int clicked_object = int.Parse(UnityEngine.EventSystems.EventSystem.current.
        currentSelectedGameObject.name);
        GameManager.instance.CharIndex = clicked_object;
        SceneManager.LoadScene("Gameplay");
    }
}
