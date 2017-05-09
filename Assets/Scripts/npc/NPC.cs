using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    void OnMouseEnter()
    {
        CurSorManager._instance.SetNpcTalk();
    }
    void OnMouseExit()
    {
        CurSorManager._instance.SetNormal();
    }
}
