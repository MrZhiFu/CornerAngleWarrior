using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    private Transform playerTrs;//主角位置
    public float moveSpeed = 2;//移动速度

	// Use this for initialization
	void Start () {
        playerTrs = GameObject.FindGameObjectWithTag(Tags.player).transform;
	}
	
	// Update is called once per frame
	void Update () {
        //位移跟随
        Vector3 targetPos = playerTrs.position + new Vector3(0f, 3f, -3f);
        this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
        
        //角度跟随（使摄像机一直注视着主角）
        //在主角和摄像机当前位置之间创建一个旋转角度，使用插值运算使摄像机注视主角
        Quaternion targetRotation = Quaternion.LookRotation(playerTrs.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, moveSpeed * Time.deltaTime);
	}
}
