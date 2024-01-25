using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SystemMenu : MonoBehaviour
{
    public Button savefile_startFile;

    public ScriptableObjectMenu menuHelper;

    // quit application
    public void Exit_button()
    {
        Application.Quit();
    }
    public void startGame_newGame_button()
    {
        // change scene
        SceneManager.LoadScene(1);
    }
    // start game file 
    public void startGameFile_button()
    {
        // check if we have a save file, if we do- load it
        // apply the saved file to the scene
        // load Home Scene
        // startGame_newGame_button();

        // this is currently not available
        savefile_startFile.interactable = false;
    }
    public void goToMine()
    {
        // loads scene with Mine gameplay
        menuHelper.goToPreperationCanvas = true;
        SceneManager.LoadScene(2);
    }
    // in the mine, able to return to gameloopscene to continue loop
    public void goToPrep()
    {
        // load correct scene
        SceneManager.LoadScene(1);
        
        // loads scene in preperation menu for after-work
        if (menuHelper.goToPreperationCanvas)
        {
            // activate correct child
            Transform gameobjectCanvas = gameObject.transform;

            //if (gameobjectCanvas.GetChild(4).tag == "prepMenu")
            //{
            //    gameobjectCanvas.GetChild(4);
            //}
            //else
            //{
            //    Debug.Log("Could not find child 4 or prepMenu");
            //}
        }
    }
}
