using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaceTower : MonoBehaviour {

	public GameObject towerPrefab;
	private GameObject tower;
    private GameManagerBehavior gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }

    private bool canPlaceTower() 
	{
        int cost = towerPrefab.GetComponent<TowerData>().levels[0].cost;
        return tower == null && gameManager.Gold >= cost;
    }

	void OnMouseUp () 
	{
		if (canPlaceTower()) 
		{
		  	tower = (GameObject) 
		    Instantiate(towerPrefab, transform.position, Quaternion.identity);

            /* This is how audio works
		    AudioSource audioSource = gameObject.GetComponent<AudioSource>();
    		audioSource.PlayOneShot(audioSource.clip);
    		*/

            //Deduct gold
            gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
        }
        else if (canUpgradeTower())
        {
            tower.GetComponent<TowerData>().increaseLevel();
            //Deduct gold
            gameManager.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
        }
    }

    private bool canUpgradeTower()
    {
        if (tower != null)
        {
            TowerData towerData = tower.GetComponent<TowerData>();
            TowerLevel nextLevel = towerData.getNextLevel();
            if (nextLevel != null)
            {
                return gameManager.Gold >= nextLevel.cost;
            }
        }
        return false;
    }
}
