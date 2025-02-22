﻿using TMModels;

namespace TMApplication.Providers;

public interface IDataProvider
{
    public Task<Home?> GetHome(CancellationToken cancellationToken);
    public Task<League?> GetLeague(string leagueId, CancellationToken cancellationToken);
    public Task<Season?> GetSeason(string? leagueId, string seasonId, CancellationToken cancellationToken);
    public Task<Division?> GetDivision(string? leagueId, string seasonId, string divisionId,
        CancellationToken cancellationToken);
    public Task<Game?> GetGame(int gameId, CancellationToken cancellationToken);
    public Task<Results?> GetResults(string leagueId, string seasonId, string divisionId, CancellationToken cancellationToken);
    public Task<Draft[]> GetDrafts(int players, CancellationToken cancellationToken);
    public Task<Summary?> GetSummary(string leagueId, CancellationToken cancellationToken);
};