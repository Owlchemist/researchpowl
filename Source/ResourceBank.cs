﻿using Verse;
using RimWorld;
using UnityEngine;

namespace ResearchPowl
{
  public static class ResourceBank
  {
        public static Color colorWhite = Color.white;
        public static class String
        {
            const string PREFIX = "ResearchPal.";
            static string TL(string s) => (PREFIX + s).Translate();
            static string TL(string s, params NamedArgument[] args) => (PREFIX + s).Translate(args);

            #region Settings
            public static readonly string ResetTreeLayout = TL("ResetLayout");
            public static readonly string LayoutRegenerated = TL("LayoutRegenerated");
            public static readonly string ShouldSeparateByTechLevels = TL("ShouldSeparateByTechLevels");
            public static readonly string ShouldSeparateByTechLevelsTip = TL("ShouldSeparateByTechLevelsTip");
            public static readonly string ShouldPauseOnOpen = TL("ShouldPauseOnOpen");
            public static readonly string ShouldPauseOnOpenTip = TL("ShouldPauseOnOpenTip");
            public static readonly string ShouldResetOnOpen = TL("ShouldResetOnOpen");
            public static readonly string ShouldResetOnOpenTip = TL("ShouldResetOnOpenTip");
            public static readonly string PlaceModTechSeparately = TL("GroupModTechs");
            public static readonly string PlaceModTechSeparatelyTip = TL("GroupModTechsTip");
            public static readonly string AlignCloserToAncestors = TL("AlignCloserToAncestors");
            public static readonly string AlignCloserToAncestorsTip = TL("AlignCloserToAncestorsTip");
            public static readonly string MinimumSeparateModTech = TL("MinimumSeparateModTech");
            public static readonly string MinimumSeparateModTechTip = TL("MinimumSeparateModTechTip");
            public static readonly string SearchByDescription = TL("SearchByDescription");
            public static readonly string SearchByDescriptionTip = TL("SearchByDescriptionTip");
            public static readonly string DelayLayoutGeneration = TL("DelayLayoutGeneration");
            public static readonly string DelayLayoutGenerationTip = TL("DelayLayoutGenerationTip");
            public static readonly string AsyncLoadingOnStartup = TL("AsyncLoadingOnStartup");
            public static readonly string AsyncLoadingOnStartupTip = TL("AsyncLoadingOnStartupTip");
            public static readonly string ProgressTooltip = TL("ProgressTooltip");
            public static readonly string ProgressTooltipTip = TL("ProgressTooltipTip");
            public static readonly string AlwaysDisplayProgress = TL("AlwaysDisplayProgress");
            public static readonly string AlwaysDisplayProgressTip = TL("AlwaysDisplayProgressTip");
            public static readonly string ShowIndexOnQueue = TL("ShowQueueIndexOnQueue");
            public static readonly string ShowIndexOnQueueTip = TL("ShowQueueIndexOnQueueTip");
            public static readonly string DisableShortcutManual = TL("DisableShortcutManual");
            public static readonly string SwapZoomMode = TL("SwapZoomMode");
            public static readonly string SwapZoomModeTip = TL("SwapZoomModeTip");
            public static readonly string DontIgnoreHiddenPrerequisites = TL("DontIgnoreHiddenPrerequisites");
            public static readonly string DontIgnoreHiddenPrerequisitesTip = TL("DontIgnoreHiddenPrerequisitesTip");
            public static readonly string useVanillaResearchFinishedMessage = TL("ShowVanillaResearchFinishedMessage");
            public static readonly string useVanillaResearchFinishedMessageTip = TL("ShowVanillaResearchFinishedMessageTip");

            #endregion

            #region ResearchProjectDef_Extensions
            public static string AllowsBuildingX(string x) => TL("AllowsBuildingX", x);
            public static string AllowsCraftingX(string x) => TL("AllowsCraftingX", x);
            public static string AllowsPlantingX(string x) => TL("AllowsPlantingX", x);
            public static string OtherPrerequisites(string x) => TL("OtherPrerequisites", x);
            public static string AllowGeneralX(string x) => TL("AllowGeneralX", x);
            #endregion

            #region ResearchNode
            public static readonly string LClickReplaceQueue = TL("LClickReplaceQueue");
            public static readonly string LClickRemoveFromQueue = TL("LClickRemoveFromQueue");
            public static readonly string SLClickAddToQueue = TL("SLClickAddToQueue");
            public static readonly string ALClickAddToQueue = TL("ALClickAddToQueue");
            public static readonly string CLClickDebugInstant = TL("CLClickDebugInstant");
            public static readonly string RClickHighlight = TL("RightClickNode");
            public static readonly string RClickIcon = TL("RightClickIcon");
            public static readonly string Drag = TL("Drag");
            public static readonly string ShiftForShortcutManual = TL("ShortcutManual");
            public static string MissingFacilities(string list) => TL("MissingFacilities", list);
            public static string FinishedResearch(string label) => TL("ResearchFinished", label);
            public static readonly string TechLevelOfResearch = TL("TechLevel");
            public static string TechLevelTooLow(TechLevel techlevel, float multiplier, int baseCost)
            {
              return "ResearchPal.TechLevelTooLow".Translate(techlevel.ToStringHuman(), multiplier.ToString(), baseCost.ToString());
            }
            #endregion

            #region MainTabWindow_ResearchTree
            public static readonly string NoResearchFound = TL("NoResearchFound");
            #endregion

            #region Queue
            public static readonly string NothingQueued = TL("NothingQueued");
            public static string NextInQueue(string label) => TL("NextInQueue", label);
            #endregion

            #region Tree
            #endregion
        }
  }
}
