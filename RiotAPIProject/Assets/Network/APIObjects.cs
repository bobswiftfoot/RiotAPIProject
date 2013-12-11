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

	public ChampionListDto(JSONObject json)
	{
		champions = new List<ChampionDto>();
		
		JSONArray array = json.GetArray("champions");
		for(int i = 0; i < array.Length; i++)
		{
			champions.Add(new ChampionDto(array[i].Obj));
		}
	}
}

public class ChampionDto
{
	public bool botMmEnabled { get; set; }
	public double defenseRank { get; set; }
	public double attackRank { get; set; }
	public double id { get; set; }
	public bool rankedPlayEnabled { get; set; }
	public string name { get; set; }
	public bool botEnabled { get; set; }
	public double difficultyRank { get; set; }
	public bool active { get; set; }
	public bool freeToPlay { get; set; }
	public double magicRank { get; set; }

	public ChampionDto(JSONObject json)
	{
		botMmEnabled = json.GetBoolean("botMmEnabled");
		defenseRank = json.GetNumber("defenseRank");
		attackRank = json.GetNumber("attackRank");
		id = json.GetNumber("id");
		rankedPlayEnabled = json.GetBoolean("rankedPlayEnabled");
		name = json.GetString("name");
		botEnabled = json.GetBoolean("botEnabled");
		difficultyRank = json.GetNumber("difficultyRank");
		active = json.GetBoolean("active");
		freeToPlay = json.GetBoolean("freeToPlay");
		magicRank = json.GetNumber("magicRank");
	}
}
#endregion

/// <summary>
/// game-v1.1
/// </summary>
#region game
public class RecentGamesDto
{
	public List<GameDto> games { get; set; }
	public double summonerId { get; set; }

	public RecentGamesDto(JSONObject json)
	{
		games = new List<GameDto>();
		
		JSONArray array = json.GetArray("games");
		for(int i = 0; i < array.Length; i++)
		{
			games.Add(new GameDto(array[i].Obj));
		}
		summonerId = json.GetNumber("summonerId");
	}
}

public class GameDto
{
	public double championId { get; set; }
	public double createDate { get; set; }
	public string createDateStr { get; set; }
	public List<PlayerDto> fellowPlayers { get; set; }
	public double gameId { get; set; }
	public string gameMode { get; set; }
	public string gameType { get; set; }
	public bool invalid { get; set; }
	public double level { get; set; }
	public double mapId { get; set; }
	public double spell1 { get; set; }
	public double spell2 { get; set; }
	public List<RawStatDto> statistics { get; set; }
	public string subType { get; set; }
	public double teamId { get; set; }

	public GameDto(JSONObject json)
	{
		championId = json.GetNumber("championId");
		createDate = json.GetNumber("createDate");
		createDateStr = json.GetString("createDateStr");

		fellowPlayers = new List<PlayerDto>();
		
		JSONArray array = json.GetArray("fellowPlayers");
		for(int i = 0; i < array.Length; i++)
		{
			fellowPlayers.Add(new PlayerDto(array[i].Obj));
		}		
		gameId = json.GetNumber("gameId");
		gameMode = json.GetString("gameMode");
		gameType = json.GetString("gameType");
		invalid = json.GetBoolean("invalid");
		level = json.GetNumber("level");
		mapId = json.GetNumber("mapId");
		spell1 = json.GetNumber("spell1");
		spell2 = json.GetNumber("spell2");
		
		statistics = new List<RawStatDto>();
		
		array = json.GetArray("statistics");
		for(int i = 0; i < array.Length; i++)
		{
			statistics.Add(new RawStatDto(array[i].Obj));
		}
		subType = json.GetString("subType");
		teamId = json.GetNumber("teamId");
	}
}

public class PlayerDto
{
	public double championId { get; set; }
	public double summonerId { get; set; }
	public double teamId { get; set; }

	public PlayerDto(JSONObject json)
	{
		championId = json.GetNumber("championId");
		summonerId = json.GetNumber("summonerId");
		teamId = json.GetNumber("teamId");
	}
}

public class RawStatDto
{
	public double id { get; set; }
	public string name { get; set; }
	public double value { get; set; }

	public RawStatDto(JSONObject json)
	{
		id = json.GetNumber("id");
		if(json.ContainsKey("name"))
			name = json.GetString("name");
		value = json.GetNumber("value");
	}
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
	public double timestamp { get; set; }

	public LeagueDto(JSONObject json)
	{
		entries = new List<LeagueItemDto>();

		if(json.ContainsKey("entries"))
		{
			JSONArray array = json.GetArray("entries");
			for(int i = 0; i < array.Length; i++)
			{
				entries.Add(new LeagueItemDto(array[i].Obj));
			}
		}
		if(json.ContainsKey("name"))
			name = json.GetString("name");
		if(json.ContainsKey("queue"))
			queue = json.GetString("queue");
		if(json.ContainsKey("tier"))
			tier = json.GetString("tier");
		if(json.ContainsKey("timestamp"))
			timestamp = json.GetNumber("timestamp");
	}
}

public class LeagueItemDto
{
	public bool isFreshBlood { get; set; }
	public bool isHotStreak { get; set; }
	public bool isInactive { get; set; }
	public bool isVeteran { get; set; }
	public double lastPlayed { get; set; }
	public string leagueName { get; set; }
	public double leaguePoints { get; set; }
	public double losses { get; set; }
	public MiniSeriesDto miniSeries { get; set; }
	public string playerOrTeamId { get; set; }
	public string playerOrTeamName { get; set; }
	public string queueType { get; set; }
	public string rank { get; set; }
	public string tier { get; set; }
	public double timeUntilDecay { get; set; }
	public double wins { get; set; }

	public LeagueItemDto(JSONObject json)
	{
		isFreshBlood = json.GetBoolean("isFreshBlood");
		isHotStreak = json.GetBoolean("isHotStreak");
		isInactive = json.GetBoolean("isInactive");
		isVeteran = json.GetBoolean("isVeteran");
		lastPlayed = json.GetNumber("lastPlayed");
		leagueName = json.GetString("leagueName");
		leaguePoints = json.GetNumber("leaguePoints");
		losses = json.GetNumber("losses");
		miniSeries = new MiniSeriesDto(json.GetObject("miniSeries"));
		playerOrTeamId = json.GetString("playerOrTeamId");
		playerOrTeamName = json.GetString("playerOrTeamName");
		queueType = json.GetString("queueType");
		rank = json.GetString("rank");
		tier = json.GetString("tier");
		timeUntilDecay = json.GetNumber("timeUntilDecay");
		wins = json.GetNumber("wins");
	}
}

public class MiniSeriesDto
{
	public double losses { get; set; }
	public List<Characters> progress { get; set; }
	public double target { get; set; }
	public double timeLeftToPlayMillis { get; set; }
	public double wins { get; set; }

	public MiniSeriesDto(JSONObject json)
	{
		losses = json.GetNumber("losses");
		progress = new List<Characters>();
		
		JSONArray array = json.GetArray("progress");
		for(int i = 0; i < array.Length; i++)
		{
			progress.Add(new Characters(array[i].Obj));
		}
		target = json.GetNumber("target");
		timeLeftToPlayMillis = json.GetNumber("timeLeftToPlayMillis");
		wins = json.GetNumber("wins");
	}
}

public class Characters
{
	public string character { get; set; }

	public Characters(JSONObject json)
	{
		character = json.GetString("character");
	}
}
#endregion

/// <summary>
/// stats-v1.1
/// </summary>
#region stats
public class PlayerStatsSummaryListDto
{
	public List<PlayerStatsSummaryDto> playerStatSummaries { get; set; }
	public double summonerId { get; set; }

	public PlayerStatsSummaryListDto(JSONObject json)
	{
		playerStatSummaries = new List<PlayerStatsSummaryDto>();
		
		JSONArray array = json.GetArray("playerStatSummaries");
		for(int i = 0; i < array.Length; i++)
		{
			playerStatSummaries.Add(new PlayerStatsSummaryDto(array[i].Obj));
		}
		summonerId = json.GetNumber("summonerId");
	}
}

public class PlayerStatsSummaryDto
{
	public List<AggregatedStatDto> aggregatedStats { get; set; }
	public double losses { get; set; }
	public double modifyDate { get; set; }
	public string modifyDateStr { get; set; }
	public string playerStatSummaryType { get; set; }
	public double wins { get; set; }

	public PlayerStatsSummaryDto(JSONObject json)
	{
		aggregatedStats = new List<AggregatedStatDto>();
		
		JSONArray array = json.GetArray("aggregatedStats");
		for(int i = 0; i < array.Length; i++)
		{
			aggregatedStats.Add(new AggregatedStatDto(array[i].Obj));
		}
		losses = json.GetNumber("losses");
		modifyDate = json.GetNumber("modifyDate");
		modifyDateStr = json.GetString("modifyDateStr");
		playerStatSummaryType = json.GetString("playerStatSummaryType");
		wins = json.GetNumber("wins");
	}
}

public class AggregatedStatDto
{
	public double count { get; set; }
	public double id { get; set; }
	public string name { get; set; }

	public AggregatedStatDto(JSONObject json)
	{
		count = json.GetNumber("count");
		id = json.GetNumber("id");
		name = json.GetString("name");
	}
}

public class RankedStatsDto
{
	public List<ChampionStatsDto> champions { get; set; }
	public double modifyDate { get; set; }
	public string modifyDateStr { get; set; }
	public double summonerId { get; set; }

	public RankedStatsDto(JSONObject json)
	{
		champions = new List<ChampionStatsDto>();
		
		JSONArray array = json.GetArray("champions");
		for(int i = 0; i < array.Length; i++)
		{
			champions.Add(new ChampionStatsDto(array[i].Obj));
		}
		modifyDate = json.GetNumber("modifyDate");
		modifyDateStr = json.GetString("modifyDateStr");
		summonerId = json.GetNumber("summonerId");
	}
}

public class ChampionStatsDto
{
	public double id { get; set; }
	public string name { get; set; }
	public List<ChampionStatDto> stats { get; set; }

	public ChampionStatsDto(JSONObject json)
	{
		id = json.GetNumber("id");
		if(json.ContainsKey("name"))
			name = json.GetString("name");

		stats = new List<ChampionStatDto>();
		
		JSONArray array = json.GetArray("stats");
		for(int i = 0; i < array.Length; i++)
		{
			stats.Add(new ChampionStatDto(array[i].Obj));
		}
	}
}

public class ChampionStatDto
{
	public double count { get; set; }
	public double id { get; set; }
	public string name { get; set; }
	public double value { get; set; }

	public ChampionStatDto(JSONObject json)
	{
		if(json.ContainsKey("count"))
			count = json.GetNumber("count");
		id = json.GetNumber("id");
		if(json.ContainsKey("name"))
			name = json.GetString("name");
		value = json.GetNumber("value");
	}
}
#endregion

/// <summary>
/// summoner-v1.1
/// </summary>
#region summoner
public class MasteryPagesDto
{
	public List<MasteryPageDto> pages { get; set; }
	public double summonerId { get; set; }

	public MasteryPagesDto(JSONObject json)
	{
		pages = new List<MasteryPageDto>();
		
		JSONArray array = json.GetArray("pages");
		for(int i = 0; i < array.Length; i++)
		{
			pages.Add(new MasteryPageDto(array[i].Obj));
		}
		summonerId = json.GetNumber("summonerId");
	}
}

public class MasteryPageDto
{
	public bool current { get; set; }
	public string name { get; set; }
	public List<TalentDto> talents { get; set; }

	public MasteryPageDto(JSONObject json)
	{
		talents = new List<TalentDto>();
		
		JSONArray array = json.GetArray("talents");
		for(int i = 0; i < array.Length; i++)
		{
			talents.Add(new TalentDto(array[i].Obj));
		}
		current = json.GetBoolean("current");
		name = json.GetString("name");
	}
}

public class TalentDto
{
	public double id { get; set; }
	public string name { get; set; }
	public double rank { get; set; }

	public TalentDto(JSONObject json)
	{
		id = json.GetNumber("id");
		name = json.GetString("name");
		rank = json.GetNumber("rank");
	}
}

public class RunePagesDto
{
	public List<RunePageDto> pages { get; set; }
	public double summonerId { get; set; }

	public RunePagesDto(JSONObject json)
	{
		pages = new List<RunePageDto>();
		
		JSONArray array = json.GetArray("pages");
		for(int i = 0; i < array.Length; i++)
		{
			pages.Add(new RunePageDto(array[i].Obj));
		}
		summonerId = json.GetNumber("summonerId");
	}
}

public class RunePageDto
{
	public bool current { get; set; }
	public double id { get; set; }
	public string name { get; set; }
	public List<RuneSlotDto> slots { get; set; }

	public RunePageDto(JSONObject json)
	{
		current = json.GetBoolean("current");
		id = json.GetNumber("id");
		name = json.GetString("name");

		slots = new List<RuneSlotDto>();
		JSONArray array = json.GetArray("slots");
		for(int i = 0; i < array.Length; i++)
		{
			slots.Add(new RuneSlotDto(array[i].Obj));
		}
	}
}

public class RuneSlotDto
{
	public RuneDto rune { get; set; }
	public double runeSlotId { get; set; }

	public RuneSlotDto(JSONObject json)
	{
		rune = new RuneDto(json.GetObject("rune"));
		runeSlotId = json.GetNumber("runeSlotId");
	}
}

public class RuneDto
{
	public string description { get; set; }
	public double id { get; set; }
	public string name { get; set; }
	public double tier { get; set; }

	public RuneDto(JSONObject json)
	{
		description = json.GetString("description");
		id = json.GetNumber("id");
		name = json.GetString("name");
		tier = json.GetNumber("tier");
	}
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
	public MessageOfDayDto messageOfDay { get; set; }
	public string modifyDate { get; set; }
	public string name { get; set; }
	public RosterDto roster { get; set; }
	public string secondLastJoinDate { get; set; }
	public string status { get; set; }
	public string tag { get; set; }
	public TeamIdDto teamId { get; set; }
	public TeamStatSummaryDto teamStatSummary { get; set; }
	public string thirdLastJoinDate { get; set; }
	public double timestamp { get; set; }

	public TeamDto(JSONObject json)
	{
		createDate = json.GetString("createDate");
		lastGameDate = json.GetString("lastGameDate");
		lastJoinDate = json.GetString("lastJoinDate");
		lastJoinedRankedTeamQueueDate = json.GetString("lastJoinedRankedTeamQueueDate");
		
		matchHistory = new List<MatchHistorySummaryDto>();
		
		JSONArray array = json.GetArray("matchHistory");
		for(int i = 0; i < array.Length; i++)
		{
			matchHistory.Add(new MatchHistorySummaryDto(array[i].Obj));
		}
		if(json.ContainsKey("messageOfDay"))
			messageOfDay = new MessageOfDayDto(json.GetObject("messageOfDay"));
		modifyDate = json.GetString("modifyDate");
		name = json.GetString("name");
		roster = new RosterDto(json.GetObject("roster"));
		secondLastJoinDate = json.GetString("secondLastJoinDate");
		status = json.GetString("status");
		tag = json.GetString("tag");
		teamId = new TeamIdDto(json.GetObject("teamId"));
		teamStatSummary = new TeamStatSummaryDto(json.GetObject("teamStatSummary"));
		thirdLastJoinDate = json.GetString("thirdLastJoinDate");
		timestamp = json.GetNumber("timestamp");
	}
}

public class MatchHistorySummaryDto
{
	public double assists { get; set; }
	public double date { get; set; }
	public double deaths { get; set; }
	public double gameId { get; set; }
	public string gameMode { get; set; }
	public bool invalid { get; set; }
	public double kills { get; set; }
	public double mapId { get; set; }
	public double opposingTeamKills { get; set; }
	public string opposingTeamName { get; set; }
	public bool win { get; set; }

	public MatchHistorySummaryDto(JSONObject json)
	{
		assists = json.GetNumber("assists");
		date = json.GetNumber("date");
		deaths = json.GetNumber("deaths");
		gameId = json.GetNumber("gameId");
		gameMode = json.GetString("gameMode");
		invalid = json.GetBoolean("invalid");
		kills = json.GetNumber("kills");
		mapId = json.GetNumber("mapId");
		opposingTeamKills = json.GetNumber("opposingTeamKills");
		opposingTeamName = json.GetString("opposingTeamName");
		win = json.GetBoolean("win");
	}
}

public class MessageOfDayDto
{
	public double createDate { get; set; }
	public string message { get; set; }
	public double version { get; set; }

	public MessageOfDayDto(JSONObject json)
	{
		createDate = json.GetNumber("createDate");
		message = json.GetString("message");
		version = json.GetNumber("version");
	}
}

public class RosterDto
{
	public List<TeamMemberInfoDto> memberList { get; set; }
	public double ownerId { get; set; }

	public RosterDto(JSONObject json)
	{
		memberList = new List<TeamMemberInfoDto>();
		
		JSONArray array = json.GetArray("memberList");
		for(int i = 0; i < array.Length; i++)
		{
			memberList.Add(new TeamMemberInfoDto(array[i].Obj));
		}
		ownerId = json.GetNumber("ownerId");
	}
}

public class TeamIdDto
{
	public string fullId { get; set; }

	public TeamIdDto(JSONObject json)
	{
		fullId = json.GetString("fullId");
	}
}

public class TeamStatSummaryDto
{
	public TeamIdDto teamId { get; set; }
	public List<TeamStatDetailDto> teamStatDetails { get; set; }

	public TeamStatSummaryDto(JSONObject json)
	{
		teamStatDetails = new List<TeamStatDetailDto>();
		
		JSONArray array = json.GetArray("teamStatDetails");
		for(int i = 0; i < array.Length; i++)
		{
			teamStatDetails.Add(new TeamStatDetailDto(array[i].Obj));
		}
		teamId = new TeamIdDto(json.GetObject("teamId"));
	}
}

public class TeamMemberInfoDto
{
	public string inviteDate { get; set; }
	public string joinDate { get; set; }
	public double playerId { get; set; }
	public string status { get; set; }

	public TeamMemberInfoDto(JSONObject json)
	{
		inviteDate = json.GetString("inviteDate");
		joinDate = json.GetString("joinDate");
		playerId = json.GetNumber("playerId");
		status = json.GetString("status");
	}
}

public class TeamStatDetailDto
{
	public double averageGamesPlayed { get; set; }
	public double losses { get; set; }
	public double maxRating { get; set; }
	public double rating { get; set; }
	public double seedRating { get; set; }
	public TeamIdDto teamId { get; set; }
	public string teamStatType { get; set; }
	public double wins { get; set; }

	public TeamStatDetailDto(JSONObject json)
	{
		averageGamesPlayed = json.GetNumber("averageGamesPlayed");
		losses = json.GetNumber("losses");
		if(json.ContainsKey("maxRating"))
			maxRating = json.GetNumber("maxRating");
		if(json.ContainsKey("rating"))
			rating = json.GetNumber("rating");
		if(json.ContainsKey("seedRating"))
			seedRating = json.GetNumber("seedRating");
		teamId = new TeamIdDto(json.GetObject("teamId"));
		teamStatType = json.GetString("teamStatType");
		wins = json.GetNumber("wins");
	}
}
#endregion
