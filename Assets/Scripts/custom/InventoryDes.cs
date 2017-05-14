using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDes : MonoBehaviour {


    public static InventoryDes _instance;
    private UILabel label;
    private float timer = 0;

	// Use this for initialization
	void Awake() {
        _instance = this;
        label = this.GetComponentInChildren<UILabel>();
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.activeInHierarchy == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                this.gameObject.SetActive(false);
            }
        }
	}

    public void Show(int id) {
        this.gameObject.SetActive(true);timer = 0.1f;
        transform.position = UICamera.currentCamera.ScreenToWorldPoint(new Vector3( Input.mousePosition.x+100, Input.mousePosition.y-100, Input.mousePosition.z));
        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
        string des = "";
        switch (info.type) {

            case ObjectType.Drug:
                des = GetDrugDes(info);
                break;
            case ObjectType.Equip:
                des = GetEqipDes(info);
                break;
        }
        label.text = des;
    }

    string GetDrugDes(ObjectInfo info) {

        string str = "";
        str += "名稱 : " + info.name + "\n";
        str += "+ HP : " + info.hp + "\n";
        str += "+ MP : " + info.mp + "\n";
        str += "出售價  : " + info.price_sell + "\n";
        str += "購買價  : " + info.price_buy ;
        

        return str;
    }
    string GetEqipDes(ObjectInfo info) {
        string str = "";
        str += "名稱 : " + info.name + "\n";
        switch (info.dressType) {
            case DressType.Headgear:
                str+="穿戴類型 : 頭盔\n";
                break;
            case DressType.Armor:
                str += "穿戴類型 : 盔甲\n";
                break;
            case DressType.LeftHand:
                str += "穿戴類型 : 左手\n";
                break;
            case DressType.RightHand:
                str += "穿戴類型 : 右手\n";
                break;
            case DressType.Shoe:
                str += "穿戴類型 : 鞋子\n";
                break;
            case DressType.Accessory:
                str += "穿戴類型 : 飾品\n";
                break;
        }
        switch (info.applicationType) {
            case ApplicationType.Swordman:
                str += "適用類型 : 劍士\n";
                break;
            case ApplicationType.Magician:
                str += "適用類型 : 魔法師\n";
                break;
            case ApplicationType.Common:
                str += "適用類型 : 通用\n";
                break;
        }

        str += "傷害值 : " + info.attack + "\n";
        str += "防禦值 : " + info.def + "\n";
        str += "速度值 : " + info.speed + "\n";

        str += "出售價 : " + info.price_sell + "\n";
        str += "購買價 : " + info.price_buy;
        return str;
    }

}
