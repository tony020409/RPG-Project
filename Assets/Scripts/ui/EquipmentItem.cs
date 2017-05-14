using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItem : MonoBehaviour {

    public UISprite sprite;
    public int id;

    void Awake()
    {
       sprite = this.GetComponent<UISprite>();
    }


    public void SetId(int id) {
        this.id = id;
        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
    }
    public void SetInfo(ObjectInfo info) {
        this.id = info.id;

        sprite.spriteName = info.icon_name; 
    }
}
