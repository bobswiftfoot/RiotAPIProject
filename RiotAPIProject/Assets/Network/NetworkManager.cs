using UnityEngine;
using System.Collections;
using Boomlagoon.JSON;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour
{
	string ApiKey = "";
	string Region = "";
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
		ApiKey = "fb1ccb17-75bf-4fbf-85c9-a8b3b8e00501";
		Region = "na";		
		KeyEnd = "?api_key=" + ApiKey;
		BaseUrl = "http://prod.api.pvp.net/api/lol/" + Region + "/v1.1";
		TeamBaseUrl = "http://prod.api.pvp.net/api/" + Region + "/v2.1";
	}		

	#region SUMMONER INFO
	public SummonerDto GetSummonerByID(double id)
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

	public RunePagesDto GetRunePagesByID(double id)
	{
		string url = BaseUrl + "/summoner/" + id + "/runes" + KeyEnd;
		return new RunePagesDto(SendRequest(url));
	}
	
	public RunePagesDto GetRunePagesBySummonerName(string summonerName)
	{
		SummonerDto summonerDto = GetSummonerByName(summonerName);
		return GetRunePagesByID(summonerDto.id);
	}
	
	public MasteryPagesDto GetMasteriesByID(double id)
	{
		string url = BaseUrl + "/summoner/" + id + "/masteries" + KeyEnd;
		return new MasteryPagesDto(SendRequest(url));
	}

	public MasteryPagesDto GetMasteriesBySummonerName(string summonerName)
	{
		SummonerDto summonerDto = GetSummonerByName(summonerName);
		return GetMasteriesByID(summonerDto.id);
	}
	#endregion

	#region TEAMS
	public TeamDto GetTeamsForID(double id)
	{
		string url = TeamBaseUrl + "/team/by-summoner/" + id + KeyEnd;
		return new TeamDto(SendRequest(url));
	}

	public TeamDto GetTeamsForSummonerName(string summonerName)
	{
		SummonerDto summonerDto = GetSummonerByName(summonerName);
		return GetTeamsForID(summonerDto.id);
	}
	#endregion

	#region STATS
	public PlayerStatsSummaryListDto GetNormalStatsByID(double id, Season season)
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
		return new PlayerStatsSummaryListDto(SendRequest(url));
	}
			
	public PlayerStatsSummaryListDto GetNormalStatsBySummonerName(string summonerName, Season season)
	{
		SummonerDto summonerDto = GetSummonerByName(summonerName);
		return GetNormalStatsByID(summonerDto.id, season);
	}
			
	public RankedStatsDto GetRankedStatsByID(double id, Season season)
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
		return new RankedStatsDto(SendRequest(url));
	}
					
	public RankedStatsDto GetRankedStatsBySummonerName(string summonerName, Season season)
	{
		SummonerDto summonerDto = GetSummonerByName(summonerName);
		return GetRankedStatsByID(summonerDto.id, season);
	}
							
	#endregion

	#region LEAGUES
	public LeagueDto GetLeagueDataByID(double id)
	{
		string url = TeamBaseUrl + "/league/by-summoner/" + id + KeyEnd;
		return new LeagueDto(SendRequest(url));
	}

	public LeagueDto GetLeagueDataBySummonerName(string summonerName)
	{
		SummonerDto summonerDto = GetSummonerByName(summonerName);
		return GetLeagueDataByID(summonerDto.id);
	}
	#endregion		

	#region GAMES
	public RecentGamesDto GetRecentGamesByID(double id)
	{
		string url = BaseUrl + "/game/by-summoner/" + id + "/recent" + KeyEnd;
		return new RecentGamesDto(SendRequest(url));
	}

	public RecentGamesDto GetRecentGamesBySummonerName(string summonerName)
	{
		SummonerDto summonerDto = GetSummonerByName(summonerName);
		return GetRecentGamesByID(summonerDto.id);
	}
	#endregion

	#region CHAMPIONS
	public ChampionListDto GetAllChampions()
	{
		string url = BaseUrl + "/champion" + KeyEnd;
		return new ChampionListDto(SendRequest(url));
	}
	
	public ChampionListDto GetFreeChampions()
	{
		string url = BaseUrl + "/champion?freeToPlay=true&" + KeyEnd.Substring(1);
		return new ChampionListDto(SendRequest(url));
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
			Debug.Log(request.text);
			return JSONObject.Parse(request.text);
		}
		else 
		{
			Debug.LogError(request.error);
			//429 is too may requests. Beta dev API is limited to 5 calls per 10 seconds.
			return null;
		}
	}

	#endregion
}