using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

	public static Manager Instance;

	public GameState state;

	public int cash;

	void Start()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		state = GameState.Game;
		cash = 10000000;
	}

	public void increaseCash(int amount)
	{
		cash = cash + amount;
	}
	public void decreaseCash(int amount)
	{
		cash = cash - amount;
	}

	public void OpenPanel(GameObject panel, bool changeState)
	{
		panel.SetActive(true);
		if (changeState)
		{
			Manager.Instance.state = GameState.BigPanel;
		}
	}
	public void OpenPanel(GameObject panel)
	{
		panel.SetActive(true);
		Manager.Instance.state = GameState.BigPanel;
	}

	public void ClosePanel(GameObject closedObject)
	{
		closedObject.SetActive(false);
		Manager.Instance.state = GameState.Game;
	}
}

public enum GameState
{
	Game,
	BigPanel,
	D1,
	D2
}
public enum ObjectType
{
	flat

}

public enum JOB_TYPE
{
	Criminal_house,
	Rent_house
}