using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class TileEditorLogic : MonoBehaviour
{
    private void ConnectToSceneCanvasUI()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach (GameObject go in allObjects)
        {
            if (go.name == "ResizeButton")
                canvasResizeButton = go;
            else if (go.name == "ResizeXInputField")
                canvasResizeXInputField = go;
            else if (go.name == "ResizeYInputField")
                canvasResizeYInputField = go;
            else if (go.name == "SaveButton")
                canvasSaveButton = go;
            else if (go.name == "LoadButton")
                canvasLoadButton = go;
            else if (go.name == "FileNameInputField")
                canvasFileNameInputField = go;
        }

        canvasResizeButton.GetComponent<Button>().onClick.AddListener(ResizeButtonPressed);
        canvasSaveButton.GetComponent<Button>().onClick.AddListener(SaveButtonPressed);
        canvasLoadButton.GetComponent<Button>().onClick.AddListener(LoadButtonPressed);
    }

}

