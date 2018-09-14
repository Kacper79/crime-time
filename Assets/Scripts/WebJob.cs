using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;

public class WebJob : MonoBehaviour
{

	// Use this for initialization
	public string clientName;
	public bool taken;
	public bool done;

	public JobType Jobtype;
	public int price;

	public GameObject panel;

	public int id;

	void Start()
	{
		Debug.Log("Start");
		panel = gameObject;
		ConstructUI();
		taken = false;
	}

	public void ConstructUI()
	{
		TMP_Text[] texts = panel.GetComponentsInChildren<TMP_Text>();

		//GameObject g = Instantiate(proto);

		//Text[] texts = panel.GetComponentsInChildren<Text>();
		texts[0].text = clientName;
		texts[1].text = "Order:<b>"+Jobtype.ToString()+"</b>";
		texts[2].text = "PRICE:"+price.ToString()+"$";
	}

	public void TakeJob()
	{
		if (!taken)
		{
			PlayerManager.Instance.AddJob(this);
			taken = true;
			gameObject.GetComponent<Image>().color = new Color(155, 155, 155);
			////if(UiManager.Instance.currentBuilding.GetComponent<InteractableObject>().type == InteractableObject.){
				//AFlat_Rent action = new AFlat_Rent(UiManager.Instance.currentBuilding,this,false);
			//	PlayerManager.Instance.AddAction(action,id);
            //
            
		}

	}

	public void ReportDone()
	{
		Action action = PlayerManager.Instance.GetAction(id);
		if(action.checkd()==true){
			action.done();
			action.finish();
		}
	
		//gameObject.GetComponent<Image>().color = new Color(55, 55, 55);
	}
}

