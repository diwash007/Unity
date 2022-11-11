using System.Collections;
using Enemy;
using UnityEngine;

namespace Spawner
{
    public class MonsterSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] monsterReference;

        private GameObject _spawnedMonster;

        [SerializeField]
        private Transform leftPos, rightPos;

        private int _randomIndex;
        private int _randomSide;

        [SerializeField]
        private bool shouldSpawnMonsters;

        private void Start()
        {
            if(!shouldSpawnMonsters) return;
            StartCoroutine(SpawnMonsters());
        }

        private IEnumerator SpawnMonsters()
        {
        
            while (true) {
                yield return new WaitForSeconds(Random.Range(1, 5));

                _randomIndex = Random.Range(0, monsterReference.Length);
                _randomSide = Random.Range(0, 2);

                _spawnedMonster = Instantiate(monsterReference[_randomIndex]);

                if (_randomSide == 0)
                {
                    _spawnedMonster.transform.position = leftPos.position;
                    _spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
                } 
                else
                {
                    _spawnedMonster.transform.position = rightPos.position;
                    _spawnedMonster.GetComponent<Monster>().speed = Random.Range(-4, -10);
                    _spawnedMonster.transform.localScale = new Vector3(-_spawnedMonster.transform.localScale.x, _spawnedMonster.transform.localScale.y, _spawnedMonster.transform.localScale.z);
                }
            } 
        }
    }
}
