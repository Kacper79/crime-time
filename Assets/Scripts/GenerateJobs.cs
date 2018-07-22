using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;
public class GenerateJobs : MonoBehaviour
{

	public GameObject job;
	public Canvas canva;
	void Start()
	{
		MakeJobs(1);
		MakeJobs(2);
		MakeJobs(3);

	}


	void Update()
	{

	}

	private void MakeJobs(float offsetY)
	{
		Debug.Log("Making Job");
		GameObject currentJob = Instantiate(job) as GameObject;
		RectTransform jobTransform = currentJob.GetComponent<RectTransform>();
		WebJob webjob = currentJob.GetComponent<WebJob>();
		webjob.clientName = "D'Es Pacito";
		webjob.Jobtype = JOB_TYPE.Criminal_house;
		webjob.price = 69;
		webjob.panel = job;
		currentJob.transform.parent = gameObject.transform;
		float transitionX = gameObject.GetComponent<RectTransform>().position.x - jobTransform.position.x;
		float transitionY = gameObject.GetComponent<RectTransform>().position.y - jobTransform.position.y - jobTransform.sizeDelta.y * offsetY;
		Vector3 transition = new Vector3(transitionX, transitionY, 0);
		jobTransform.Translate(transition);
		jobTransform.offsetMin = new Vector2(0, jobTransform.offsetMin.y);
		jobTransform.offsetMin = new Vector2(2, jobTransform.offsetMax.y);
	}
}