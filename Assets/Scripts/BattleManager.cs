using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private static BattleManager instance = null;
    private StageNode CurrentStageNode;
    public delegate void BattleEnd();
    public event BattleEnd battleEndDelegate;
    public static BattleManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            else
            {
                return instance;
            }
        }
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void LinkeToStageNode(StageNode _stageNode)
    {
        CurrentStageNode = _stageNode;
    }

    public void GenerateBattle(int _stageInfo)
    {
        Debug.Log(_stageInfo);
    }

    public void Complete()
    {
        Debug.Log("Complete");
        
        CurrentStageNode.Complete();
        StageManager.Instance.ClearStep(CurrentStageNode.Step);
        Debug.Log(StageManager.Instance.stageList.Count);
        battleEndDelegate();
    }

    public void Uncomplete()
    {
        Debug.Log("UnComplete");
        battleEndDelegate();
    }
}
