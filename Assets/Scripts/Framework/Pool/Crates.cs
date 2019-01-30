using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    /// <summary>
    /// Class intended to manage prizes in the game. 
    /// Objects that can be assembled appear in random locations, that are selected from the list of points.
    /// </summary>
    public class Crates {

        GameObject[] crateList;
        /// <summary>
        /// List of objects for collection that can appear on the scene. Read only.
        /// </summary>
        public GameObject[] CrateList
        {
            get { return crateList; }
        }

        int randNumberOfCrates;
        /// <summary>
        /// Number of objects that will appear on the scene. Read only.
        /// </summary>
        public int RandNumberOfCrates
        {
            get { return randNumberOfCrates; }
        }

        GameObject crate;
        List<int> randomList = new List<int>();
        /// <summary>
        /// Method initializes the CrateList and places collectable objects at their respective points. 
        /// Objects are not active.
        /// </summary>
        /// <param name="spawnPointList"></param>Array of points for showing objects for prizes.
        /// <param name="cratePrefab"></param>Object to be collected.
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
        /// <summary>
        /// Method that sets collectable objects as active, that is, visible on the scene. 
        /// Number of objects and their locationa are randomly selected.
        /// </summary>
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
        /// <summary>
        /// Method that returns collected object. 
        /// Collected object becomes inactive until it is again selected to appear on the scene.
        /// </summary>
        /// <param name="crate"></param>Collected object.
        public void ReturnCrate(GameObject crate)
        {
            crate.SetActive(false);
        }    
    }
}

