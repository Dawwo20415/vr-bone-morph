using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDisplacement : ScriptableObject
{
    virtual public void setup(GameObject obj) {}
    virtual public Vector3 getDisplacement(Vector3 ref_position) { return Vector3.zero;}
    virtual public Quaternion getAngularDisplacement(Quaternion ref_rotation) { return Quaternion.identity; }
}
