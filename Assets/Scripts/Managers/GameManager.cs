using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> enemysActive;
    [SerializeField] int countEnemy;
    private void Awake()
    {
        Instance = this;
    }



    public void SetNewEnemyActive(GameObject enemy)
    {
        enemysActive.Add(enemy);
    }
    public GameObject GetPlayer()
    {
        return player;
    }
    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
    public List<GameObject> GetListEnemy()
    {
        return enemysActive;
    }
    public void RemoveEnemyFromList(GameObject enemy)
    {
        enemysActive.Remove(enemy);
    }
}
