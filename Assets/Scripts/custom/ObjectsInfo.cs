using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInfo : MonoBehaviour {


    public static ObjectsInfo _instance;

    private Dictionary<int, ObjectInfo> objectinfoDict = new Dictionary<int, ObjectInfo>();

    public TextAsset objectsInfoListText;

    void Awake()
    {
        _instance = this;
        ReadInfo();
        //print(objectinfoDict.Keys.Count);
        
    }
    public ObjectInfo GetObjectInfoById(int id) {
        ObjectInfo info = null;

        objectinfoDict.TryGetValue(id, out info);

        return info;
    }



    void ReadInfo() {
        string text = objectsInfoListText.text;
        string[] strArray = text.Split('\n');

        foreach (string str in strArray) {
            string[] proArray = str.Split(',');
            ObjectInfo info = new ObjectInfo();


            int id = int.Parse(proArray[0]); 
            string name = proArray[1];
            string icon_name = proArray[2];
            string str_type = proArray[3];
            ObjectType type = ObjectType.Drug;

            switch (str_type) {
                case "Drug":
                    type = ObjectType.Drug;
                    break;
                case "Equip":
                    type = ObjectType.Equip;
                    break;
                case "Mat":
                    type = ObjectType.Mat;
                    break;


            }
            info.id = id;info.name = name;info.icon_name = icon_name;
            info.type = type;
            if (type == ObjectType.Drug) {
                int hp = int.Parse(proArray[4]);
                int mp = int.Parse(proArray[5]);
                int price_sell = int.Parse(proArray[6]);
                int price_buy = int.Parse(proArray[7]);
                info.hp = hp; info.mp = mp;
                info.price_buy = price_buy; info.price_sell = price_sell;
            } else if (type == ObjectType.Equip) {
                info.attack = int.Parse(proArray[4]);
                info.def = int.Parse(proArray[5]);
                info.speed = int.Parse(proArray[6]);
                info.price_sell = int.Parse(proArray[9]);
                info.price_buy = int.Parse(proArray[10]);
                string str_dresstype = proArray[7];
                switch (str_dresstype) {
                    case "Heargear":
                        info.dressType = DressType.Headgear;
                        break;
                    case "Armor":
                        info.dressType = DressType.Armor;
                        break;
                    case "LeftHand":
                        info.dressType = DressType.LeftHand;
                        break;
                    case "RightHand":
                        info.dressType = DressType.RightHand;
                        break;
                    case "Shoe":
                        info.dressType = DressType.Shoe;
                        break;
                    case "Accessory":
                        info.dressType = DressType.Accessory;
                        break;
                }
                string str_apptype = proArray[8];
                switch (str_apptype) {
                    case "Swordman":
                        info.applicationType = ApplicationType.Swordman;
                        break;
                    case "Magician":
                        info.applicationType = ApplicationType.Magician;
                        break;
                    case "Common":
                        info.applicationType = ApplicationType.Common;
                        break;



                }


            }

            objectinfoDict.Add(id, info);//添加到字典中,id為key,可以很方便的根據id查找到物品訊息
        }

    }
}




    //id
    //名稱
    //icon名稱
    //類型(藥品drag)
    //加血量值
    //加魔法值
    //出售價
    //販售
    public enum ObjectType {
        Drug,
        Equip,
        Mat
    }

    public enum DressType {
        Headgear,
        Armor,
        RightHand,
        LeftHand,
        Shoe,
        Accessory
    }
    public enum ApplicationType {
        Swordman,//劍士
        Magician,//魔法師
        Common//通用
    }

    public class ObjectInfo {
        public int id;
        public string name;
        public string icon_name;//這個名稱是儲存在圖集中的名稱
        public ObjectType type;
        public int hp;
        public int mp;
        public int price_sell;
        public int price_buy;

        public int attack;
        public int def;
        public int speed;
        public DressType dressType;
        public ApplicationType applicationType;

    }

