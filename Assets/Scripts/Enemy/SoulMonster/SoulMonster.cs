 using UnityEngine;
using System.Collections;

public class SoulMonster : MonoBehaviour{

    private Transform playerTrs;//需要跟踪的主角位置
    private PlayerATKAndDamage playerATKAndDamage;//主角的攻击和受伤脚本
    private CharacterController cc;//Monster的角色控制器
    private Animator animator;//动画控制器

    public float attackDistance = 2.0f;//Monster的攻击距离
    public float moveSpeed = 2.0f;//Monster的移动速度

    public float attackTime = 3.0f;//攻击时间，每3秒攻击一次
    private float attackTimer = 0f;//攻击计时器

	// Use this for initialization
	void Start () {
        playerTrs = GameObject.FindGameObjectWithTag(Tags.player).transform;
        playerATKAndDamage = playerTrs.GetComponent<PlayerATKAndDamage>();
        cc = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
        attackTimer = attackTime;//使Boss一开始到达攻击距离的时候第一次就马上攻击，而不是再等3秒才攻击
	}
	
	// Update is called once per frame
	void Update () {
        if (playerATKAndDamage.hp <= 0)//主角死后保存静止状态，不再进行攻击
        {
            animator.SetBool("Walk", false);
            return;
        }
        Vector3 targetPos = playerTrs.position;
        targetPos.y = this.transform.position.y;//固定y轴的高度不变
        this.transform.LookAt(targetPos);
        float distance = Vector3.Distance(this.transform.position, targetPos);
        if (distance<= attackDistance)//在攻击距离之内可以攻击主角
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackTime)//达到攻击时间，开始随机攻击
            {

                animator.SetTrigger("Attack");
                attackTimer = 0;//攻击完成，计时器归零
            }
            else//不攻击时处于Idle状态
            {
                animator.SetBool("Walk", false);
            }
        }
        else //在攻击距离之外，跟踪主角
        {
            attackTimer = attackTime;//在非攻击状态下设置计时器达到时间，这样进入攻击范围的时候可以直接进行攻击，而不再等待3秒
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("MonRun"))
            {
                cc.SimpleMove(transform.forward * moveSpeed);
            } 
            animator.SetBool("Walk", true);
        }
	}
}
