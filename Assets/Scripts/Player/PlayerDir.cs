using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDir : MonoBehaviour {

    public GameObject effect_click_prefab;
    private bool isMoving = false; //表示鼠標是否按下
    public Vector3 targetPosition = Vector3.zero;
    private PlayerMove playerMove;
    
   void Start()
    {
        targetPosition = transform.position;
        playerMove = this.GetComponent<PlayerMove>();
    }

   
    void Update () {
        
        if (Input.GetMouseButtonDown(0) && UICamera.hoveredObject.layer != LayerMask.NameToLayer("UILayer")) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider && hitInfo.collider.tag == Tags.ground) {
                isMoving = true;
                ShowClickEffect(hitInfo.point);
                LookAtTarget(hitInfo.point);
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            isMoving = false;
        }

        if (isMoving)
        {
            //得到要移動的目標位置
            //讓主角朝向目標位置
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider && hitInfo.collider.tag == Tags.ground)
            {
                LookAtTarget(hitInfo.point);
            }

        }
        else {
            if (playerMove.isMoving) {
                LookAtTarget(targetPosition);
            }

        }
	}
    //實例化出來點擊的效果
    void ShowClickEffect(Vector3 hitPoint) {
        hitPoint = new Vector3(hitPoint.x, hitPoint.y + 0.1f, hitPoint.z);
        GameObject.Instantiate(effect_click_prefab, hitPoint, Quaternion.identity);
    }
    //讓主角朝向目標位置
    void LookAtTarget(Vector3 hitPoint) {
        targetPosition = hitPoint;
        targetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        this.transform.LookAt(targetPosition);
    }
}
