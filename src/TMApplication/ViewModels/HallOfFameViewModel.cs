﻿namespace TMApplication.ViewModels;

public record HallOfFameViewModel(
    IReadOnlyCollection<HallOfFameSectionViewModel> Sections);

public record HallOfFameSectionViewModel(
    string Section,
    IReadOnlyCollection<HallOfFameDivisionViewModel> Divisions);

public record HallOfFameDivisionViewModel(
    string Division,
    IReadOnlyCollection<HallOfFamePlayerViewModel> Players);

public record HallOfFamePlayerViewModel(
    string Player,
    double Score);