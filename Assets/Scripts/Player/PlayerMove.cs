using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    private CharacterController playerCC;//主角角色控制器
    private Animator playerAnimator;//主角动画控制器
    public float speed = 4;//移动速度

	// Use this for initialization
	void Start () {
        playerCC = this.GetComponent<CharacterController>();
        playerAnimator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //h和v的取值以虚拟杆的取值为优先
        if (Joystick.h != 0 || Joystick.v != 0)
        {
            h = Joystick.h;
            v = Joystick.v;
        }
        if (Mathf.Abs(h)>0.1f || Mathf.Abs(v)>0.1f)//临界值判断
        {
            playerAnimator.SetBool("Walk", true);
            if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun") == true)//当主角动画处于PlayerRun时才可以实现移动控制 
            {
                //不论按下上下左右哪个键，其实都是往前移动，只是同时使其望向的目标点不同而已
                Vector3 targetPos = new Vector3(h, 0, v);
                this.transform.LookAt(targetPos + this.transform.position);
                playerCC.SimpleMove(this.transform.forward * speed);
            }
        }
        else
        {
            playerAnimator.SetBool("Walk", false);
        }
	}
}
