using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/*
You add[System.Serializable] at the top to make instances of the class editable from the inspector.
This allows you to quickly change all values in the Level class — even while the game is running.
It’s incredibly useful for balancing your game.
*/

public class TowerLevel
{
    public int cost;
    public GameObject visualization;
}

public class TowerData : MonoBehaviour {

    public List<TowerLevel> levels;
    private TowerLevel currentLevel;

    void OnEnable()
    {
        CurrentLevel = levels[0];
    }

    public TowerLevel CurrentLevel
    {        
        get
        {
            return currentLevel;
        }        
        set
        {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);

            GameObject levelVisualization = levels[currentLevelIndex].visualization;
            for (int i = 0; i < levels.Count; i++)
            {
                if (levelVisualization != null)
                {
                    if (i == currentLevelIndex)
                    {
                        levels[i].visualization.SetActive(true);
                    }
                    else
                    {
                        levels[i].visualization.SetActive(false);
                    }
                }
            }
        }
    }

    public TowerLevel getNextLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        int maxLevelIndex = levels.Count - 1;
        if (currentLevelIndex < maxLevelIndex)
        {
            return levels[currentLevelIndex + 1];
        }
        else
        {
            return null;
        }
    }

    public void increaseLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        if (currentLevelIndex < levels.Count - 1)
        {
            CurrentLevel = levels[currentLevelIndex + 1];
        }
    }
}


