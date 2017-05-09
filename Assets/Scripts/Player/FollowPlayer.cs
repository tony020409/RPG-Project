using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private Transform player;
    private Vector3 offsetPosition;//位置偏移
    private bool isRotating = false;


    public float distance = 0;
    public float scrollSpeed = 10;
    public float rotateSpeed = 2;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player.position);
        offsetPosition = transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = offsetPosition + player.position;
        //處理視野的旋轉
        RotateView();
        //處理視野拉近和拉遠效果
        ScrollView();
    }

    void ScrollView() {
        //print(Input.GetAxis("Mouse ScrollWheel"));//向後 返回負值(拉近視野) 向前 返回正值(拉遠視野)
        distance = offsetPosition.magnitude;
        distance += Input.GetAxis("Mouse ScrollWheel");
        offsetPosition = offsetPosition.normalized * distance;
    }
    void RotateView() {
        //Input.GetAxis("Mouse X")//得到鼠標在水平方向的滑動
        //Input.GetAxis("Mouse Y")//得到鼠標在垂直方向的滑動
        if (Input.GetMouseButtonDown(1)) {
            isRotating = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }
        if (isRotating)
        {
            transform.RotateAround(player.position,player.up, rotateSpeed * Input.GetAxis("Mouse X"));

            Vector3 originalPos = transform.position;
            Quaternion orginalRotation = transform.rotation;

            transform.RotateAround(player.position, transform.right, -rotateSpeed * Input.GetAxis("Mouse Y"));//影響的屬性有兩個 一個是position 一個是rotation

            float x = transform.eulerAngles.x;
            if (x < 10 || x > 80) {//當超出範圍之後,我們將屬性歸為原來的,就是讓旋轉無效
                transform.position = originalPos;
                transform.rotation = orginalRotation;
            }
            x = Mathf.Clamp(x, 10, 80);
            transform.eulerAngles = new Vector3(x, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        offsetPosition = transform.position - player.position;

    }
}
