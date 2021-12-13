using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public MonsterCreator monsterCreator;
    List<GameObject> currentMonster;

    private void Start()
    {
        currentMonster = monsterCreator.CreateMonster(this);
    }

    public void CheckMonster(GameObject mon)
    {
        if(currentMonster.Contains(mon))
            currentMonster.Remove(mon);

        if (currentMonster.Count == 0)
            currentMonster = monsterCreator.CreateMonster(this);
    }
}
