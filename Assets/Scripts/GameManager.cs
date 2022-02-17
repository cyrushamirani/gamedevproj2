using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    #region Unity_functions
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Scene_transitions
    public void StartGame()
    {
        SceneManager.LoadScene("Start Screen");
    }
     
    public void StartLevel()
    {
        SceneManager.LoadScene("Layer");
    }
    public void LoseGame()
    {
        SceneManager.LoadScene("Lose Screen");
    }
    #endregion
}
