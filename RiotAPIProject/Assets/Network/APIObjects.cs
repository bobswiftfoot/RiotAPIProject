using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Boomlagoon.JSON;

/// <summary>
/// champion-v1.1
/// </summary>
#region champion
public class ChampionListDto
{
	public List<ChampionDto> champions { get; set;}
}

public class ChampionDto
{
	public bool botMmEnabled { get; set; }
	public int defenseRank { get; set; }
	public int attackRank { get; set; }
	public int id { get; set; }
	public bool rankedPlayEnabled { get; set; }
	public string name { get; set; }
	public bool botEnabled { get; set; }
	public int difficultyRank { get; set; }
	public bool active { get; set; }
	public bool freeToPlay { get; set; }
	public int magicRank { get; set; }
}
#endregion

/// <summary>
/// game-v1.1
/// </summary>
#region game
public class RecentGamesDto
{
	public List<GameDto> games { get; set; }
	public long summonerId { get; set; }
}

public class GameDto
{
	public int championId { get; set; }
	public long createDate { get; set; }
	public string createDateStr { get; set; }
	public List<PlayerDto> fellowPlayers { get; set; }
	public long gameId { get; set; }
	public string gameMode { get; set; }
	public string gameType { get; set; }
	public bool invalid { get; set; }
	public int level { get; set; }
	public int mapId { get; set; }
	public int spell1 { get; set; }
	public int spell2 { get; set; }
	public List<RawStatDto> statistics { get; set; }
	public string subType { get; set; }
	public int teamId { get; set; }
}

public class PlayerDto
{
	public int championId { get; set; }
	public long summonerId { get; set; }
	public int teamid { get; set; }
}

public class RawStatDto
{
	public int id { get; set; }
	public string name { get; set; }
	public int value { get; set; }
}
#endregion

/// <summary>
/// league-v2.1
/// </summary>
#region league
public class LeagueDto
{
	public List<LeagueItemDto> entries { get; set; }
	public string name { get; set; }
	public string queue { get; set; }
	public string tier { get; set; }
	public long timestamp { get; set; }
}

public class LeagueItemDto
{
	public bool isFreshBlood { get; set; }
	public bool isHotStreak { get; set; }
	public bool isInactive { get; set; }
	public bool isVeteran { get; set; }
	public long lastPlayed { get; set; }
	public string leagueName { get; set; }
	public int leaguePoints { get; set; }
	public int losses { get; set; }
	public MiniSeriesDto miniSeries { get; set; }
	public string playerOrTeamId { get; set; }
	public string playerOrTeamName { get; set; }
	public string queueType { get; set; }
	public string rank { get; set; }
	public string tier { get; set; }
	public long timeUnitDecay { get; set; }
	public int wins { get; set; }
}

public class MiniSeriesDto
{
	public int losses { get; set; }
	public List<characters> progress { get; set; }
	public int target { get; set; }
	public long tiemLeftToPlayMillis { get; set; }
	public int wins { get; set; }
}

public class characters
{
	public string character { get; set; }
}
#endregion

/// <summary>
/// stats-v1.1
/// </summary>
#region stats
public class PlayerStatsSummaryListDto
{
	public List<PlayerStatsSummaryDto> playerStatSummaries { get; set; }
	public long summonerId { get; set; }
}

public class PlayerStatsSummaryDto
{
	public List<AggregatedStatDto> aggregatedStats { get; set; }
	public int losses { get; set; }
	public long modifyDate { get; set; }
	public string modifyDateStr { get; set; }
	public string playerStatSummaryType { get; set; }
	public int wins { get; set; }
}

public class AggregatedStatDto
{
	public int count { get; set; }
	public int id { get; set; }
	public string name { get; set; }
}

public class RankedStatsDto
{
	public List<ChampionStatsDto> champions { get; set; }
	public long modifyDate { get; set; }
	public string modifyDateStr { get; set; }
	public long sommonerId { get; set; }
}

public class ChampionStatsDto
{
	public int id { get; set; }
	public string name { get; set; }
	public List<ChampionStatDto> stats { get; set; }
}

public class ChampionStatDto
{
	public int count { get; set; }
	public int id { get; set; }
	public string name { get; set; }
	public int value { get; set; }
}
#endregion

/// <summary>
/// summoner-v1.1
/// </summary>
#region summoner
public class MasteryPagesDto
{
	public List<MasteryPageDto> pages { get; set; }
	public long summonerId { get; set; }
}

public class MasteryPageDto
{
	public bool current { get; set; }
	public string name { get; set; }
	public List<TalentDto> talents { get; set; }
}

public class TalentDto
{
	public int id { get; set; }
	public string name { get; set; }
	public int rank { get; set; }
}

public class RunePagesDto
{
	public List<RunePageDto> pages { get; set; }
	public long summonerId { get; set; }
}

public class RunePageDto
{
	public bool current { get; set; }
	public long id { get; set; }
	public string name { get; set; }
	public List<RuneSlotDto> slots { get; set; }
}

public class RuneSlotDto
{
	public RuneDto rune { get; set; }
	public int runeSlotId { get; set; }
}

public class RuneDto
{
	public string description { get; set; }
	public int id { get; set; }
	public string name { get; set; }
	public int tier { get; set; }
}

public class SummonerDto
{
	public double id { get; set; }
	public string name { get; set; }
	public double profileIconId { get; set; }
	public double revisionDate { get; set; }
	public string revisionDateStr { get; set; }
	public double summonerLevel { get; set; }

	public SummonerDto(JSONObject json)
	{
		id = json.GetNumber("id");
		name = json.GetString("name");
		profileIconId = json.GetNumber("profileIconId");
		revisionDate = json.GetNumber("revisionDate");
		revisionDateStr = json.GetString("revisionDateStr");
		summonerLevel = json.GetNumber("summonerLevel");
	}	

}

public class SummonerNameListDto
{
	public List<SummonerNameDto> summoners { get; set; }

	public SummonerNameListDto(JSONObject json)
	{
		Debug.Log(json.ToString());
		summoners = new List<SummonerNameDto>();

		JSONArray array = json.GetArray("summoners");
		for(int i = 0; i < array.Length; i++)
		{
			summoners.Add(new SummonerNameDto(array[i].Obj));
		}
	}
}

public class SummonerNameDto
{
	public double id { get; set; }
	public string name { get; set; }
	
	public SummonerNameDto(JSONObject json)
	{
		id = json.GetNumber("id");
		name = json.GetString("name");
	}
}
#endregion

/// <summary>
/// team-v2.1
/// </summary>
#region team
public class TeamDto
{
	public string createDate { get; set; }
	public string lastGameDate { get; set; }
	public string lastJoinDate { get; set; }
	public string lastJoinedRankedTeamQueueDate { get; set; }
	public List<MatchHistorySummaryDto> matchHistory { get; set; }
	public MessageOfDayDto messageofDat { get; set; }
	public string modifyDate { get; set; }
	public string name { get; set; }
	public RosterDto roster { get; set; }
	public string secondLastJoinDate { get; set; }
	public string status { get; set; }
	public string tag { get; set; }
	public teamIdDto teamId { get; set; }
	public TeamStatSummaryDto teamStatSummary { get; set; }
	public string thirdLastJoinDate { get; set; }
	public long timestamp { get; set; }
}

public class MatchHistorySummaryDto
{
	public int assists { get; set; }
	public long date { get; set; }
	public int deaths { get; set; }
	public long gameId { get; set; }
	public string gameMode { get; set; }
	public bool invalid { get; set; }
	public int kills { get; set; }
	public int mapId { get; set; }
	public int opposingTeamKills { get; set; }
	public string opposingTeamName { get; set; }
	public bool win { get; set; }
}

public class MessageOfDayDto
{
	public long createDate { get; set; }
	public string message { get; set; }
	public int version { get; set; }
}

public class RosterDto
{
	public List<TeamMemberInfoDto> memberList { get; set; }
	public long ownerId { get; set; }
}

public class teamIdDto
{
	public string fullId { get; set; }
}

public class TeamStatSummaryDto
{
	public teamIdDto teamId { get; set; }
	public List<TeamStatDetailDto> teamStatDetails { get; set; }
}

public class TeamMemberInfoDto
{
	public string inviteDate { get; set; }
	public string joinDate { get; set; }
	public long playerId { get; set; }
	public string status { get; set; }
}

public class TeamStatDetailDto
{
	public int averageGamesPlayed { get; set; }
	public int losses { get; set; }
	public int maxRating { get; set; }
	public int rating { get; set; }
	public int seedRating { get; set; }
	public teamIdDto teamid { get; set; }
	public string teamStatType { get; set; }
	public int wins { get; set; }
}
#endregion
