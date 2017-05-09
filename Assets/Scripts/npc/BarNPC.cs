using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarNPC : NPC {

    public TweenPosition questTween;
    public UILabel desLabel;
    public GameObject acceptBtnGo;
    public GameObject okBtnGo;
    public GameObject canelBtnGo;

    public bool isInTask = false;//表示是否在任務中
    public int killCount = 0;//表示任務進度,已經殺死了幾隻小野狼

    private PlayerStatus status;

    void Start()
    {
        status = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }


    void OnMouseOver()//當鼠標位於這個collider之上的時候,會在每一幀調用這個方法
    {
        if (Input.GetMouseButtonDown(0)) {//當點擊了老爺爺
            if (isInTask)
            {
                ShowTaskProgress();

            }
            else {
                ShowTaskDes();
            }
            ShowQuest();
        }
    }

    void ShowQuest() {
        questTween.gameObject.SetActive(true);
        questTween.PlayForward();
    }
    void HideQuest() {
        questTween.PlayReverse();
    }

    void ShowTaskDes() {
        desLabel.text = "任務 : \n殺死了10隻狼\n\n獎勵 :\n1000金幣";
        okBtnGo.SetActive(false);
        acceptBtnGo.SetActive(true);
        canelBtnGo.SetActive(true);
    }
    void ShowTaskProgress() {
        desLabel.text = "任務 : \n你已經殺死了" + killCount + "\\10隻狼\n\n獎勵 :\n1000金幣";
        okBtnGo.SetActive(true);
        acceptBtnGo.SetActive(false);
        canelBtnGo.SetActive(false);
    }


    //任務系統 任務對話框上的按鈕點擊時間的處理
    public void OnCloseButtonClick() {
        HideQuest(); 
    }

    public void OnAcceptButtonClick() {
        ShowTaskProgress();
        isInTask = true;//表示在任務中

    }
    public void OnOkButtonClick() {
        if (killCount >= 10)//完成任務
        {
            status.GetCoint(1000);
            killCount = 0;
            ShowTaskDes();
        }
        else{//沒有完成任務
            HideQuest();
        }
    }
    public void OnCanelButton() {
        HideQuest();
    }
    
}
