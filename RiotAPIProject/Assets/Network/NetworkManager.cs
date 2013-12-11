using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour
{
	string ApiKey = "fb1ccb17-75bf-4fbf-85c9-a8b3b8e00501";
	string Region = "na";
	string KeyEnd = "";
	string BaseUrl = "";
	string TeamBaseUrl = "";

	public enum Season
	{
		Season3,
		Season4
	}

	void Start()
	{
		KeyEnd = "?api_key=" + ApiKey;
		BaseUrl = "http://prod.api.pvp.net/api/lol/" + Region + "/v1.1";
		TeamBaseUrl = "http://prod.api.pvp.net/api/" + Region + "/v2.1";
	}		

	#region SUMMONER INFO
	public SummonerDto GetSummonerByID(string id)
	{
		string url = BaseUrl + "/summoner/" + id + KeyEnd;
		return new SummonerDto(SendRequest(url));
	}
			
	public SummonerNameListDto GetSummonersByID(List<double> ids)
	{
		string Ids = "";
		foreach(double s in ids)
		{
			Ids += s + ",";
		}
		string url = BaseUrl + "/summoner/" + Ids + "/name" + KeyEnd;
		return new SummonerNameListDto(SendRequest(url));
	}
			
	public SummonerDto GetSummonerByName(string name)
	{
		string url = BaseUrl + "/summoner/by-name/" + name + KeyEnd;
		return new SummonerDto(SendRequest(url));
	}

	public JSONObject GetRunePagesByID(double id)
	{
		string url = BaseUrl + "/summoner/" + id + "/runes" + KeyEnd;
		return SendRequest(url);
	}
	
	public JSONObject GetRunePagesBySummonerName(string summonerName)
	{
		SummonerDto summonerDto = GetSummonerByName(summonerName);
		return GetRunePagesByID(summonerDto.id);
	}
	
	public JSONObject GetMasteriesByID(double id)
	{
		string url = BaseUrl + "/summoner/" + id + "/masteries" + KeyEnd;
		return SendRequest(url);
	}

	public JSONObject GetMasteriesBySummonerName(string summonerName)
	{
		SummonerDto summonerDto = GetSummonerByName(summonerName);
		return GetMasteriesByID(summonerDto.id);
	}
	#endregion

	#region TEAMS
	public JSONObject GetTeamsForID(double id)
	{
		string url = TeamBaseUrl + "/team/by-summoner/" + id + KeyEnd;
		return SendRequest(url);
	}

	public JSONObject GetTeamsForSummonerName(string summonerName)
	{
		SummonerDto summonerDto = GetSummonerByName(summonerName);
		return GetTeamsForID(summonerDto.id);
	}
	#endregion


	#region STATS
	public JSONObject GetNormalStatsByID(double id, Season season)
	{
		string url = BaseUrl + "/stats/by-summoner/" + id + "/summary";
		if (season == Season.Season3)
		{
			url += "?season=SEASON3&" + KeyEnd.Substring(1);
		}
		else if (season == Season.Season4)
		{
			url += "?season=SEASON4&" + KeyEnd.Substring(1);
		}
		else
		{
			url += KeyEnd;
		}
		return SendRequest(url);
	}
			
	public JSONObject GetNormalStatsBySummonerName(string summonerName, Season season)
	{
		SummonerDto summonerDto = GetSummonerByName(summonerName);
		return GetNormalStatsByID(summonerDto.id, season);
	}
			
	public JSONObject GetRankedStatsByID(double id, Season season)
	{
		string url = BaseUrl + "/stats/by-summoner/" + id + "/ranked";
		if (season == Season.Season3)
		{
			url += "?season=SEASON3&" + KeyEnd.Substring(1);
		}
		else if(season == Season.Season4)
		{
			url += "?season=SEASON4&" + KeyEnd.Substring(1);
		}
		else
		{
			url += KeyEnd;
		}
		return SendRequest(url);
	}
					
	public JSONObject GetRankedStatsBySummonerName(string summonerName, Season season)
	{
		SummonerDto summonerDto = GetSummonerByName(summonerName);
		return GetRankedStatsByID(summonerDto.id, season);
	}
							
	#endregion

	#region LEAGUES
	public JSONObject GetLeagueDataByID(double id)
	{
		string url = TeamBaseUrl + "/league/by-summoner/" + id + KeyEnd;
		return SendRequest(url);
	}

	public JSONObject GetLEagueDataBySummonerName(string summonerName)
	{
		SummonerDto summonerDto = GetSummonerByName(summonerName);
		return GetLeagueDataByID(summonerDto.id);
	}
	#endregion		

	#region GAMES
	public JSONObject GetRecentGamesByID(double id)
	{
		string url = BaseUrl + "/game/by-summoner/" + id + "/recent" + KeyEnd;
		return SendRequest(url);
	}

	public JSONObject GetRecentGamesBySummonerName(string summonerName)
	{
		SummonerDto summonerDto = GetSummonerByName(summonerName);
		return GetRecentGamesByID(summonerDto.id);
	}
	#endregion

	#region CHAMPIONS
	public JSONObject GetAllChampions()
	{
		string url = BaseUrl + "/champion" + KeyEnd;
		return SendRequest(url);
	}
	
	public JSONObject GetFreeChampions()
	{
		string url = BaseUrl + "/champion?freeToPlay=true&" + KeyEnd.Substring(1);
		return SendRequest(url);
	}
	#endregion

	#region INTERNAL FUNCS
	private JSONObject SendRequest(string url)
	{
		WWW request = new WWW(url);
		while(!request.isDone)
		{
			//Wait
		}
		if (request.error == null)
		{
			return JSONObject.Parse(request.text);
		}
		else 
		{
			Debug.LogError(request.error);
			return null;
		}
	}

	#endregion
}