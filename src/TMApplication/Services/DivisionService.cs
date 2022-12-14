﻿using TMApplication.Providers;
using TMApplication.ViewModels;

namespace TMApplication.Services;

public class DivisionService
{
    private readonly IDataProvider _dataProvider;
    private readonly GameService _gameService;

    public DivisionService(IDataProvider dataProvider, GameService gameService)
    {
        _dataProvider = dataProvider;
        _gameService = gameService;
    }

    public async Task<DivisionSummaryViewModel?> GetDivisionSummaryVm(string leagueId, string seasonId, string divisionId, CancellationToken cancellationToken = default)
    {
        var division = await _dataProvider.GetDivision(leagueId, seasonId, divisionId, cancellationToken);

        var games = new List<GameSummaryViewModel?>();

        if (division == null)
            return new DivisionSummaryViewModel(leagueId, seasonId, divisionId, division?.Name, 0, games);

        var progress = 0.0;
        foreach (var gameId in division.Games)
        {
            var game = await _gameService.GetGameSummaryVm(gameId, cancellationToken);
            if (game == null)
                continue;

            games.Add(game);
            progress += game.Progress;
        }

        progress /= games.Count;

        return new DivisionSummaryViewModel(leagueId, seasonId, divisionId, division?.Name, progress, games);
    }
}