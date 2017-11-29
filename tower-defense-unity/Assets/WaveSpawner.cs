﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour {
    public Transform EnemyPrefab;
    public Transform SpawnPoint;
    public Text waveCountDownText;

    public float timeBetweenWaves = 5f;

    private float countDown = 2f;
    private int waveIndex = 0;

    private void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
        waveCountDownText.text = Mathf.Round(countDown).ToString();
    }
    private IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
