using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurSorManager : MonoBehaviour {

    public static CurSorManager _instance;

    public Texture2D cursor_normal;
    public Texture2D cursor_npc_talk;
    public Texture2D cursor_lockTarget;
    public Texture2D cursor_pick;

    private Vector2 hostpot = Vector2.zero;
    private CursorMode mode = CursorMode.Auto;

    void Start()
    {
        _instance = this;
    }

    public void SetNormal() {
        Cursor.SetCursor(cursor_normal, hostpot, mode);

            
    }
    public void SetNpcTalk() {
        Cursor.SetCursor(cursor_npc_talk, hostpot, mode);
    }
}


