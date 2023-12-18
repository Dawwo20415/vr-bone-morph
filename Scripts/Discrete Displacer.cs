using PlasticPipe.PlasticProtocol.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteDisplacer : MonoBehaviour
{
    public GameObject reference_object;
    private Transform ref_transform;
    private Transform own_transform;

    public GameObject[] displacement_references;
    public PointDisplacement[] operations;

    void Awake()
    {
        ref_transform = reference_object.transform;
        own_transform = gameObject.transform;

        for (int i = 0; i < operations.Length; i++)
        {
            if (displacement_references[i])
                operations[i].setup(displacement_references[i]);
        }
    }

    public void computeDisplacement()
    {
        Vector3 displacement = Vector3.zero;
        Quaternion angular_displacement = Quaternion.identity;
        foreach (PointDisplacement op in operations)
        {
            displacement += op.getDisplacement(own_transform.position);
            angular_displacement *= op.getAngularDisplacement(own_transform.rotation);
        }

        own_transform.position = ref_transform.position + displacement;
        own_transform.rotation = ref_transform.rotation * angular_displacement;
    }

    public List<int> CheckReferences()
    {
        List<int> brokenOperations = new List<int>();

        if (operations.Length != displacement_references.Length)
        {
            brokenOperations.Add(1);
            return brokenOperations;
        }
        else
        {
            brokenOperations.Add(0);
        }

        for (int i = 0; i < operations.Length; i++)
        {
            if (operations[i].NeedSetup)
                if (displacement_references[i] == null)
                {
                    //Debug.LogWarning("Operation #" + (i+1) + " necessitates a reference object but found none.");
                    brokenOperations.Add(i);
                }
        }

        return brokenOperations;
    }
}
