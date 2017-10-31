using UnityEngine;
using System.Collections;

public class Level3Door : MonoBehaviour {

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
            SpawnManager._instance.Level3SpawnEnemyFun();//第三关敌人的生成
            LevelHintsContiner._instance.Leve3EnterFun();//第三关提示信息的显示
        }
    }

}
