using UnityEngine;
using System.Collections;

public class Level2Door : MonoBehaviour {

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
            SpawnManager._instance.Level2SpawnEnemyFun();//第二关敌人的生成
            LevelHintsContiner._instance.Leve2EnterFun();//第二关提示信息的显示
        }
    }
}
