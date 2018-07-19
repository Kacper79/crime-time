using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
	//public bool b = false;
	public ObjectType type;

	public void OnMouseDown()
	{
		if (UiManager.Instance.currentBuilding != gameObject/*b == false && Manager.Instance.state == GameState.Game*/)
		{
			//DisplayPanel.enable(panel);
			UiManager.Instance.currentBuilding = gameObject;
			//b = true;
			Manager.Instance.state = GameState.BigPanel;
			UiManager.Instance.openPanel(type);
		}
		/*else
		{
			//DisplayPanel.Instance.disable(DisplayPanel.Instance.flatPanel);
			UiManager.Instance.currentBuilding = null;
			b = false;
			Manager.Instance.state = GameState.Game;
			UiManager.Instance.closePanel(type);

		}*/
	}
	//public void GeneratePanelForBuilding(GameObject building)
	//{
	//	DisplayPanel.Instance.GeneratePanelForBuilding(building);
	//panel.GetComponent<RectTransform> ().SetPositionAndRotation (building.GetComponent<RectTransform> ().position,Quaternion.identity);
	//building.GetComponent<RectTransform> ().SetPositionAndRotation (new Vector3(),Quaternion.identity);
	//}

}
