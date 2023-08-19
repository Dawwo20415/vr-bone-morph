using GluonGui.WorkspaceWindow.Views.WorkspaceExplorer.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DisplacementType", menuName = "ScriptableObjects/DisplacementType", order = 1)]
public class DisplacementType : ScriptableObject
{

    public Vector3 displacement;

    public Vector3 apply(Vector3 starting_point)
    {
        return starting_point + displacement;
    }

}
