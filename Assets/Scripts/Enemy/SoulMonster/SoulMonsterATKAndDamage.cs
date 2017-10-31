using UnityEngine;
using System.Collections;

public class SoulMonsterATKAndDamage : ATKAndDamage {

    private Transform player;//主角

    // Use this for initialization
    void Awake(){
        base.Awake();
        player = GameObject.FindWithTag(Tags.player).transform;
    }

    public void MonAttack() {//在Monster攻击动画中添加的触发事件
        if (Vector3.Distance(transform.position,player.transform.position)<attackDistance)
        {
            player.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }
}
