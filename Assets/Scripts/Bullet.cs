using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed = 10;//子弹的速度
    public float attack = 100;//子弹的攻击力

    private void Start()
    {
        Destroy(this.gameObject,3f);//子弹实例化出来3秒后自动销毁
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)//触发检测，如果碰到的是敌人，敌人就掉血
    {
        if (other.tag == Tags.soulBoss1 || other.tag == Tags.soulBoss2 || other.tag == Tags.soulMonster)
        {
            other.GetComponent<ATKAndDamage>().TakeDamage(attack);
        }
    }
}
