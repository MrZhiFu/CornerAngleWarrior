using UnityEngine;
using System.Collections;

public class HeadState : MonoBehaviour {

    private UISlider hpBar;//主角血条
    private PlayerATKAndDamage playerATK;//主角的攻击和伤害脚本
	// Use this for initialization
	void Awake () {
        hpBar = GameObject.Find("HeadState/HPBar").GetComponent<UISlider>();
        playerATK = GameObject.FindWithTag(Tags.player).GetComponent<PlayerATKAndDamage>();
	}

    private void Update()
    {
        hpBar.value = playerATK.hp/100;
    }
}
