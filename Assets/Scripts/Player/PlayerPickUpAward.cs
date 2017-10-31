using UnityEngine;
using System.Collections;

public class PlayerPickUpAward : MonoBehaviour {

    public GameObject singleSwordGo;
    public GameObject dualSwordGo;
    public GameObject gunGo;

    public float exitTime = 10;//切换武器后武器存在的时间
    private float dualSwordTimer = 0;//双刃剑存在的计时器
    private float gunTimer = 0;//枪存在的计时器

    public AudioClip pickeUpItem;//捡到奖励物品音效

    void Update()
    {
        if (dualSwordTimer > 0)
        {
            dualSwordTimer -= Time.deltaTime;
            if (dualSwordTimer <= 0)
            {
                ChangeToSingleSword();
            }
        }
        if (gunTimer > 0)
        {
            gunTimer -= Time.deltaTime;
            if (gunTimer <= 0)
            {
                ChangeToSingleSword();
            }
        }
    }

    public void PickeUpAward(ItemType type) {//主角拾取奖励物品
        AudioSource.PlayClipAtPoint(pickeUpItem, this.transform.position, 1f);//播放捡到奖励物品的音效
        if (type == ItemType.DualSword)//捡到双刃剑切换的奖励物品，切换为双刃剑
        {
            ChangeToDualSword();
        }
        else if (type == ItemType.Gun)//捡到枪切换的奖励物品，切换为枪
        {
            ChangeToGun();
        }
    }

    void ChangeToDualSword() {//切换为双刃剑
        singleSwordGo.SetActive(false);
        dualSwordGo.SetActive(true);
        gunGo.SetActive(false);
        dualSwordTimer = exitTime;
        gunTimer = 0;
        UIAttackButtonChang._instance.ChangeToTwoAttackButton();//攻击按钮变成两个
    }
    void ChangeToGun() {//切换为枪
        singleSwordGo.SetActive(false);
        dualSwordGo.SetActive(false);
        gunGo.SetActive(true);
        gunTimer = exitTime;
        dualSwordTimer = 0;
        UIAttackButtonChang._instance.ChangeToOneAttackButton();//攻击按钮变成一个
    }
    void ChangeToSingleSword(){ //切换为单刃剑
        singleSwordGo.SetActive(true);
        dualSwordGo.SetActive(false);
        gunGo.SetActive(false);
        gunTimer = 0;
        dualSwordTimer = 0;
        UIAttackButtonChang._instance.ChangeToTwoAttackButton(); //攻击按钮变成两个
    }
    }
