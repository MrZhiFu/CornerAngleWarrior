using UnityEngine;
using System.Collections;

public class LevelHintsContiner : MonoBehaviour {
    public static LevelHintsContiner _instance;
    public GameObject level1HintGo;//进入关卡1显示的提示
    public GameObject level2HintGo;//进入关卡2显示的提示
    public GameObject level3HintGo;//进入关卡3显示的提示
    public GameObject level4HintGo;//进入关卡4显示的提示

    private Animator animator;

    // Use this for initialization
    void Awake () {
        _instance = this;
        animator = this.GetComponent<Animator>();
	}

    public void Leve1EnterFun(){//进入关卡1是显示提示信息
        StartCoroutine(Level1Enter());
    }

    IEnumerator Level1Enter()
    {
        level1HintGo.SetActive(true);
        level2HintGo.SetActive(false);
        level3HintGo.SetActive(false);
        level4HintGo.SetActive(false);
        animator.SetTrigger("Enter");
        yield return new WaitForSeconds(3f);
        animator.SetTrigger("Exit");
    }
    public void Leve2EnterFun(){//进入关卡2是显示提示信息
        StartCoroutine(Level2Enter());
    }

    IEnumerator Level2Enter()
    {
        level1HintGo.SetActive(false);
        level2HintGo.SetActive(true);
        level3HintGo.SetActive(false);
        level4HintGo.SetActive(false);
        animator.SetTrigger("Enter");
        yield return new WaitForSeconds(3f);
        animator.SetTrigger("Exit");
    }

    public void Leve3EnterFun(){//进入关卡3是显示提示信息
        StartCoroutine(Level3Enter());
    }

    IEnumerator Level3Enter()
    {
        level1HintGo.SetActive(false);
        level2HintGo.SetActive(false);
        level3HintGo.SetActive(true);
        level4HintGo.SetActive(false);
        animator.SetTrigger("Enter");
        yield return new WaitForSeconds(3f);
        animator.SetTrigger("Exit");
    }

    public void Leve4EnterFun(){//进入关卡4是显示提示信息
        StartCoroutine(Level4Enter());
    }

   IEnumerator Level4Enter()
    {
        level1HintGo.SetActive(false);
        level2HintGo.SetActive(false);
        level3HintGo.SetActive(false);
        level4HintGo.SetActive(true);
        animator.SetTrigger("Enter");
        yield return new WaitForSeconds(3f);
        animator.SetTrigger("Exit");
    }
}
