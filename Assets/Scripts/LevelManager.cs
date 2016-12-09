using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void LoadLevel (string name)
    {
        Debug.Log ("Level load requested for: " + name);
        Application.LoadLevel(name);
    }

    //no argument needed since we don't quit to a specific place
    public void QuitRequest ()
    {
        Debug.Log ("Game quit requested via: " + name);
        Application.Quit();
    }

}
