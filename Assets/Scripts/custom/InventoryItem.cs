using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : UIDragDropItem {

    private UISprite sprite;
    private int id;

    protected override void Awake()
    {
        base.Awake();
        sprite = this.GetComponent<UISprite>();
    }

    protected override void Update()
    {
        base.Update();
        if (isHover) {
            //顯示提示訊息
            InventoryDes._instance.Show(id);


            if (Input.GetMouseButtonDown(1)) {
                //出來穿戴功能
                bool success = EquipmentUI._instance.Dress(id);
                if (success) {
                    transform.parent.GetComponent<InventoryItemGrid>().MinusNumber();
                }
            }
        }
    }


    protected override void OnDragDropRelease(GameObject surface) {
        base.OnDragDropRelease(surface);
        if (surface != null)
        {
            
           
            if (surface.tag == Tags.inventory_item_grid){//當拖放到一個空的格子裡面
                if (surface == this.transform.parent.gameObject){//拖放到了自己的格子裡面
                    
                }
                else{
                    InventoryItemGrid oldParent = this.transform.parent.GetComponent<InventoryItemGrid>();
                    

                    this.transform.parent = surface.transform;ResetPosition();
                    InventoryItemGrid newParent = surface.GetComponent<InventoryItemGrid>();
                    newParent.SetId(oldParent.id, oldParent.num);

                    oldParent.ClearInfo();
                }
            }else if (surface.tag == Tags.inventory_item){//當拖放到了一個有物品的格子裡面
               
                InventoryItemGrid grid1 = this.transform.parent.GetComponent<InventoryItemGrid>();
                InventoryItemGrid grid2 = surface.transform.parent.GetComponent<InventoryItemGrid>();
                int id = grid1.id; int num = grid1.num;
                grid1.SetId(grid2.id, grid2.num); 
                grid2.SetId(id, num);

            }
            
        }

        ResetPosition();
    }

    void ResetPosition()
    {
        transform.localPosition = Vector3.zero;
    }


    public void SetId(int id) {
        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
        sprite.spriteName = info.icon_name;
    }

    public void SetIconName(int id,string icon_name)
    {
        sprite.spriteName = icon_name;
        this.id = id;
    }


    private bool isHover = false;

    public void OnHoverOver(){
        isHover = true;
    }
    public void OnHoverOut(){
        isHover = false;
    }
}
