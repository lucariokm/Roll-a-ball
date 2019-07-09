using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nextscene : MonoBehaviour
{
    // Start is called before the first frame update
   public void MinigameLoad()
    {
        SceneManager.LoadScene("Minigame");
    }
    public void ChallengeLoad()
    {
        SceneManager.LoadScene("Challenge");
    }

    public void exitPress()
    {
        Application.Quit();
    }
}
