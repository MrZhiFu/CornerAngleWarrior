using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager _instance;//单例模式

    public EnemySpawn[] level1Monster1SpawnArray;//关卡1生成monster1敌人的每一个位置上的EnemySpawn脚本组件，用于生成一波一波的敌人
    public EnemySpawn[] level2Monster1SpawnArray;//关卡2生成monster2敌人的每一个位置上的EnemySpawn脚本组件，用于生成一波一波的敌人
    public EnemySpawn[] level2bossSpawnArray;//关卡2生成Boss敌人的每一个位置上的EnemySpawn脚本组件，用于生成一波一波的敌人
    public EnemySpawn[] level3bossSpawnArray;//关卡3生成Boss敌人的每一个位置上的EnemySpawn脚本组件，用于生成一波一波的敌人
    public EnemySpawn[] level3MonsterSpawnArray;//关卡3生成Monster敌人的每一个位置上的EnemySpawn脚本组件，用于生成一波一波的敌人
    public EnemySpawn[] level4bossSpawnArray;//关卡4生成Boss敌人的每一个位置上的EnemySpawn脚本组件，用于生成一波一波的敌人

    public List<GameObject> enemyList = new List<GameObject>();//用于存放所有生成的敌人‘
    public AudioClip victory;//胜利音效

    private Animator Level2DoorAnimator;//进入关卡2的门的动画控制器
    private Collider level2DoorCollider;//进入关卡2的门的碰撞器

    private Animator Level3DoorAnimator;//进入关卡3的门的动画控制器
    private Collider level3DoorCollider;//进入关卡3的门的碰撞器

    private Animator Level4DoorAnimator;//进入关卡3的门的动画控制器
    private Collider level4DoorCollider;//进入关卡3的门的碰撞器

    public int levelIndex = 0;//记录通过的关卡数
    public bool isGameover = false;//游戏是否结束
    public bool isVictory = false;//记录游戏是否胜利
    public GameObject victorySprite;//胜利的Sprite
    public GameObject filedSprite;//失败的Sprite

    void Awake()
    {
        _instance = this;
        Level2DoorAnimator = GameObject.Find("Env/Door/Level2").GetComponent<Animator>();
        level2DoorCollider = GameObject.Find("Env/Door/Level2").GetComponent<Collider>();
        Level3DoorAnimator = GameObject.Find("Env/Door/Level3").GetComponent<Animator>();
        level3DoorCollider = GameObject.Find("Env/Door/Level3").GetComponent<Collider>();
        Level4DoorAnimator = GameObject.Find("Env/Door/Level4").GetComponent<Animator>();
        level4DoorCollider = GameObject.Find("Env/Door/Level4").GetComponent<Collider>();
    }

    void Start()
    {
        StartCoroutine(Level1SpawnEnemy1());
    }

    //关卡1生成敌人的方法（12个monster，分为2波）
    IEnumerator Level1SpawnEnemy1()
    {
        yield return new WaitForSeconds(8f);//一开始9秒后出现关卡提示，为了等待故事情节介绍
        LevelHintsContiner._instance.Leve1EnterFun();//进入第一关卡显示关卡1提示信息

        //第一波敌人的生成：4个monster
        yield return new WaitForSeconds(5f);//再过5秒后才出现敌人，等待故事情节介绍
        foreach (EnemySpawn item in level1Monster1SpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }
        while (enemyList.Count > 0)//死循环判断该波敌人是否全部死亡，如果全部死亡再生成第二波敌人
        {
            yield return new WaitForSeconds(0.2f);
        }

        //第二波敌人的生成：8个monster
        foreach (EnemySpawn item in level1Monster1SpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }
        yield return new WaitForSeconds(0.5f);//等待0.5秒，防止敌人重合在一起
        foreach (EnemySpawn item in level1Monster1SpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }

        while (enemyList.Count > 0)//死循环判断该波敌人是否全部死亡，如果全部死亡再生成第三波敌人
        {
            yield return new WaitForSeconds(0.2f);
        }
        Level2DoorAnimator.SetTrigger("ToScale");
        level2DoorCollider.isTrigger = true;
        levelIndex = 1;//记录通过第一关
    }

    //用于在进入第二关卡大门后第二关敌人的生成
    public void Level2SpawnEnemyFun()
    {
        StartCoroutine(Level2SpawnEnemy());
    }

    //关卡2生成敌人的方法（6个monster，2个Boss）
    IEnumerator Level2SpawnEnemy()
    {
        yield return new WaitForSeconds(5f);//等待5秒，第二关敌人生成
        //6个monster的生成：
        foreach (EnemySpawn item in level2Monster1SpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }
        yield return new WaitForSeconds(0.5f);//等待0.5秒，防止敌人重合在一起
        foreach (EnemySpawn item in level2Monster1SpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }
        yield return new WaitForSeconds(0.5f);//等待0.5秒，防止敌人重合在一起
        foreach (EnemySpawn item in level2Monster1SpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }
        while (enemyList.Count > 0)//死循环判断该波敌人是否全部死亡，如果全部死亡再生成第三波敌人
        {
            yield return new WaitForSeconds(0.2f);
        }
        
        //2个Boss的生成
        foreach (EnemySpawn item in level2bossSpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }

        while (enemyList.Count > 0)//死循环判断该波敌人是否全部死亡，如果全部死亡再生成第三波敌人
        {
            yield return new WaitForSeconds(0.2f);
        }
        Level3DoorAnimator.SetTrigger("ToScale");
        level3DoorCollider.isTrigger = true;
        levelIndex = 2;//记录通过第二关
    }

    //用于在进入第三关卡大门后第三关敌人的生成
    public void Level3SpawnEnemyFun()
    {
        StartCoroutine(Level3SpawnEnemy());
    }

    //关卡3的敌人生成方法（6个Monster，4个Boss）
    IEnumerator Level3SpawnEnemy()
    {
        yield return new WaitForSeconds(5f);//等待5秒，第二关敌人生成
        //6个monster的生成
        foreach (EnemySpawn item in level3MonsterSpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }
        yield return new WaitForSeconds(0.5f);//等待0.5秒，防止敌人重合在一起
        foreach (EnemySpawn item in level3MonsterSpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }
        yield return new WaitForSeconds(0.5f);//等待0.5秒，防止敌人重合在一起
        foreach (EnemySpawn item in level3MonsterSpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }
        while (enemyList.Count > 0)//死循环判断该波敌人是否全部死亡，如果全部死亡再生成第二波敌人
        {
            yield return new WaitForSeconds(0.2f);
        }

        //4个Boss的生成
        foreach (EnemySpawn item in level3bossSpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }
        yield return new WaitForSeconds(0.5f);//等待0.5秒，防止敌人重合在一起
        foreach (EnemySpawn item in level3bossSpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }

        while (enemyList.Count > 0)//再次死循环判断该波敌人是否全部死亡，如果全部死亡2秒后就播放胜利音效
        {
            yield return new WaitForSeconds(0.2f);
        }
       
        while (enemyList.Count > 0)//死循环判断该波敌人是否全部死亡，如果全部死亡再生成第三波敌人
        {
            yield return new WaitForSeconds(0.2f);
        }
        Level4DoorAnimator.SetTrigger("ToScale");
        level4DoorCollider.isTrigger = true;
        levelIndex = 3;//记录通过第三关
    }

    //用于在进入第四关卡大门后第四关敌人的生成
    public void Level4pawnEnemyFun()
    {
        StartCoroutine(Level4SpawnEnemy());
    }

    //关卡3的敌人生成方法（8个Boss）
    IEnumerator Level4SpawnEnemy()
    {
        yield return new WaitForSeconds(5f);//等待5秒，第二关敌人生成
        //8个Boss的生成
        foreach (EnemySpawn item in level4bossSpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }
        yield return new WaitForSeconds(0.5f);//等待0.5秒，防止敌人重合在一起
        foreach (EnemySpawn item in level4bossSpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }
        yield return new WaitForSeconds(5f);//等待5秒，第二关敌人生成
        foreach (EnemySpawn item in level4bossSpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }
        yield return new WaitForSeconds(0.5f);//等待0.5秒，防止敌人重合在一起
        foreach (EnemySpawn item in level4bossSpawnArray)
        {
            enemyList.Add(item.SpwanEnemy());
        }
        while (enemyList.Count > 0)//再次死循环判断该波敌人是否全部死亡，如果全部死亡2秒后就播放胜利音效
        {
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(2f);
        AudioSource.PlayClipAtPoint(victory, this.transform.position, 1f);//播放游戏胜利音效
        victorySprite.SetActive(true);//显示游戏胜利Spirit
        levelIndex = 4;//记录通过第四关
        MenuContiner._instance.SetMenuPanelTrueFun();//显示菜单按钮
        isGameover = true;//游戏结束
        isVictory = true;//表示游戏胜利
    }
 }