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
			Instance = this; ;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		state = GameState.Game;
		cash = 100000;
	}

	public void increaseCash(int amount)
	{
		cash = cash + amount;
	}
	public void decreaseCash(int amount)
	{
		cash = cash - amount;
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