using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaterCreation : MonoBehaviour {

    public GameObject[] characterPrefabs;
    public UIInput nameInput ;//用來得到輸入的文本
    private GameObject[] characterGameObjects;
    private int selectedIndex = 0;
    private int length;//所有可供選擇的角色的個數

	// Use this for initialization
	void Start () {
        length = characterPrefabs.Length;
        characterGameObjects = new GameObject[length];
        for (int i = 0; i < length; i++) {
            characterGameObjects[i] = GameObject.Instantiate(characterPrefabs[i], transform.position, transform.rotation) as GameObject;
        }
        UpdateCharacterShow(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateCharacterShow()
    {//更新所有角色的顯示
        characterGameObjects[selectedIndex].SetActive(true);
        for (int i = 0; i < length; i++)
        {
            if (i != selectedIndex){
            characterGameObjects[i].SetActive(false);//把未選擇的角色為隱藏

            }
        }
    }

    public void OnNextButtonClick() {//當我們點擊了下一個按鈕
        selectedIndex++;
        selectedIndex %= length;
        UpdateCharacterShow();
    }
    public void OnPrevButtonClick(){//當我們點擊了上一個按鈕
        selectedIndex--;
        if (selectedIndex == -1) {
            selectedIndex = length - 1;
        }
        UpdateCharacterShow();
    }
    public void OnOkButtonClick() { 
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedIndex);//存檔選擇的角色
        PlayerPrefs.SetString("name", nameInput.value);//存儲輸入的名字
        //加載下一個場景

    }
}
