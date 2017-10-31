using UnityEngine;
using System.Collections;

public class UIAttackButtonChang : MonoBehaviour {

    public static UIAttackButtonChang _instance;//单例模式

    //持有三个按钮的引用
    public GameObject redAttack;
    private GameObject normalAttack; 
    private GameObject rangeAttack;

    private void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start () {
        normalAttack = GameObject.Find("NormalAttack");
        rangeAttack = GameObject.Find("RangeAttack");
	}

    public void ChangeToOneAttackButton() {//切换为一个攻击按钮（枪攻击时）
        redAttack.SetActive(true);
        normalAttack.SetActive(false);
        rangeAttack.SetActive(false);
    }

    public void ChangeToTwoAttackButton(){//切换为两个攻击按钮（剑攻击时）
        redAttack.SetActive(false);
        normalAttack.SetActive(true);
        rangeAttack.SetActive(true);
    }
}
