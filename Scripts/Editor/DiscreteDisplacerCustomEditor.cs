using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(DiscreteDisplacer), true)]
public class DiscreteDisplacerCustomEditor : Editor
{
    private bool componentHealthStatus = false;
    private string errorString = "Placeholder Error String";
    public override void OnInspectorGUI()
    {
        DiscreteDisplacer displacer = (DiscreteDisplacer)target;
        EditorGUI.BeginChangeCheck();

        if (componentHealthStatus)
            drawWarningBox(errorString);

        base.OnInspectorGUI();

        if (EditorGUI.EndChangeCheck())
        {
            List<int> indexes = displacer.CheckReferences();
            if (indexes[0] == 1)
            {
                componentHealthStatus = true;
                errorString = "\"operations\" array and \"displacement_references\" array have different sizes, please add empty elements or delete from \"displacement_references\" accordingly.";
            }
            else
            {
                if (indexes.Count > 1)
                {
                    componentHealthStatus = true;
                    errorString = "WARNING: Operations with index: ";
                    for (int i = 1; i < indexes.Count; i++)
                    {
                        errorString += i.ToString();
                        if (i != indexes.Count - 1)
                            errorString += ",";
                    }
                    errorString += " require a corresponding reference GameObject, but it was not found.";
                }
                else
                {
                    componentHealthStatus = false;
                }
            }
        }


    }

    public void drawWarningBox(string errorString)
    {
        EditorGUILayout.HelpBox(errorString, MessageType.Error);
    }
}

#endif
