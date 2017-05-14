using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


    public static Inventory _instance;
    private TweenPosition tween;
    private int coinCount = 1000;//金幣數量


    public List<InventoryItemGrid> itemGridList = new List<InventoryItemGrid>();
    public UILabel coinNumberLabel;
    public GameObject inventoryItem;


	// Use this for initialization
	void Awake () {
        _instance = this;
        tween = this.GetComponent<TweenPosition>();
        

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) {
            Getid(Random.Range(2001, 2023));
        }
    }

    //拾取到id的物品,並添加到物品欄裡面
    //處理拾取物品的功能
    public void Getid(int id, int count =1) {
        //第一步是查找在所有的問題中是否存在該物品
        //第二如果存在,讓num+1
        
        InventoryItemGrid grid = null;
        foreach (InventoryItemGrid temp in itemGridList) {
            if (temp.id == id) {
                grid = temp; break; 

            }
        }
        if (grid != null){//存在的情況
            grid.PlusNumber(count);
        }
        else {//不存在的情況
            foreach (InventoryItemGrid temp in itemGridList) {
                if (temp.id == 0) {
                    grid = temp; break;
                }
            }
            if (grid != null){//第三如果不存在,查找空的方格,然後把新創建的IventoryItem放到這個空的方格裡面
                GameObject itemGo = NGUITools.AddChild(grid.gameObject, inventoryItem);
                itemGo.transform.localPosition = Vector3.zero;
                itemGo.GetComponent<UISprite>().depth = 4;
                grid.SetId(id,count);
            }
        }

    }

    private bool isShow = false;

    void Show() {
        isShow = true;
        tween.PlayForward();
    }

    void Hide() {
        isShow = false;
        tween.PlayReverse();
    }



    public void TransformState() {//轉變狀態
        if (isShow == false)
        {
            Show();
        }
        else {
            Hide();
        }
    }
    //這個是取款方法,返回true表示取款成功,返回true表示取款成功,返回false取款失敗
    public bool GetCoint(int count) {
        if (coinCount >= count) {
            coinCount -= count;
            coinNumberLabel.text = coinCount.ToString();//更新錢幣的顯示
            return true;
        }
        return false;
     }
}
