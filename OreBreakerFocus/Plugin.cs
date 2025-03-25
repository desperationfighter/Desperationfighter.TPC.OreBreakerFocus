using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using System.Reflection;

namespace RecycletoInventory
{
    [BepInPlugin(GUID, Name, Version)]
    public class Plugin : BaseUnityPlugin
    {
        public new static ManualLogSource Logger { get; private set; }
        public const string GUID = "Desperationfighter.TPC.OreBreakerFocus";
        public const string Name = "Ore Breaker Focus";
        public const string Version = "1.0.0.0"; //Remmber to Update Assembly Version too !

        public static ConfigEntry<bool> ModisActive;
        public static ConfigEntry<bool> ModifyTick;
        public static ConfigEntry<bool> ModifyBreakintoXParts;
        //public static ConfigEntry<int> UseStage;
        //public static ConfigEntry<int> Breakluck;
        public static ConfigEntry<int> BreakIntervaltier1;
        public static ConfigEntry<int> BreakIntervaltier2;
        public static ConfigEntry<int> BreakIntervaltier3;
        public static ConfigEntry<int> BreakintoPartstier1;
        public static ConfigEntry<int> BreakintoPartstier2;
        public static ConfigEntry<int> BreakintoPartstier3;
        public static ConfigEntry<bool> Debuglogging;

        public const int OriginalBreakIntervaltier1 = 130;
        public const int OriginalBreakIntervaltier2 = 90;
        public const int OriginalBreakIntervaltier3 = 70;
        public const int OriginalBreakintoPartstier1 = 3;
        public const int OriginalBreakintoPartstier2 = 4;
        public const int OriginalBreakintoPartstier3 = 5;

        private void Awake()
        {
            ModisActive = Config.Bind("1_General", "ModisActive", true, "Set if the Mod should running or not. Should work while Game is running. Not gurantee");
            ModifyTick = Config.Bind("2_Config", "ModifyTick", true, "Set if you want to Manipulate this speicifc Mod Feature");
            ModifyBreakintoXParts = Config.Bind("2_Config", "ModifyBreakintoXParts", true, "Set if you want to Manipulate this speicifc Mod Feature");
            
            //          UseStage = Config.Bind("2_Usage", "UseStage", 2, "Set wanted usage Methode. " +
            //   "0 = Just adjust Interval and let everything else Vanilla; " +
            //   "1 = Extract only Primary Ore and NEVER get any by Product; " +
            //   "2 = Focus on Primary ore. You still get a small amount of by product Ores");
            //          Breakluck = Config.Bind("4_Stage2-Subconfig", "Breakluck", 2, "This config only applies when UseStage 2 is used. Its a 1 of X mechanic when you get eventually byproducts. For example Setting this to 1 mean 1 of 1 time you get eventually byproduct. Setting it on 2 means 1 of 2 Times you get eventually byproduct. 3 => 1 of 3 times eventually byproduct. In Percentage that means 33% of times you get a eventually random byproduct. But 2 Times gurantee the Primary Ore.");

            BreakIntervaltier1 = Config.Bind("3_Tick", "BreakIntervaltier1", 130, "Affect Tier 1 Ore Breaker -> Default value in Game = 130; Time span between two Ore break tries.");
            BreakIntervaltier2 = Config.Bind("3_Tick", "BreakIntervaltier2", 90, "Affect Tier 2 Ore Breaker -> Default value in Game = 90; Time span between two break tries.");
            BreakIntervaltier3 = Config.Bind("3_Tick", "BreakIntervaltier3", 70, "Affect Tier 3 Ore Breaker -> Default value in Game = 70; Time span between two break tries.");
            BreakintoPartstier1 = Config.Bind("5_BreakintoParts", "BreakintoParts1", 3, "Affect Tier 1 Ore Breaker -> Default value in Game = 3; Modify how much Ores you get back per Break.");
            BreakintoPartstier2 = Config.Bind("5_BreakintoParts", "BreakintoParts2", 4, "Affect Tier 2 Ore Breaker -> Default value in Game = 4; Modify how much Ores you get back per Break.");
            BreakintoPartstier3 = Config.Bind("5_BreakintoParts", "BreakintoParts3", 5, "Affect Tier 3 Ore Breaker -> Default value in Game = 3; Modify how much Ores you get back per Break.");
            
            Debuglogging = Config.Bind("9_Advanced", "Debuglogging", false, "Enables Debug Logging. Should be only activated when you know what you do.");

            // set project-scoped logger instance
            Logger = base.Logger;

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), GUID);
            Logger.LogInfo($"Plugin {GUID} is loaded!");
        }

        public static void MyDebugLogger(string message)
        {
            if (Debuglogging.Value)
            {
                Logger.LogDebug($"{message}");
            }
        }
    }
}
