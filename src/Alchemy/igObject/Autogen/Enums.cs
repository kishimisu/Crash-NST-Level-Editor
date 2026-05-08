namespace Alchemy
{
    public enum CGuiManager_EPriority
    {
        eP_DisableUnderPriority = -2,
        eP_DisableUnderNone = -1,
        eP_Screenspace = 0,
        eP_HUD = 1,
        eP_TargetArrow = 2,
        eP_Alert = 3,
        eP_ObjectiveCounter = 4,
        eP_VirtualController = 5,
        eP_NetworkUnderMenu = 6,
        eP_MenuAllowSound = 7,
        eP_Menu = 8,
        eP_Urgent = 9,
        eP_AutoSaveIcon = 10,
    }

    public enum EAccoladeGroup
    {
        eAG_Invalid = -1,
        eAG_Challenge = 0,
        eAG_Collectible = 1,
        eAG_Toys = 2,
        eAG_Traversal = 3,
        eAG_Count = 4,
    }

    public enum EAcquireInsertMethod
    {
        eAIM_Clear = 0,
        eAIM_Append = 1,
        eAIM_RemoveFront = 2,
        eAIM_RandomSwap = 3,
        eAIM_FilterCurrentList = 4,
    }

    public enum EActionType
    {
        eAT_Invalid = -1,
        eAT_LoadMap = 0,
        eAT_RunScript = 1,
        eAT_ImageCompare = 2,
        eAT_ImageDump = 3,
        eAT_LoadHeroes = 4,
        eAT_Exit = 5,
        eAT_Wait = 6,
        eAT_PrintPerformanceStats = 7,
        eAT_Race = 8,
        eAT_Hub = 9,
        eAT_Arena = 10,
    }

    public enum EAimingMethod
    {
        eAM_NoAiming = 0,
        eAM_AimAtTarget = 1,
        eAM_AimAtAimedPosition = 2,
        eAM_AimAtTargetThenPosition = 3,
        eAM_LeadTarget = 4,
    }

    public enum EAllowedHitReactDirections
    {
        eAHRD_NoReaction = 0,
        eAHRD_NoDirection = 1,
        eAHRD_Front = 2,
        eAHRD_FrontAndBack = 3,
        eAHRD_FrontBackLeftRight = 4,
    }

    public enum EAnalogStick
    {
        eAS_None = -1,
        eAS_Left = 0,
        eAS_Right = 1,
        eAS_Mouse = 2,
        eAS_CTRNF_Max = 2,
        eAS_Max = 3,
    }

    public enum EAnimationEventMask
    {
        eAEM_None = 0,
        eAEM_Added = 1,
        eAEM_Started = 2,
        eAEM_EaseInStarted = 4,
        eAEM_EaseInCompleted = 8,
        eAEM_EaseOutStarted = 16,
        eAEM_EaseOutCompleted = 32,
        eAEM_Pause = 64,
        eAEM_Cycled = 128,
        eAEM_Completed = 256,
        eAEM_Removed = 512,
    }

    public enum EAsyncMatchmakingGameTypes
    {
        eAMGT_Invalid = 0,
        eAMGT_Race = 1,
        eAMGT_Battle = 2,
    }

    public enum EAttackType
    {
        eAT_None = 0,
        eAT_Melee = 1,
        eAT_Ranged = 2,
    }

    public enum EBakeLight
    {
        eBL_DynamicAndBaked = 0,
        eBL_DynamicOnly = 1,
        eBL_BakedOnly = 2,
    }

    public enum EBidiType
    {
        kBidiTypeLeft = 0,
        kBidiTypeRight = 1,
        kBidiTypeNeutral = 2,
        kBidiTypeNumeric = 3,
        kBidiTypeSeparator = 4,
    }

    public enum EBlendFormat
    {
        kFormatNormal = 0,
        kFormatInvert = 1,
        kFormatSigned = 2,
        kFormatInvertDouble = 3,
        kFormatInvertSigned = 4,
        kFormatDouble = 5,
        kFormatBottomHalf = 6,
        kFormatInvertTopHalf = 7,
        kFormatTopHalf = 8,
        kFormatInvertBottomHalf = 9,
        kFormatNegative = 10,
        kFormatNegativeHalf = 11,
        kFormatNegativeDouble = 12,
        kFormatOne = 13,
        kFormatZero = 14,
    }

    public enum EBlendType
    {
        BLEND_TYPE_BLEND_IN = 0,
        BLEND_TYPE_FULL_ON = 1,
    }

    public enum EBobResetType
    {
        eBRT_HardReset = 0,
        eBRT_ResetDirection = 1,
        eBRT_ContinueDirection = 2,
    }

    public enum EBoltonModels
    {
        EBOLTON_NONE = -1,
        EBOLTON_CLAW_RIGHT = 0,
        EBOLTON_WEAPON = 1,
        EBOLTON_CLAW_LEFT = 2,
        EBOLTON_ALT_WEAPON = 3,
        EBOLTON_CAPE = 4,
        EBOLTON_TAIL = 5,
        EBOLTON_WINGS = 6,
        EBOLTON_HAIR = 7,
        EBOLTON_ALT_WEAPON2 = 8,
        EBOLTON_ALT_WEAPON3 = 9,
        EBOLTON_ALT_WEAPON4 = 10,
        EBOLTON_ALT_WEAPON5 = 11,
        EBOLTON_EQUIPMENT01 = 12,
        EBOLTON_EQUIPMENT02 = 13,
        EBOLTON_EQUIPMENT03 = 14,
        EBOLTON_EQUIPMENT04 = 15,
        EBOLTON_EQUIPMENT05 = 16,
        EBOLTON_EQUIPMENT06 = 17,
        EBOLTON_EQUIPMENT07 = 18,
        EBOLTON_CHARACTERMOD01 = 19,
        EBOLTON_PASSENGERGRIP01 = 20,
        EBOLTON_VEHICLE_PRIMARYMOD01 = 21,
        EBOLTON_VEHICLE_PRIMARYMOD02 = 22,
        EBOLTON_VEHICLE_PRIMARYMOD03 = 23,
        EBOLTON_VEHICLE_PRIMARYMOD04 = 24,
        EBOLTON_VEHICLE_PRIMARYMOD05 = 25,
        EBOLTON_VEHICLE_PRIMARYMOD06 = 26,
        EBOLTON_VEHICLE_PRIMARYMOD07 = 27,
        EBOLTON_VEHICLE_PRIMARYMOD08 = 28,
        EBOLTON_VEHICLE_SECONDARYMOD01 = 29,
        EBOLTON_VEHICLE_SECONDARYMOD02 = 30,
        EBOLTON_VEHICLE_SECONDARYMOD03 = 31,
        EBOLTON_VEHICLE_SECONDARYMOD04 = 32,
        EBOLTON_VEHICLE_SECONDARYMOD05 = 33,
        EBOLTON_VEHICLE_SECONDARYMOD06 = 34,
        EBOLTON_VEHICLE_SECONDARYMOD07 = 35,
        EBOLTON_VEHICLE_SECONDARYMOD08 = 36,
        EBOLTON_MAX = 37,
    }

    public enum EButtonLegendButton
    {
        eBLB_Invalid = 0,
        eBLB_Select = 1,
        eBLB_Back = 2,
        eBLB_Option1 = 3,
        eBLB_Option2 = 4,
        eBLB_BumperLeft = 5,
        eBLB_BumperRight = 6,
        eBLB_TriggerLeft = 7,
        eBLB_TriggerRight = 8,
        eBLB_LeftStick = 9,
        eBLB_RightStick = 10,
        eBLB_Dpad = 11,
        eBLB_Option3 = 12,
        eBLB_CTRNF_Menu = 12,
    }

    public enum EBuyButtonStatusIconState
    {
        eBBSIS_NotVisible = 0,
        eBBSIS_Purchased = 1,
        eBBSIS_Warning = 2,
    }

    public enum ECameraBoxState
    {
        eCBS_Invalid = 0,
        eCBS_Reset = 1,
        eCBS_ProgressedThrough = 2,
        eCBS_Progressing = 3,
        eCBS_BacktrackedThrough = 4,
    }

    public enum ECameraModelBlendType
    {
        eCMBT_Spherical = 0,
        eCMBT_Linear = 1,
        eCMBT_SeparateYawAndPitch = 2,
    }

    public enum ECastShadows
    {
        eCS_No = 0,
        eCS_Yes = 1,
        eCS_Only = 2,
    }

    public enum ECGuiLobbyTimerState
    {
        eLTS_Invalid = -1,
        eLTS_Default = 0,
        eLTS_TopRightCorner = 1,
    }

    public enum ECharacterAttribute
    {
        eCA_Invalid = 0,
        eCA_MaximumHealth = 1,
        eCA_BaseResistance = 2,
        eCA_MeleeResistance = 3,
        eCA_RangedResistance = 4,
        eCA_BaseStrength = 5,
        eCA_MeleeStrength = 6,
        eCA_RangedStrength = 7,
        eCA_Speed = 8,
        eCA_MovementSpeed = 9,
        eCA_AttackSpeed = 10,
        eCA_CriticalHitChance = 11,
        eCA_CriticalHitMultiplier = 12,
        eCA_Count = 13,
    }

    public enum ECharacterCollisionPriority
    {
        eCCP_NonGameplayCritical = 0,
        eCCP_None = 1,
        eCCP_Low = 2,
        eCCP_NormalSelfPushable = 3,
        eCCP_Normal = 4,
        eCCP_JumpingPlayer = 5,
        eCCP_High = 6,
        eCCP_Charger = 7,
        eCCP_PlayerTraversable = 8,
        eCCP_Immobile = 9,
    }

    public enum ECharacterType
    {
        eCT_Driver = 0,
        eCT_Kart = 1,
        eCT_Done = 2,
    }

    public enum ECollectibleType
    {
        eCT_Invalid = 0,
        eCT_Begin = 1,
        eCT_Health = 1,
        eCT_Money = 2,
        eCT_Xp = 3,
        eCT_VehicleXp = 4,
        eCT_VehicleShields = 5,
        eCT_Stardust = 6,
        eCT_Max = 7,
    }

    public enum ECollectibleWorldModifierCategory
    {
        eCWMC_UseCollectibleDefaults = -1,
        eCWMC_Coin = 0,
        eCWMC_Crown = 1,
        eCWMC_Food = 2,
        eCWMC_Medalian = 3,
        eCWMC_Ring01 = 4,
        eCWMC_Ring02 = 5,
        eCWMC_Ring03 = 6,
        eCWMC_StackedGold = 7,
        eCWMC_TreasureChestCrown = 8,
        eCWMC_TurboWingedGem = 9,
        eCWMC_XPSmall = 10,
        eCWMC_XPMedium = 11,
        eCWMC_XPLarge = 12,
        eCWMC_OnFoot_VehicleXPSmall = 13,
        eCWMC_OnFoot_VehicleXPLarge = 14,
        eCWMC_Max = 15,
    }

    public enum EColorMode
    {
        kFlatColor = 0,
        kLinearVerticalAToB = 1,
    }

    public enum ECombatMusicIntensity
    {
        eCMI_NoChange = 0,
        eCMI_Low = 1,
        eCMI_Medium = 2,
        eCMI_High = 3,
        eCMI_Special1 = 4,
        eCMI_Special2 = 5,
        eCMI_Special3 = 6,
        eCMI_Special4 = 7,
        eCMI_Special5 = 8,
    }

    public enum ECombatTargetList
    {
        eCTL_Default = 0,
        eCTL_DriverMod = 1,
        eCTL_DriverMod2 = 2,
        eCTL_PassengerMod = 3,
        eCTL_PassengerMod2 = 4,
        eCTL_VehicleMod = 5,
        eCTL_VehicleMod2 = 6,
    }

    public enum ECombatTargetSelect
    {
        eCTS_None = 0,
        eCTS_Self = 1,
        eCTS_First = 2,
        eCTS_Last = 3,
        eCTS_Owner = 4,
        eCTS_PlayerControlledHero = 5,
        eCTS_All = 6,
    }

    public enum EConstraintAxis
    {
        eCA_X = 0,
        eCA_Y = 1,
        eCA_Z = 2,
    }

    public enum EController
    {
        ECONTROLLER_NONE = -1,
        ECONTROLLER_ONE = 0,
        CTRNF_kControllerNone = 0,
        ECONTROLLER_TWO = 1,
        CTRNF_kController1 = 1,
        ECONTROLLER_THREE = 2,
        CTRNF_kController2 = 2,
        ECONTROLLER_FOUR = 3,
        ECONTROLLER_FIVE = 4,
        CTRNF_kController3 = 4,
        ECONTROLLER_SIX = 5,
        ECONTROLLER_SEVEN = 6,
        ECONTROLLER_EIGHT = 7,
        ECONTROLLER_MAX = 8,
        CTRNF_kController4 = 8,
        CTRNF_kControllerMax = 8,
        CTRNF_kController5 = 16,
        CTRNF_kController6 = 32,
        CTRNF_kController7 = 64,
        CTRNF_kController8 = 128,
        CTRNF_kControllerAll = 255,
    }

    public enum EControllerPriorityCategory
    {
        kPriorityNone = 0,
        kCoreController = 1,
        kLevelController = 2,
        kCombatController = 3,
        kManualController = 4,
        kManualOverrideController = 5,
    }

    public enum EControllerType
    {
        ECONTROLLERTYPE_INVALID = 0,
        ECONTROLLERTYPE_XENON = 1,
        ECONTROLLERTYPE_PS3 = 2,
        ECONTROLLERTYPE_DURANGO = 3,
        ECONTROLLERTYPE_PS4 = 4,
        ECONTROLLERTYPE_ASPEN = 5,
        ECONTROLLERTYPE_ASPEN_VIRTUAL = 6,
        ECONTROLLERTYPE_APPLE_TV = 7,
        ECONTROLLERTYPE_NX = 8,
        ECONTROLLERTYPE_CTRNF_NX_LEFT = 8,
        ECONTROLLERTYPE_CTRNF_NX_RIGHT = 9,
        ECONTROLLERTYPE_CTRNF_NX_DUAL = 10,
        ECONTROLLERTYPE_CTRNF_NX_PRO = 11,
        ECONTROLLERTYPE_CTRNF_NX_HANDHELD = 12,
        ECONTROLLERTYPE_CTRNF_NX_DEBUG = 13,
    }

    public enum ECrashGame
    {
        eCG_Invalid = 0,
        eCG_Crash1 = 1,
        eCG_Crash2 = 2,
        eCG_Crash3 = 3,
    }

    public enum ECrashSecretZones
    {
        eCSZ_None = 0,
        eCSZ_C2_AirCrash = 1,
        eCSZ_C2_SnowGo = 2,
        eCSZ_C2_RoadToRuin = 3,
        eCSZ_C2_TotallyBear = 4,
        eCSZ_C2_TotallyFly = 5,
        eCSZ_C3_SkiCrazed = 6,
        eCSZ_C3_HangemHigh = 7,
        eCSZ_C3_Area51 = 8,
        eCSZ_C3_FutureFrenzy = 9,
        eCSZ_C3_RingsOfPower = 10,
        eCSZ_C3_HotCoco = 11,
        eCSZ_C3_EggipusRex = 12,
        eCSZ_C3_FutureTense = 13,
        eCSZ_Max = 14,
    }

    public enum ECrateContent
    {
        eCC_PowerUp = 0,
        eCC_WumpaCrate = 1,
        eCC_WumpaFruit = 2,
        eCC_SwitchCrate = 3,
    }

    public enum ECRMMessageLocation
    {
        eCRMML_Invalid = 0,
        eCRMML_NewsTicker = 1,
        eCRMML_Count = 2,
    }

    public enum ECtrChallengeTokenType
    {
        eCCTT_C = 0,
        eCCTT_T = 1,
        eCCTT_R = 2,
    }

    public enum ECullType
    {
        kCullNone = 0,
        kCullDefault = 1,
        kCullSoft = 2,
        kCullHard = 4,
        kCullPause = 8,
        kCullAll = 14,
    }

    public enum ECustomizationMenuDisplayType
    {
        eCMDT_Default = 0,
        eCMDT_DriverOnly = 1,
        eCMDT_KartOnly = 2,
    }

    public enum ECustomizationType
    {
        eCT_Invalid = 0,
        eCT_CharacterRacer = 1,
        eCT_CharacterSkin = 2,
        eCT_KartBody = 3,
        eCT_KartWheels = 4,
        eCT_KartPaint = 5,
        eCT_KartDecal = 6,
        eCT_KartSticker = 7,
        eCT_Preset = 8,
    }

    public enum EDamageNumberType
    {
        eDNT_Health = 0,
        eDNT_Damage = 1,
        eDNT_DamageFromPlayer = 2,
        eDNT_CriticalDamage = 3,
        eDNT_Money = 4,
        eDNT_StatBoost = 5,
        eDNT_SuperchargeDamage = 6,
        eDNT_SuperchargeDamageCritical = 7,
        eDNT_Custom = 8,
        eDNT_CustomSigned = 9,
        eDNT_ArmorBlocked = 10,
    }

    public enum EDamageType
    {
        eDMG_None = 0,
        eDMG_Basic = 1,
        eDMG_Poison = 2,
        eDMG_Water = 3,
        eDMG_Fire = 4,
        eDMG_Air = 5,
        eDMG_Electricity = 6,
        eDMG_Crushing = 7,
        eDMG_Magic = 8,
        eDMG_Blade = 9,
        eDMG_Victim = 10,
        eDMG_VehicleCollision = 11,
        eDMG_Max = 12,
    }

    public enum EDamageVibration
    {
        eDV_Auto = -2,
        eDV_None = -1,
        eDV_Weakest = 0,
        eDV_Weak = 1,
        eDV_Medium = 2,
        eDV_Strong = 3,
        eDV_Strongest = 4,
        eDV_WeakPain = 5,
        eDV_MediumPain = 6,
        eDV_StrongPain = 7,
    }

    public enum EDebugVisibility
    {
        kDebugVisibilityHide = 0,
        kDebugVisibilityShow = 1,
        kDebugVisibilityDefault = 2,
    }

    public enum EDeviceClass
    {
        eDC_None = 0,
        eDC_Gen8Console = 1,
        eDC_Gen7Console = 2,
        eDC_HighTablet = 4,
        eDC_MediumTablet = 8,
        eDC_LowTablet = 16,
        eDC_All = 31,
        eDC_Special_NoSplitGen7 = 32,
        eDC_Special_SplitGen7Only = 64,
        eDC_CTRNF_XBONEConsole = 128,
        eDC_CTRNF_All = 159,
    }

    public enum EDifficultyLevel
    {
        eDL_Invalid = -1,
        eDL_Easy = 0,
        eDL_Medium = 1,
        eDL_Hard = 2,
        eDL_Nightmare = 3,
        eDL_Count = 4,
    }

    public enum EDisableInCutsceneBehavior
    {
        eDICB_HideInAllCutscenes = 0,
        eGSCB_HideInListedCutscenes = 1,
        eGSCB_ShowInListedCutscenes = 2,
    }

    public enum EDistanceCullImportance
    {
        kVeryLow = 0,
        kLow = 1,
        kMedium = 2,
        kHigh = 3,
        kCritical = 4,
        kImportanceCount = 4,
        CTRNF_kLighting = 4,
        CTRNF_kImportanceCount = 5,
        CTRNF_kCritical = 5,
    }

    public enum EDrawForceCoordinateSystem
    {
        eDFCS_Cartesian = 0,
        eDFCS_Spherical = 1,
        eDFCS_Cylindrical = 2,
    }

    public enum EDrawForceRangeCorrelation
    {
        eDFRC_Random = 0,
        eDFRC_Instance = 1,
    }

    public enum EDrawForceShapeType
    {
        eDFST_Sphere = 0,
        eDFST_Box = 1,
    }

    public enum EDriverDifficultyClass
    {
        eDDC_Invalid = 0,
        eDDC_Beginner = 1,
        eDDC_Intermediate = 2,
        eDDC_Advanced = 3,
        eDDC_IntermediateB = 4,
    }

    public enum EDriverFaction
    {
        eDF_Invalid = 0,
        eDF_AkuAku = 1,
        eDF_UkaUka = 2,
        eDF_Velo = 3,
        eDF_Mixed = 4,
        eDF_Sparx = 5,
    }

    public enum EeDialogCloseSource
    {
        eDCS_UserAccept = 0,
        eDCS_UserBackOut = 1,
        eDCS_CloseAllUI = 2,
    }

    public enum EeLeaderboardPopulatorState
    {
        eLPS_Idle = 0,
        eLPS_DelayReadQuery = 1,
        eLPS_WaitingForReadResults = 2,
        eLPS_Ready = 3,
    }

    public enum EEntityTeam
    {
        eET_None = 0,
        eET_Hero = 1,
        eET_Enemy = 2,
        eET_AltEnemy = 3,
    }

    public enum EFacing
    {
        eF_EntityDirection = 0,
        eF_LastPressedStickDirection = 1,
    }

    public enum EffectKillType
    {
        kSoftKill = 0,
        kHardKill = 1,
    }

    public enum EFlags
    {
        FLAG_INVALID = -1,
        HAVOK_FLAGS_DIRTY = 0,
        MOVE_NOCOLLIDE = 1,
        MOVE_NOGRAVITY = 2,
        MOVE_NOPUSH = 3,
        STOP_TEAM_HERO = 4,
        STOP_PLAYERS = 5,
        STOP_NPC_NEUTRAL = 6,
        STOP_NPC_ENEMY = 7,
        STOP_NPC_ALT_ENEMY = 8,
        STOP_PROJECTILE = 9,
        STOP_DEBRIS = 10,
        STOP_WORLD = 11,
        STOP_LEVEL_BORDER = 12,
        CAM_NOT_TRACKABLE = 13,
        ENT_SCALE_DIRTY = 14,
        ENT_MOVING = 15,
        ENT_ENABLED = 16,
        TEAM_NONE = 17,
        TEAM_HERO = 18,
        TEAM_ENEMY = 19,
        TEAM_ALT_ENEMY = 20,
        TEAM_MAX = 21,
        TEAM_FACTION_1 = 22,
        TEAM_FACTION_2 = 23,
        TEAM_FACTION_3 = 24,
        TEAM_FACTION_4 = 25,
        TEAM_FACTION_5 = 26,
        TEAM_FACTION_6 = 27,
        TEAM_FACTION_7 = 28,
        TEAM_FACTION_8 = 29,
        TEAM_FACTION_9 = 30,
        TEAM_FACTION_10 = 31,
        TEAM_FACTION_11 = 32,
        TEAM_FACTION_12 = 33,
        TARGETABLE = 34,
        DAMAGEABLE = 35,
        FIRST_CASTABLE = 36,
    }

    public enum EFoot
    {
        eF_UNDEFINED = 0,
        eF_LEFT = 1,
        eF_RIGHT = 2,
    }

    public enum EGameMode
    {
        eGM_Max = -1,
        eGM_Invalid = 0,
        eGM_Story = 1,
        eGM_VehicleTesting = 4,
        eGM_Arcade = 8,
        eGM_OnlinePlay = 16,
    }

    public enum EGameplayGrabState
    {
        eGGS_Start = 0,
        eGGS_WaitForCamCut = 1,
        eGGS_WaitForScreenGrab = 2,
        eGGS_End = 3,
    }

    public enum EGameSoundClassPlayBehavior
    {
        eGSCB_Fail = 0,
        eGSCB_Queue = 1,
    }

    public enum EGameStateKey
    {
        eGSK_None = -1,
        eGSK_Map_Begin = 0,
        eGSK_Map_LastDestructibleDestroyed = 0,
        eGSK_Map_EnemyGoalProgress = 1,
        eGSK_Map_LastEntityInteractedWith = 2,
        eGSK_Map_LastFetchedEntity = 3,
        eGSK_Map_Name = 4,
        eGSK_Map_LowestDifficulty = 5,
        eGSK_Map_StoryModePercentComplete = 6,
        eGSK_Map_SkylanderDamageTaken = 7,
        eGSK_Map_SkylandersDefeated = 8,
        eGSK_Map_InTurboZone = 9,
        eGSK_Map_TurboZoneThirdStarTimeThreshold = 10,
        eGSK_Map_PlayerJumpMultiplier = 11,
        eGSK_Map_TutorialPlayed = 12,
        eGSK_Map_SideScrollerMode = 13,
        eGSK_Map_CoinsCollected = 14,
        eGSK_Map_GearbitsCollected = 15,
        eGSK_Map_RaceModeStoppedDuration = 16,
        eGSK_Map_PreparingToLoadAnotherMap = 17,
        eGSK_Map_InMinigame = 18,
        eGSK_Map_End = 19,
        eGSK_Persistent_Begin = 19,
        eGSK_Persistent_GameMode = 19,
        eGSK_CTRNF_Map_MirrorMode = 19,
        eGSK_Persistent_MirrorMode = 20,
        eGSK_CTRNF_Map_End = 20,
        eGSK_CTRNF_Persistent_Begin = 20,
        eGSK_CTRNF_Persistent_GameMode = 20,
        eGSK_Persistent_LastCompletedMap = 21,
        eGSK_Persistent_SaveBegin = 22,
        eGSK_Persistent_TrilogyFirstDayPlayed = 22,
        eGSK_Persistent_TrilogyMostRecentDayPlayed = 23,
        eGSK_Persistent_TrilogyUniqueDaysPlayed = 24,
        eGSK_Persistent_C1FirstDayPlayed = 25,
        eGSK_Persistent_C1MostRecentDayPlayed = 26,
        eGSK_Persistent_C1UniqueDaysPlayed = 27,
        eGSK_Persistent_C1PercentCompleted = 28,
        eGSK_Persistent_C1TimePlayedTotal = 29,
        eGSK_Persistent_C1TimeInLevelsFirstPlay = 30,
        eGSK_Persistent_C1TimeInLevelsFirstPlayStoryComplete = 31,
        eGSK_Persistent_C1TimeInLevelsReplay = 32,
        eGSK_Persistent_C1TimeInLevelsReplayStoryComplete = 33,
        eGSK_Persistent_C1TimeInHub = 34,
        eGSK_Persistent_C1TimeInHubStoryComplete = 35,
        eGSK_Persistent_C1TimeInCutscenes = 36,
        eGSK_Persistent_C1TimeInCutscenesStoryComplete = 37,
        eGSK_Persistent_C1TimeFromStartToStoryComplete = 38,
        eGSK_Persistent_C1TimePlayedWithCrash = 39,
        eGSK_Persistent_C1TimePlayedWithCoco = 40,
        eGSK_Persistent_C2FirstDayPlayed = 41,
        eGSK_Persistent_C2MostRecentDayPlayed = 42,
        eGSK_Persistent_C2UniqueDaysPlayed = 43,
        eGSK_Persistent_C2PercentCompleted = 44,
        eGSK_Persistent_C2TimePlayedTotal = 45,
        eGSK_Persistent_C2TimeInLevelsFirstPlay = 46,
        eGSK_Persistent_C2TimeInLevelsFirstPlayStoryComplete = 47,
        eGSK_Persistent_C2TimeInLevelsReplay = 48,
        eGSK_Persistent_C2TimeInLevelsReplayStoryComplete = 49,
        eGSK_Persistent_C2TimeInHub = 50,
        eGSK_Persistent_C2TimeInHubStoryComplete = 51,
        eGSK_Persistent_C2TimeInCutscenes = 52,
        eGSK_Persistent_C2TimeInCutscenesStoryComplete = 53,
        eGSK_Persistent_C2TimeFromStartToStoryComplete = 54,
        eGSK_Persistent_C2TimePlayedWithCrash = 55,
        eGSK_Persistent_C2TimePlayedWithCoco = 56,
        eGSK_Persistent_C3FirstDayPlayed = 57,
        eGSK_Persistent_C3MostRecentDayPlayed = 58,
        eGSK_Persistent_C3UniqueDaysPlayed = 59,
        eGSK_Persistent_C3PercentCompleted = 60,
        eGSK_Persistent_C3TimePlayedTotal = 61,
        eGSK_Persistent_C3TimeInLevelsFirstPlay = 62,
        eGSK_Persistent_C3TimeInLevelsFirstPlayStoryComplete = 63,
        eGSK_Persistent_C3TimeInLevelsReplay = 64,
        eGSK_Persistent_C3TimeInLevelsReplayStoryComplete = 65,
        eGSK_Persistent_C3TimeInHub = 66,
        eGSK_Persistent_C3TimeInHubStoryComplete = 67,
        eGSK_Persistent_C3TimeInCutscenes = 68,
        eGSK_Persistent_C3TimeInCutscenesStoryComplete = 69,
        eGSK_Persistent_C3TimeFromStartToStoryComplete = 70,
        eGSK_Persistent_C3TimePlayedWithCrash = 71,
        eGSK_Persistent_C3TimePlayedWithCoco = 72,
        eGSK_Persistent_C1IntroStartedCount = 73,
        eGSK_Persistent_L101StartedCount = 74,
        eGSK_Persistent_L101CompletedCount = 75,
        eGSK_Persistent_L101CollectiblesBitMask = 76,
        eGSK_Persistent_L102StartedCount = 77,
        eGSK_Persistent_L102CompletedCount = 78,
        eGSK_Persistent_L102CollectiblesBitMask = 79,
        eGSK_Persistent_L103StartedCount = 80,
        eGSK_Persistent_L103CompletedCount = 81,
        eGSK_Persistent_L103CollectiblesBitMask = 82,
        eGSK_Persistent_L104StartedCount = 83,
        eGSK_Persistent_L104CompletedCount = 84,
        eGSK_Persistent_L104CollectiblesBitMask = 85,
        eGSK_Persistent_L105StartedCount = 86,
        eGSK_Persistent_L105CompletedCount = 87,
        eGSK_Persistent_L105CollectiblesBitMask = 88,
        eGSK_Persistent_B101StartedCount = 89,
        eGSK_Persistent_B101CompletedCount = 90,
        eGSK_Persistent_L106StartedCount = 91,
        eGSK_Persistent_L106CompletedCount = 92,
        eGSK_Persistent_L106CollectiblesBitMask = 93,
        eGSK_Persistent_L107StartedCount = 94,
        eGSK_Persistent_L107CompletedCount = 95,
        eGSK_Persistent_L107CollectiblesBitMask = 96,
        eGSK_Persistent_L108StartedCount = 97,
        eGSK_Persistent_L108CompletedCount = 98,
        eGSK_Persistent_L108CollectiblesBitMask = 99,
        eGSK_Persistent_L109StartedCount = 100,
        eGSK_Persistent_L109CompletedCount = 101,
        eGSK_Persistent_L109CollectiblesBitMask = 102,
        eGSK_Persistent_B102StartedCount = 103,
        eGSK_Persistent_B102CompletedCount = 104,
        eGSK_Persistent_L110StartedCount = 105,
        eGSK_Persistent_L110CompletedCount = 106,
        eGSK_Persistent_L110CollectiblesBitMask = 107,
        eGSK_Persistent_L111StartedCount = 108,
        eGSK_Persistent_L111CompletedCount = 109,
        eGSK_Persistent_L111CollectiblesBitMask = 110,
        eGSK_Persistent_L112StartedCount = 111,
        eGSK_Persistent_L112CompletedCount = 112,
        eGSK_Persistent_L112CollectiblesBitMask = 113,
        eGSK_Persistent_L113StartedCount = 114,
        eGSK_Persistent_L113CompletedCount = 115,
        eGSK_Persistent_L113CollectiblesBitMask = 116,
        eGSK_Persistent_L114StartedCount = 117,
        eGSK_Persistent_L114CompletedCount = 118,
        eGSK_Persistent_L114CollectiblesBitMask = 119,
        eGSK_Persistent_L115StartedCount = 120,
        eGSK_Persistent_L115CompletedCount = 121,
        eGSK_Persistent_L115CollectiblesBitMask = 122,
        eGSK_Persistent_B103StartedCount = 123,
        eGSK_Persistent_B103CompletedCount = 124,
        eGSK_Persistent_L116StartedCount = 125,
        eGSK_Persistent_L116CompletedCount = 126,
        eGSK_Persistent_L116CollectiblesBitMask = 127,
        eGSK_Persistent_L117StartedCount = 128,
        eGSK_Persistent_L117CompletedCount = 129,
        eGSK_Persistent_L117CollectiblesBitMask = 130,
        eGSK_Persistent_L118StartedCount = 131,
        eGSK_Persistent_L118CompletedCount = 132,
        eGSK_Persistent_L118CollectiblesBitMask = 133,
        eGSK_Persistent_L119StartedCount = 134,
        eGSK_Persistent_L119CompletedCount = 135,
        eGSK_Persistent_L119CollectiblesBitMask = 136,
        eGSK_Persistent_B104StartedCount = 137,
        eGSK_Persistent_B104CompletedCount = 138,
        eGSK_Persistent_L120StartedCount = 139,
        eGSK_Persistent_L120CompletedCount = 140,
        eGSK_Persistent_L120CollectiblesBitMask = 141,
        eGSK_Persistent_L121StartedCount = 142,
        eGSK_Persistent_L121CompletedCount = 143,
        eGSK_Persistent_L121CollectiblesBitMask = 144,
        eGSK_Persistent_L122StartedCount = 145,
        eGSK_Persistent_L122CompletedCount = 146,
        eGSK_Persistent_L122CollectiblesBitMask = 147,
        eGSK_Persistent_L123StartedCount = 148,
        eGSK_Persistent_L123CompletedCount = 149,
        eGSK_Persistent_L123CollectiblesBitMask = 150,
        eGSK_Persistent_L124StartedCount = 151,
        eGSK_Persistent_L124CompletedCount = 152,
        eGSK_Persistent_L124CollectiblesBitMask = 153,
        eGSK_Persistent_L125StartedCount = 154,
        eGSK_Persistent_L125CompletedCount = 155,
        eGSK_Persistent_L125CollectiblesBitMask = 156,
        eGSK_Persistent_B105StartedCount = 157,
        eGSK_Persistent_B105CompletedCount = 158,
        eGSK_Persistent_L126StartedCount = 159,
        eGSK_Persistent_L126CompletedCount = 160,
        eGSK_Persistent_L126CollectiblesBitMask = 161,
        eGSK_Persistent_L127StartedCount = 162,
        eGSK_Persistent_L127CompletedCount = 163,
        eGSK_Persistent_L127CollectiblesBitMask = 164,
        eGSK_Persistent_B106StartedCount = 165,
        eGSK_Persistent_B106CompletedCount = 166,
        eGSK_Persistent_C1Outro01StartedCount = 167,
        eGSK_Persistent_C1Outro02StartedCount = 168,
        eGSK_Persistent_L128StartedCount = 169,
        eGSK_Persistent_L128CompletedCount = 170,
        eGSK_Persistent_L128CollectiblesBitMask = 171,
        eGSK_Persistent_C2IntroStartedCount = 172,
        eGSK_Persistent_L200StartedCount = 173,
        eGSK_Persistent_L200CompletedCount = 174,
        eGSK_Persistent_L200CollectiblesBitMask = 175,
        eGSK_Persistent_L201StartedCount = 176,
        eGSK_Persistent_L201CompletedCount = 177,
        eGSK_Persistent_L201CollectiblesBitMask = 178,
        eGSK_Persistent_L202StartedCount = 179,
        eGSK_Persistent_L202CompletedCount = 180,
        eGSK_Persistent_L202CollectiblesBitMask = 181,
        eGSK_Persistent_L203StartedCount = 182,
        eGSK_Persistent_L203CompletedCount = 183,
        eGSK_Persistent_L203CollectiblesBitMask = 184,
        eGSK_Persistent_L204StartedCount = 185,
        eGSK_Persistent_L204CompletedCount = 186,
        eGSK_Persistent_L204CollectiblesBitMask = 187,
        eGSK_Persistent_L205StartedCount = 188,
        eGSK_Persistent_L205CompletedCount = 189,
        eGSK_Persistent_L205CollectiblesBitMask = 190,
        eGSK_Persistent_B201StartedCount = 191,
        eGSK_Persistent_B201CompletedCount = 192,
        eGSK_Persistent_L206StartedCount = 193,
        eGSK_Persistent_L206CompletedCount = 194,
        eGSK_Persistent_L206CollectiblesBitMask = 195,
        eGSK_Persistent_L207StartedCount = 196,
        eGSK_Persistent_L207CompletedCount = 197,
        eGSK_Persistent_L207CollectiblesBitMask = 198,
        eGSK_Persistent_L208StartedCount = 199,
        eGSK_Persistent_L208CompletedCount = 200,
        eGSK_Persistent_L208CollectiblesBitMask = 201,
        eGSK_Persistent_L209StartedCount = 202,
        eGSK_Persistent_L209CompletedCount = 203,
        eGSK_Persistent_L209CollectiblesBitMask = 204,
        eGSK_Persistent_L210StartedCount = 205,
        eGSK_Persistent_L210CompletedCount = 206,
        eGSK_Persistent_L210CollectiblesBitMask = 207,
        eGSK_Persistent_B202StartedCount = 208,
        eGSK_Persistent_B202CompletedCount = 209,
        eGSK_Persistent_L211StartedCount = 210,
        eGSK_Persistent_L211CompletedCount = 211,
        eGSK_Persistent_L211CollectiblesBitMask = 212,
        eGSK_Persistent_L212StartedCount = 213,
        eGSK_Persistent_L212CompletedCount = 214,
        eGSK_Persistent_L212CollectiblesBitMask = 215,
        eGSK_Persistent_L213StartedCount = 216,
        eGSK_Persistent_L213CompletedCount = 217,
        eGSK_Persistent_L213CollectiblesBitMask = 218,
        eGSK_Persistent_L214StartedCount = 219,
        eGSK_Persistent_L214CompletedCount = 220,
        eGSK_Persistent_L214CollectiblesBitMask = 221,
        eGSK_Persistent_L215StartedCount = 222,
        eGSK_Persistent_L215CompletedCount = 223,
        eGSK_Persistent_L215CollectiblesBitMask = 224,
        eGSK_Persistent_B203StartedCount = 225,
        eGSK_Persistent_B203CompletedCount = 226,
        eGSK_Persistent_L216StartedCount = 227,
        eGSK_Persistent_L216CompletedCount = 228,
        eGSK_Persistent_L216CollectiblesBitMask = 229,
        eGSK_Persistent_L217StartedCount = 230,
        eGSK_Persistent_L217CompletedCount = 231,
        eGSK_Persistent_L217CollectiblesBitMask = 232,
        eGSK_Persistent_L218StartedCount = 233,
        eGSK_Persistent_L218CompletedCount = 234,
        eGSK_Persistent_L218CollectiblesBitMask = 235,
        eGSK_Persistent_L219StartedCount = 236,
        eGSK_Persistent_L219CompletedCount = 237,
        eGSK_Persistent_L219CollectiblesBitMask = 238,
        eGSK_Persistent_L220StartedCount = 239,
        eGSK_Persistent_L220CompletedCount = 240,
        eGSK_Persistent_L220CollectiblesBitMask = 241,
        eGSK_Persistent_B204StartedCount = 242,
        eGSK_Persistent_B204CompletedCount = 243,
        eGSK_Persistent_L221StartedCount = 244,
        eGSK_Persistent_L221CompletedCount = 245,
        eGSK_Persistent_L221CollectiblesBitMask = 246,
        eGSK_Persistent_L222StartedCount = 247,
        eGSK_Persistent_L222CompletedCount = 248,
        eGSK_Persistent_L222CollectiblesBitMask = 249,
        eGSK_Persistent_L223StartedCount = 250,
        eGSK_Persistent_L223CompletedCount = 251,
        eGSK_Persistent_L223CollectiblesBitMask = 252,
        eGSK_Persistent_L224StartedCount = 253,
        eGSK_Persistent_L224CompletedCount = 254,
        eGSK_Persistent_L224CollectiblesBitMask = 255,
        eGSK_Persistent_L225StartedCount = 256,
        eGSK_Persistent_L225CompletedCount = 257,
        eGSK_Persistent_L225CollectiblesBitMask = 258,
        eGSK_Persistent_B205StartedCount = 259,
        eGSK_Persistent_B205CompletedCount = 260,
        eGSK_Persistent_C2Outro01StartedCount = 261,
        eGSK_Persistent_C2Outro02StartedCount = 262,
        eGSK_Persistent_L226StartedCount = 263,
        eGSK_Persistent_L226CompletedCount = 264,
        eGSK_Persistent_L226CollectiblesBitMask = 265,
        eGSK_Persistent_L227StartedCount = 266,
        eGSK_Persistent_L227CompletedCount = 267,
        eGSK_Persistent_L227CollectiblesBitMask = 268,
        eGSK_Persistent_C3IntroStartedCount = 269,
        eGSK_Persistent_L301StartedCount = 270,
        eGSK_Persistent_L301CompletedCount = 271,
        eGSK_Persistent_L301CollectiblesBitMask = 272,
        eGSK_Persistent_L302StartedCount = 273,
        eGSK_Persistent_L302CompletedCount = 274,
        eGSK_Persistent_L302CollectiblesBitMask = 275,
        eGSK_Persistent_L303StartedCount = 276,
        eGSK_Persistent_L303CompletedCount = 277,
        eGSK_Persistent_L303CollectiblesBitMask = 278,
        eGSK_Persistent_L304StartedCount = 279,
        eGSK_Persistent_L304CompletedCount = 280,
        eGSK_Persistent_L304CollectiblesBitMask = 281,
        eGSK_Persistent_L305StartedCount = 282,
        eGSK_Persistent_L305CompletedCount = 283,
        eGSK_Persistent_L305CollectiblesBitMask = 284,
        eGSK_Persistent_B301StartedCount = 285,
        eGSK_Persistent_B301CompletedCount = 286,
        eGSK_Persistent_L306StartedCount = 287,
        eGSK_Persistent_L306CompletedCount = 288,
        eGSK_Persistent_L306CollectiblesBitMask = 289,
        eGSK_Persistent_L307StartedCount = 290,
        eGSK_Persistent_L307CompletedCount = 291,
        eGSK_Persistent_L307CollectiblesBitMask = 292,
        eGSK_Persistent_L308StartedCount = 293,
        eGSK_Persistent_L308CompletedCount = 294,
        eGSK_Persistent_L308CollectiblesBitMask = 295,
        eGSK_Persistent_L309StartedCount = 296,
        eGSK_Persistent_L309CompletedCount = 297,
        eGSK_Persistent_L309CollectiblesBitMask = 298,
        eGSK_Persistent_L310StartedCount = 299,
        eGSK_Persistent_L310CompletedCount = 300,
        eGSK_Persistent_L310CollectiblesBitMask = 301,
        eGSK_Persistent_B302StartedCount = 302,
        eGSK_Persistent_B302CompletedCount = 303,
        eGSK_Persistent_L311StartedCount = 304,
        eGSK_Persistent_L311CompletedCount = 305,
        eGSK_Persistent_L311CollectiblesBitMask = 306,
        eGSK_Persistent_L312StartedCount = 307,
        eGSK_Persistent_L312CompletedCount = 308,
        eGSK_Persistent_L312CollectiblesBitMask = 309,
        eGSK_Persistent_L313StartedCount = 310,
        eGSK_Persistent_L313CompletedCount = 311,
        eGSK_Persistent_L313CollectiblesBitMask = 312,
        eGSK_Persistent_L314StartedCount = 313,
        eGSK_Persistent_L314CompletedCount = 314,
        eGSK_Persistent_L314CollectiblesBitMask = 315,
        eGSK_Persistent_L315StartedCount = 316,
        eGSK_Persistent_L315CompletedCount = 317,
        eGSK_Persistent_L315CollectiblesBitMask = 318,
        eGSK_Persistent_B303StartedCount = 319,
        eGSK_Persistent_B303CompletedCount = 320,
        eGSK_Persistent_L316StartedCount = 321,
        eGSK_Persistent_L316CompletedCount = 322,
        eGSK_Persistent_L316CollectiblesBitMask = 323,
        eGSK_Persistent_L317StartedCount = 324,
        eGSK_Persistent_L317CompletedCount = 325,
        eGSK_Persistent_L317CollectiblesBitMask = 326,
        eGSK_Persistent_L318StartedCount = 327,
        eGSK_Persistent_L318CompletedCount = 328,
        eGSK_Persistent_L318CollectiblesBitMask = 329,
        eGSK_Persistent_L319StartedCount = 330,
        eGSK_Persistent_L319CompletedCount = 331,
        eGSK_Persistent_L319CollectiblesBitMask = 332,
        eGSK_Persistent_L320StartedCount = 333,
        eGSK_Persistent_L320CompletedCount = 334,
        eGSK_Persistent_L320CollectiblesBitMask = 335,
        eGSK_Persistent_B304StartedCount = 336,
        eGSK_Persistent_B304CompletedCount = 337,
        eGSK_Persistent_L321StartedCount = 338,
        eGSK_Persistent_L321CompletedCount = 339,
        eGSK_Persistent_L321CollectiblesBitMask = 340,
        eGSK_Persistent_L322StartedCount = 341,
        eGSK_Persistent_L322CompletedCount = 342,
        eGSK_Persistent_L322CollectiblesBitMask = 343,
        eGSK_Persistent_L323StartedCount = 344,
        eGSK_Persistent_L323CompletedCount = 345,
        eGSK_Persistent_L323CollectiblesBitMask = 346,
        eGSK_Persistent_L324StartedCount = 347,
        eGSK_Persistent_L324CompletedCount = 348,
        eGSK_Persistent_L324CollectiblesBitMask = 349,
        eGSK_Persistent_L325StartedCount = 350,
        eGSK_Persistent_L325CompletedCount = 351,
        eGSK_Persistent_L325CollectiblesBitMask = 352,
        eGSK_Persistent_B305StartedCount = 353,
        eGSK_Persistent_B305CompletedCount = 354,
        eGSK_Persistent_C3Outro01StartedCount = 355,
        eGSK_Persistent_C3Outro02StartedCount = 356,
        eGSK_Persistent_L326StartedCount = 357,
        eGSK_Persistent_L326CompletedCount = 358,
        eGSK_Persistent_L326CollectiblesBitMask = 359,
        eGSK_Persistent_L328StartedCount = 360,
        eGSK_Persistent_L328CompletedCount = 361,
        eGSK_Persistent_L328CollectiblesBitMask = 362,
        eGSK_Persistent_L330StartedCount = 363,
        eGSK_Persistent_L330CompletedCount = 364,
        eGSK_Persistent_L330CollectiblesBitMask = 365,
        eGSK_Persistent_L331StartedCount = 366,
        eGSK_Persistent_L331CompletedCount = 367,
        eGSK_Persistent_L331CollectiblesBitMask = 368,
        eGSK_Persistent_L332StartedCount = 369,
        eGSK_Persistent_L332CompletedCount = 370,
        eGSK_Persistent_L332CollectiblesBitMask = 371,
        eGSK_Persistent_L333StartedCount = 372,
        eGSK_Persistent_L333CompletedCount = 373,
        eGSK_Persistent_L333CollectiblesBitMask = 374,
        eGSK_Persistent_EnemiesKilled = 375,
        eGSK_Persistent_LocksFullyCompleted = 376,
        eGSK_Persistent_OnlineRaces = 377,
        eGSK_Persistent_Stardust = 378,
        eGSK_Persistent_VehicleSeaTutorialShown = 379,
        eGSK_Persistent_VehicleAirTutorialShown = 380,
        eGSK_Persistent_VehicleCoopTutorialShown = 381,
        eGSK_Persistent_AlwaysSkipDialogue = 382,
        eGSK_Persistent_StoryProgressionEasy = 383,
        eGSK_Persistent_StoryProgressionNormal = 384,
        eGSK_Persistent_StoryProgressionHard = 385,
        eGSK_Persistent_StoryProgressionNightmare = 386,
        eGSK_Persistent_TotalSkylandersAtMaxLevel = 387,
        eGSK_Persistent_SkystonesGamesPlayed = 388,
        eGSK_Persistent_SkystonesGamesWon = 389,
        eGSK_Persistent_SkylandersWithAllAbilitiesPurchased = 390,
        eGSK_Persistent_VehiclesAtMaxUpgrade = 391,
        eGSK_Persistent_VehiclesAtMaxMods = 392,
        eGSK_Persistent_VehicleGatesCompleted = 393,
        eGSK_Persistent_DriverGatesCompleted = 394,
        eGSK_Persistent_SuperChargeCombinations = 395,
        eGSK_Persistent_LockPickGamesComplete = 396,
        eGSK_Persistent_SkylanderDeaths = 397,
        eGSK_Persistent_Wishes = 398,
        eGSK_Persistent_TotalVehicleDistance = 399,
        eGSK_Persistent_JumpCount = 400,
        eGSK_Persistent_SheepScared = 401,
        eGSK_Persistent_TimesFlynnSaidBoom = 402,
        eGSK_Persistent_FoodEaten = 403,
        eGSK_Persistent_GearBitsCollected = 404,
        eGSK_Persistent_ObjectsSmashed = 405,
        eGSK_Persistent_StepsTaken = 406,
        eGSK_Persistent_CandyFromPinatas = 407,
        eGSK_Persistent_ChompiesWhoLostTheirHelmets = 408,
        eGSK_Persistent_TimesGravityWasFlipped = 409,
        eGSK_Persistent_DistanceDrifted = 410,
        eGSK_Persistent_DistanceTraveledUnderwater = 411,
        eGSK_Persistent_FlightTime = 412,
        eGSK_Persistent_HornsHonked = 413,
        eGSK_Persistent_TotalGoldCollected = 414,
        eGSK_Persistent_TotalGoldSpent = 415,
        eGSK_Persistent_TotalGoldSpentOnUpgrades = 416,
        eGSK_Persistent_SkystonesMatchesPlayedOnline = 417,
        eGSK_Persistent_LocalCoopSessions = 418,
        eGSK_Persistent_ShopPurchases = 419,
        eGSK_Persistent_TotalSkylandersLeveledAtLeastOnce = 420,
        eGSK_Persistent_LevelsReplayed = 421,
        eGSK_Persistent_DriverGatesPlayed = 422,
        eGSK_Persistent_NumberOfVehicleElements = 423,
        eGSK_Persistent_VehicleGatesPlayed = 424,
        eGSK_Persistent_SuccessfulMatchmakingAttemptsCount = 425,
        eGSK_Persistent_SuccessfulMatchmakingDuration = 426,
        eGSK_Persistent_UnsuccessfulMatchmakingAttemptsCount = 427,
        eGSK_Persistent_UnsuccessfulMatchmakingDuration = 428,
        eGSK_Persistent_CoopTotalPingSamplesGood = 429,
        eGSK_Persistent_CoopTotalPingSamplesNormal = 430,
        eGSK_Persistent_CoopTotalPingSamplesBad = 431,
        eGSK_Persistent_RacePackTotalPingSamplesGood = 432,
        eGSK_Persistent_RacePackTotalPingSamplesNormal = 433,
        eGSK_Persistent_RacePackTotalPingSamplesBad = 434,
        eGSK_Persistent_OnlineSessionsRacePacks = 435,
        eGSK_Persistent_OnlineSessionsCoOp = 436,
        eGSK_Persistent_OnlineSessionsVoiceChatUsedCount = 437,
        eGSK_Persistent_DisconnectWhileWaitingToEnterLevelCount = 438,
        eGSK_Persistent_FailedToEstablishConnectionCount = 439,
        eGSK_Persistent_OnlineRacePack2Players = 440,
        eGSK_Persistent_OnlineRacePack3Players = 441,
        eGSK_Persistent_OnlineRacePack4Players = 442,
        eGSK_Persistent_VoiceChatDisabled = 443,
        eGSK_Persistent_BlockCoopFriendJoins = 444,
        eGSK_Persistent_InitialSkystonesUnlocked = 445,
        eGSK_Persistent_MainMenuRaceFunnel = 446,
        eGSK_Persistent_PauseMenuRaceFunnel = 447,
        eGSK_Persistent_PandergastRaceFunnel = 448,
        eGSK_Persistent_WishstoneFound = 449,
        eGSK_Persistent_GearBitsSpent = 450,
        eGSK_Persistent_ElementalGateFunnel = 451,
        eGSK_Persistent_LevelElementalGateFunnel = 452,
        eGSK_Persistent_DriverChallengeFunnel = 453,
        eGSK_Persistent_ElementalGateChestOpenedCount = 454,
        eGSK_Persistent_DriverChallengeChestOpenedCount = 455,
        eGSK_Persistent_DriverChallengeChestLevel = 456,
        eGSK_Persistent_DriverChallengeCompletedBitMask = 457,
        eGSK_Persistent_NumElementalGatesStartedInAcademy = 458,
        eGSK_Persistent_NumElementalGatesStartedInLevels = 459,
        eGSK_Persistent_LicenseAgreementAccepted = 460,
        eGSK_Persistent_BoomKitPurchasesWithGearBits = 461,
        eGSK_Persistent_BoomKitPurchasesWithMoney = 462,
        eGSK_Persistent_UnlockedStormyAscent = 463,
        eGSK_IsRetailDisk = 464,
        eGSK_Multiplayer_Begin = 465,
        eGSK_Persistent_End = 465,
        eGSK_Persistent_SaveEnd = 465,
        eGSK_Max = 466,
        eGSK_Multiplayer_End = 466,
    }

    public enum EGameYear
    {
        eGY_Invalid = -1,
        eGY_2011 = 0,
        eGY_2012 = 1,
        eGY_2013 = 2,
        eGY_2014 = 3,
        eGY_2015 = 4,
        eGY_2016 = 5,
        eGY_2017 = 6,
        eGY_2017_Crash1 = 7,
        eGY_2017_Crash2 = 8,
        eGY_2017_Crash3 = 9,
        eGY_Count = 10,
    }

    public enum EGlobalOption
    {
        kMusicVolume = 0,
        kVoiceVolume = 1,
        kFxVolume = 2,
        kShowSubtitles = 3,
        kLegacyMusicActive = 4,
        kShowMinimap = 5,
        kAutoSkipFlyBy = 6,
        kControlScheme = 7,
        kVibrationActive = 8,
        kBoostGaugeStyle = 9,
        kTrainingWheels = 10,
    }

    public enum EGlobalStrings
    {
        eGS_OptionsPrompt = 0,
        eGS_ContinueString = 1,
        eGS_ShopNameString = 2,
        eGS_ShopLoadingString = 3,
        eGS_CancelString = 4,
        eGS_WumpaCoinNotSignedInTitle = 5,
        eGS_WumpaCoinNotSignedInBody = 6,
        eGS_ShopUnavailableTitle = 7,
        eGS_ShopUnavailableBody = 8,
        eGS_PitStopDailyTimeRemaining = 9,
        eGS_NetworkError_Account = 10,
        eGS_NetworkError_NoConnection = 11,
        eGS_NetworkError_PatchRequired = 12,
        eGS_NetworkError_SignIn = 13,
        eGS_NetworkError_ServerUnavailable = 14,
        eGS_NetworkError_PlayerRestricted = 15,
        eGS_NetworkError_UserContentRestricted = 16,
        eGS_GrandPrixUnavailableTitle = 17,
        eGS_GrandPrixUnavailableBody = 18,
        eGS_GrandPrixLoadingTitle = 19,
        eGS_GrandPrixLoadingBody = 20,
        eGS_GrandPrixDaysRemaining = 21,
        eGS_GrandPrixOneDayRemaining = 22,
        eGS_GrandPrixOffSeason = 23,
        eGS_GrandPrixLeaderboardReward = 24,
        eGS_GrandPrixLeaderboardTotalPlayerCount = 25,
        eGS_CheatCodeAchievementsDisabled = 26,
        eGS_GrandPrixResetChallengesMessages = 27,
        eGS_GrandPrixOffSeasonMessage = 28,
        eGS_PitStopGPCompleteTitle = 29,
        eGS_PitStopGPCompleteBody = 30,
        eGS_NoNetworkConnectionNoticeTitle = 31,
        eGS_NoNetworkConnectionNoticeBody = 32,
        eGS_ConfigDownloadedBody = 33,
        eGS_DialogBoxNotificationTitle = 34,
    }

    public enum EGrabType
    {
        eGT_Front = 0,
        eGT_Back = 1,
        eGT_MaxTypes = 2,
    }

    public enum EGraphicsMenuSettingType
    {
        GMS_Invalid = 0,
        GMS_DisplayMode = 1,
        GMS_First = 1,
        GMS_Resolution = 2,
        GMS_FirstNonDisplay = 3,
        GMS_MaxFPS = 3,
        GMS_VSync = 4,
        GMS_MotionBlur = 5,
        GMS_Preset = 6,
        GMS_AntiAliasing = 7,
        GMS_FirstPresetData = 7,
        GMS_ShadowResolution = 8,
        GMS_AmbientOcclusion = 9,
        GMS_Bloom = 10,
        GMS_DOF = 11,
        GMS_FurBlur = 12,
        GMS_Count = 13,
    }

    public enum EGuiColorStyle
    {
        eGCS_Invalid = 0,
        eGCS_Darkest = 1,
        eGCS_Dark = 2,
        eGCS_Medium = 3,
        eGCS_Light = 4,
        eGCS_Lightest = 5,
    }

    public enum EGuiDialogBoxOption
    {
        eGDBO_OptionNone = 0,
        eGDBO_Option1 = 1,
        eGDBO_Option2 = 2,
    }

    public enum EGuiMenuSound
    {
        eGMS_None = 0,
        eGMS_Confirm = 1,
        eGMS_Back = 2,
        eGMS_Navigate = 3,
        eGMS_ListNavigate = 4,
        eGMS_PageNavigate = 5,
        eGMS_TextNavigate = 6,
        eGMS_MenuAppear = 7,
        eGMS_Failure = 8,
        eGMS_Slider = 9,
    }

    public enum EHavokEntityType
    {
        eHET_Undefined = 0,
        eHET_Dynamic = 1,
        eHET_Fixed = 2,
        eHET_Keyframed = 3,
        eHET_BehaviorController = 4,
    }

    public enum EHavokQueryKillReason
    {
        eHQKR_Unknown = 0,
        eHQKR_InvalidSetup = 1,
        eHQKR_InvalidSource = 2,
        eHQKR_InvalidTarget = 3,
        eHQKR_InvalidFilter = 4,
        eHQKR_OutOfSpace = 5,
        eHQKR_AutoCleanup = 6,
        eHQKR_ManualKill = 7,
        eHQKR_KillAll = 8,
    }

    public enum EHavokQuerySubType
    {
        eHQST_Invalid = 0,
        eHQST_StartWorld = 1,
        eHQST_WorldPointCast = 1,
        eHQST_WorldShapeCast = 2,
        eHQST_WorldPointClosestPoints = 3,
        eHQST_WorldShapeClosestPoints = 4,
        eHQST_PairPointCast = 5,
        eHQST_StartPair = 5,
        eHQST_PairShapeCast = 6,
        eHQST_PairPointClosestPoints = 7,
        eHQST_PairShapeClosestPoints = 8,
        eHQST_Count = 9,
    }

    public enum EHavokQueryType
    {
        eHQT_Invalid = 0,
        eHQT_LinearCast = 1,
        eHQT_ClosestPoints = 2,
    }

    public enum EHeroScreenGrabActionState
    {
        eHSGAS_InitScreenShot = 0,
        eHSGAS_TakeScreenShot = 1,
        eHSGAS_Finish = 2,
    }

    public enum EHorizontalAlignment
    {
        kHorizontalAlignmentLeft = 0,
        kHorizontalAlignmentRight = 1,
        kHorizontalAlignmentCenter = 2,
    }

    public enum EIG_CORE_LANGUAGE
    {
        CTRNF_UNKNOWN = -1,
        ARABIC = 0,
        FIRST = 0,
        BULGARIAN = 1,
        CHINESE = 2,
        CZECH = 3,
        DANISH = 4,
        DUTCH = 5,
        ENGLISH = 6,
        FINNISH = 7,
        FRENCH = 8,
        GERMAN = 9,
        GREEK = 10,
        HEBREW = 11,
        HINDI = 12,
        HUNGARIAN = 13,
        ITALIAN = 14,
        JAPANESE = 15,
        KOREAN = 16,
        NORWEGIAN = 17,
        POLISH = 18,
        PORTUGUESE = 19,
        RUSSIAN = 20,
        SPANISH = 21,
        SPANISH_MEXICAN = 22,
        SWEDISH = 23,
        TAIWANESE = 24,
        LAST = 25,
        TURKISH = 25,
    }

    public enum EIG_CORE_PLATFORM
    {
        DEFAULT = 0,
        WIN32 = 1,
        NX = 2,
        DURANGO = 3,
        ASPEN = 4,
        OSX = 5,
        WIN64 = 6,
        ASPEN64 = 7,
        PS4 = 8,
        NXWIN = 9,
        CTRNF_LINUX = 9,
        LINUX = 10,
        CTRNF_MAX = 10,
        MAX = 11,
    }

    public enum EIG_GFX_ALPHA_FUNCTION
    {
        NEVER = 0,
        LESS = 1,
        EQUAL = 2,
        LEQUAL = 3,
        GREATER = 4,
        NOTEQUAL = 5,
        GEQUAL = 6,
        ALWAYS = 7,
    }

    public enum EIG_GFX_BLENDING_EQUATION
    {
        ADD = 0,
        SUBTRACT = 1,
        REVERSE_SUBTRACT = 2,
        MIN = 3,
        MAX = 4,
    }

    public enum EIG_GFX_BLENDING_FUNCTION
    {
        ZERO = 0,
        ONE = 1,
        SOURCE_COLOR = 2,
        ONE_MINUS_SOURCE_COLOR = 3,
        SOURCE_ALPHA = 4,
        ONE_MINUS_SOURCE_ALPHA = 5,
        DESTINATION_COLOR = 6,
        ONE_MINUS_DESTINATION_COLOR = 7,
        DESTINATION_ALPHA = 8,
        ONE_MINUS_DESTINATION_ALPHA = 9,
        SOURCE_ALPHA_SATURATE = 10,
    }

    public enum EIG_GFX_CULL_FACE_MODE
    {
        BACK = 0,
        FRONT = 1,
    }

    public enum EIG_GFX_DEPTH_TEST_FUNCTION
    {
        NEVER = 0,
        LESS = 1,
        EQUAL = 2,
        LEQUAL = 3,
        GREATER = 4,
        NOT_EQUAL = 5,
        GEQUAL = 6,
        ALWAYS = 7,
    }

    public enum EIG_GFX_DRAW
    {
        POINTS = 0,
        LINES = 1,
        LINE_STRIP = 2,
        TRIANGLES = 3,
        TRIANGLE_STRIP = 4,
        TRIANGLE_FAN = 5,
        QUADS = 6,
    }

    public enum EIG_GFX_HISTENCIL_CLEAR
    {
        CULL = 0,
        PASS = 1,
    }

    public enum EIG_GFX_MULTISAMPLE_TYPE
    {
        IG_GFX_MULTISAMPLE_NONE = 0,
        IG_GFX_MULTISAMPLE_2X = 1,
        IG_GFX_MULTISAMPLE_4X = 2,
        IG_GFX_MULTISAMPLE_4X_ROTATED = 3,
    }

    public enum EIG_GFX_PLATFORM
    {
        DEFAULT = 0,
        DX = 1,
        NX = 2,
        DURANGO = 3,
        ASPEN = 4,
        OSX = 5,
        DX11 = 6,
        NULL = 7,
        METAL = 8,
        WGL = 9,
        PS4 = 10,
        LINUX = 11,
        MAX = 12,
    }

    public enum EIG_GFX_RENDER_MODE
    {
        FILL = 0,
        LINES = 1,
        POINTS = 2,
    }

    public enum EIG_GFX_SHADER_TYPE
    {
        IG_GFX_PIXEL_SHADER = 0,
        IG_GFX_VERTEX_SHADER = 1,
        IG_GFX_GEOMETRY_SHADER = 2,
        IG_GFX_PS4_EXPORT_SHADER = 3,
    }

    public enum EIG_GFX_STENCIL_FUNCTION
    {
        NEVER = 0,
        LESS = 1,
        EQUAL = 2,
        LEQUAL = 3,
        GREATER = 4,
        NOTEQUAL = 5,
        GEQUAL = 6,
        ALWAYS = 7,
    }

    public enum EIG_GFX_STENCIL_OPERATION
    {
        KEEP = 0,
        ZERO = 1,
        REPLACE = 2,
        INCR = 3,
        INCR_WRAP = 4,
        DECR = 5,
        DECR_WRAP = 6,
        INVERT = 7,
    }

    public enum EIG_GFX_TEXTURE_FILTER
    {
        NEAREST = 0,
        NEAREST_MIPMAP_NONE = 0,
        LINEAR = 1,
        LINEAR_MIPMAP_NONE = 1,
        NEAREST_MIPMAP_NEAREST = 2,
        NEAREST_MIPMAP_LINEAR = 3,
        LINEAR_MIPMAP_NEAREST = 4,
        LINEAR_MIPMAP_LINEAR = 5,
        ANISOTROPIC = 6,
        ANISOTROPIC_MIPMAP_NONE = 6,
        ANISOTROPIC_MIPMAP_NEAREST = 7,
        ANISOTROPIC_MIPMAP_LINEAR = 8,
    }

    public enum EIG_GFX_TEXTURE_SOURCE
    {
        IMAGE = 0,
        VIDEO = 2,
        BUFFER = 3,
    }

    public enum EIG_GFX_TEXTURE_WRAP
    {
        CLAMP = 0,
        REPEAT = 1,
        REGION_CLAMP = 2,
        REGION_REPEAT = 3,
        BORDER = 4,
    }

    public enum EIG_INDEX_TYPE
    {
        INT8 = 1,
        INT16 = 2,
        INT32 = 4,
    }

    public enum EIG_MATH_SPATIAL_REGION
    {
        XP_YP_ZP = 0,
        XP_YP_ZN = 1,
        XP_YN_ZP = 2,
        XP_YN_ZN = 3,
        XN_YP_ZP = 4,
        XN_YP_ZN = 5,
        XN_YN_ZP = 6,
        XN_YN_ZN = 7,
    }

    public enum EIG_UTILS_PLAY_MODE
    {
        REPEAT = 0,
        CLAMP = 1,
        BOUNCE = 2,
        LOOP = 3,
        BOUNCEONCE = 4,
        MANUAL = 5,
    }

    public enum EIG_VERTEX_USAGE
    {
        POSITION = 0,
        NORMAL = 1,
        TANGENT = 2,
        BINORMAL = 3,
        COLOR = 4,
        TEXCOORD = 5,
        BLENDWEIGHTS = 6,
        UNUSED_0 = 7,
        BLENDINDICES = 8,
        FOGCOORD = 9,
        PSIZE = 10,
    }

    public enum EigBlockingType
    {
        kNonBlocking = 0,
        kBlocking = 1,
        kMayBlock = 2,
    }

    public enum EigCustomMaterialAnimationTarget
    {
        kAnimationTargetTextureMatrix = 0,
        kAnimationTargetColor = 1,
    }

    public enum EigCustomMaterialAnimationTimeSource
    {
        kAnimationTimeSourceTransformed = 0,
        kAnimationTimeSourceGlobal = 1,
        kAnimationTimeSourceRandom = 2,
    }

    public enum EigDrawType
    {
        kDrawTypeOpaque = 0,
        kDrawTypeAlphaTest = 1,
        kDrawTypeTransparent = 2,
        kDrawTypePostDraw = 3,
    }

    public enum EigDspType
    {
        kUnknown = 0,
        kMixer = 1,
        kOscillator = 2,
        kLowpass = 3,
        kHighpass = 4,
        kEcho = 5,
        kFlange = 6,
        kDistortion = 7,
        kNormalize = 8,
        kParamEq = 9,
        kPitchShift = 10,
        kChorus = 11,
        kCompressor = 12,
        kSfxReverb = 13,
        kLowpassSimple = 14,
        kHighpassSimple = 15,
        kParamEqParamEqCompressor = 16,
    }

    public enum EigEaseMode
    {
        kEaseModeIn = 0,
        kEaseModeOut = 1,
        kEaseModeInOut = 2,
    }

    public enum EigEaseType
    {
        kEaseTypeLinear = 0,
        kEaseTypeQuadratic = 1,
        kEaseTypeCubic = 2,
        kEaseTypeQuartic = 3,
        kEaseTypeQuintic = 4,
        kEaseTypeSinusoidal = 5,
        kEaseTypeExponential = 6,
        kEaseTypeCircular = 7,
        kEaseTypeElastic = 8,
        kEaseTypeBack = 9,
        kEaseTypeBounce = 10,
        kEaseTypeStep = 11,
    }

    public enum EigGraphicsMaterialAnimationConstantType
    {
        kGraphicsMaterialAnimationMatrix44f = 0,
        kGraphicsMaterialAnimationVec4f = 1,
    }

    public enum EigGraphicsMaterialAnimationTimeSource
    {
        kGraphicsMaterialAnimationTimeSourceTransformed = 0,
        kGraphicsMaterialAnimationTimeSourceGlobal = 1,
        kGraphicsMaterialAnimationTimeSourceRandom = 2,
    }

    public enum EigGraphicsResourceType
    {
        kNone = 0,
        kBuffer = 1,
        kVertexFormat = 2,
    }

    public enum EigGuiAnchorTargetX
    {
        kXAnchorLeft = 0,
        kXAnchorRight = 1,
        kXAnchorCenter = 2,
    }

    public enum EigGuiAnchorTargetY
    {
        kYAnchorTop = 0,
        kYAnchorBottom = 1,
        kYAnchorCenter = 2,
    }

    public enum EigGuiAnimationLoopMode
    {
        kGuiLoopNone = 0,
        kGuiLoopClamp = 1,
        kGuiLoopRepeat = 2,
        kGuiLoopBounce = 3,
        kGuiLoopToolPreview = 4,
    }

    public enum EigGuiDeviceAutoScaleMode
    {
        kAutoScaleUseParentSettings = 0,
        kAutoScaleNone = 1,
        kAutoScaleAll = 2,
        kAutoScaleX = 3,
        kAutoScaleY = 4,
        kAutoScaleYMinValueOne = 5,
    }

    public enum EigResourceUsage
    {
        kUsageDefault = 0,
        kUsageStatic = 1,
        kUsageDynamic = 2,
        kUsageStaging = 3,
    }

    public enum EigResult
    {
        kSuccess = 0,
        kFailure = 1,
    }

    public enum EigSetStencilRefOperation
    {
        kSetStencilRefOperationNone = 0,
        kSetStencilRefOperationOr = 1,
    }

    public enum EigVfxCurveCorrelation
    {
        kIndependent = 0,
        kLinked = 1,
        kAspectSquare = 2,
        kAspectRatio = 3,
        kAspectChain = 4,
    }

    public enum EInterleavedMusicState
    {
        eIMS_Combat = 0,
        eIMS_Traversal = 1,
        eIMS_Vehicle = 2,
        eIMS_None = 3,
    }

    public enum EInterpolationMode
    {
        kInterpolationInheritFromTrack = -1,
        kInterpolationNone = 0,
        kInterpolationLinear = 1,
        kInterpolationBezier = 2,
    }

    public enum EKartCameraMode
    {
        eKCM_Near = 0,
        eKCM_Far = 1,
        eKCM_Count = 2,
    }

    public enum EKartCustomizationType
    {
        eKCT_Wheels = 0,
        eKCT_Paint = 1,
        eKCT_Decal = 2,
        eKCT_Sticker = 3,
        eKCT_Count = 4,
    }

    public enum EKartStickerFilterGroup
    {
        eKSFG_Invalid = 0,
        eKSFG_All = 1,
        eKSFG_Numbers = 2,
        eKSFG_Themes = 3,
        eKSFG_Portraits = 4,
    }

    public enum ELeaderBoardID
    {
        eLBID_INVALID = 0,
        eLBID_GAMEANALYTICS = 1,
        eLBID_CTRNF_T111_TIMETRIAL = 1,
        eLBID_L101_TIMETRIAL = 2,
        eLBID_CTRNF_T111_RELICRACE = 2,
        eLBID_L102_TIMETRIAL = 3,
        eLBID_CTRNF_T112_TIMETRIAL = 3,
        eLBID_L103_TIMETRIAL = 4,
        eLBID_CTRNF_T112_RELICRACE = 4,
        eLBID_L104_TIMETRIAL = 5,
        eLBID_CTRNF_T113_TIMETRIAL = 5,
        eLBID_L105_TIMETRIAL = 6,
        eLBID_CTRNF_T113_RELICRACE = 6,
        eLBID_L106_TIMETRIAL = 7,
        eLBID_CTRNF_T114_TIMETRIAL = 7,
        eLBID_L107_TIMETRIAL = 8,
        eLBID_CTRNF_T114_RELICRACE = 8,
        eLBID_L108_TIMETRIAL = 9,
        eLBID_CTRNF_T121_TIMETRIAL = 9,
        eLBID_L109_TIMETRIAL = 10,
        eLBID_CTRNF_T121_RELICRACE = 10,
        eLBID_L110_TIMETRIAL = 11,
        eLBID_CTRNF_T122_TIMETRIAL = 11,
        eLBID_L111_TIMETRIAL = 12,
        eLBID_CTRNF_T122_RELICRACE = 12,
        eLBID_L112_TIMETRIAL = 13,
        eLBID_CTRNF_T131_TIMETRIAL = 13,
        eLBID_L113_TIMETRIAL = 14,
        eLBID_CTRNF_T131_RELICRACE = 14,
        eLBID_L114_TIMETRIAL = 15,
        eLBID_CTRNF_T132_TIMETRIAL = 15,
        eLBID_L115_TIMETRIAL = 16,
        eLBID_CTRNF_T132_RELICRACE = 16,
        eLBID_L116_TIMETRIAL = 17,
        eLBID_CTRNF_T133_TIMETRIAL = 17,
        eLBID_L117_TIMETRIAL = 18,
        eLBID_CTRNF_T133_RELICRACE = 18,
        eLBID_L118_TIMETRIAL = 19,
        eLBID_CTRNF_T134_TIMETRIAL = 19,
        eLBID_L119_TIMETRIAL = 20,
        eLBID_CTRNF_T134_RELICRACE = 20,
        eLBID_L120_TIMETRIAL = 21,
        eLBID_CTRNF_T141_TIMETRIAL = 21,
        eLBID_L121_TIMETRIAL = 22,
        eLBID_CTRNF_T141_RELICRACE = 22,
        eLBID_L122_TIMETRIAL = 23,
        eLBID_CTRNF_T142_TIMETRIAL = 23,
        eLBID_L123_TIMETRIAL = 24,
        eLBID_CTRNF_T142_RELICRACE = 24,
        eLBID_L124_TIMETRIAL = 25,
        eLBID_CTRNF_T143_TIMETRIAL = 25,
        eLBID_L125_TIMETRIAL = 26,
        eLBID_CTRNF_T143_RELICRACE = 26,
        eLBID_L126_TIMETRIAL = 27,
        eLBID_CTRNF_T144_TIMETRIAL = 27,
        eLBID_L128_TIMETRIAL = 28,
        eLBID_CTRNF_T144_RELICRACE = 28,
        eLBID_L201_TIMETRIAL = 29,
        eLBID_CTRNF_T151_TIMETRIAL = 29,
        eLBID_L202_TIMETRIAL = 30,
        eLBID_CTRNF_T151_RELICRACE = 30,
        eLBID_L203_TIMETRIAL = 31,
        eLBID_CTRNF_T152_TIMETRIAL = 31,
        eLBID_L204_TIMETRIAL = 32,
        eLBID_CTRNF_T152_RELICRACE = 32,
        eLBID_L205_TIMETRIAL = 33,
        eLBID_CTRNF_T153_TIMETRIAL = 33,
        eLBID_L206_TIMETRIAL = 34,
        eLBID_CTRNF_T153_RELICRACE = 34,
        eLBID_L207_TIMETRIAL = 35,
        eLBID_CTRNF_T154_TIMETRIAL = 35,
        eLBID_L208_TIMETRIAL = 36,
        eLBID_CTRNF_T154_RELICRACE = 36,
        eLBID_L209_TIMETRIAL = 37,
        eLBID_CTRNF_T155_TIMETRIAL = 37,
        eLBID_L210_TIMETRIAL = 38,
        eLBID_CTRNF_T155_RELICRACE = 38,
        eLBID_L211_TIMETRIAL = 39,
        eLBID_CTRNF_T211_TIMETRIAL = 39,
        eLBID_L212_TIMETRIAL = 40,
        eLBID_CTRNF_T211_RELICRACE = 40,
        eLBID_L213_TIMETRIAL = 41,
        eLBID_CTRNF_T212_TIMETRIAL = 41,
        eLBID_L214_TIMETRIAL = 42,
        eLBID_CTRNF_T212_RELICRACE = 42,
        eLBID_L215_TIMETRIAL = 43,
        eLBID_CTRNF_T213_TIMETRIAL = 43,
        eLBID_L216_TIMETRIAL = 44,
        eLBID_CTRNF_T213_RELICRACE = 44,
        eLBID_L217_TIMETRIAL = 45,
        eLBID_CTRNF_T221_TIMETRIAL = 45,
        eLBID_L218_TIMETRIAL = 46,
        eLBID_CTRNF_T221_RELICRACE = 46,
        eLBID_L219_TIMETRIAL = 47,
        eLBID_CTRNF_T222_TIMETRIAL = 47,
        eLBID_L220_TIMETRIAL = 48,
        eLBID_CTRNF_T222_RELICRACE = 48,
        eLBID_L221_TIMETRIAL = 49,
        eLBID_CTRNF_T223_TIMETRIAL = 49,
        eLBID_L222_TIMETRIAL = 50,
        eLBID_CTRNF_T223_RELICRACE = 50,
        eLBID_L223_TIMETRIAL = 51,
        eLBID_CTRNF_T231_TIMETRIAL = 51,
        eLBID_L224_TIMETRIAL = 52,
        eLBID_CTRNF_T231_RELICRACE = 52,
        eLBID_L225_TIMETRIAL = 53,
        eLBID_CTRNF_T232_TIMETRIAL = 53,
        eLBID_L226_TIMETRIAL = 54,
        eLBID_CTRNF_T232_RELICRACE = 54,
        eLBID_L227_TIMETRIAL = 55,
        eLBID_CTRNF_T233_TIMETRIAL = 55,
        eLBID_L301_TIMETRIAL = 56,
        eLBID_CTRNF_T233_RELICRACE = 56,
        eLBID_L302_TIMETRIAL = 57,
        eLBID_CTRNF_T241_TIMETRIAL = 57,
        eLBID_L303_TIMETRIAL = 58,
        eLBID_CTRNF_T241_RELICRACE = 58,
        eLBID_L304_TIMETRIAL = 59,
        eLBID_CTRNF_T242_TIMETRIAL = 59,
        eLBID_L305_TIMETRIAL = 60,
        eLBID_CTRNF_T242_RELICRACE = 60,
        eLBID_L306_TIMETRIAL = 61,
        eLBID_CTRNF_T243_TIMETRIAL = 61,
        eLBID_L307_TIMETRIAL = 62,
        eLBID_CTRNF_T243_RELICRACE = 62,
        eLBID_L308_TIMETRIAL = 63,
        eLBID_CTRNF_T255_TIMETRIAL = 63,
        eLBID_L309_TIMETRIAL = 64,
        eLBID_CTRNF_T255_RELICRACE = 64,
        eLBID_L310_TIMETRIAL = 65,
        eLBID_CTRNF_GP001_WIN = 65,
        eLBID_L311_TIMETRIAL = 66,
        eLBID_CTRNF_GP001_NITRO = 66,
        eLBID_L312_TIMETRIAL = 67,
        eLBID_CTRNF_GP002_WIN = 67,
        eLBID_L313_TIMETRIAL = 68,
        eLBID_CTRNF_GP002_NITRO = 68,
        eLBID_L314_TIMETRIAL = 69,
        eLBID_CTRNF_GP003_WIN = 69,
        eLBID_L315_TIMETRIAL = 70,
        eLBID_CTRNF_GP003_NITRO = 70,
        eLBID_L316_TIMETRIAL = 71,
        eLBID_CTRNF_GP004_WIN = 71,
        eLBID_L317_TIMETRIAL = 72,
        eLBID_CTRNF_GP004_NITRO = 72,
        eLBID_L318_TIMETRIAL = 73,
        eLBID_CTRNF_GP005_WIN = 73,
        eLBID_L319_TIMETRIAL = 74,
        eLBID_CTRNF_GP005_NITRO = 74,
        eLBID_L320_TIMETRIAL = 75,
        eLBID_CTRNF_GP006_WIN = 75,
        eLBID_L321_TIMETRIAL = 76,
        eLBID_CTRNF_GP006_NITRO = 76,
        eLBID_L322_TIMETRIAL = 77,
        eLBID_CTRNF_T501_TIMETRIAL = 77,
        eLBID_L323_TIMETRIAL = 78,
        eLBID_CTRNF_T501_RELICRACE = 78,
        eLBID_L324_TIMETRIAL = 79,
        eLBID_CTRNF_T502_TIMETRIAL = 79,
        eLBID_L325_TIMETRIAL = 80,
        eLBID_CTRNF_T502_RELICRACE = 80,
        eLBID_L326_TIMETRIAL = 81,
        eLBID_CTRNF_T503_TIMETRIAL = 81,
        eLBID_L328_TIMETRIAL = 82,
        eLBID_CTRNF_T503_RELICRACE = 82,
        eLBID_L330_TIMETRIAL = 83,
        eLBID_CTRNF_T504_TIMETRIAL = 83,
        eLBID_L331_TIMETRIAL = 84,
        eLBID_CTRNF_T504_RELICRACE = 84,
        eLBID_L332_TIMETRIAL = 85,
        eLBID_CTRNF_T505_TIMETRIAL = 85,
        eLBID_L333_TIMETRIAL = 86,
        eLBID_CTRNF_T505_RELICRACE = 86,
        eLBID_DEVMAPUSAGE = 87,
        eLBID_CTRNF_T506_TIMETRIAL = 87,
        eLBID_CTRNF_T506_RELICRACE = 88,
        eLBID_CTRNF_COUNT = 89,
        eLBID_CTRNF_MKT_DELUXE_EDITION = 1000,
    }

    public enum ELeaderboardRankFocus
    {
        eLRF_Invalid = 0,
        eLRF_AroundPlayer = 1,
        eLRF_FromTop = 2,
    }

    public enum ELevelStars
    {
        eLS_Land = 0,
        eLS_Sea = 1,
        eLS_Sky = 2,
        eLS_Invalid = 3,
    }

    public enum ELevelStreamingType
    {
        eLST_Shared = 0,
        eLST_Pooled = 1,
    }

    public enum ELoadAllHeroesActionState
    {
        eLAHAS_Idle = 0,
        eLAHAS_LoadingMap = 1,
        eLAHAS_ClearHero = 2,
        eLAHAS_SwapHero = 3,
        eLAHAS_SwapHeroWait = 4,
        eLAHAS_SwapFinished = 5,
        eLAHAS_ScreenGrabInit = 6,
        eLAHAS_ScreenGrabTake = 7,
        eLAHAS_CheckLoadVariant = 8,
    }

    public enum ELoadHeroesActionState
    {
        eLHAS_Idle = 0,
        eLHAS_LoadingMap = 1,
        eLHAS_SwapHero = 2,
        eLHAS_SwapFinished = 3,
    }

    public enum ELocalFilter
    {
        LF_Default = 0,
        LF_Local = 1,
        LF_Other = 2,
    }

    public enum EMemoryPoolID
    {
        MP_INVALID = 0,
        MP_DEBUG = 5,
        MP_DEFAULT = 48,
        MP_RESERVE = 49,
        MP_GAME_COMMUNICATION = 50,
        MP_PERMANENT = 51,
        MP_TEMPORARY = 52,
        MP_SOUND = 53,
        MP_SOUND_STREAM = 54,
        MP_GRAPHICS = 55,
        MP_LEVEL = 56,
        MP_LEVEL_RUNTIME = 57,
        MP_MENU = 58,
        MP_HAVOK = 59,
        MP_MEMORYMONITOR = 60,
        MP_MOVIE = 61,
        MP_MOVIE_BUFFERS = 62,
        MP_NETWORK = 63,
        MP_DOTNET = 64,
        MP_DOTNET_GENERICS = 65,
        MP_CTRNF_WINDOWS_VRAM = 65,
        MP_WINDOWS_VRAM = 66,
        MP_CTRNF_MESSAGING = 66,
        MP_MESSAGING = 67,
        MP_CTRNF_HERO_BEGIN = 67,
        MP_HERO_BEGIN = 68,
        MP_POOL_COUNT = 976,
        MP_MAX_POOL = 1024,
    }

    public enum EMirror
    {
        kMirrorNone = 0,
        kMirrorReverse = 1,
        kMirrorRandom = 2,
    }

    public enum EMITier
    {
        eEMIT_Invalid = 0,
        eEMIT_Basic = 1,
        eEMIT_Exotic = 2,
        eEMIT_Premium = 3,
    }

    public enum EMobileShadowState
    {
        eMSS_LetGameDecide = 0,
        eMSS_CastsShadows = 1,
        eMSS_RecievesShadows = 2,
        eMSS_DoesNotCastOrReceiveShadows = 3,
    }

    public enum EMode
    {
        eM_Dynamic = 0,
        eM_Character = 1,
    }

    public enum EModulation
    {
        kReplace = 0,
        kModulate = 1,
        kAdd = 2,
        kSubtract = 3,
        kSubtractReverse = 4,
        kDivide = 5,
        kDivideReverse = 6,
        kKeep = 7,
    }

    public enum EMotionPathBehavior
    {
        kSpawnAlongPath = 0,
        kInstanceAlignBolt = 1,
        kInstanceAlignSpawn = 2,
        kInstanceAlignMotion = 3,
        kInstanceAlignRotated = 4,
        kInstanceAlignWorld = 5,
        kInstanceAlignCamera = 6,
        kMotionPathDisabled = 7,
    }

    public enum EMotor
    {
        EMOTOR_VIBRATE = 0,
        EMOTOR_RUMBLE = 1,
        EMOTOR_MAX = 2,
    }

    public enum EMoverBehavior
    {
        eMB_Relative = 0,
        eMB_Absolute = 1,
    }

    public enum EMSPlatform
    {
        eEMSP_PS4 = 0,
        eEMSP_XBONE = 1,
        eEMSP_Switch = 2,
    }

    public enum ENetworkSendPriority
    {
        eNSP_Low = 0,
        eNSP_Normal = 1,
        eNSP_High = 2,
        eNSP_Critical = 3,
    }

    public enum ENetworkSendRestriction
    {
        eNSR_Local = 0,
        eNSR_FromAuthorityToAll = 1,
        eNSR_FromAuthorityToAllReliable = 2,
        eNSR_FromCreatorAuthorityToAll = 3,
        eNSR_FromHostToAll = 4,
        eNSR_FromHostToAllReliable = 5,
        eNSR_Broadcast = 6,
        eNSR_BroadcastReliable = 7,
    }

    public enum EObjectBoltType
    {
        eOBT_INVALID = 0,
        eOBT_WORLD = 1,
        eOBT_ENTITY = 2,
        eOBT_GAME_ENTITY = 3,
        eOBT_CUTSCENE_ENTITY = 4,
        eOBT_BOLT_ON = 5,
        eOBT_MODEL = 6,
        eOBT_IGENTITY = 7,
        eOBT_MANIPULATOR = 8,
        eOBT_COUNT = 9,
    }

    public enum EOctaneAdventureArea
    {
        eOAA_Nothing = 0,
        eOAA_NSanityBeach = 1,
        eOAA_GemStoneValley = 2,
        eOAA_TheLostRuins = 3,
        eOAA_GlacierPark = 4,
        eOAA_CitadelCity = 5,
    }

    public enum EOctaneAdventureCutscene
    {
        eOACB_None = 0,
        eOACB_RipperRooIntro = 2,
        eOACB_PapuPapuIntro = 4,
        eOACB_KomodoIntro = 8,
        eOACB_PinstripeIntro = 16,
        eOACB_OxideIntroFirst = 32,
        eOACB_OxideIntroSecond = 64,
        eOACB_RipperRooOutro = 128,
        eOACB_PapuPapuOutro = 256,
        eOACB_KomodoOutro = 512,
        eOACB_PinstripeOutro = 1024,
        eOACB_OxideOutroFirst = 2048,
        eOACB_OxideOutroSecond = 4096,
        eOACB_UnlockDoorNsanityBeach = 8192,
        eOACB_UnlockDoorLostRuins = 16384,
        eOACB_UnlockDoorGlacierPark = 32768,
        eOACB_UnlockDoorBeachToGlacier = 65536,
        eOACB_Last = 131072,
        eOACB_UnlockDoorGemsCup = 131072,
    }

    public enum EOctaneAdventureHints
    {
        eOAH_None = 0,
        eOAH_PowerSliding = 2,
        eOAH_TurboBoost = 4,
        eOAH_TNT = 8,
        eOAH_NewWorldGreeting = 16,
        eOAH_WumpaFruit = 32,
        eOAH_BrakeSlide = 64,
        eOAH_HangTime = 128,
        eOAH_AccessingATrack = 256,
        eOAH_UsingABossGarage = 512,
        eOAH_DoubleLockWorldDoors = 1024,
        eOAH_LoadSaveScreen = 2048,
        eOAH_FirstSpeech = 4096,
        eOAH_UsingWarpPad = 8192,
        eOAH_MapInformation = 16384,
        eOAH_BonusRounds = 32768,
        eOAH_CtrChallenge = 65536,
        eOAH_GemCups = 131072,
        eOAH_SecretTracks = 262144,
        eOAH_RelicRace = 524288,
        eOAH_OpeningWorldDoor = 1048576,
        eOAH_OxideGarage = 2097152,
        eOAH_Customization = 4194304,
        eOAH_Last = 8388608,
        eOAH_WumpaCoin = 8388608,
    }

    public enum EOctaneAdventureType
    {
        eOAT_NitroFueled = 0,
        eOAT_Classic = 1,
    }

    public enum EOctaneArcadeMenus
    {
        eOAM_None = 0,
        eOAM_ModeSelect = 1,
        eOAM_TrackSelect = 2,
        eOAM_CharacterSelect = 3,
        eOAM_BattleSettings = 4,
        eOAM_CupSelect = 5,
        eOAM_MainMenu = 6,
    }

    public enum EOctaneBoostBarType
    {
        eOBT_Classic = 0,
        eOBT_Speedometer = 1,
        eOBT_NitroFueled = 2,
        eOBT_Count = 3,
    }

    public enum EOctaneBreadcrumbsCategory
    {
        eOBC_Invalid = 0,
        eOBC_Character = 1,
        eOBC_Skin = 2,
        eOBC_CharacterCategory = 3,
        eOBC_KartBody = 4,
        eOBC_KartDecal = 8,
        eOBC_Wheels = 16,
        eOBC_Paintjob = 32,
        eOBC_Stickers = 64,
        eOBC_KartCategory = 124,
        eOBC_Custo = 127,
    }

    public enum EOctaneCheats
    {
        eOC_PentaPenguin = 0,
        eOC_SuperEngin = 1,
        eOC_SuperTurboPads = 2,
        eOC_PermanentInvisibility = 3,
        eOC_InfiniteWumpaFruits = 4,
        eOC_InfiniteBowlingBombs = 5,
        eOC_InfiniteInvinsibilityMask = 6,
        eOC_UnlimitedTurbos = 7,
        eOC_IcyTracks = 8,
        eOC_OneLapRaces = 9,
        eOC_DisplayBoostCount = 10,
        eOC_SuperHardMode = 11,
        eOC_Count = 12,
    }

    public enum EOctaneCreditsLineType
    {
        eOCL_Empty = 0,
        eOCL_Header = 1,
        eOCL_SubHeader = 2,
        eOCL_Image = 3,
        eOCL_Single = 4,
        eOCL_Double = 5,
        eOCL_Triple = 6,
    }

    public enum EOctaneDriverThematic
    {
        eODT_None = 0,
        eODT_Thematic1 = 1,
        eODT_Thematic2 = 2,
        eODT_Thematic3 = 3,
        eODT_Thematic4 = 4,
        eODT_Thematic5 = 5,
        eODT_Thematic6 = 6,
        eODT_Thematic7 = 7,
        eODT_Thematic8 = 8,
        eODT_Thematic9 = 9,
        eODT_Thematic10 = 10,
        eODT_Thematic11 = 11,
        eODT_Thematic12 = 12,
        eODT_Thematic13 = 13,
        eODT_Thematic14 = 14,
        eODT_Thematic15 = 15,
        eODT_Thematic16 = 16,
        eODT_Thematic17 = 17,
        eODT_Thematic18 = 18,
        eODT_Thematic19 = 19,
        eODT_Thematic20 = 20,
        eODT_Thematic21 = 21,
        eODT_Thematic22 = 22,
        eODT_Thematic23 = 23,
        eODT_Thematic24 = 24,
        eODT_Thematic25 = 25,
        eODT_Thematic26 = 26,
        eODT_Thematic27 = 27,
        eODT_Thematic28 = 28,
        eODT_Thematic29 = 29,
        eODT_Thematic30 = 30,
        eODT_Thematic31 = 31,
        eODT_Thematic32 = 32,
    }

    public enum EOctaneGameVersion
    {
        eOCTGV_Invalid = 0,
        eOCTGV_Disk = 1,
        eOCTGV_TU0 = 2,
        eOCTGV_JulyGP = 3,
        eOCTGV_AugustGP = 4,
        eOCTGV_CURRENT_VERSION = 5,
        eOCTGV_SeptemberGP = 5,
        eOCTGV_OctoberGP = 6,
        eOCTGV_NovemberGP = 7,
        eOCTGV_DecemberGP = 8,
        eOCTGV_Count = 9,
        eOCTGV_MAX = 64,
    }

    public enum EOctaneHintCategories
    {
        eOHC_Controls = 0,
        eOHC_GPI = 1,
        eOHC_GameModes = 2,
        eOHC_Rewards = 3,
        eOHC_Hub = 4,
    }

    public enum EOctaneLeaderboardPopulationType
    {
        eOLPT_Invalid = 0,
        eOLPT_Everyone = 1,
        eOLPT_Friends = 2,
    }

    public enum EOctaneLeaderboardType
    {
        eOLT_Invalid = 0,
        eOLT_Time = 1,
        eOLT_GrandPrixWins = 2,
        eOLT_GrandPrixNitro = 3,
    }

    public enum EOctaneMarketplaceItemCategory
    {
        eOMIC_CharacterBundle = 0,
        eOMIC_KartSet = 1,
        eOMIC_LastBundle = 1,
        eOMIC_Character = 2,
        eOMIC_Skin = 3,
        eOMIC_ColorSet = 4,
        eOMIC_Decal = 5,
        eOMIC_Wheels = 6,
        eOMIC_LastItemCategory = 7,
        eOMIC_StickerPack = 7,
        eOMIC_NitroBoost = 8,
        eOMIC_WumpaCoins = 9,
        eOMIC_Hidden = 10,
    }

    public enum EOctaneOptionPages
    {
        eOOP_Invalid = 0,
        eOOP_Gameplay = 1,
        eOOP_Audio = 2,
        eOOP_Controls = 3,
        eOOP_Extras = 4,
    }

    public enum EOctaneRaceModes
    {
        eORM_Invalid = 0,
        eORM_SingleRace = 1,
        eORM_TimeTrial = 2,
        eORM_RelicRace = 3,
        eORM_BossFight = 4,
        eORM_CtrChallenge = 5,
        eORM_CupRace = 6,
        eORM_HUB = 7,
        eORM_CrystalChallenge = 8,
        eORM_BattleArena = 9,
        eORM_CaptureTheFlag = 10,
        eORM_LastKartDriving = 11,
        eORM_StealTheBacon = 12,
        eORM_CrystalGrabBattle = 13,
        eORM_Sports = 14,
        eORM_ModeR = 15,
    }

    public enum EOctaneTeam
    {
        eOT_teamBlue = 0,
        eOT_teamRed = 1,
    }

    public enum EOctaneTheme
    {
        eOT_Invalid = -1,
        eOT_Default = 1,
        eOT_GP3 = 2,
        eOT_Count = 3,
    }

    public enum EOpenUIActionState
    {
        eOUIAS_Idle = 0,
        eOUIAS_Open = 1,
        eOUIAS_Close = 2,
    }

    public enum EOperatorCurveInput
    {
        kStackTime = 0,
        kPrimitiveTime = 1,
        kInstanceTime = 2,
        kZeroTime = 3,
        kTrackParameter1 = 4,
        kTrackParameter2 = 5,
        kTrackParameter3 = 6,
        kTrackParameter4 = 7,
        kBolt1Input1 = 8,
        kBolt1Input2 = 9,
        kBolt1Input3 = 10,
        kBolt1Input4 = 11,
        kBolt2Input1 = 12,
        kBolt2Input2 = 13,
        kBolt2Input3 = 14,
        kBolt2Input4 = 15,
    }

    public enum EOperatorCurveOutput
    {
        kSetTrackParameter1 = 4,
        kSetTrackParameter2 = 5,
        kSetTrackParameter3 = 6,
        kSetTrackParameter4 = 7,
    }

    public enum EOptionsChannelGroup
    {
        eOCG_Sfx = 0,
        eOCG_Music = 1,
        eOCG_Vo = 2,
        eOCG_Fmv = 3,
        eOCG_Count = 4,
    }

    public enum EOutfitType
    {
        eOT_Default = 0,
        eOT_Cutscene = 1,
        eOT_CutsceneLose = 2,
    }

    public enum EPathDifficulty
    {
        ePD_None = 0,
        ePD_VeryEasy = 1,
        ePD_Easy = 2,
        ePD_Normal = 3,
        ePD_Hard = 4,
        ePD_VeryHard = 5,
    }

    public enum EPlayBehavior
    {
        ePB_OLDEST = 0,
        ePB_NEWEST = 1,
        ePB_QUIETEST = 2,
        ePB_FARTHEST = 3,
        ePB_FAIL = 4,
    }

    public enum EPlayerAttackType
    {
        ePAT_Primary = 0,
        ePAT_Secondary = 1,
        ePAT_Tertiary = 2,
        ePAT_Quaternary = 3,
        ePAT_Count = 4,
    }

    public enum EPlayerCancelAttackReason
    {
        ePCAR_Jump = 0,
        ePCAR_LockedControls = 1,
        ePCAR_Respawn = 2,
        ePCAR_HitReact = 3,
        ePCAR_ReleasedButton = 4,
        ePCAR_ActorInVehicle = 5,
        ePCAR_TriggeredOtherAttack = 6,
        ePCAR_DisabledRacing = 7,
        ePCAR_NetForceLocomotion = 8,
        ePCAR_Other = 9,
    }

    public enum EPlayerId
    {
        EPLAYERID_NONE = -1,
        EPLAYERID_ONE = 0,
        EPLAYERID_TWO = 1,
        EPLAYERID_THREE = 2,
        EPLAYERID_FOUR = 3,
        EPLAYERID_FIVE = 4,
        EPLAYERID_SIX = 5,
        EPLAYERID_SEVEN = 6,
        EPLAYERID_EIGHT = 7,
        EPLAYERID_NINE = 8,
        EPLAYERID_CTRNF_MAX = 8,
        EPLAYERID_CTRNF_COUNT = 8,
        EPLAYERID_TEN = 9,
        EPLAYERID_ELEVEN = 10,
        EPLAYERID_TWELVE = 11,
        EPLAYERID_MAX = 12,
    }

    public enum EPlayerSupportType
    {
        ePST_Physics = 0,
        ePST_Logic = 1,
    }

    public enum EPlayerType
    {
        Local = 0,
        Online = 1,
        Computer = 2,
    }

    public enum EPlayFeature
    {
        ePF_RANDOM = 0,
        ePF_SEQUENTIAL = 1,
        ePF_RANDOM_NOREPEAT = 2,
        ePF_SHUFFLE = 3,
    }

    public enum EPointOfInterest
    {
        ePOI_Invalid = -1,
        ePOI_Camera = 0,
        ePOI_Sound = 1,
        ePOI_Objective = 2,
        ePOI_Player = 3,
        ePOI_Enemy = 4,
        ePOI_Ambient = 5,
        ePOI_Treasure = 6,
        ePOI_Conversation = 7,
    }

    public enum EPowerUpType
    {
        ePT_None = -1,
        ePT_Bomb = 0,
        ePT_Missile = 1,
        ePT_ExplosiveCrate = 2,
        ePT_Beaker = 3,
        ePT_InvincibilityMask = 4,
        ePT_NTropy = 5,
        ePT_TurboBoost = 6,
        ePT_WarpOrb = 7,
        ePT_PowerShield = 8,
        ePT_TripleBomb = 9,
        ePT_TripleMissile = 10,
        ePT_SuperEngine = 11,
        ePT_Invisibility = 12,
        ePT_MultiPowerUp = 13,
    }

    public enum EPriority
    {
        kHigh = 0,
        kMedium = 1,
        kLow = 2,
    }

    public enum EProjectileMovementMode
    {
        ePMM_StraightLine = 0,
        ePMM_FollowGround = 1,
        ePMM_Lobbed = 2,
        ePMM_Homing = 3,
        ePMM_HomingAvoidGround = 4,
        ePMM_Physics = 5,
        ePMM_HomingFollowGround = 6,
        ePMM_HomingFollowWallAndGround = 7,
        ePMM_AvoidGround = 8,
        ePMM_HomingPlanar = 9,
    }

    public enum EQuerySortMode
    {
        eQSM_NoSort = 0,
        eQSM_SortByDistance = 1,
        eQSM_SortByFaceAngle = 2,
        eQSM_SortByHealth = 3,
        eQSM_SortByLeftToRight = 4,
        eQSM_SortByRightToLeft = 5,
    }

    public enum EQueueType
    {
        kQueueNone = 0,
        kQueueRegular = 1,
        kQueueOne = 2,
    }

    public enum ERaceClockMode
    {
        ERCM_CountUp = 0,
        ERCM_CountDown = 1,
    }

    public enum ERacingMinimapDirection
    {
        eRMD_Right = 0,
        eRMD_Left = 1,
        eRMD_Bottom = 2,
        eRMD_Top = 3,
        eRMD_None = 4,
        eRMD_Debug = 5,
    }

    public enum EReferenceFrame
    {
        eRF_World = 0,
        kFrameWorld = 0,
        eRF_Camera = 1,
        kFrameCamera = 1,
        eRF_Bolt1 = 2,
        kFrameBolt1 = 2,
        eRF_Bolt2 = 3,
        kFrameBolt2 = 3,
        eRF_GroundBolt = 4,
        kFrameGroundBolt = 4,
        eRF_Instance = 5,
        kFrameInstance = 5,
        eRF_Track1 = 6,
        kFrameTrack1 = 6,
        eRF_Track2 = 7,
        kFrameTrack2 = 7,
        eRF_Track3 = 8,
        kFrameTrack3 = 8,
        eRF_Track4 = 9,
        kFrameTrack4 = 9,
        eRF_None = 10,
        kFrameNone = 10,
    }

    public enum EReplication
    {
        eR_NotReplicated = 0,
        eR_Replicated = 1,
        eR_ReplicateOnce = 2,
    }

    public enum ERespawnType
    {
        eRT_RespawnTrigger = 0,
        eRT_InstantRespawnTrigger = 1,
        eRT_WaterRespawnTrigger = 2,
        eRT_IceRespawnTrigger = 3,
        eRT_CheckpointRespawn = 4,
        eRT_KillZ = 5,
        eRT_Instant = 6,
        eRT_PVPDeathDelayed = 7,
        eRT_Unknown = 8,
    }

    public enum ERigidAnimCtrlState
    {
        eRACS_Inactive = 0,
        eRACS_Complete = 1,
        eRACS_Active = 2,
    }

    public enum ERotate
    {
        kRotationNone = 0,
        kRotation90 = 1,
        kRotation180 = 2,
        kRotation270 = 3,
        kRotationRandom = 4,
    }

    public enum ESaveLoad
    {
        SL_IDLE = 0,
        SL_SAVE_OPTIONS = 1,
        SL_LOAD_SLOTS_AND_OPTIONS = 2,
        SL_VERIFY_SPACE_FOR_NEWGAME = 3,
        SL_LOAD_GAME = 4,
        SL_SAVE_GAME = 5,
        SL_DELETE_GAME = 6,
        SL_DELETE_OPTIONS = 7,
        SL_FETCH_AND_RESOLVE_CLOUD_DATA = 8,
    }

    public enum ESignal
    {
        kSignalTouched1 = 0,
        kSignalTouched2 = 1,
        kSignalTouched3 = 2,
        kSignalTouched4 = 3,
        kSignalTouched5 = 4,
        kSignalTouch1X = 11,
        kSignalTouch1Y = 12,
        kSignalTouch2X = 13,
        kSignalTouch2Y = 14,
        kSignalTouch3X = 15,
        kSignalTouch3Y = 16,
        kSignalTouch4X = 17,
        kSignalTouch4Y = 18,
        kSignalTouch5X = 19,
        kSignalTouch5Y = 20,
        kSignalCount = 33,
    }

    public enum ESliderMode
    {
        eSM_PlayOnce = 0,
        eSM_Loop = 1,
        eSM_PingPong = 2,
    }

    public enum ESortMode
    {
        kSortNone = 0,
        kSortBackToFront = 1,
        kSortFrontToBack = 2,
    }

    public enum ESound3dBehavior
    {
        eS3B_2d = 0,
        eS3B_attenuation = 1,
        eS3B_3dMono = 2,
        eS3B_3dStereo = 3,
    }

    public enum ESoundFocusPositionType
    {
        eSFPT_Default = 0,
        eSFPT_Players = 0,
        eSFPT_CameraPosition = 1,
        eSFPT_Entity = 2,
        eSFPT_Count = 3,
    }

    public enum ESoundGroupPlaybackBehavior
    {
        eSGPB_Fail = 0,
        eSGPB_Mute = 1,
        eSGPB_StealLowest = 2,
    }

    public enum ESoundLoopEvent
    {
        SLE_START = 0,
        SLE_STOP = 1,
    }

    public enum ESoundPauseType
    {
        eSPT_InGame = 0,
        eSPT_Dialog = 1,
        eSPT_MagicMoment = 2,
        eSPT_PauseMenu = 3,
        eSPT_AllPaused = 4,
    }

    public enum ESourceAxis
    {
        eSA_XAxis = 0,
        kSourceXAxis = 0,
        eSA_YAxis = 1,
        kSourceYAxis = 1,
        eSA_ZAxis = 2,
        kSourceZAxis = 2,
        eSA_Position = 3,
        kSourcePosition = 3,
        eSA_Velocity = 4,
        kSourceVelocity = 4,
    }

    public enum ESpawnGroup
    {
        kSpawnGroupInherit = -1,
        kSpawnGroup0 = 0,
        kSpawnGroupDefault = 0,
        kSpawnGroup1 = 1,
        kSpawnGroup2 = 2,
        kSpawnGroup3 = 3,
        kSpawnGroup4 = 4,
        kSpawnGroup5 = 5,
        kSpawnGroup6 = 6,
        kSpawnGroup7 = 7,
        kMaxSpawnGroupCount = 8,
    }

    public enum ESplineEndBehavior
    {
        eSEB_None = 0,
        eSEB_Wrap = 1,
        eSEB_PingPong = 2,
        eSEB_KillEntity = 3,
    }

    public enum ESplineLaneMoverForwardMovementType
    {
        eSLMF_PlayOnce = 0,
        eSLMF_Loop = 1,
        eSLMF_PingPong = 2,
    }

    public enum ESplineLaneMoverHorizontalMovementType
    {
        eSLMH_SetVelocity = 0,
        eSLMH_Accelerate = 1,
        eSLMH_Converge = 2,
    }

    public enum ESplineLaneMoverOrientationType
    {
        eSLMO_Free = 0,
        eSLMO_FaceAlongSpline = 1,
        eSLMO_FaceVelocityVector = 2,
        eSLMO_FaceAlongSplineAbsolute = 3,
        eSLMO_FaceVelocityVectorAbsolute = 4,
    }

    public enum ESplineLaneMoverUpOrientation
    {
        eSLMU_ZVector = 0,
        eSLMU_TowardSpline = 1,
    }

    public enum ESplineLaneMoverVerticalMovementType
    {
        eSLMV_Free = 0,
        eSLMV_ClampToSplineZ = 1,
        eSLMV_CeilToSplineZ = 2,
    }

    public enum ESplineMode
    {
        eSM_UseAllAxes = -1,
        eSM_Auto = 0,
        eSM_Vertical = 1,
        eSM_Horizontal = 2,
        eSM_ForceIgnoreX = 3,
        eSM_ForceIgnoreY = 4,
        eSM_ForceIgnoreZ = 5,
    }

    public enum ESplineOffsetState
    {
        eSPT_Correct = 0,
        eSPT_Inside = 1,
        eSPT_Outside = 2,
    }

    public enum EStackType
    {
        kStackEffect = 0,
        kStackPrimitive = 1,
        kStackSpawn = 2,
        kStackUpdate = 3,
        kStackCount = 4,
    }

    public enum EStartDistanceDirection
    {
        eSDD_PlayerDirection = 0,
        eSDD_ForwardDirection = 1,
        eSDD_BackwardDirection = 2,
        eSDD_VerticalDirection = 3,
    }

    public enum EStreamBufferUnits
    {
        kUnitsBytes = 0,
        kUnitsMs = 1,
    }

    public enum ETargetAxis
    {
        eTA_XAxis = 0,
        kTargetXAxis = 0,
        eTA_YAxis = 1,
        kTargetYAxis = 1,
        eTA_ZAxis = 2,
        kTargetZAxis = 2,
    }

    public enum ETeamFilterLayers
    {
        eTFL_None = 0,
        eTFL_Entity = 1,
        eTFL_Level = 2,
        eTFL_LevelBorder = 3,
        eTFL_Query = 4,
        eTFL_Debris = 5,
        eTFL_Collectibles = 6,
        eTFL_TriggerVolumes = 7,
        eTFL_Player1 = 8,
        eTFL_Player2 = 9,
        eTFL_Destructibles = 10,
        eTFL_EntityNoTrigger = 11,
        eTFL_NeverCollide = 12,
        eTFL_Player3 = 13,
        eTFL_Player4 = 14,
        eTFL_Player5 = 15,
        eTFL_Player6 = 16,
        eTFL_Player7 = 17,
        eTFL_Player8 = 18,
        eTFL_Player9 = 19,
        eTFL_Player10 = 20,
        eTFL_Player11 = 21,
        eTFL_Player12 = 22,
        eTFL_Max = 23,
    }

    public enum ETextAlignment
    {
        eTA_Left = 0,
        eTA_Center = 1,
        eTA_Right = 2,
    }

    public enum EThemeModelType
    {
        eTMT_Invalid = -1,
        eTMT_Pickable = 0,
        eTMT_PickableCrate = 1,
        eTMT_PowerupCrate = 2,
    }

    public enum EThemeSFXType
    {
        eTST_Invalid = -1,
        eTST_PowerupCratePlayer = 1,
        eTST_PowerupCrateNPC = 2,
        eTST_Pickable = 3,
        eTST_PickableUIAdd = 4,
        eTST_PickableUIMax = 5,
        eTST_PickableUINoChange = 6,
        eTST_PickableCratePlayer = 7,
        eTST_PickableCrateNPC = 8,
    }

    public enum ETimerType
    {
        eTT_Game = 0,
        eTT_Absolute = 1,
    }

    public enum ETransformSpace
    {
        kCameraSpace = 0,
        kWorldSpace = 1,
        kLocalSpace = 2,
    }

    public enum ETriggerVolumeDetectionType
    {
        eTVDT_Aabb = 0,
        eTVDT_Normal = 1,
        eTVDT_Critical = 2,
    }

    public enum ETriggerVolumeQualityType
    {
        eTVQT_Fixed = 0,
        eTVCF_Keyframed_DynamicsOnly = 1,
        eTVCF_Keyframed_All = 2,
    }

    public enum ETrophy
    {
        eTrophy_Invalid = 0,
        eTrophy_firstWin = 1,
        eTrophy_winRipperRoo = 2,
        eTrophy_winPapuPapu = 3,
        eTrophy_winKomodoJoe = 4,
        eTrophy_winPinStripe = 5,
        eTrophy_winNitrousOxide = 6,
        eTrophy_defeatNitrousOxide = 7,
        eTrophy_completeAdventureCrystalChallenge = 8,
        eTrophy_winAdventureCTRChallenge = 9,
        eTrophy_winAdventureRelicRace = 10,
        eTrophy_winAdventureCupRace = 11,
        eTrophy_collectAllAdventureRelics = 12,
        eTrophy_collectAllAdventureGems = 13,
        eTrophy_collectAllAdventureCTRTokens = 14,
        eTrophy_photoFinish = 15,
        eTrophy_oneBombTwoVictims = 16,
        eTrophy_doASuperBoost = 17,
        eTrophy_winBossRaceWithoutBossPowerup = 18,
        eTrophy_driftsInARow = 19,
        eTrophy_useAllTurbosInARow = 20,
        eTrophy_driftsTotal = 21,
        eTrophy_completeAdventureHardDifficulty = 22,
        eTrophy_finishFirstAfterLastLastLap = 23,
        eTrophy_blockMissileWithOtherPowerups = 24,
        eTrophy_beatNefariousTropysTimes = 25,
        eTrophy_beatNitrousOxideTimes = 26,
        eTrophy_noPowerUpsUsedWin = 27,
        eTrophy_firstPlaceAllTracks = 28,
        eTrophy_tripleMissileAllHit = 29,
        eTrophy_useAllPowerups = 30,
        eTrophy_useCortexCastleShortcut = 31,
        eTrophy_usePolarPassShortcut = 32,
        eTrophy_useBlizzardBluffsShortcuts = 33,
        eTrophy_usePapuPyramidsShortcuts = 34,
        eTrophy_useCrashCoveShortcut = 35,
        eTrophy_useSewerSpeedwayShortcut = 36,
        eTrophy_useTigerTempleShortcut = 37,
        eTrophy_useDragonMinesShortcut = 38,
        eTrophy_useAllShortcuts = 39,
        eTrophy_useAllJuicedPowerups = 40,
        eTrophy_sustainBoostWholeLap = 41,
        eTrophy_winInEveryBattleMode = 42,
        eTrophy_tntFreedom = 43,
        eTrophy_directBeakerHit = 44,
        eTrophy_customizeYourRide = 45,
        eTrophy_unlockAllOriginalCharacters = 46,
        eTrophy_completeAllCrystalChallenges = 47,
        eTrophy_earnAllOtherTrophies = 48,
    }

    public enum EVehicleCollisionCriteriaOwner
    {
        eVCCO_Any = 0,
        eVCCO_Source = 1,
        eVCCO_Target = 2,
    }

    public enum EVehicleCollisionReaction
    {
        eVCR_None = -1,
        eVCR_Minor = 0,
        eVCR_Moderate = 1,
        eVCR_Major = 2,
    }

    public enum EVehicleCollisionTriState
    {
        eVCTS_No = 0,
        eVCTS_Yes = 1,
        eVCTS_Either = 2,
    }

    public enum EVehicleCollisionTweakAxis
    {
        eVCTA_Forward = 0,
        eVCTA_Right = 1,
        eVCTA_Up = 2,
        eVCTA_None = 3,
    }

    public enum EVehicleCollisionWeightClassRelationship
    {
        eVCWC_Equal = 0,
        eVCWC_SourceHigher = 1,
        eVCWC_TargetHigher = 2,
        eVCWC_All = 3,
    }

    public enum EVehicleId
    {
        EVEHICLEID_NONE = -1,
        EVEHICLEID_ONE = 0,
        EVEHICLEID_TWO = 1,
        EVEHICLEID_THREE = 2,
        EVEHICLEID_FOUR = 3,
        EVEHICLEID_MAX = 4,
        EVEHICLEID_CTRNF_FIVE = 4,
        EVEHICLEID_CTRNF_SIX = 5,
        EVEHICLEID_CTRNF_SEVEN = 6,
        EVEHICLEID_CTRNF_EIGHT = 7,
        EVEHICLEID_CTRNF_MAX = 8,
        EVEHICLEID_CTRNF_COUNT = 8,
    }

    public enum EVehiclePersonalizationBoost
    {
        eVPB_None = -1,
        eVPB_RoboRepair = 0,
        eVPB_BoomBoost = 1,
        eVPB_RapidRecovery = 2,
        eVPB_DynamiteDash = 3,
        eVPB_TimeWarp = 4,
        eVPB_BuzzKill = 5,
        eVPB_ItsATrap = 6,
        eVPB_SnotRocket = 7,
        eVPB_BugZapper = 8,
        eVPB_SelfDestruct = 9,
        eVPB_ShrapnelShield = 10,
        eVPB_PeaceOut = 11,
    }

    public enum EVehiclePersonalizationType
    {
        eVPT_None = -1,
        eVPT_Set = 0,
        eVPT_Topper = 1,
        eVPT_ColorScheme = 2,
        eVPT_Taunt = 3,
        eVPT_Neon = 4,
        eVPT_Boost = 5,
    }

    public enum EVehicleStat
    {
        eVS_Invalid = 0,
        eVS_Begin = 1,
        eVS_Grip = 1,
        eVS_Drift = 2,
        eVS_Weight = 3,
        eVS_Acceleration = 4,
        eVS_TopSpeed = 5,
        eVS_Maneuver = 6,
        eVS_Shield = 7,
        eVS_Armor = 8,
        eVS_Buoyancy = 9,
        eVS_Hover = 10,
        eVS_Count = 11,
    }

    public enum EVehicleStatSource
    {
        eVSS_Invalid = 0,
        eVSS_Base = 1,
        eVSS_Start = 1,
        eVSS_Variant = 2,
        eVSS_PrimaryMod = 3,
        eVSS_SecondaryMod = 4,
        eVSS_UpgradeBoost = 5,
        eVSS_SuperchargeBoost = 6,
        eVSS_TemporaryBoost = 7,
        eVSS_VehicleState = 8,
        eVSS_Count = 9,
    }

    public enum EVehicleType
    {
        eVT_Invalid = 0,
        eVT_Driving = 1,
        eVT_Flying = 2,
        eVT_Hover = 3,
        eVT_Any = 4,
    }

    public enum EVerticalAlignment
    {
        kVerticalAlignmentTop = 0,
        kVerticalAlignmentCenter = 1,
        kVerticalAlignmentBottom = 2,
    }

    public enum EViewportID
    {
        kViewportID_0 = 0,
        kViewportID_CTRNF_Default = 0,
        kViewportID_1 = 1,
        kViewportID_Count = 2,
        kViewportID_CTRNF_Count = 4,
    }

    public enum EVulnerability
    {
        eV_Invalid = -1,
        eV_CanBeDamaged = 0,
        eV_RedirectedOnly = 1,
        eV_Invulnerable = 2,
    }

    public enum EWorldGameplayMode
    {
        eWGM_Traditional = 0,
        eWGM_Chase = 1,
        eWGM_Boss = 2,
        eWGM_Ride = 3,
        eWGM_JetPack = 4,
        eWGM_Plane = 5,
        eWGM_Swimming = 6,
        eWGM_Motorcycle = 7,
        eWGM_Hub = 8,
        eWGM_JetSki = 9,
        eWGM_Sidescrolling = 10,
        eWGM_Isometric = 11,
        eWGM_JetBoard = 12,
        eWGM_Bazooka = 13,
        eWGM_SwimJet = 14,
        eWGM_JetPackBoss = 15,
        eWGM_Count = 16,
        eWGM_CTRNF_Kart = 16,
        eWGM_CTRNF_Count = 17,
    }

    public enum EXBUTTON
    {
        MOVE_X = 0,
        MOVE_Y = 1,
        CAMERA_X = 2,
        CAMERA_Y = 3,
        A = 4,
        B = 5,
        Y = 6,
        R2 = 7,
        X = 8,
        L3 = 9,
        R3 = 10,
        L1 = 11,
        L2 = 12,
        R1 = 13,
        DPAD_UP = 14,
        DPAD_DN = 15,
        DPAD_RT = 16,
        DPAD_LF = 17,
        MENU = 18,
        PAUSE = 19,
        MENU_ACCEPT = 20,
        MENU_BACK = 21,
        MENU_OPTION1 = 22,
        MENU_OPTION2 = 23,
        JUMP = 24,
        ATTACK_PRIMARY = 25,
        ATTACK_SECONDARY = 26,
        ATTACK_TERTIARY = 27,
        GADGET01 = 28,
        GADGET02 = 29,
        GADGET03 = 30,
        GADGET04 = 31,
        TOUCH1 = 32,
        TOUCH2 = 33,
        TOUCH3 = 34,
        TOUCH4 = 35,
        TOUCH5 = 36,
        TOUCH1_X = 37,
        TOUCH1_Y = 38,
        TOUCH2_X = 39,
        TOUCH2_Y = 40,
        TOUCH3_X = 41,
        TOUCH3_Y = 42,
        TOUCH4_X = 43,
        TOUCH4_Y = 44,
        TOUCH5_X = 45,
        TOUCH5_Y = 46,
        BRAKE = 47,
        REMOVE_TOYS = 48,
        PLACE_CTRNF_TREASURE = 48,
        MENU_SAVE_LOAD = 49,
        REMOVE_CTRNF_TREASURE = 49,
        SPEED_SHOES = 50,
        REMOVE_CTRNF_TOYS = 50,
        EQUIP_BAZOOKA = 51,
        CTRNF_MAX = 51,
        TOUCH1_AIM_X = 52,
        TOUCH1_AIM_Y = 53,
        MENU_TAB_LEFT = 54,
        MENU_TAB_RIGHT = 55,
        MENU_OPTION3 = 56,
        B_LSHIFT = 57,
        A_SPACE = 58,
        B_RCLICK = 59,
        R2_LCLICK = 60,
        R2_SPACE = 61,
        MAX = 62,
    }

    public enum EZoneCategory
    {
        eZC_Invalid = -1,
        eZC_Story = 0,
        eZC_Testrooms = 1,
        eZC_Cinematics = 2,
        eZC_Debug = 3,
        eZC_Whiterooms = 4,
        eZC_PVP = 5,
        eZC_Vehicle = 6,
        eZC_Count = 7,
    }

    public enum EZoneCollectibleType
    {
        eZCT_None = 0,
        eZCT_Gem_Clear = 2,
        eZCT_CTRNF_Trophy = 2,
        eZCT_Gem_Blue = 4,
        eZCT_CTRNF_Key = 4,
        eZCT_Gem_Green = 8,
        eZCT_CTRNF_RelicPlatinum = 8,
        eZCT_Gem_Purple = 16,
        eZCT_CTRNF_RelicSapphire = 16,
        eZCT_Gem_Red = 32,
        eZCT_CTRNF_RelicGold = 32,
        eZCT_Gem_Yellow = 64,
        eZCT_CTRNF_TokenRed = 64,
        eZCT_Gem_Orange = 128,
        eZCT_CTRNF_TokenBlue = 128,
        eZCT_Gem_Clear2 = 256,
        eZCT_CTRNF_TokenPurple = 256,
        eZCT_PowerCrystal = 512,
        eZCT_CTRNF_TokenGreen = 512,
        eZCT_Key = 1024,
        eZCT_CTRNF_TokenYellow = 1024,
        eZCT_BossFight = 2048,
        eZCT_RelicPlatinum = 4096,
        eZCT_CTRNF_GemRed = 4096,
        eZCT_RelicSapphire = 8192,
        eZCT_CTRNF_GemBlue = 8192,
        eZCT_RelicGold = 16384,
        eZCT_CTRNF_GemPurple = 16384,
        eZCT_CTRNF_GemGreen = 32768,
        eZCT_CTRNF_GemYellow = 65536,
        eZCT_CTRNF_GemsAll = 131072,
        eZCT_CTRNF_OxideStar = 262144,
    }

    public enum EZoneInfoProgressionGroup
    {
        eZIPG_None = 0,
        eZIPG_Intro = 1,
        eZIPG_Sky = 2,
        eZIPG_Nature = 3,
        eZIPG_Magic = 4,
        eZIPG_Quest = 5,
        eZIPG_Final = 6,
        eZIPG_DarkBoss = 7,
        eZIPG_Hub = 8,
    }
}