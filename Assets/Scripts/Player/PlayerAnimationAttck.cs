using UnityEngine;
using System.Collections;

public class PlayerAnimationAttck : MonoBehaviour {

    private Animator playerAnimator;//主角的动画控制器组件
    private bool isCanAttackB = false;//是否能从攻击状态A转换为攻击状态B（也就是是否能连招）
	// Use this for initialization
	void Start () {

        playerAnimator = this.GetComponent<Animator>();

        //通过事件委托动态地向各个攻击按钮中添加相应的点击事件
        EventDelegate normalAttackEvent = new EventDelegate(this,"OnNormalAttackClick");//普通攻击按钮事件的添加
        GameObject.Find("NormalAttack").GetComponent<UIButton>().onClick.Add(normalAttackEvent);

        EventDelegate rangeAttackEvent = new EventDelegate(this, "OnRangeAttackClick");//大范围攻击按钮事件的添加
        GameObject.Find("RangeAttack").GetComponent<UIButton>().onClick.Add(rangeAttackEvent);
        
         
        EventDelegate redAttackEvent = new EventDelegate(this, "OnRedAttackClick");//变身之后红色攻击按钮事件的添加
        GameObject redAttack = GameObject.Find("RedAttack");
        redAttack.GetComponent<UIButton>().onClick.Add(redAttackEvent);
        redAttack.SetActive(false);
    }

    public void OnNormalAttackClick()//普通攻击按钮事件
    {
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackA") && isCanAttackB == true)//如果动画处于AttackA并且可以进行AttackB的连招，那就触发连招攻击
        {
            playerAnimator.SetTrigger("AttackB");
        }
        else
        {
            playerAnimator.SetTrigger("AttackA");
        }
    }

    public void OnRangeAttackClick() //大范围攻击按钮事件
    {
        playerAnimator.SetTrigger("AttackRange");
    }

    public void OnRedAttackClick()//变身之后红色攻击按钮事件
    {
        playerAnimator.SetTrigger("AttackGun");
    }

    //下列两个事件表示在AttackA攻击时设定的动画时间区间可以进行连招
    public void AttackBEvenStart() //该事件是在AttackA动画中定义的，在播放AttackA动画时自己会触发
    {
        isCanAttackB = true;
    }

    public void AttackBEventEnd() //该事件也是在AttackA动画中定义的，在播放AttackA动画时自己会触发
    {
        isCanAttackB = false;
    }
}
