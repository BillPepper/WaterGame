using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public Transform Target;

    private LineRenderer ownLine;

    private void Start()
    {
        ownLine = GetComponent<LineRenderer>();
        ownLine.SetPosition(0, this.transform.parent.transform.position);
        ownLine.SetPosition(1, Target.position);
    }
}
