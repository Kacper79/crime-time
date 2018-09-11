using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;
using System.IO;
public class GenerateJobs : MonoBehaviour
{

	public GameObject[] jobs;
	public string[] names;
	System.Random r;
	public int[] prices;
	public int minPrice;
	public int maxPrice;
	void Start()
	{
		r = new System.Random();
		names = GetNamesFromFile("Assets/Configs/identities.cfg");
		MakeJobs(jobs.Length);
	}


	void Update()
	{

	}

	private void MakeJobs(int count)
	{
		/*Debug.Log("Making Job");
		GameObject currentJob = Instantiate(job, job.transform.position, job.transform.rotation) as GameObject;
		RectTransform jobTransform = currentJob.GetComponent<RectTransform>();
		WebJob webjob = currentJob.GetComponent<WebJob>();
		webjob.clientName = "D'Es Pacito";
		webjob.Jobtype = JOB_TYPE.Criminal_house;
		webjob.price = 69;
		webjob.panel = job;
		currentJob.transform.parent = gameObject.transform;
		float transitionX = job.GetComponent<RectTransform>().position.x - jobTransform.position.x;
		float transitionY = job.GetComponent<RectTransform>().position.y - jobTransform.position.y - jobTransform.sizeDelta.y * offsetY;
		Vector3 transition = new Vector3(transitionX, transitionY, 0);
		jobTransform.Translate(transition);
		jobTransform.offsetMin = new Vector2(0, jobTransform.offsetMin.y);
		jobTransform.offsetMin = new Vector2(2, jobTransform.offsetMax.y);
		//jobTransform = job.GetComponent<RectTransform>();*/
		for (int i = 0; i < jobs.Length && i < count; i++)
		{

			WebJob job = jobs[i].GetComponent<WebJob>();
			if (job.taken && !job.done)
			{
				count++;
			}
			else
			{
				job.panel = jobs[i];
				job.clientName = GenerateName();
				job.Jobtype = JOB_TYPE.Criminal_house;
				job.price = 69;//GenPrice();
				job.done = false;
				job.taken = false;
				job.ConstructUI();
				jobs[i].SetActive(true);
			}

		}
	}
	public string[] GetNamesFromFile(string path)
	{
		StreamReader reader = new StreamReader(path);
		string[] lines = new string[200];
		for (int i = 0; i < 200; i++)
		{
			lines[i] = reader.ReadLine();
		}
		reader.Close();
		return lines;
	}

	public string GenerateName()
	{
		return names[r.Next(0, 199)];

	}
	public int GenPrice(){
		int[] v = new int[10];
		v[0] = minPrice;
		v[1] = (int)(minPrice * 1.15);
		v[2] = (int)(minPrice * 1.21);
		v[3] = (int)(minPrice * 1.37);
		v[4] = (int)(minPrice * 1.41);
		v[5] = (int)(maxPrice * 0.91);
		v[6] = (int)(maxPrice * 0.87);
		v[7] = (int)(maxPrice * 0.81);
		v[8] = (int)(maxPrice * 0.73);
		v[9] = maxPrice;
		prices = v;
		return prices[r.Next(0, 10)];
	}
}