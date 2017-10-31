using UnityEngine;
using System.Collections;

public class SoulBossATKAndDamage : ATKAndDamage {
    private Transform player;//主角
    public AudioClip bossAttack;//Boss攻击音效

    // Use this for initialization
    void Awake()
    {
        base.Awake();
        player = GameObject.FindWithTag(Tags.player).transform;
    }

    public void Attack1(){//在Boss攻击1动画中添加的触发事件
        if (Vector3.Distance(transform.position, player.transform.position) < attackDistance)
        {
            AudioSource.PlayClipAtPoint(bossAttack, this.transform.position, 1f);
            player.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }

    }
    public void Attack2() {//在Boss攻击2动画中添加的触发事件
        if (Vector3.Distance(transform.position, player.transform.position) < attackDistance)
        {
            AudioSource.PlayClipAtPoint(bossAttack, this.transform.position, 1f);
            player.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }
}
