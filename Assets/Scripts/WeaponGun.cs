using UnityEngine;
using System.Collections;

public class WeaponGun : MonoBehaviour {

    public Transform bulletPos;//子弹发射位置
    public GameObject bulletPrefab;//需要实例化的子弹
    public float attack = 100;//枪的攻击力，也就是子弹的攻击力

    public void Shot() {//射击方法
        GameObject bulletGo = GameObject.Instantiate(bulletPrefab, bulletPos.position, transform.root.rotation) as GameObject;
        bulletGo.GetComponent<Bullet>().attack = this.attack;
    }
}
