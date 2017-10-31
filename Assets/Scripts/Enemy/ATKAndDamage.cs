using UnityEngine;
using System.Collections;

//受到伤害的公共接口
public class ATKAndDamage : MonoBehaviour {

    public float hp = 100;
    public float normalAttack = 50;//普通攻击伤害值
    public float attackDistance = 1;//攻击距离
    private Animator animator;//动画控制器
    public AudioClip death;//死亡音效

    protected void Awake(){//申明为受保护的方便子类调用
        animator = this.GetComponent<Animator>();
    }

    public virtual void TakeDamage(float damage) //受到伤害的方法
    {
        if (this.hp > 0)
        {
            this.hp -= damage;
        }
        if (this.hp > 0)
        {
            if (this.tag == Tags.soulBoss1 || this.tag == Tags.soulBoss2 || this.tag == Tags.soulMonster)//如果是敌人受伤才播放受伤动画，主角不播放，因为主角播放的话会影响主角的攻击动画
            {
                animator.SetTrigger("Damage");
            }
        }
        else
        {
            animator.SetTrigger("Dead");
            if (this.tag == Tags.player)
            {
                SpawnManager._instance.isGameover = true;
                SpawnManager._instance.filedSprite.SetActive(true);//显示游戏失败UI
                SpawnManager._instance.isVictory = false;//表示游戏失败
                MenuContiner._instance.SetMenuPanelTrueFun();//显示游戏结束后菜单按钮
            }
            AudioSource.PlayClipAtPoint(death, this.transform.position, 1f);

            if (this.tag == Tags.soulBoss1 || this.tag == Tags.soulBoss2 || this.tag == Tags.soulMonster)//如果是敌人死亡，就在集合中移除敌人，同时销毁敌人，禁用敌人的CharacterController组件（因为该组件可能会影响主角的行走）
            {
                SpawnManager._instance.enemyList.Remove(this.gameObject);
                SpawnAwardItem(); //死亡后生成奖励物品
                this.GetComponent<CharacterController>().enabled = false;
                Destroy(this.gameObject, 1f);
            }
        }
        //实例化攻击特效
        if (this.tag == Tags.soulBoss1 || this.tag == Tags.soulBoss2)//如果受到打击的是SoulBoss，那就实例化打击SoulBoss的特效
        {
            GameObject.Instantiate(Resources.Load("HitBoss"), this.transform.position + Vector3.up, this.transform.rotation);
        }
        else if (this.tag == Tags.soulMonster)//如果受到打击的是SoulMonster，那就实例化打击SoulMonster的特效
        {
            GameObject.Instantiate(Resources.Load("HitMonster"), this.transform.position + Vector3.up, this.transform.rotation);
        }
    }

    void SpawnAwardItem() { //在敌人死亡后生成奖励物品
        int itemCount = Random.Range(0, 2);//奖励物品随机个数0个，1个，2个
        for (int i = 0; i < itemCount; i++)
        {
            int itemIndex = Random.Range(0, 2);//奖励物品类型随机生成
            if (itemIndex == 0)
            {
                GameObject.Instantiate(Resources.Load("Item_DualSword"), this.transform.position + Vector3.up, Quaternion.identity);
            }
            else if (itemIndex == 1)
            {
                GameObject.Instantiate(Resources.Load("Item_Gun"), this.transform.position + Vector3.up, Quaternion.identity);
            }
        }
    }
}
