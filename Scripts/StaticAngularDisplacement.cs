using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Static Angular Displacement", menuName = "ScriptableObjects/Point Displacement/Static Quaternion")]
public class StaticAngularDisplacement : PointDisplacement
{
    [SerializeField]
    private Vector3 angular_displacement;

    override public Quaternion getAngularDisplacement(Quaternion ref_position) { return Quaternion.Euler(angular_displacement); }
}
