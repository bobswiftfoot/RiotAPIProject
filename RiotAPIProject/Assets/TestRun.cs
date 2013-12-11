using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;
using System.Collections.Generic;

public class TestRun : MonoBehaviour {

	double SummonerID;
	public NetworkManager networkManager;

	// Use this for initialization
	void Start () 
	{
		List<double> ids = new List<double>(); 
		
		SummonerDto summonerDto = networkManager.GetSummonerByName("bobswiftfoot");
		Debug.Log("Bobswiftfoot: " + summonerDto.id);
		ids.Add(summonerDto.id);
		summonerDto = networkManager.GetSummonerByName("thedisneychan");
		Debug.Log("thedisneychan: " + summonerDto.id);
		ids.Add(summonerDto.id);
		networkManager.GetSummonersByID(ids);
	}
	
}
