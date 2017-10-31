using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuContiner : MonoBehaviour {
    public static MenuContiner _instance;

    public GameObject menuPanelGo;//菜单面板
    private float gameTime = 0;//游戏时长
    public UILabel resultLabel;//显示游戏结果的文本UI

    private void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update () {
        if (SpawnManager._instance.isGameover == false)
        {
            gameTime += Time.deltaTime;
        }
	}

    private void SetResultLabel() { //设置游戏结果的值
        int temp = (int)gameTime;
        resultLabel.text = "恭喜你！你通过了" + SpawnManager._instance.levelIndex.ToString() + "关，花费时间为" + temp.ToString()+"秒";
    }


    public void SetMenuPanelTrueFun() {//激活游戏结束后的菜单按钮
        SetResultLabel();
        StartCoroutine(SetMenuPanelTrue());
    }

    IEnumerator SetMenuPanelTrue() {
        yield return new WaitForSeconds(3.5f);
        if (SpawnManager._instance.isVictory == true)//根据游戏是否胜利来隐藏相应的Sprite
        {
            SpawnManager._instance.victorySprite.SetActive(false);//隐藏显示游戏胜利的Sprite
        }
        else
        {
            SpawnManager._instance.filedSprite.SetActive(false);//隐藏显示游戏失败的Sprite
        }
        
        menuPanelGo.SetActive(true);//激活菜单按钮
    }

    public void OnRePlayBtnDown(){ //再次游戏按钮事件
        SceneManager.LoadScene(0);
    }

    public void OnQuitBtnDown(){ //退出游戏按钮事件
        Application.Quit();
    }
}
