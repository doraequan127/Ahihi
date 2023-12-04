using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing.Printing;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

[CustomEditor(typeof(TestCustomEditor)), CanEditMultipleObjects]
public class TestCustomEditor_ : Editor
{
    float horizontalScrollbarValue, horizontalSliderValue;
    Vector2 scrollViewPosition;
    string passwordFieldValue = "My Password";
    string textAreaValue = "Hello World\nI've got 2 lines...";
    string textFieldValue = "Hello World";
    bool toggleValue = false;

    int selGridInt = 0;
    string[] selStrings = { "radio1", "radio2", "radio3" };

    int toolbarInt = 0;
    string[] toolbarStrings = { "Toolbar1", "Toolbar2", "Toolbar3" };

    BuildTargetGroup selectedBuildTargetGroup;

    AnimBool m_ShowExtraFields = new AnimBool();
    string m_String;
    Color m_Color = Color.white;
    int m_Number = 0;

    bool foldoutHeaderGroupBoolValue = true;

    bool[] pos = new bool[3] { true, true, true };
    bool posGroupEnabled = true;

    bool foldoutBoolValue = true;


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(20);
        GUILayout.Box("Custom Editor tính từ đây :");

        GUILayout.Space(20);
        if (GUILayout.Button(new GUIContent("Click me", "This is tool tip"), GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false), GUILayout.Width(serializedObject.FindProperty("garnacho").intValue), GUILayout.Height(50)))
            Debug.Log("Click me");

        //horizontalScrollbarValue = GUILayout.HorizontalScrollbar(horizontalScrollbarValue, 1.0f, 0.0f, 10.0f);
        //horizontalSliderValue = GUILayout.HorizontalSlider(horizontalSliderValue, 0.0f, 10.0f);

        GUILayout.Space(20);
        scrollViewPosition = GUILayout.BeginScrollView(scrollViewPosition, GUILayout.Width(150), GUILayout.Height(100));
        GUILayout.Label(serializedObject.FindProperty("mainoo").stringValue);
        GUILayout.EndScrollView();

        GUILayout.Space(20);
        passwordFieldValue = GUILayout.PasswordField(passwordFieldValue, '*', 25);

        GUILayout.Space(20);
        textAreaValue = GUILayout.TextArea(textAreaValue, 200);

        //GUI.backgroundColor = Color.yellow;
        //GUI.color = Color.yellow;
        //GUI.enabled = false;

        GUILayout.Space(20);
        textFieldValue = GUILayout.TextField(textFieldValue, 25);
        
        GUILayout.Space(20);
        toggleValue = GUILayout.Toggle(toggleValue, "A Toggle text");

        GUILayout.Space(20);
        GUILayout.BeginVertical("Box");
        selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings, 1);
        if (GUILayout.Button("Start"))
        {
            Debug.Log("You chose " + selStrings[selGridInt]);
        }
        GUILayout.EndVertical();
        
        GUILayout.Space(20);
        toolbarInt = GUILayout.Toolbar(toolbarInt, toolbarStrings);

        GUILayout.Space(20);
        selectedBuildTargetGroup = EditorGUILayout.BeginBuildTargetSelectionGrouping();
        switch (selectedBuildTargetGroup)
        {
            case BuildTargetGroup.Android:
                EditorGUILayout.LabelField("Android specific things");
                break;
            case BuildTargetGroup.Standalone:
                EditorGUILayout.LabelField("Standalone specific things");
                break;
        }
        EditorGUILayout.EndBuildTargetSelectionGrouping();

        GUILayout.Space(20);
        m_ShowExtraFields.target = EditorGUILayout.ToggleLeft("Fade Group", m_ShowExtraFields.target);
        if (EditorGUILayout.BeginFadeGroup(m_ShowExtraFields.faded))
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PrefixLabel("Color");
            m_Color = EditorGUILayout.ColorField(m_Color);
            EditorGUILayout.PrefixLabel("Text");
            m_String = EditorGUILayout.TextField(m_String);
            EditorGUILayout.PrefixLabel("Number");
            m_Number = EditorGUILayout.IntSlider(m_Number, 0, 10);
            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndFadeGroup();

        GUILayout.Space(20);
        foldoutHeaderGroupBoolValue = EditorGUILayout.BeginFoldoutHeaderGroup(foldoutHeaderGroupBoolValue, "Đây là Foldout Header Group");
        if (foldoutHeaderGroupBoolValue)
            GUILayout.Label("Đây là Foldout Header Group");
        EditorGUILayout.EndFoldoutHeaderGroup();

        GUILayout.Space(20);
        foldoutBoolValue = EditorGUILayout.Foldout(foldoutBoolValue, "Đây là Fouldout");
        if (foldoutBoolValue)
            GUILayout.Label("Đây là Foldout");

        GUILayout.Space(20);
        posGroupEnabled = EditorGUILayout.BeginToggleGroup("Toggle Group", posGroupEnabled);
        pos[0] = EditorGUILayout.Toggle("x", pos[0]);
        pos[1] = EditorGUILayout.Toggle("y", pos[1]);
        pos[2] = EditorGUILayout.Toggle("z", pos[2]);
        EditorGUILayout.EndToggleGroup();

        GUILayout.Space(20);
        if (EditorGUILayout.LinkButton("Đây là 1 đường link"))
            Debug.Log("Click vào đường link");

        GUILayout.Space(20);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("garnacho"));

        serializedObject.ApplyModifiedProperties();
    }
}