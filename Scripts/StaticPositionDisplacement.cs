using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Static Position Displacement", menuName="ScriptableObjects/Point Displacement/Static Vector")]
public class StaticPositionDisplacement : PointDisplacement
{
    [SerializeField]
    private Vector3 displacement;

    override public Vector3 getDisplacement(Vector3 ref_position) {return displacement;}
}

