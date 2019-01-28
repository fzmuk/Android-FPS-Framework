using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class Crates {

        int randNumberOfCrates;
        int randCrate;
        GameObject crate;
        GameObject[] CrateList;
        List<int> randomList = new List<int>();

        public void InitCrates(GameObject[] spawnPointList, GameObject cratePrefab)
        {
            CrateList = new GameObject[spawnPointList.Length];

            for (int i = 0; i < spawnPointList.Length; i++)
            {
                crate = GameObject.Instantiate(cratePrefab);
                crate.transform.position = spawnPointList[i].transform.position;
                crate.transform.rotation = spawnPointList[i].transform.rotation;
                crate.SetActive(false);
                CrateList[i] = crate;
            }
        }

        public void GenerateRandomList(int size)
        {
            for (int i = 0; i < size; i++)
            {
                int numToAdd = Random.Range(0, size);
                while (randomList.Contains(numToAdd))
                {
                    numToAdd = Random.Range(0, size);
                }
                randomList.Add(numToAdd);
            }

            for (int i = 0; i < size; i++)
            {
                Debug.Log(randomList[i]);
            }
        }

        public void SetCrates()
        {
            //randNumberOfCrates = Random.Range(0, CrateList.Length);
            randNumberOfCrates = 3;

            GenerateRandomList(randNumberOfCrates);
            /*
            for (int i = 0; i < CrateList.Length; i++)
            {
                crate = CrateList[i];
                crate.SetActive(false);
                CrateList[i] = crate;
            }
            Debug.Log("sve na false");

            for (int i = 0; i < randNumberOfCrates; i++)
            {
                CrateList[randomList[0]].SetActive(true);
                randomList.RemoveAt(0);
            }*/
        }

        
        public void ReturnCrate(GameObject crate)
        {
            crate.SetActive(false);
        }
    
    }
}

