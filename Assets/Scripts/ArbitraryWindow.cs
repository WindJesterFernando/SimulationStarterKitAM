
using UnityEngine;
using UnityEditor;
using System.Collections;


public class ArbitraryWindow : EditorWindow
{
    float scrollVal = 0.5f;
    string myString = "asd";

    bool togVal;

    [MenuItem("Window/Arbitrary Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ArbitraryWindow));
    }
    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);

        myString = EditorGUILayout.TextField("Text Field", myString);

        Debug.Log("string data == " + myString);


        // if (GUI.Button(new Rect(50, 50, 150, 100), "I am a button"))
        // {

        //     Debug.Log("You clicked the button!");

        //     //ContentLoader.GetNewMapSpriteGameObject(TextureSpriteID.Grass);

        //     GameObject go = new GameObject("MapObject");

        //     //GameObject go2 = Instantiate(Resources.Load<GameObject>("MapSprite"));
        // }

        bool prevTogVal = togVal;

        togVal = GUILayout.Toggle(togVal, "fdsg sdgs");

        if(prevTogVal != togVal)
        {
            Debug.Log("You toggled the thing");
            this.ShowNotification(new GUIContent("No savsadfadsg selected for searching"));
        }

        // {
        //     Debug.Log("You toggled the thing");
        // }

        scrollVal = GUILayout.HorizontalSlider(scrollVal, 0.0f, 1f);



        if (scrollVal > 0.5f)
        {
            if (GUILayout.Toggle(togVal, "fdsg sdgs"))
            {
                Debug.Log("You toggled the thing");
            }
            if (GUILayout.Toggle(togVal, "fdsg sdgs"))
            {
                Debug.Log("You toggled the thing");
            }
            if (GUILayout.Toggle(togVal, "fdsg sdgs"))
            {
                Debug.Log("You toggled the thing");
            }
        }

        // Concat("asfas");

        // Concat("asfas", "sege", "vewgewg");

    }


    // public static void Concat(params string[] csvData)
    // {

    // }
}


