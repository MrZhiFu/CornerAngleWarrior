using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerATKAndDamage : ATKAndDamage {

    public float attackB = 80;//B攻击的攻击力为80
    public float attackRange = 100;//大范围攻击的攻击力为100
    public float attackGun = 100;//枪的攻击力
    public WeaponGun weaponGun;//枪攻击脚本
    public AudioClip gunShot;//打枪的音效
    public AudioClip swordSwing;//用剑的音效


    public void AttackA() {//朝着离主角最近的敌人进行攻击
        AudioSource.PlayClipAtPoint(swordSwing, this.transform.position, 1f);//播放用剑的音效
        GameObject enemy = null;
        float distance = this.attackDistance;
        foreach (GameObject go in SpawnManager._instance.enemyList)
        {
            float temp = Vector3.Distance(go.transform.position, this.transform.position);
            if (temp < distance )
            {
                enemy = go;
                distance = temp;
            }
        }
        if (enemy != null)
        {
            Vector3 targetPos = enemy.transform.position;
            targetPos.y = this.transform.position.y;
            this.transform.LookAt(targetPos);//使主角望向距离最近的敌人并开始攻击
            enemy.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }
    public void AttackB(){//攻击方式同AttackA一样，朝着离主角最近的敌人进行攻击只是攻击力的不同
        AudioSource.PlayClipAtPoint(swordSwing, this.transform.position, 1f);//播放用剑的音效
        GameObject enemy = null;
        float distance = this.attackDistance;
        foreach (GameObject go in SpawnManager._instance.enemyList)
        {
            float temp = Vector3.Distance(go.transform.position, this.transform.position);
            if (temp < distance)
            {
                enemy = go;
                distance = temp;
            }
        }
        if (enemy != null)
        {
            Vector3 targetPos = enemy.transform.position;
            targetPos.y = this.transform.position.y;
            this.transform.LookAt(targetPos);//使主角望向距离最近的敌人并开始攻击
            enemy.GetComponent<ATKAndDamage>().TakeDamage(attackB);
        }
    } 

    public void AttackRange() {//大范围攻击
        AudioSource.PlayClipAtPoint(swordSwing, this.transform.position, 1f);//播放用剑的音效
        List<GameObject> enemyTempList = new List<GameObject>();//存储敌人的临时集合，因为不能在原来集合中同时一边遍历一边修改（Remove）
        foreach (GameObject go in SpawnManager._instance.enemyList)
        {
            float temp = Vector3.Distance(go.transform.position, this.transform.position);
            if (temp < attackDistance)
            {
                enemyTempList.Add(go);
             // go.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
            }    
        }
        foreach (GameObject item in enemyTempList)
        {
            item.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
        }
    }
    public void AttackGun() {//用枪攻击
        weaponGun.attack = attackGun;
        AudioSource.PlayClipAtPoint(gunShot, this.transform.position, 1f);//播放打枪的音效
        weaponGun.Shot();
    }
}
