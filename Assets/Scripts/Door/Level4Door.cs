using UnityEngine;
using System.Collections;

public class Level4Door : MonoBehaviour {

    private Animator animator;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.player)
        {
            animator.SetTrigger("ToTranslate");
            SpawnManager._instance.Level4pawnEnemyFun();//第四关敌人的生成
            LevelHintsContiner._instance.Leve4EnterFun();//进入第四关提示信息的显示
        }
    }

}
