//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;   // list
    private static int _nextLevelIndex = 1;


    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called one per frame
    void Update()
    {
        foreach(Enemy enemy in _enemies)
        {
            if (enemy != null)  // If a enemy is still alive
            {
                return;
            }
        }

        // Show
        Debug.Log("You killed all enemies");


        //Load the next level
        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;

        SceneManager.LoadScene(nextLevelName);
    }
}
