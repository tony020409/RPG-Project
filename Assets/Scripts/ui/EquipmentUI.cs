using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour {

    public static EquipmentUI _instance;
    private TweenPosition tween;
    private bool isShow = false;

    private GameObject heargear;
    private GameObject armor;
    private GameObject rightHand;
    private GameObject leftHand;
    private GameObject shoe;
    private GameObject accessory;

    private PlayerStatus ps;

    public GameObject equipmentItem;
    

    void Awake()
    {
        _instance = this;
        tween = this.GetComponent<TweenPosition>();
        heargear = transform.Find("Headgear").gameObject;
        armor = transform.Find("Armor").gameObject;
        rightHand = transform.Find("RightHand").gameObject;
        leftHand = transform.Find("LeftHand").gameObject;
        shoe = transform.Find("Shoe").gameObject;
        accessory = transform.Find("Accessory").gameObject;

        ps = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();

    }

    public void TransformState() {
        if (isShow == false) {
            tween.PlayForward();
            isShow = true;
        }
        else{
            tween.PlayReverse();
            isShow = false;
        }
    }
    //處理裝備穿戴功能
    public bool Dress(int id) {
        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
        if (info.type != ObjectType.Equip) {
            return false;//穿戴不成功
        }
        if (ps.heroType == HeroType.Magician) {
            if (info.applicationType == ApplicationType.Swordman) {
                return false;
            }
        }
        if (ps.heroType == HeroType.Swordman) {
            if (info.applicationType == ApplicationType.Magician)
            {
                return false;
            }
        }

        GameObject parent = null;
        switch (info.dressType)
        {
            case DressType.Headgear:
                parent = heargear;
                break;
            case DressType.Armor:
                parent = armor;
                break;
            case DressType.RightHand:
                parent = rightHand;
                break;
            case DressType.LeftHand:
                parent = leftHand;
                break;
            case DressType.Shoe:
                parent = shoe;
                break;
            case DressType.Accessory:
                parent = accessory;
                break;


        }

        EquipmentItem item = parent.GetComponentInChildren<EquipmentItem>();
        if (item != null)
        {//說明已經穿戴了同樣類型的裝備
            Inventory._instance.Getid(item.id);//把已經穿戴的裝備卸下,放回物品欄
            item.SetInfo(info);

        }
        else
        {//沒有穿戴同樣類型的裝備
            GameObject itemGo = NGUITools.AddChild(parent, equipmentItem);
            itemGo.transform.localPosition = Vector3.zero;
            itemGo.GetComponent<EquipmentItem>().SetInfo(info);
        }
        return true;
    }
}
