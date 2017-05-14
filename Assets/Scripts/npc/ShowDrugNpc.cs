using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDrugNpc : NPC {

    private new AudioSource audio;

    void Awake()
    {
        audio = this.GetComponent<AudioSource>();
    }


    public void OnMouseOver(){//當鼠標在這個遊戲物體之上的時候，會一直調用這個方法
        if (Input.GetMouseButtonDown(0) && UICamera.hoveredObject.layer != LayerMask.NameToLayer("UILayer"))//彈出來藥品販賣列表
        {
            audio.Play();
            ShopDrug._instance.TransformState();
        }
    }
}
