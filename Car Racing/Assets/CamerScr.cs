using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerScr : MonoBehaviour
{
    public Transform PlayerPos;

    void Update()
    {
        transform.position = PlayerPos.position;
        transform.rotation = PlayerPos.rotation;
    }
}
