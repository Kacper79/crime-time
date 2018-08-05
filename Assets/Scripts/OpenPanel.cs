using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
	public GameObject openedPanel;

	public void Open()
	{
		Manager.Instance.state = GameState.BigPanel;
		openedPanel.SetActive(true);
	}
}