using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public float RoundEndDelay = 2f;
    private float _roundTimer;
    [SerializeField]
    public List<Round> Rounds = new List<Round>();
    public bool RoundEnd = false;

    [Header("Represents the round started, but not the active round")]
    public float CurrentRound = 0;
    private float _activatedRound = 0;

    private void Start()
    {
        _roundTimer = RoundEndDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (!RoundEnd && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            _roundTimer -= Time.deltaTime;
            RoundEnd = true;
            // Round end, time to do shit
        }

        if (_roundTimer <= 0)
        {
            _roundTimer = RoundEndDelay;
        }
    }

    public void StartRound()
    {
        RoundEnd = false;
        CurrentRound++;
    }
}

[Serializable]
public class Round
{
    [SerializeField]
    public SpawnInfo[] spawnInfo;


}

[Serializable]
public class SpawnInfo
{
    public enum SpawnNextWhen
    {
        Immediate,
        WaveCleared,
        AfterTime,
    }

    [Header("Enemy To Spawn")]
    [SerializeField]
    public GameObject EnemyToSpawn;
    public int SpawnAmount = 1;
    [SerializeField]
    [Header("How will the next wave spawn")]
    public SpawnNextWhen SpawnNextSetting;
    [Header("Only if After Time Setting")]
    public int AterTime = 1;
}
