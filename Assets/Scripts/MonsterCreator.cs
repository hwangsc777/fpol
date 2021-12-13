using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreator : MonoBehaviour
{
    public GameObject player; //나중에 메세지 전달로 변경
    public List<Transform> sponPos;
    public List<GameObject> monsterPrefabs;
    public int minMonsterCount;
    public int maxMonsterCount;

    public List<GameObject> CreateMonster(MonsterManager monsterManager)
    {
        List<GameObject> monsters = new List<GameObject>();
        int count = Random.Range(minMonsterCount, maxMonsterCount);

        for(int i = 0; i < count; i++)
        {
            int pos = Random.Range(0, sponPos.Count);
            int mon = Random.Range(0, monsterPrefabs.Count);

            GameObject gameObject = Instantiate(monsterPrefabs[mon], sponPos[pos]);
            gameObject.SetActive(false);
            Enemy script = gameObject.GetComponent<Enemy>();
            script.player = player;
            script.monsterManager = monsterManager;
            monsters.Add(gameObject);
        }

        minMonsterCount++;
        maxMonsterCount += 2;

        StartCoroutine("MakeMonster", monsters);

        return monsters;
    }

    IEnumerator MakeMonster(List<GameObject> monList)
    {
        SoundManager.Instance.PlaySource(AudioClips.spawn0);
        yield return new WaitForSeconds(0.5f);

        GameObject[] monArr = monList.ToArray();
        int count = monList.Count;

        for (int i = 0; i < count; i++)
        {
            monArr[i].SetActive(true);
            SoundManager.Instance.PlaySource(AudioClips.spawn1);
            yield return new WaitForSeconds(0.15f);
        }
    }
}
