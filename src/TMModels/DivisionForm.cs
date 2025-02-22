﻿using TMModels;

namespace TMLeague.Models.Judge;

public class DivisionForm
{
    public string? League { get; set; }
    public string? Season { get; set; }
    public string? Division { get; set; }
    public string? Password { get; set; }
    public string? Contact { get; set; }
    public string? JudgeName { get; set; }
    public string? MessageSubject { get; set; }
    public string? MessageBody { get; set; }
    public string? Player1 { get; set; }
    public string? Player2 { get; set; }
    public string? Player3 { get; set; }
    public string? Player4 { get; set; }
    public string? Player5 { get; set; }
    public string? Player6 { get; set; }
    public string? Player7 { get; set; }
    public string? Player8 { get; set; }
    public string? Player9 { get; set; }
    public string? Player10 { get; set; }
    public string[] Players => new[] { Player1, Player2, Player3, Player4, Player5, Player6, Player7, Player8, Player9, Player10 }
        .Where(p => !string.IsNullOrWhiteSpace(p))
        .Select(s => s!).ToArray();
}

public record DivisionDraft(List<PlayerDraft> Draft)
{
    public int Players => Draft.Count;
    public int Games => Draft.FirstOrDefault()?.Games.Length ?? 0;
}

public record PlayerDraft(
    string Name,
    House[] Games,
    string MessageSubject,
    string MessageBody,
    PlayerDraftStats? Stats);

public record PlayerDraftStats(
    List<PlayerDraftStat> Enemies,
    List<PlayerDraftStat> Neighbors)
{
    public PlayerDraftStat CommonEnemy
    {
        get
        {
            var max = Enemies.Max(stat => stat.Games);
            return Enemies.First(stat => stat.Games == max);
        }
    }

    public PlayerDraftStat CommonNeighbor
    {
        get
        {
            var max = Neighbors.Max(stat => stat.Games);
            return Neighbors.First(stat => stat.Games == max);
        }
    }
}

public record PlayerDraftStat(string Player, int Games);

public record PlayerHouseGames(int Baratheon, int Lannister, int Stark, int Tyrell, int Greyjoy, int Martell, int Arryn);