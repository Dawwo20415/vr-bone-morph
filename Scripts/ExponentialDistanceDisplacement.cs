using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Exponential Distance Displacement", menuName="ScriptableObjects/Point Displacement/Exponential Distance")]
public class ExponentialDistanceDisplacement : PointDisplacement
{
    [SerializeField]
    private float target_distance;
    [SerializeField]
    private float slope;
    [SerializeField]
    private float path;
    [SerializeField]
    private Vector3 direction;

    private Transform origin;

    override public void setup(GameObject obj) {
        origin = obj.transform;
    }
    
    override public Vector3 getDisplacement(Vector3 ref_position) {
        float distance = (origin.position - ref_position).magnitude;

        // y = a * (1-e^(-k|x|^c))
        float displacement = target_distance * (1 - Mathf.Exp(- slope * Mathf.Pow(Mathf.Abs(distance), path)));
    
        return direction.normalized * displacement;
    
    }
}
