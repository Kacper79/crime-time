using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DateManager : MonoBehaviour {

	public static DateManager Instance;
	public float timeElapsed;
	public float timePerDay;
	public float timePerHour;
	public Text timeText;
	public int hour;
	public int day;
	void Start () {
		timePerHour = timePerDay / 24;
		day = 1;
		hour = 8;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > timeElapsed + timePerHour){
			if(hour == 24){
				hour = 1;
				day++;
			}else{
				hour++;
			}

			if(hour > 12){
				timeText.text = "Day: " + day + "  " + (hour -12) + "pm";
			}else{
				timeText.text = "Day: "+day+"  "+hour+"am";
			}
			timeElapsed = Time.time;
		}
	}
}
