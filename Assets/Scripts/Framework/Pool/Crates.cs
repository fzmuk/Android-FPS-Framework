using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class Crates {

        GameObject[] crateList;
        public GameObject[] CrateList
        {
            get { return crateList; }
        }

        int randNumberOfCrates;
        public int RandNumberOfCrates
        {
            get { return randNumberOfCrates; }
        }

        GameObject crate;
        List<int> randomList = new List<int>();

        public void InitCrates(GameObject[] spawnPointList, GameObject cratePrefab)
        {
            crateList = new GameObject[spawnPointList.Length];

            for (int i = 0; i < spawnPointList.Length; i++)
            {
                crate = GameObject.Instantiate(cratePrefab);
                crate.transform.position = spawnPointList[i].transform.position;
                crate.transform.rotation = spawnPointList[i].transform.rotation;
                crate.SetActive(false);
                crateList[i] = crate;
            }
        }

        private void GenerateRandomList(int size)
        {
            for (int i = 0; i < size; i++)
                randomList.Add(i);

            for (var i = 0; i < randomList.Count; i++)
            {
                int tmp = randomList[i];
                int random = Random.Range(i, randomList.Count);
                randomList[i] = randomList[random];
                randomList[random] = tmp;
            }
            
        }

        public void SetCrates()
        {
            randNumberOfCrates = Random.Range(0, crateList.Length);

            GenerateRandomList(crateList.Length);
            
            for (int i = 0; i < crateList.Length; i++)
            {
                crate = crateList[i];
                crate.SetActive(false);
                crateList[i] = crate;
            }

            for (int i = 0; i < randNumberOfCrates; i++)
            {
                crateList[randomList[0]].SetActive(true);
                randomList.RemoveAt(0);
            }
        }
        
        public void ReturnCrate(GameObject crate)
        {
            crate.SetActive(false);
        }
    
    }
}

