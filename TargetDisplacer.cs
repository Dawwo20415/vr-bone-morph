using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDisplacer : MonoBehaviour
{
    // Attach this component to an empty object that acts as the second target for
    // Whatever you are pointing it to

    public DisplacementType[] displacements;

    public GameObject original_target;
    private Transform original_target_transform;
    private Transform obj_transform;

    void Awake()
    {
        original_target_transform = original_target.transform;
        obj_transform = gameObject.transform;
    }

    // Each frame take the position of the original target and apply the transforms
    void Update()
    {
        Vector3 position = original_target_transform.position;
        Quaternion rotation = original_target_transform.rotation;

        //Apply all transformations
        foreach (DisplacementType d in displacements)
        {
            position = d.apply(position);
        }


        obj_transform.position = position;
        obj_transform.rotation = rotation;

    }
}
