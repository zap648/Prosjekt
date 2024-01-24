using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SystemMenu : MonoBehaviour
{
    public Button savefile_startFile;


    // go to MainMenu
    public void goToMainMenu_button()
    {

        /*
        int gameobj = transform.childCount;
        Debug.Log(gameobj);

        Transform childtag = transform.GetChild(1);
        string nameTag = childtag.tag;
        if (nameTag == "saveFile")
        {
            Debug.Log("got it");
        }
        else if (nameTag == "grandparent")
        {
            Debug.Log("got parent");
        }
        else if (nameTag == "mainMenu")
        {
            Debug.Log("got the mains!");
        }
        else
        {
            Debug.Log("what sadness");
        }
        */

        // deactivate empty objects 
       
        
        // activate empty object  (main menu)

    }

    // quit application
    public void Exit_button()
    {
        Application.Quit();
    }

    // go to optionMenu
    public void goToOptionMenu_button()
    {
        // deactivate empty objects 
        // activate empty object  (Option menu)
    }

    // go to characterCreationMenu
    public void goToCharacterCreationMenu_button()
    {
        // deactivate empty objects 
        // activate empty object  (Character creation menu)
    }

    // go to continue a saved file
    public void goToContinueSaveFileMenu_button()
    {
        // deactivate empty objects 
        // activate empty object  (Continue Save File menu)
    }

    // start game file 
    public void startGameFile_button()
    {
        // this is currently not available
        savefile_startFile.interactable = false;

        // deactivate all menues
        // load up GameScene
        // dismiss SystemMenuScene
    }
}
