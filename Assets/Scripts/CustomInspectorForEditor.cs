using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TileEditorLogic))]
public class CustomInspectorForEditor : Editor
{

    float scrollVal = 0.2f;
    bool togVal;
    string myString;

    bool showStuff;

    Color colorEditor = Color.blue;

    //GameObject gameObjectToMod;
    public Object objectToMod;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //void OnInspectorGUI()
    public override void OnInspectorGUI()
    {


        TileEditorLogic tileEditorLogic = FindObjectOfType<TileEditorLogic>();



        GUILayout.Label("Base Settings", EditorStyles.boldLabel);

        myString = EditorGUILayout.TextField("Text Field", myString);

        Debug.Log("string data == " + myString);

        float newVal = 0;
        if(float.TryParse(myString, out newVal))
            tileEditorLogic.testValToSetViaCustomEditor = newVal;


        //GUI.Button(new Rect(50, 50, 150, 100), "asfsaf");

        if (GUI.Button(new Rect(50, 50, 150, 100), new GUIContent("I am a button", "This is the tooltip")))
        {
            Debug.Log("You clicked the button!");

            showStuff = !showStuff;

            //ContentLoader.GetNewMapSpriteGameObject(TextureSpriteID.Grass);

            //GameObject go = new GameObject("MapObject");

            //GameObject go2 = Instantiate(Resources.Load<GameObject>("MapSprite"));

            

            tileEditorLogic.CreateMapVisuals();
        }


        GUILayout.Space(120);

        colorEditor = EditorGUILayout.ColorField(colorEditor);

        //gameObjectToMod = EditorGUILayout.ObjectField(gameObjectToMod, typeof(GameObject));
        
        //EditorGUILayout.ObjectField((Object)gameObjectToMod, typeof(GameObject));


        objectToMod = EditorGUILayout.ObjectField(objectToMod, typeof(TileEditorLogic));


        bool prevTogVal = togVal;

        togVal = GUILayout.Toggle(togVal, "fdsg sdgs");

        if (prevTogVal != togVal)
        {
            Debug.Log("You toggled the thing");
        }


        // {
        //     Debug.Log("You toggled the thing");
        // }

        //

        //scrollVal = 0.2f;
        scrollVal = GUILayout.HorizontalSlider(scrollVal, 0.0f, 1f);


        


        if (showStuff)
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
}
