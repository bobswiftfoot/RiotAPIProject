using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;
using System.Collections.Generic;

public class TestRun : MonoBehaviour {

	double SummonerID;
	public NetworkManager networkManager;

	// Use this for initialization
	IEnumerator Start () 
	{
		//This is each API call with a 2 second wait in between to account for the call limit
		Debug.Log("GetSummonerByName");
		SummonerDto summonerDto = networkManager.GetSummonerByName("bobswiftfoot");
		yield return new WaitForSeconds(2);
		Debug.Log("GetSummonerByID");
		SummonerDto summonerDto2 = networkManager.GetSummonerByID(28744052); //TheDisneyChan
		yield return new WaitForSeconds(2);
		List<double> ids = new List<double>();
		ids.Add(summonerDto.id);
		ids.Add(summonerDto2.id);
		Debug.Log("GetSummonersByID");
		networkManager.GetSummonersByID(ids);
		yield return new WaitForSeconds(2);
		Debug.Log("GetRunePagesByID");
		networkManager.GetRunePagesByID(summonerDto.id);
		yield return new WaitForSeconds(2);
		Debug.Log("GetMasteriesByID");
		networkManager.GetMasteriesByID(summonerDto.id);
		yield return new WaitForSeconds(2);
		Debug.Log("GetTeamsForID");
		networkManager.GetTeamsForID(summonerDto.id);
		yield return new WaitForSeconds(2);
		Debug.Log("GetNormalStatsByID");
		networkManager.GetNormalStatsByID(summonerDto.id, NetworkManager.Season.Season3);
		yield return new WaitForSeconds(2);
		Debug.Log("GetRankedStatsByID");
		networkManager.GetRankedStatsByID(summonerDto.id, NetworkManager.Season.Season3);
		yield return new WaitForSeconds(2);
		Debug.Log("GetLeagueDataByID");
		networkManager.GetLeagueDataByID(summonerDto.id);
		yield return new WaitForSeconds(2);
		Debug.Log("GetRecentGamesByID");
		networkManager.GetRecentGamesByID(summonerDto.id);
		yield return new WaitForSeconds(2);
		Debug.Log("GetAllChampions");
		networkManager.GetAllChampions();
		yield return new WaitForSeconds(2);
		Debug.Log("GetFreeChampions");
		networkManager.GetFreeChampions();
	}
	
}
