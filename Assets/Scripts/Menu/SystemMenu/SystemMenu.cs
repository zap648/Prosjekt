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
        SceneManager.LoadScene(2);
    }
    // in the mine, able to return to gameloopscene to continue loop
    public void goToPrep()
    {
        // loads scene in preperation menu for after-work
        SceneManager.LoadScene(1);
    }
}
