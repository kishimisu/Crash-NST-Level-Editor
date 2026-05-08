namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CAccelerationVehicleSettingList : CBaseVehicleSettingList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CAccoladeDataList : igObjectList<CAccoladeData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CAccoladeGoalDataList : igObjectList<CAccoladeGoalData> { }
    [ObjectAttr(nst: 32, align: 8)] public class CAccoladeGraphGoalData : CAccoladeGoalData { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CAccoladeRequirement : igObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CAccoladeRequirementList : igObjectList<CAccoladeRequirement> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CAchievementEvent : igObject { }
    [ObjectAttr(nst: 56, align: 8)] public class CActivateMessage : CEntityMessage { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CActorHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, align: 8)] public class CActorInputListenerList : igObjectList<CActorInputListener> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CActorInputMapList : igObjectList<CActorInputMap> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CActorTimeScaleNonRefcountedList : igNonRefCountedObjectList { }
    [ObjectAttr(ctr: 40, align: 8)] public class CAEAchievementList : igObjectList<CAEAchievement> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CAEAchievementParamListList : igObjectList<CAEAchievementParamList> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CAEEventHandleList : igSmartHandleList { }
    [ObjectAttr(ctr: 40, align: 8)] public class CAEEventList : igObjectList<CAEEvent> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CAEKindList : igObjectList<CAEKind> { }
    [ObjectAttr(nst: 40, align: 8)] public class CAIAggroRuleList : igObjectList<CAIAggroRule> { }
    [ObjectAttr(nst: 40, align: 8)] public class CAIAggroRuleTableList : igObjectList<CAIAggroRuleTable> { }
    [ObjectAttr(nst: 80, align: 8)] public class CAIFallHandler : CBehaviorLogic { }
    [ObjectAttr(nst: 112, ctr: 112, align: 8)] public class CAirVehicleControllerSettings : CBaseVehicleControllerSettings { }
    [ObjectAttr(nst: 24, align: 4)] public class CAITargetSourceBasic : CAITargetSource { }
    [ObjectAttr(nst: 40, align: 8)] public class CAITargetSourceList : igObjectList<CAITargetSource> { }
    [ObjectAttr(nst: 608, ctr: 592, align: 16)] public class CAmbientDiffuseGeneratorRenderPass : CColorGeneratorRenderPass { }
    [ObjectAttr(nst: 120, ctr: 120, align: 8)] public class CAmbientOcclusionMaterial : igFxMaterial { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CAnalogStickDirectionToVfxAnalogStickTable : igHashTable<igEnumMetaField, igHandleMetaField> { }
    [ObjectAttr(nst: 96, align: 8)] public class CAnimationAddedEventMessage : CAnimationEventMessage { }
    [ObjectAttr(nst: 32, align: 8)] public class CAnimationClip : CCharacterClip { }
    [ObjectAttr(nst: 40, align: 8)] public class CAnimationEventTimelineList : CCharacterEventTimelineList { }
    [ObjectAttr(nst: 96, align: 8)] public class CAnimationRemovedEventMessage : CAnimationEventMessage { }
    [ObjectAttr(nst: 64, align: 8)] public class CAnimationSubStatesDataTable : igHashTable<string, igObject> { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CArenaDriftVehicleSettingList : CDriftVehicleSettingList { }
    [ObjectAttr(nst: 24, ctr: 24, align: 4)] public class CArmorVehicleSetting : CBaseVehicleSetting { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CArmorVehicleSettingList : CBaseVehicleSettingList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CAttachmentSplineAttachmentList : igObjectList<CAttachmentSplineAttachment> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CAttachModelList : igObjectList<CAttachModel> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CAttackImmunityTimestampTable : igHashTable<string, igTimeMetaField> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CAttackNumberTimestampTable : igHashTable<u32, igTimeMetaField> { }
    [ObjectAttr(nst: 40, align: 8)] public class CAttackRegionShapeList : igObjectList<CAttackRegionShape> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CAudioArchiveHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CAudioArchiveList : igObjectList<CAudioArchive> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CAudioBinkSettingsList : igObjectList<CAudioBinkSettings> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CAudioGraphDriverList : igObjectList<CAudioGraphDriver> { }
    [ObjectAttr(nst: 80, align: 8)] public class CAudioGraphDriverModeEpicJump : CAudioGraphDriverModeStickBased { }
    [ObjectAttr(nst: 80, ctr: 72, align: 8)] public class CAudioGraphDriverModeInAir : CAudioGraphDriverModeStickBased { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CAudioGraphDriverModeList : igObjectList<CAudioGraphDriverMode> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CAudioGraphDriverModeSurfaceAccelStageList : igObjectList<CAudioGraphDriverModeSurfaceAccelStage> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CAudioGraphDriverModeSurfaceBoostStageList : igObjectList<CAudioGraphDriverModeSurfaceBoostStage> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CAudioGraphDriverModeSurfaceDriftStageList : igObjectList<CAudioGraphDriverModeSurfaceDriftStage> { }
    [ObjectAttr(nst: 40, align: 8)] public class CAudioGraphHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CAudioGraphList : igObjectList<CAudioGraph> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CAudioGraphModuleList : igObjectList<CAudioGraphModule> { }
    [ObjectAttr(nst: 40, align: 8)] public class CAudioGraphModuleOverrideList : igObjectList { }
    [ObjectAttr(nst: 16, align: 4)] public class CBaseInputTransformController : igObject { }
    [ObjectAttr(nst: 40, align: 8)] public class CBaseInputTransformControllerList : igObjectList<CBaseInputTransformController> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CBaseMovementControllerList : igObjectList<CBaseMovementController> { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class CBasePhysicsComponentData : CEntityComponentData { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CBaseUpgradeFilter : igObject { }
    [ObjectAttr(nst: 16, align: 4)] public class CBaseVehicleModeFilter : igObject { }
    [ObjectAttr(nst: 40, align: 8)] public class CBehaviorActivatorNodeHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CBehaviorActivatorNodeMap : igHashTable<string, CBehaviorActivatorNode> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CBehaviorEventFilterTable : igHashTable<int, CBehaviorEventFilterItemData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CBehaviorEventTimelineList : CCharacterEventTimelineList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CBehaviorGraphReflectionDataEntryList : igObjectList<CBehaviorGraphReflectionDataEntry> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CBehaviorLayerList : igObjectList<CBehaviorLayer> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CBehaviorLogicDataTable : igHashTable<string, CBehaviorLogic> { }
    [ObjectAttr(nst: 72, align: 8)] public class CBehaviorPhysicsCapsuleComponentData : CBehaviorPhysicsComponentData { }
    [ObjectAttr(nst: 72, ctr: 64, align: 8)] public class CBehaviorPhysicsComponentData : CPhysicsShapeComponentData { }
    [ObjectAttr(nst: 72, ctr: 64, align: 8)] public class CBehaviorPhysicsPencilComponentData : CBehaviorPhysicsComponentData { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CBehaviorState : CBehaviorActivatorNode { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CBehaviorStateList : igObjectList<CBehaviorState> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CBehaviorStateMachineList : igObjectList<CBehaviorStateMachine> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CBlackboardInfo : igObject { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8, refCountKeys: false)] public class CBlackboardInfoTable : igHashTable<igObject, CBlackboardInfo> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CBlackboardInfoUpdater : igObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CBlackboardInfoUpdaterList : igObjectList<CBlackboardInfoUpdater> { }
    [ObjectAttr(nst: 120, align: 8)] public class CBloomApplyMaterial : igFxMaterial { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CBoltPointHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CBoltPointList : igObjectList<CBoltPoint> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CBossPowerUpRubberbandDataList : igObjectList<CBossPowerUpRubberbandData> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CBoxLightComponentList : igObjectList<CBoxLightComponent> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CBuildDataList : igObjectList<CBuildData> { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CBuoyancyVehicleSettingList : CBaseVehicleSettingList { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CButtonAliasMapping : igHashTable<igEnumMetaField, igEnumMetaField> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CButtonListenerInstanceTable : igHashTable<igEnumMetaField, CButtonListenerInstance> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CButtonMap : igHashTable<igEnumMetaField, igEnumMetaField> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CButtonToAnalogStickDirectionTable : igHashTable<igEnumMetaField, CAnalogStickDirectionToVfxAnalogStickTable> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCameraBaseHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, align: 8)] public class CCameraBoxHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, align: 8)] public class CCameraList : igObjectList<CCamera> { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class CCarriedEntitiesComponentData : CEntityComponentData { }
    [ObjectAttr(nst: 80, ctr: 64, align: 8)] public class CCEBeginJumpInputWindow : CCombatNodeEvent { }
    [ObjectAttr(nst: 80, ctr: 64, align: 8)] public class CCEBeginRunTransitionWindow : CCombatNodeEvent { }
    [ObjectAttr(nst: 88, ctr: 72, align: 8)] public class CCEJumpDisabledWindow : CCombatNodeIntervalEvent { }
    [ObjectAttr(nst: 88, align: 8)] public class CCELockAnglesEvent : CCombatNodeIntervalEvent { }
    [ObjectAttr(ctr: 40, align: 8)] public class CChallengeGhostDataList : igObjectList<CChallengeGhostData> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CChallengeGroupInfoList : igObjectList<CChallengeGroupInfo> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CChallengeGroupOrderList : igObjectList<CAEKind> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CChangeRequestList : igObjectList<CChangeRequest> { }
    [ObjectAttr(nst: 64, align: 8)] public class CChangeSkin2ComponentItemHashTable : igHashTable<string, igObject> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CChannelGroupList : igObjectList<CChannelGroup> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCharacterAttributeList : igObjectList<CCharacterAttribute> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCharacterAttributeMultiplierList : igObjectList<CCharacterAttributeMultiplier> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CCharacterAttributeStringHashTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CCharacterClipMap : igHashTable<string, CCharacterClip> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCharacterEventTimelineList : igObjectList<CCharacterEventTimeline> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CCharacterInfoHashTable : igHashTable<u16, CCharacterInfo> { }
    [ObjectAttr(nst: 120, align: 8)] public class CCheckerboardResolveMaterial : igFxMaterial { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class CCheckpointEventDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class CCheckpointEventList : igEventLinkedList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCheckpointList : igObjectList<CCheckpoint> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCinematicBuildingProject : CCinematicBuildingTimelineGroupList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCinematicBuildingTimelineGroupList : igObjectList<CCinematicBuildingTimelineGroup> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCinematicBuildingTimelineTrackList : igObjectList<CCinematicBuildingTimelineTrack> { }
    [ObjectAttr(nst: 120, align: 8)] public class CCinematicTiledLightMaterial : igFxMaterial { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCollectibleFilterList : igObjectList<CCollectibleFilter> { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class CCollectibleTrackerEventDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class CCollectibleTrackerEventList : igEventLinkedList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCollectibleTrackerList : igObjectList<CCollectibleTracker> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCollectibleTrackerListList : igObjectList<CCollectibleTrackerList> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCollisionMaterialHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 120, align: 8)] public class CColorGeneratorMaterial : igFxMaterial { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCombatNodeEventList : igObjectList<CCombatNodeEvent> { }
    [ObjectAttr(nst: 88, ctr: 72, align: 8)] public class CCombatNodeExecuteIntervalEvent : CCombatNodeIntervalEvent { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCombatTargetDataList : igObjectList<CCombatTargetData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCombatTargetDataListList : igObjectList<CCombatTargetDataList> { }
    [ObjectAttr(nst: 120, align: 8)] public class CComposeSceneMaterial : igFxMaterial { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CControllerButtonCharacterMapList : igObjectList<CControllerButtonCharacterMap> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CControllerToButtonAnalogStickTable : igHashTable<string, CButtonToAnalogStickDirectionTable> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CControllerTypeToGuiInputSignalIconMaterialTable : igHashTable<igEnumMetaField, CGuiInputSignalToIconMaterialTable> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CControllerVfxTable : igHashTable<igEnumMetaField, igHandleMetaField> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CControllerVibrationDataPresetTable : igHashTable<igEnumMetaField, CControllerVibrationData> { }
    [ObjectAttr(nst: 40, align: 8)] public class CCrashBandicootBounceDataList : igObjectList<CCrashBandicootBounceData> { }
    [ObjectAttr(nst: 16, align: 4)] public class CCrashDebugInitializer : CSystemInitializer { }
    [ObjectAttr(nst: 16, align: 4)] public class CCrashDebugMenu : CUIDebugMenu { }
    [ObjectAttr(ctr: 16, align: 8)] public class CCrateCollectorComponentData : CEntityComponentData { }
    [ObjectAttr(ctr: 40, align: 8)] public class CCreditsLineList : igObjectList<CCreditsLine> { }
    [ObjectAttr(ctr: 16, align: 8)] public class CCrystalChallengeCollectibleComponentData : CEntityComponentData { }
    [ObjectAttr(ctr: 16, align: 8)] public class CCtrChallengeControllerComponentData : CEntityComponentData { }
    [ObjectAttr(nst: 120, align: 8)] public class CCubemapFilteringMaterial : igFxMaterial { }
    [ObjectAttr(ctr: 40, align: 8)] public class CCupPositionPointsData : igIntList { }
    [ObjectAttr(nst: 64, align: 8)] public class CCustomEventSpline : CCustomEvent { }
    [ObjectAttr(nst: 24, ctr: 24, align: 8)] public class CCutsceneAction : JuiceVisualAction { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCutsceneActorList : igObjectList<CCutsceneActor> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CCutsceneCameraHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CCutsceneDataList : igObjectList<CCutsceneData> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CCutsceneUnlockDoorFactionHashTable : igHashTable<igEnumMetaField, CCutsceneUnlockDoorFaction> { }
    [ObjectAttr(nst: 56, align: 8)] public class CDeactivateMessage : CEntityMessage { }
    [ObjectAttr(ctr: 40, align: 8)] public class CDebugDrivingArchetypeList : igObjectList<CDebugDrivingArchetype> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CDebugUpdateChannelList : igSmartHandleList { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class CDebugUpdateDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class CDebugUpdateEventList : igEventLinkedList { }
    [ObjectAttr(nst: 120, align: 8)] public class CDecalCostMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CDefocusHorizontalGaussianMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CDefocusLerpMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CDefocusMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CDefocusVerticalGaussianMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CDepthDownsampleMaterial : igFxMaterial { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CDesignerCutsceneInfo : igObject { }
    [ObjectAttr(nst: 40, align: 8)] public class CDestructibleStageList : igObjectList<CDestructibleStage> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CDifficultySpecificValue : igObject { }
    [ObjectAttr(nst: 80, ctr: 64, align: 8)] public class CDisableJumpHandler : CBehaviorLogic { }
    [ObjectAttr(nst: 56, ctr: 48, align: 8)] public class CDisableRequestManager : CChangeRequestManager { }
    [ObjectAttr(nst: 80, ctr: 64, align: 8)] public class CDisableTimeScalingHandler : CBehaviorLogic { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CDistantGeometryModelNameList : igStringRefList { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CDriftVehicleSettingList : CBaseVehicleSettingList { }
    [ObjectAttr(ctr: 64, align: 8)] public class CDriverCustomAmbienceSFXTable : igHashTable<string, igHandleMetaField> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CDriverCustomBackgroundEntityTable : igHashTable<string, igHandleMetaField> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CDriverDifficultyClassDataHashTable : igHashTable<igEnumMetaField, CRacerDifficultyClassData> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CDriverSkinDataHandleList : igSmartHandleList { }
    [ObjectAttr(ctr: 40, align: 8)] public class CDriverSkinDataList : igObjectList<CDriverSkinData> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CDrivingArchetypeDataHashmap : igHashTable<igEnumMetaField, CDrivingArchetypeData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CDspList : igObjectList<CDsp> { }
    [ObjectAttr(nst: 24, ctr: 24, align: 4)] public class CDurabilityVehicleSetting : CBaseVehicleSetting { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CDurabilityVehicleSettingList : CBaseVehicleSettingList { }
    [ObjectAttr(nst: 128, align: 8)] public class CDynamicClipEntityData : CGameEntityData { }
    [ObjectAttr(nst: 120, align: 8)] public class CEdgeDetectMaterial : igFxMaterial { }
    [ObjectAttr(nst: 56, ctr: 48, align: 8)] public class CEnableRequestManager : CChangeRequestManager { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class CEntityComponentData : igComponentData { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CEntityComponentDataList : igObjectList<CEntityComponentData> { }
    [ObjectAttr(nst: 40, align: 8)] public class CEntityComponentHandleList : igSmartHandleList { }
    [ObjectAttr(ctr: 64, align: 8)] public class CEntityFlagsColorTable : igHashTable<igEnumMetaField, igVec4ucMetaField> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CEntityHandleGuiMaterialHashTable : igHashTable<igHandleMetaField, igHandleMetaField> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CEntityHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CEntityList : igObjectList<CEntity> { }
    [ObjectAttr(nst: 24, ctr: 24, align: 8)] public class CEntityTag : igNamedObject { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CEntityTagSet : igHashTable<CEntityTag, bool> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CEntityTargetList : igObjectList<CEntityTarget> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CFadeInPresetList : igObjectList<CFadeInPresetData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CFadeOutPresetList : igObjectList<CFadeOutPresetData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CFadeSequencePresetList : igObjectList<CFadeSequencePresetData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CFallSpeedModifierList : igObjectList<CFallSpeedModifier> { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class CFilterAllies : CFilterMethod { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class CFilterByAIAwarenessRadius : CFilterMethod { }
    [ObjectAttr(nst: 24, align: 4)] public class CFilterByClosest : CFilterMethod { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class CFilterByHeroes : CFilterMethod { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class CFilterByLineOfSight : CFilterMethod { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CFilterMethodList : igObjectList<CFilterMethod> { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class CFilterOnScreen : CFilterMethod { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class CFilterOpponents : CFilterMethod { }
    [ObjectAttr(nst: 24, align: 4)] public class CFilterTargetable : CFilterMethod { }
    [ObjectAttr(nst: 24, align: 4)] public class CFilterVisible : CFilterMethod { }
    [ObjectAttr(nst: 432, ctr: 464, align: 16)] public class CFixedCamera : CConstrainedCamera { }
    [ObjectAttr(ctr: 64, align: 8)] public class CFlagsWaypointHandleListTable : igHashTable<igEnumMetaField, CWaypointHandleList> { }
    [ObjectAttr(nst: 120, align: 8)] public class CFurBlurMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CFxaaLowMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CFxaaMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CFxaaMediumMaterial : igFxMaterial { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CGameEntityDataList : igObjectList<CGameEntityData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CGameEntityHandleList : igSmartHandleList { }
    [ObjectAttr(ctr: 64, align: 8)] public class CGameModeTTRTable : igHashTable<igEnumMetaField, CDifficultySpecificTTRData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CGameSoundClassList : igObjectList<CGameSoundClass> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CGameSoundMusicEventBeatDataList : igObjectList<CGameSoundMusicEventBeatData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CGameSoundMusicEventPatternList : igObjectList<CGameSoundMusicEventPattern> { }
    [ObjectAttr(nst: 40, align: 8)] public class CGameVariableHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 120, align: 8)] public class CGBufferClearMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CGbufferVisualizationMaterial : igFxMaterial { }
    [ObjectAttr(ctr: 40, align: 8)] public class CGhostHeaderDataList : igObjectList<CChallengeGhostHeaderData> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CGrandPrixCustomizationsNPMultiplierList : igObjectList<CGrandPrixCustomizationsNPMultiplier> { }
    [ObjectAttr(nst: 64, align: 8)] public class CGraphicsSettingTable : igHashTable<igEnumMetaField, int> { }
    [ObjectAttr(ctr: 16, align: 4)] public class CGuiBehaviorCaptureFrameMarker : igGuiBehavior { }
    [ObjectAttr(ctr: 16, align: 4)] public class CGuiBehaviorCustomizationInfoBox : igGuiBehavior { }
    [ObjectAttr(nst: 144, align: 8)] public class CGuiBehaviorForceShowMouseCursor : CGuiBehavior { }
    [ObjectAttr(ctr: 16, align: 4)] public class CGuiBehaviorHighScoreList : igGuiBehavior { }
    [ObjectAttr(ctr: 144, align: 8)] public class CGuiBehaviorMenuBackground : CGuiBehavior { }
    [ObjectAttr(ctr: 256, align: 8)] public class CGuiBehaviorOctaneContinueGameButton : CGuiBehaviorContinueGameButton { }
    [ObjectAttr(ctr: 296, align: 8)] public class CGuiBehaviorOctaneDialogBox : CGuiBehaviorDialogBox { }
    [ObjectAttr(ctr: 16, align: 4)] public class CGuiBehaviorOctaneLevelSelectItemCategory : igGuiBehavior { }
    [ObjectAttr(ctr: 16, align: 4)] public class CGuiBehaviorOctaneProgressionAreaListCategory : igGuiBehavior { }
    [ObjectAttr(nst: 200, ctr: 200, align: 8)] public class CGuiBehaviorPauseMenuOptionResume : CGuiBehaviorPauseMenuOption { }
    [ObjectAttr(ctr: 16, align: 4)] public class CGuiBehaviorPitStopWumpaButton : igGuiBehavior { }
    [ObjectAttr(ctr: 448, align: 8)] public class CGuiBehaviorPlaylistMapSelector : CGuiBehaviorBaseSettingSelector { }
    [ObjectAttr(ctr: 16, align: 4)] public class CGuiBehaviorSetWumpaPlaceableEffectForTheme : igGuiBehavior { }
    [ObjectAttr(ctr: 16, align: 4)] public class CGuiBehaviorStartRaceButton : igGuiBehavior { }
    [ObjectAttr(nst: 216, ctr: 224, align: 8)] public class CGuiBehaviorSubtitleToggleOption : CGuiBehaviorBaseToggleOption { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CGuiButtonLegendTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CGuiColorStyleColorTable : igHashTable<igEnumMetaField, igVec4ucMetaField> { }
    [ObjectAttr(nst: 24, align: 8)] public class CGuiEventBossHealthBarShake : igGuiEvent { }
    [ObjectAttr(nst: 24, align: 8)] public class CGuiEventPlayerHudShake : igGuiEvent { }
    [ObjectAttr(nst: 64, align: 8)] public class CGuiGraphicsMenuSettingTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CGuiInputSignalToIconMaterialTable : igHashTable<igEnumMetaField, igHandleMetaField> { }
    [ObjectAttr(nst: 24, align: 4)] public class CGuiIntroFlowComponentData : CEntityComponentData { }
    [ObjectAttr(ctr: 64, align: 8)] public class CGuiItemTierColorTable : igHashTable<igEnumMetaField, CGuiItemTierColors> { }
    [ObjectAttr(nst: 64, align: 8)] public class CGuiKeyMappingTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CGuiListItemConverter : igGuiListItemConverter { }
    [ObjectAttr(ctr: 16, align: 4)] public class CGuiListItemConverterAdhocGameList : igGuiListItemConverter { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CGuiListItemConverterButtonLegend : igGuiListItemConverter { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CGuiListItemConverterFriendList : CGuiListItemConverter { }
    [ObjectAttr(nst: 16, align: 4)] public class CGuiListItemConverterGraphicsMenu : igGuiListItemConverter { }
    [ObjectAttr(nst: 16, align: 4)] public class CGuiListItemConverterInitialsCharacter : igGuiListItemConverter { }
    [ObjectAttr(nst: 16, align: 4)] public class CGuiListItemConverterKeyboardMenu : igGuiListItemConverter { }
    [ObjectAttr(nst: 16, align: 4)] public class CGuiListItemConverterPauseMenu : CGuiListItemConverter { }
    [ObjectAttr(ctr: 16, align: 4)] public class CGuiListItemPopulatorGrandPrixChallengeList : igGuiListItemPopulator { }
    [ObjectAttr(nst: 16, align: 4)] public class CGuiListItemPopulatorGraphicsMenu : igGuiListItemPopulator { }
    [ObjectAttr(nst: 16, align: 4)] public class CGuiListItemPopulatorInitialsCharacter : igGuiListItemPopulator { }
    [ObjectAttr(nst: 16, align: 4)] public class CGuiListItemPopulatorKeyboardMenu : igGuiListItemPopulator { }
    [ObjectAttr(ctr: 16, align: 4)] public class CGuiListItemPopulatorOctaneBattleModeSelect : igGuiListItemPopulator { }
    [ObjectAttr(ctr: 16, align: 4)] public class CGuiListItemPopulatorOctaneBundles : igGuiListItemPopulator { }
    [ObjectAttr(ctr: 16, align: 4)] public class CGuiListItemPopulatorOctaneMarketCategories : igGuiListItemPopulator { }
    [ObjectAttr(nst: 40, align: 8)] public class CGuiMaterialHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CGuiMenuSoundTable : igHashTable<igEnumMetaField, igHandleMetaField> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CGuiOctaneAreaLevelListList : igObjectList<CGuiOctaneAreaLevelList> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CGuiOctaneLevelSelectDataListList : igObjectList<CGuiOctaneLevelSelectDataList> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CGuiOctaneLoadingScreenHintList : igObjectList<CGuiOctaneLoadingScreenHint> { }
    [ObjectAttr(ctr: 32, align: 8)] public class CGuiOctanePitstopTabExtra : CGuiOctaneTabBarData { }
    [ObjectAttr(ctr: 32, align: 8)] public class CGuiOctanePitstopTabFill : CGuiOctaneTabBarData { }
    [ObjectAttr(ctr: 40, align: 8)] public class CGuiOctaneScrapbookImageList : igSmartHandleList { }
    [ObjectAttr(ctr: 40, align: 8)] public class CGuiOctaneTabBarDataList : igObjectList<CGuiOctaneTabBarData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CGuiSaveSlotOperationList : igObjectList<CGuiSaveSlotOperationBase> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CGuiSoundEventTable : igHashTable<igEnumMetaField, CEGuiMenuSoundList> { }
    [ObjectAttr(nst: 72, ctr: 72, align: 8)] public class CHavokAnimationCombiner : igAnimationSystem2 { }
    [ObjectAttr(nst: 32, align: 8)] public class CHavokBallAndSocketConstraintData : CHavokConstraintData { }
    [ObjectAttr(nst: 120, align: 8)] public class CHeroShadowsMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CHorizontalBilateralMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CHorizontalTileMaxVelocityMaterial : igFxMaterial { }
    [ObjectAttr(ctr: 64, align: 8)] public class CHubAdventureAreaDataHashTable : igHashTable<igEnumMetaField, CHubAdventureAreaData> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CHubCollectibleHashTable : igHashTable<igEnumMetaField, CHubCollectibleData> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CHUBHintHashTable : igHashTable<igEnumMetaField, CHUBHintData> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CHUBMinimapRegionDataTable : igHashTable<igEnumMetaField, CHUBMinimapRegionData> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CHubRequirementVfxHashTable : igHashTable<igEnumMetaField, igVfxEffect> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CHUBZoneList : igObjectList<CHUBZone> { }
    [ObjectAttr(ctr: 16, align: 8)] public class CHUBZoneSaveComponentData : CEntityComponentData { }
    [ObjectAttr(ctr: 40, align: 8)] public class ChunkOcclusionDataList : igObjectList<ChunkOcclusionData> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CHurtRubberbandDataTable : igHashTable<igEnumMetaField, CHurtRubberbandData> { }
    [ObjectAttr(nst: 40, align: 8)] public class CInteractionComponentDataList : igObjectList<CInteractionComponentData> { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8, meta: true)] public class CInteractionRestriction : Object { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class CInterruptManagerComponentData : CEntityComponentData { }
    [ObjectAttr(ctr: 24, align: 8)] public class CKartAIRaceControllerComponentData : CKartAIControllerComponentData { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartAirTimeBoostDataList : igObjectList<CKartAirTimeBoostData> { }
    [ObjectAttr(ctr: 16, align: 8)] public class CKartBoostComponentData : CEntityComponentData { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartCollisionMaterialBoostDataList : igObjectList<CKartCollisionMaterialBoostData> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartCollisionMaterialSlipperyDataList : igObjectList<CKartCollisionMaterialSlipperyData> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartControlSchemeDataList : igObjectList<CKartControlSchemeData> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartCustomizationColorSchemeHandleList : igSmartHandleList { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartCustomizationColorSchemeList : igObjectList<CKartCustomizationColorScheme> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartCustomizationDecalHandleList : igSmartHandleList { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartCustomizationDecalList : igObjectList<CKartCustomizationDecal> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartCustomizationGroupList : igObjectList<CKartCustomizationGroup> { }
    [ObjectAttr(ctr: 16, align: 4)] public class CKartCustomizationItemBaseData : igObject { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartCustomizationItemHandleList : igSmartHandleList { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartCustomizationItemList : igObjectList<CKartCustomizationItem> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartCustomizationPresetItemHandleList : igSmartHandleList { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartCustomizationPresetItemList : igObjectList<CKartCustomizationPresetItem> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartCustomizationPresetList : igObjectList<CKartCustomizationPreset> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartCustomizationStickerHandleList : igSmartHandleList { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartCustomizationStickerList : igObjectList<CKartCustomizationSticker> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CKartDetectGroundHandler : CBehaviorLogic { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartDriftBoostList : igObjectList<CKartDriftBoost> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CKartExhaustEffectsHashTable : igHashTable<igEnumMetaField, CKartVfxObject> { }
    [ObjectAttr(ctr: 16, align: 8)] public class CKartPowerStartComponentData : CEntityComponentData { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartSpawnedEffectBySpeedDataList : igObjectList<CKartSpawnedEffectBySpeedData> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CKartStickerFilterGroupNamesTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartVfxObjectList : igObjectList<CKartPersistentEffect> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CKartWheelTrailsHashTable : igHashTable<igHandleMetaField, CKartVfxObject> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CKartWheelVisualDataList : igObjectList<CKartWheelVisualData> { }
    [ObjectAttr(nst: 64, align: 8)] public class CLanguageAnimationTagTable : igHashTable<igEnumMetaField, igObject> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CLanguageStringHashTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CLensFlareList : igObjectList<CLensFlare> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CLevelAdditionalPackagesHastTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CLevelBorderWaypointList : igObjectList<CLevelBorderWaypoint> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CLevelBorderWaypointListList : igObjectList<CLevelBorderWaypointList> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CLevelChunkInfoHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CLevelGoalList : igObjectList<CLevelGoal> { }
    [ObjectAttr(nst: 120, align: 8)] public class CLinearConvertMaterial : igFxMaterial { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CLinearDriftVehicleSettingList : CDriftVehicleSettingList { }
    [ObjectAttr(nst: 120, align: 8)] public class CLinearizeDepthMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CLinearizeWaterDepthMaterial : igFxMaterial { }
    [ObjectAttr(nst: 32, align: 4)] public class CLinearVehicleXOffsetKeyframe : igSplineFloatKeyframe { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CLocalizedLineList : igObjectList<CLocalizedLine> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CLODModeRacerLODSettingsTable : igHashTable<igEnumMetaField, CRacerLODSettings> { }
    [ObjectAttr(nst: 120, align: 8)] public class CLutGeneratorMaterial : igFxMaterial { }
    [ObjectAttr(nst: 16, align: 4)] public class CManager : igObject { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CManeuverVehicleSettingList : CBaseVehicleSettingList { }
    [ObjectAttr(nst: 64, align: 8)] public class CMapToEnemyTable : igHashTable<string, igObject> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CMarketplaceCurrencyList : igObjectList<CMarketplaceCurrency> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CMarketplaceExchangeSkuDataList : igObjectList<CMarketplaceExchangeSkuData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CMarketplaceItemHandleList : igSmartHandleList { }
    [ObjectAttr(ctr: 40, align: 8)] public class CMarketplaceItemHandleListList : igObjectList<CMarketplaceItemHandleList> { }
    [ObjectAttr(nst: 40, align: 8)] public class CMarketplaceLootBoxDataList : igObjectList { }
    [ObjectAttr(nst: 40, align: 8)] public class CMarketplaceLootBoxRarityDataList : igObjectList { }
    [ObjectAttr(ctr: 40, align: 8)] public class CMarketplaceProductCurrencyList : igObjectList<CMarketplaceProductCurrency> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CMarketplaceProductItemList : igObjectList<CMarketplaceProductItem> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CMarketplaceProductList : igObjectList<CMarketplaceProduct> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CMarketplaceSkuHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CMarketplaceSkuList : igObjectList<CMarketplaceSku> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CMarketplaceSkuListList : igObjectList<CMarketplaceSkuHandleList> { }
    [ObjectAttr(nst: 40, align: 8)] public class CMarketplaceSkuPriceList : igObjectList { }
    [ObjectAttr(ctr: 64, align: 8)] public class CMarketplaceTierWeightTable : igHashTable<igEnumMetaField, float> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CMarketplaceTimeWeightList : igObjectList<CMarketplaceTimeWeight> { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class CMaterialOverrideCombinerComponentData : CEntityComponentData { }
    [ObjectAttr(nst: 40, align: 8)] public class CMinigameDataList : igObjectList<CMinigameData> { }
    [ObjectAttr(nst: 120, align: 8)] public class CMipMapDebugMaterial : igFxMaterial { }
    [ObjectAttr(nst: 64, align: 8)] public class CMobileGameStatBoostTable : igHashTable<igEnumMetaField, igObject> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CModelAnimationHashTable : igHashTable<string, CModelAnimation> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CModeRRingDataList : igObjectList<CModeRRingData> { }
    [ObjectAttr(nst: 40, align: 8)] public class CModList : igObjectList<CMod> { }
    [ObjectAttr(nst: 64, align: 8)] public class CModLocationStringHashTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(nst: 40, align: 8)] public class CModSoundDataList : igObjectList<CModSoundData> { }
    [ObjectAttr(nst: 40, align: 8)] public class CModVfxDataList : igObjectList<CModVfxData> { }
    [ObjectAttr(nst: 24, align: 4)] public class CMorphingCollisionComponentData : CEntityComponentData { }
    [ObjectAttr(nst: 120, align: 8)] public class CMotionBlurMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CMotionBlurStencilFillMaterial : igFxMaterial { }
    [ObjectAttr(nst: 56, align: 8)] public class CMotorcycleLandEntityMessage : CEntityMessage { }
    [ObjectAttr(nst: 56, align: 8)] public class CMotorcycleLeftGroundEntityMessage : CEntityMessage { }
    [ObjectAttr(nst: 56, align: 8)] public class CMountControllerLanded : CEntityMessage { }
    [ObjectAttr(nst: 56, align: 8)] public class CMountControllerLeftGround : CEntityMessage { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CMusicMixList : igObjectList<CMusicMix> { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class CMusicSyncComponentData : CEntityComponentData { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CNavMeshBuildDataList : igObjectList<CNavMeshBuildData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CNavPowerSettingsList : igObjectList<CNavPowerSettings> { }
    [ObjectAttr(nst: 120, align: 8)] public class CNeighborMaxVelocityMaterial : igFxMaterial { }
    [ObjectAttr(ctr: 40, align: 8)] public class CNetworkAutenticationLicenceList : igObjectList<CNetworkAuthenticationLicence> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CNetworkDisableDefaultReplicationTable : igHashTable<string, igEnumMetaField> { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class CNetworkDisablePreTeleportActorReplicationComponentData : CEntityComponentData { }
    [ObjectAttr(ctr: 40, align: 8)] public class CNitroBarTierList : igObjectList<CNitroBarTier> { }
    [ObjectAttr(nst: 40, align: 8)] public class CNovaCollisionInfoList : igObjectList<CNovaCollisionInfo> { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class CNullPhysicsComponentData : CBasePhysicsComponentData { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class CObjectiveEventDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class CObjectiveEventList : igEventLinkedList { }
    [ObjectAttr(ctr: 64, align: 8)] public class COctaneAudioDriverThematicHastTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(ctr: 40, align: 8)] public class COctaneBattleModeDataList : igObjectList<COctaneBattleModeData> { }
    [ObjectAttr(ctr: 32, align: 8)] public class COctaneBeatNefariousTimesUnlockable : COctaneUnlockable { }
    [ObjectAttr(ctr: 32, align: 8)] public class COctaneBeatOxideTimesUnlockable : COctaneUnlockable { }
    [ObjectAttr(ctr: 40, align: 8)] public class COctaneCheatInputDataList : igObjectList<COctaneCheatInputData> { }
    [ObjectAttr(ctr: 40, align: 8)] public class COctaneCupSelectDataListList : igObjectList<COctaneCupSelectDataList> { }
    [ObjectAttr(ctr: 64, align: 8)] public class COctaneCutsceneSubtitleDataTable : igHashTable<string, COctaneCutsceneSubtitleData> { }
    [ObjectAttr(ctr: 16, align: 4)] public class COctaneDebugInitializer : CSystemInitializer { }
    [ObjectAttr(ctr: 16, align: 4)] public class COctaneDebugMenu : CUIDebugMenu { }
    [ObjectAttr(ctr: 40, align: 8)] public class COctaneGameModeFilterList : igObjectList<COctaneGameModeFilter> { }
    [ObjectAttr(ctr: 64, align: 8)] public class COctaneGrandPrixVignetteStringTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(ctr: 1056, align: 8)] public class COctaneGuiSystemData : CGuiSystemData { }
    [ObjectAttr(ctr: 40, align: 8)] public class COctaneHelpHintsDataListList : igObjectList<COctaneHelpHintsDataList> { }
    [ObjectAttr(ctr: 64, align: 8)] public class COctaneLeaderboardPopulationTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(ctr: 16, align: 8)] public class COctaneLobbyTimerComponentData : CEntityComponentData { }
    [ObjectAttr(ctr: 40, align: 8)] public class COctanePlayerCountFilterList : igObjectList<COctanePlayerCountFilter> { }
    [ObjectAttr(ctr: 64, align: 8)] public class COctaneRaceModeNameTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(ctr: 64, align: 8)] public class COctaneRaceModesDifficultySpecificIntHashTable : igHashTable<igEnumMetaField, CDifficultySpecificInt> { }
    [ObjectAttr(ctr: 64, align: 8)] public class COctaneRaceModesDifficultySpecificRangedFloatHashTable : igHashTable<igEnumMetaField, CDifficultySpecificRangedFloat> { }
    [ObjectAttr(ctr: 32, align: 8)] public class COctaneSaveSystemData : CSaveSystemData { }
    [ObjectAttr(ctr: 40, align: 8)] public class COctaneSubtitleDataList : igObjectList<COctaneSubtitleData> { }
    [ObjectAttr(ctr: 64, align: 8)] public class COctaneSubtitleDataTable : igHashTable<string, COctaneSubtitleDataList> { }
    [ObjectAttr(ctr: 16, align: 4)] public class COctaneSystemData : igSingleton { }
    [ObjectAttr(ctr: 64, align: 8)] public class COctaneThemePackagesHashTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(ctr: 64, align: 8)] public class COctaneThemeSFXEffectHashTable : igHashTable<igEnumMetaField, igHandleMetaField> { }
    [ObjectAttr(ctr: 64, align: 8)] public class COctaneThemeVFXEffectHashTable : igHashTable<igEnumMetaField, igHandleMetaField> { }
    [ObjectAttr(ctr: 40, align: 8)] public class COctaneTimeTrialList : igObjectList<COctaneTimeTrialData> { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class COnChangeDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class COnChangeEventList : igEventLinkedList { }
    [ObjectAttr(nst: 56, align: 8)] public class COnCollectibleComponentCollectedDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, align: 8)] public class COnCollectibleComponentCollectedEventList : igEventLinkedList { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class COnCutsceneStageFinishedDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class COnCutsceneStageFinishedEventList : igEventLinkedList { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class COnCutsceneStagePreparedDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class COnCutsceneStagePreparedEventList : igEventLinkedList { }
    [ObjectAttr(nst: 32, align: 8)] public class COnFinishedEventList : igEventLinkedList { }
    [ObjectAttr(nst: 56, align: 8)] public class COnFormChangeDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, align: 8)] public class COnFormChangeEventList : igEventLinkedList { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class COnGameBoolVariableChangedDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class COnGameBoolVariableChangeEventList : igEventLinkedList { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class COnGameFloatVariableChangedDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class COnGameFloatVariableChangeEventList : igEventLinkedList { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class COnGameIntVariableChangedDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class COnGameIntVariableChangeEventList : igEventLinkedList { }
    [ObjectAttr(nst: 32, align: 8)] public class COnGameSoundInstancePlayEventList : igEventLinkedList { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class COnGameStringVariableChangedDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class COnGameStringVariableChangedEventList : igEventLinkedList { }
    [ObjectAttr(ctr: 40, align: 8)] public class COnlinePlaylistDataList : igObjectList<COnlinePlaylistData> { }
    [ObjectAttr(ctr: 40, align: 8)] public class COnlinePlaylistMapDataList : igObjectList<COnlinePlaylistMapData> { }
    [ObjectAttr(nst: 32, align: 8)] public class COnLockChangeEventList : igEventLinkedList { }
    [ObjectAttr(nst: 56, align: 8)] public class COnModeChangeDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, align: 8)] public class COnModeChangeEventList : igEventLinkedList { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class COnProcessInputDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class COnProcessInputEventList : igEventLinkedList { }
    [ObjectAttr(nst: 56, align: 8)] public class COnScreenspaceTargetManagerPostUpdateDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, align: 8)] public class COnScreenspaceTargetManagerPostUpdateEventList : igEventLinkedList { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class COnSoundInstanceStopEventList : igEventLinkedList { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class COnSplineCompleteEventList : igEventLinkedList { }
    [ObjectAttr(nst: 32, align: 8)] public class COnTeleportFinishedEventList : igEventLinkedList { }
    [ObjectAttr(nst: 56, align: 8)] public class COnVehiclePlayerChangeDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, align: 8)] public class COnVehiclePlayerChangeEventList : igEventLinkedList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class COptionalRenderPassEnabledDataHandleList : igSmartHandleList { }
    [ObjectAttr(ctr: 16, align: 8)] public class COutfitComponentData : CEntityComponentData { }
    [ObjectAttr(ctr: 40, align: 8)] public class COutfitMaterialFileList : igObjectList<COutfitMaterialFile> { }
    [ObjectAttr(ctr: 40, align: 8)] public class COutfitMaterialPackageList : igObjectList<COutfitMaterialPackage> { }
    [ObjectAttr(nst: 24, align: 4)] public class COverrideStickDirectionComponentData : CEntityComponentData { }
    [ObjectAttr(nst: 120, align: 8)] public class CPassthroughMaterial : igFxMaterial { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CPauseMenuOptionList : igObjectList<CPauseMenuOption> { }
    [ObjectAttr(nst: 72, ctr: 64, align: 8)] public class CPhysicsBoundingBoxComponentData : CPhysicsShapeComponentData { }
    [ObjectAttr(nst: 72, ctr: 64, align: 8)] public class CPhysicsBoundingSphereComponentData : CPhysicsShapeComponentData { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CPhysicsMotionPropertiesHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 72, ctr: 64, align: 8)] public class CPhysicsShapeComponentData : CPhysicsComponentData { }
    [ObjectAttr(nst: 72, ctr: 64, align: 8)] public class CPhysicsSystemComponentData : CPhysicsComponentData { }
    [ObjectAttr(nst: 72, ctr: 64, align: 8)] public class CPhysicsSystemEntityModelComponentData : CPhysicsSystemComponentData { }
    [ObjectAttr(nst: 120, align: 8)] public class CPixelCostDownsampleMaterial : igFxMaterial { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CPlatformAudioSettingsOverrideList : igObjectList<CPlatformAudioSettingsOverride> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CPlatformControllerTable : igHashTable<string, CControllerVfxTable> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CPlatformControllerToAnalogStickVfxTable : igHashTable<igEnumMetaField, CControllerToButtonAnalogStickTable> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CPlatformControllerVfxTable : igHashTable<igEnumMetaField, CPlatformControllerTable> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CPlatformRacerLODSettingsTable : igHashTable<igEnumMetaField, CLODModeRacerLODSettingsTable> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CPlayerAttackDataTable : igHashTable<igEnumMetaField, CPlayerAttackData> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CPlayerHandleBoolHashTable : igHashTable<igHandleMetaField, bool> { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class CPlayerHudComponentData : CEntityComponentData { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class CPlayerMagnetManagerComponentData : CEntityComponentData { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class CPlayerRespawnComponentData : CEntityComponentData { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class CPlayerRingComponentData : CEntityComponentData { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class CPlayerStartEntityData : CEntityData { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CPlayerStartEntityHandleList : igSmartHandleList { }
    [ObjectAttr(ctr: 64, align: 8)] public class CPlaylistModesWeightsTable : igHashTable<igEnumMetaField, int> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CPodiumAnimationDataList : igObjectList<CPodiumAnimationsData> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CPointLightComponentList : igObjectList<CPointLightComponent> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CPositionPortraitAnimationInfoList : igObjectList<CPositionPortraitAnimationInfo> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CPowerCrankUpDataList : igObjectList<CPowerCrankUpData> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CPowerUpCooldownHashTable : igHashTable<igEnumMetaField, float> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CPowerUpGameModesTable : igHashTable<igEnumMetaField, CPowerUpWeightRefList> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CPowerUpNamesTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CPowerUpTypeMaterialHandleHashTable : igHashTable<igEnumMetaField, igHandleMetaField> { }
    [ObjectAttr(ctr: 64, align: 8)] public class CPowerUpWeightHashTable : igHashTable<igEnumMetaField, float> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CPowerUpWeightRefList : igObjectList<CPowerUpWeightHashTable> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CProgressionChallengeList : igObjectList<CProgressionChallenge> { }
    [ObjectAttr(ctr: 16, align: 4)] public class CProgressionReward : igObject { }
    [ObjectAttr(ctr: 40, align: 8)] public class CProgressionRewardList : igObjectList<CProgressionReward> { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class CProxyComponentData : CEntityComponentData { }
    [ObjectAttr(nst: 40, align: 8)] public class CQuestConversationPresetDataList : igObjectList<CQuestConversationPresetData> { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class CQuestEventDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class CQuestEventList : igEventLinkedList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CQuestList : igObjectList<CQuest> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CQuestRequirement : igObject { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class CQuestStartEventList : igEventLinkedList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CQuestStepList : igObjectList<CQuestStep> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CQuestTrackList : igObjectList<CQuestTrack> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CQueuedGameSoundList : igObjectList<CQueuedGameSound> { }
    [ObjectAttr(ctr: 16, align: 8)] public class CRaceIntroHudComponentData : CEntityComponentData { }
    [ObjectAttr(ctr: 64, align: 8)] public class CRaceModeMaterialHandleTable : igHashTable<igEnumMetaField, igHandleMetaField> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CRacerCustomizationPresetList : igObjectList<CRacerCustomizationPreset> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CRacerDriverDataHandleList : igSmartHandleList { }
    [ObjectAttr(ctr: 40, align: 8)] public class CRacerDriverDataList : igObjectList<CRacerDriverData> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CRacerDroppedInfoList : igObjectList<CRacerDroppedInfo> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CRacerKartDataHandleList : igSmartHandleList { }
    [ObjectAttr(ctr: 40, align: 8)] public class CRacerKartDataList : igObjectList<CRacerKartData> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CRacerList : igObjectList<CRacer> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CRacerLODList : igObjectList<CRacerLOD> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CRacerPodiumDataList : igObjectList<CRacerPodiumData> { }
    [ObjectAttr(nst: 80, ctr: 64, align: 8)] public class CRailSlideHandler : CBehaviorLogic { }
    [ObjectAttr(nst: 24, align: 4)] public class CRailSlideTimeSettingComponentData : CEntityComponentData { }
    [ObjectAttr(nst: 120, align: 8)] public class CReflectionBlendMaterial : igFxMaterial { }
    [ObjectAttr(nst: 432, align: 16)] public class CRelativeCamera : CConstrainedCamera { }
    [ObjectAttr(ctr: 16, align: 8)] public class CRelicRaceControllerComponentData : CEntityComponentData { }
    [ObjectAttr(nst: 56, align: 8)] public class CRemoveMessage : CEntityMessage { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CRumbleDataList : igObjectList<CRumbleData> { }
    [ObjectAttr(nst: 120, align: 8)] public class CSceneCostMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CScreenDistortionMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CScreenSpaceShadowsMaterial : igFxMaterial { }
    [ObjectAttr(nst: 40, align: 8)] public class CScreenspaceTargetList : igObjectList<CScreenspaceTarget> { }
    [ObjectAttr(nst: 16, align: 4)] public class CScreenspaceTargetShape : igObject { }
    [ObjectAttr(nst: 1776, align: 8)] public class CScriptVehicleControllerComponentData : CBaseVehicleControllerComponentData { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CShape : igObject { }
    [ObjectAttr(ctr: 40, align: 8)] public class CShapeList : igObjectList<CShape> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CShowroomCharacterKeyFrameDataList : igObjectList<CShowroomCharacterKeyFrameData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CSkillsUpgradePathList : igObjectList<CSkillsUpgradePath> { }
    [ObjectAttr(nst: 40, align: 8)] public class CSkillUpgradeFilterList : igObjectList<CSkillUpgradeFilter> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CSkillUpgradeList : igObjectList<CSkillUpgrade> { }
    [ObjectAttr(nst: 120, align: 8)] public class CSkyboxMaterial : igFxMaterial { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CSkyboxModelsHashTable : igHashTable<igHandleMetaField, CSkyboxModels> { }
    [ObjectAttr(nst: 608, ctr: 592, align: 16)] public class CSkyGradientGeneratorRenderPass : CColorGeneratorRenderPass { }
    [ObjectAttr(nst: 128, ctr: 128, align: 16)] public class CSkyRenderPassData : igForwardLitRenderPassData { }
    [ObjectAttr(nst: 24, align: 4)] public class CSlipperySlopeMoverComponentData : CEntityComponentData { }
    [ObjectAttr(ctr: 64, align: 8)] public class CSmokeTestDataTable : igHashTable<string, CSmokeActionBaseList> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CSortEntities : igObject { }
    [ObjectAttr(nst: 24, ctr: 24, align: 8)] public class CSoundDotNetHandle : igDotNetHandle { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CSoundHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CSoundHandleListList : igObjectList<CSoundHandleList> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CSoundHandleOrNameList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CSoundInstanceHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CSoundList : igObjectList<CSound> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CSoundUpdateMethodList : igObjectList<CSoundUpdateMethod> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CSoundUpdateReferenceOverride : igObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CSoundUpdateTaskList : igObjectList<CSoundUpdateTask> { }
    [ObjectAttr(nst: 16, align: 4)] public class CSourceData : igObject { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class CSplineEventDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class CSplineEventDelegateEventList : igEventLinkedList { }
    [ObjectAttr(nst: 80, ctr: 64, align: 8)] public class CSplineHandler : CBehaviorLogic { }
    [ObjectAttr(nst: 128, ctr: 128, align: 16)] public class CSplineKeyframedRotationMover : CSplineRotationMover { }
    [ObjectAttr(nst: 40, align: 4)] public class CSplineLaneKeyframe : igSplineVec3fKeyframe { }
    [ObjectAttr(nst: 56, align: 8)] public class CSplineLaneMoverFinished : CEntityMessage { }
    [ObjectAttr(nst: 56, ctr: 48, align: 8)] public class CSplineRotationKeyframe : igSplineRotationKeyframe { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class CSplineSnapAttachBehavior : CSplineAttachBehavior { }
    [ObjectAttr(nst: 144, ctr: 128, align: 16)] public class CSplineTangentConvergeMover : CSplineTangentRotationMover { }
    [ObjectAttr(nst: 144, ctr: 128, align: 16)] public class CSplineTrackBankKeyframedRotationMover : CSplineTangentRotationMover { }
    [ObjectAttr(nst: 32, ctr: 24, align: 4)] public class CSplineVelocityKeyframe : igSplineFloatKeyframe { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CStackCameraControllerList : igObjectList<CStackCameraControllerBase> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CStaticCollisionHashInstanceIdHashTable : igHashTable<u64, i16> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CStaticComponentList : igObjectList<CStaticComponent> { }
    [ObjectAttr(nst: 24, align: 4)] public class CStaticMaterialOverrideCombinerComponentData : igComponentData { }
    [ObjectAttr(ctr: 64, align: 8)] public class CStringGuiColorStyleColorTable : igHashTable<string, CGuiColorStyleColorTable> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CStringPauseMenuConfigurationHashTable : igHashTable<string, CPauseMenuConfiguration> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CStrippedRacerLODList : CRacerLODList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CSubSoundList : igObjectList<CSubSound> { }
    [ObjectAttr(ctr: 16, align: 8)] public class CSuperFallZoneComponentData : CEntityComponentData { }
    [ObjectAttr(ctr: 40, align: 8)] public class CSurfaceMaterialAccumulationOverrideList : igObjectList<CSurfaceMaterialAccumulationOverride> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CSystemInitializer : igObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CSystemInitializerList : igObjectList<CSystemInitializer> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CTargetAquisitionRangeDataList : igObjectList<CTargetAquisitionRangeData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CTelegramList : igObjectList<CTelegram> { }
    [ObjectAttr(nst: 120, align: 8)] public class CTiledLightMaterial : igFxMaterial { }
    [ObjectAttr(ctr: 40, align: 8)] public class CTintSphereComponentList : igObjectList<CTintSphereComponent> { }
    [ObjectAttr(nst: 120, align: 8)] public class CToonMaterial : igFxMaterial { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CTopSpeedVehicleSettingList : CBaseVehicleSettingList { }
    [ObjectAttr(nst: 32, align: 4)] public class CTrackBankKeyframe : igSplineFloatKeyframe { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CTractionVehicleSettingList : CBaseVehicleSettingList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CTraversalPathList : igObjectList<CTraversalPath> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CUIDebugMenu : igObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CUIDebugMenuList : igObjectList<CUIDebugMenu> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CUnlockablePackageFirstPartyList : igObjectList<CUnlockablePackageFirstParty> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CUnlockablePackageList : igObjectList<CUnlockablePackage> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CUpgradeableFloatTable : igHashTable<CPrioritizedUpgrade, float> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CUpgradeableIntTable : igHashTable<CPrioritizedUpgrade, int> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CUpgradeableModelTable : igHashTable<CPrioritizedUpgrade, CModelPath> { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class CUpgradeableProjectileExplodeRadius : CUpgradeableFloat { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class CUpgradeableProjectileLifeTime : CUpgradeableFloat { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class CUpgradeableProjectileMaxRange : CUpgradeableFloat { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class CUpgradeableProjectileSpeed : CUpgradeableFloat { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CUpgradeableSoundTable : igHashTable<CPrioritizedUpgrade, CSoundDotNetHandle> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CUpgradeableValue : igObject { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CUpgradeableVfxTable : igHashTable<CPrioritizedUpgrade, CUpgradeableVfxData> { }
    [ObjectAttr(nst: 120, align: 8)] public class CUpsampleVfxMaterial : igFxMaterial { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class CutsceneActionDisableLights : CutsceneLightsAction { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class CutsceneActionEnableLights : CutsceneLightsAction { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CutsceneActionPlayCameraList : igObjectList<CutsceneActionPlayCamera> { }
    [ObjectAttr(nst: 24, align: 8)] public class CutsceneActionRemoveIBLCubemap : CCutsceneAction { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CVehicleAudioCollisionDataList : igObjectList<CVehicleAudioCollisionData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CVehicleCollisionDriftMassModList : igObjectList<CVehicleCollisionDriftMassMod> { }
    [ObjectAttr(nst: 80, align: 8)] public class CVehicleCollisionExtraResponseAirLevelBorder : CVehicleCollisionExtraResponseMaintainSpeed { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class CVehicleCollisionExtraResponseDamage : CVehicleCollisionExtraResponseBase { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CVehicleCollisionReactionDataList : igObjectList<CVehicleCollisionReactionData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CVehicleCollisionResponseCriteriaList : igObjectList<CVehicleCollisionResponseCriteria> { }
    [ObjectAttr(nst: 64, align: 8)] public class CVehicleCollisionResponseCriteriaTable : igHashTable<string, igObject> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CVehicleCollisionSpeedMassModList : igObjectList<CVehicleCollisionSpeedMassMod> { }
    [ObjectAttr(nst: 64, align: 8)] public class CVehicleCustomizationColorSchemeDataTable : igHashTable<string, igObject> { }
    [ObjectAttr(nst: 40, align: 8)] public class CVehicleModeFilterList : igObjectList<CVehicleModeFilter> { }
    [ObjectAttr(nst: 40, align: 8)] public class CVehicleModeVfxDataList : igObjectList<CVehicleModeVfxData> { }
    [ObjectAttr(nst: 40, align: 8)] public class CVehicleModeVfxDataListList : igObjectList<CVehicleModeVfxDataList> { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CVehiclePersonalizationBoostItemList : CVehiclePersonalizationBaseItemList { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CVehiclePersonalizationColorSchemeItemList : CVehiclePersonalizationBaseItemList { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CVehiclePersonalizationNeonItemList : CVehiclePersonalizationBaseItemList { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CVehiclePersonalizationSetItemList : CVehiclePersonalizationBaseItemList { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CVehiclePersonalizationTauntItemList : CVehiclePersonalizationBaseItemList { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CVehiclePersonalizationTopperItemList : CVehiclePersonalizationBaseItemList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CVehicleStatsList : igObjectList<CVehicleStats> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CVehicleStatStringHashTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(nst: 40, align: 8)] public class CVehicleUpgradeList : igObjectList<CVehicleUpgrade> { }
    [ObjectAttr(nst: 40, align: 8)] public class CVehicleVfxHandlerDataList : igObjectList<CVehicleVfxHandlerData> { }
    [ObjectAttr(nst: 120, align: 8)] public class CVerticalBilateralMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CVerticalTileMaxVelocityMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CVfxCostHalfResMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CVfxCostMaterial : igFxMaterial { }
    [ObjectAttr(nst: 440, ctr: 432, align: 8)] public class CVfxDrawPointForceOperator : CVfxDrawForceOperator { }
    [ObjectAttr(nst: 24, align: 8)] public class CVfxEffectDotNetHandle : igDotNetHandle { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CVfxPhysicsBoxShape : CVfxPhysicsShape { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CVfxPhysicsCapsuleShape : CVfxPhysicsShape { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CVfxPhysicsShape : igObject { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class CVfxPhysicsSphereShape : CVfxPhysicsShape { }
    [ObjectAttr(nst: 120, align: 8)] public class CViewerSelectedMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CViewerSelectedOutlineMaterial : igFxMaterial { }
    [ObjectAttr(nst: 120, align: 8)] public class CViewerSelectionIdMaterial : igFxMaterial { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class CVscComponentDataAccessor : igVscObjectAccessor { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class CVscComponentEntityAccessor : igVscObjectAccessor { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CVscComponentEntityMessageDelegator : igVscMessageDelegator { }
    [ObjectAttr(nst: 80, ctr: 80, align: 8)] public class CVscComponentSendEntityMessageNode : igVscSendMessageNode { }
    [ObjectAttr(nst: 120, align: 8)] public class CWaterRippleMaterial : igFxMaterial { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CWaterSimulationSettingsList : igObjectList<CWaterSimulationSettings> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CWaypointHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CWaypointList : igObjectList<CWaypoint> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CWeightedSoundList : igObjectList<CWeightedSound> { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class CWeightVehicleSettingList : CBaseVehicleSettingList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CWorldCollectibleModifierItemList : igObjectList<CWorldCollectibleModifierItem> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CWorldCollectibleModifierTable : igHashTable<igEnumMetaField, CWorldCollectibleModifier> { }
    [ObjectAttr(ctr: 16, align: 8)] public class CWorldEndRaceLapComponentData : CEntityComponentData { }
    [ObjectAttr(nst: 1280, ctr: 1328, align: 16)] public class CWorldVisualDataGroup : CVisualDataGroup { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class CXButtonStringTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CZoneInfoDynamicDifficultyDataList : igObjectList<CZoneInfoDynamicDifficultyData> { }
    [ObjectAttr(ctr: 40, align: 8)] public class CZoneInfoGrandPrixDataList : igObjectList<CZoneInfoGrandPrixData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CZoneInfoHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class CZoneInfoList : igObjectList<CZoneInfo> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class EFlagsWrapperList : igObjectList<EFlagsWrapper> { }
    [ObjectAttr(ctr: 40, align: 8)] public class EOctaneMarketplaceItemCategoryListList : igObjectList<EOctaneMarketplaceItemCategoryList> { }
    [ObjectAttr(ctr: 64, align: 8)] public class EOctaneMarketplaceItemCategoryNamesTable : igHashTable<igEnumMetaField, string?> { }
    [ObjectAttr(nst: 32, align: 8)] public class HavokPrismaticConstraint : HavokConstraint { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igAnimation2List : igObjectList<igAnimation2> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igAnimationBinding2List : igObjectList<igAnimationBinding2> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igAnimationTransitionList : igObjectList<igAnimationTransition> { }
    [ObjectAttr(nst: 40, align: 8)] public class igArchiveList : igObjectList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igAttrList : igObjectList<igAttr> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igBaseMetaList : igObjectList<igBaseMeta> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igCachedAttrListList : igObjectList<igCachedAttrList> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igCharMetricsList : igObjectList<igCharMetrics> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igCinematicAnimationInstanceList : igObjectList<igCinematicAnimationInstance> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igCinematicObject : igObject { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igComponentDataTable : igHashTable<string, igComponentData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igComponentList : igObjectList<igComponent> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8, refCountValues: false)] public class igConstNonRefCountedObjectNonRefCountedObjectHashTable : igHashTable<igObject, igObject> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igContainer : igObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igCustomMaterialAnimationList : igObjectList<igCustomMaterialAnimation> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igDataBindingList : igObjectList<igDataBinding> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igDataTransformList : igObjectList<igDataTransform> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igDebugPrimitiveList : igObjectList<igDebugPrimitive> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igDirectoryList : igObjectList<igDirectory> { }
    [ObjectAttr(nst: 64, align: 8)] public class igDotNetDataDataHashTable : igHashTable<DotNetDataMetaField, DotNetDataMetaField> { }
    [ObjectAttr(nst: 152, ctr: 152, align: 8)] public class igDynamicMetaObject : igMetaObject { }
    [ObjectAttr(nst: 40, align: 8)] public class igEffectAnnotationList : igObjectList<igEffectAnnotation> { }
    [ObjectAttr(nst: 40, align: 8)] public class igEffectAnnotationListList : igObjectList<igEffectAnnotationList> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igEntityHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igEntityList : igObjectList<igEntity> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8, refCountValues: false)] public class igEnumVscActionNodeHashTable : igHashTable<int, igObject> { }
    [ObjectAttr(nst: 40, align: 8)] public class igFileWorkItemList : igObjectList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igFloatListList : igObjectList<igFloatList> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igFxMaterialHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGfxShaderConstantList : igObjectList<igGfxShaderConstant> { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class igGraphicsGeometryShader : igGraphicsShader { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGraphicsMaterialAnimationList : igObjectList<igGraphicsMaterialAnimation> { }
    [ObjectAttr(nst: 24, ctr: 24, align: 8)] public class igGraphicsObject : igNamedObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGraphicsObjectList : igObjectList<igGraphicsObject> { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8)] public class igGraphicsPixelShader : igGraphicsShader { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGraphicsShaderList : igObjectList<igGraphicsShader> { }
    [ObjectAttr(nst: 48, align: 8)] public class igGuiActionPopProject : igGuiAction { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiActionTable : igObjectList<igGuiAction> { }
    [ObjectAttr(nst: 24, ctr: 24, align: 8)] public class igGuiActionTrack : igGuiTrack { }
    [ObjectAttr(nst: 24, ctr: 24, align: 8)] public class igGuiAnimationCategory : igNamedObject { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igGuiAnimationTable : igHashTable<igGuiAnimationTag, igGuiAnimation> { }
    [ObjectAttr(nst: 24, ctr: 24, align: 8)] public class igGuiAnimationTag : igNamedObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiAnimationTagList : igObjectList<igGuiAnimationTag> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiAssetList : igObjectList<igGuiAsset> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igGuiBehavior : igObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiBehaviorList : igObjectList<igGuiBehavior> { }
    [ObjectAttr(nst: 32, ctr: 32, align: 16)] public class igGuiControl : igGuiAsset { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class igGuiDelegateList : igEventLinkedList { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8, refCountKeys: false)] public class igGuiDelegateTable : igHashTable<igObject, igGuiDelegateList> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igGuiEventActionTable : igHashTable<igGuiEvent, igGuiActionTable> { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8, metaType: typeof(Delegate))] public class igGuiEventDelegate : MulticastDelegate { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class igGuiEventFocusInputReleased : igGuiEventInput { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class igGuiEventFocusInputRepeated : igGuiEventInput { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiEventList : igObjectList<igGuiEvent> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiEventPlaceableGainHover : igGuiEventHover { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiEventPlaceableLoseHover : igGuiEventHover { }
    [ObjectAttr(nst: 24, align: 8)] public class igGuiEventProjectGainFocus : igGuiEvent { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class igGuiEventProjectInputReleased : igGuiEventInput { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8)] public class igGuiEventProjectInputRepeated : igGuiEventInput { }
    [ObjectAttr(nst: 24, ctr: 24, align: 8)] public class igGuiEventProjectLoad : igGuiEvent { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8, refCountKeys: false)] public class igGuiEventTable : igHashTable<igObject, igGuiEventContainer> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiEventTouchCanceled : igGuiEventTouch { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiEventTouchPressed : igGuiEventTouch { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class igGuiFieldKeyframe : igGuiKeyframe { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class igGuiFloatTrack : igGuiFieldTrack { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igGuiInstanceMap : igConstNonRefCountedObjectNonRefCountedObjectHashTable { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiKeyframeList : igObjectList<igGuiKeyframe> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igGuiListItemConverter : igObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiListItemList : igObjectList<igGuiListItem> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igGuiListItemPopulator : igObject { }
    [ObjectAttr(nst: 32, ctr: 32, align: 16)] public class igGuiNullAsset : igGuiAsset { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiPlaceableHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiPlaceableList : igObjectList<igGuiPlaceable> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiPlaceableTable : igObjectList<igGuiPlaceable> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiProjectList : igObjectList<igGuiProject> { }
    [ObjectAttr(nst: 232, ctr: 232, align: 8)] public class igGuiSharedAssetProject : igGuiProject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igGuiTrackList : igObjectList<igGuiTrack> { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class igGuiVec2Track : igGuiFieldTrack { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class igGuiVec3Track : igGuiFieldTrack { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class igGuiVec4Track : igGuiFieldTrack { }
    [ObjectAttr(nst: 48, ctr: 48, align: 8)] public class igGuiVscEventDelegator : igVscMessageDelegator { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class igGuiVscPlaceableAccessor : igVscObjectAccessor { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igImageInputDataList : igObjectList<igImageInputData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igInfoList : igObjectList<igInfo> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igIntFloatHashTable : igHashTable<int, float> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igIntIntHashTable : igHashTable<int, int> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igIntListList : igObjectList<igIntList> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igKerningPairHashTable : igHashTable<igKerningPairMetaField, float> { }
    [ObjectAttr(nst: 48, ctr: 40, align: 8)] public class igListenerRelativeAbsoluteVelocityFrameReference : igListenerRelativeVelocityFrameReference { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igLocalizedHashTableList : igObjectList<igLocalizedHashTable> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igLocalizedInfo : igInfo { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igLocalizedListList : igObjectList<igLocalizedList> { }
    [ObjectAttr(nst: 24, ctr: 24, align: 8)] public class igLocalizedNamedObject : igNamedObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igLocalizedStringDataList : igObjectList<igLocalizedStringData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igLocalizedStringList : igObjectList<igLocalizedString> { }
    [ObjectAttr(nst: 24, ctr: 24, align: 8)] public class igMaterial : igNamedObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igMemoryCommandStreamList : igObjectList<igMemoryCommandStream> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igMetaFieldList : igObjectList<igMetaFieldInstance> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igMetaObjectPrimitiveInfoHashTable : igMetaObjectVfxRuntimeObjectInfoHashTable { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igMetaObjectVfxRuntimeObjectInfoHashTable : igHashTable<igMetaObject, igVfxRuntimeObjectInfo> { }
    [ObjectAttr(nst: 32, ctr: 40, align: 8)] public class igMutex : igBaseMutex { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igNetSyncOnJipAttribute : igObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igNetTaskList : igObjectList<igNetTask> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igNodeList : igObjectList<igNode> { }
    [ObjectAttr(nst: 40, align: 8)] public class igNonRefCountedGuiAnimationTagList : igNonRefCountedObjectList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igNonRefCountedGuiPlaceableList : igNonRefCountedObjectList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igNonRefCountedMetaImageList : igNonRefCountedObjectList { }
    [ObjectAttr(nst: 64, align: 8, refCountKeys: false)] public class igNonRefCountedMetaObjectSpawnGroupPassDataHashTable : igHashTable<igObject, igObject> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igNonRefCountedNodeList : igNonRefCountedObjectList { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igObjectIntHashTable : igHashTable<igObject, int> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igObjectLoader : igObject { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igPeachesBaseCallback : igObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igPitchOverrideList : igObjectList<igPitchOverride> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igPlatformRenderPassMap : igHashTable<igEnumMetaField, igRenderPass> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igPlatformRenderTargetMap : igHashTable<igEnumMetaField, igRenderTarget> { }
    [ObjectAttr(nst: 24, ctr: 24, align: 8)] public class igReferenceResolver : igNamedObject { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igReferenceResolverSet : igStringObjectHashTable { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igRenderCameraList : igObjectList<igRenderCamera> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igRenderPassList : igObjectList<igRenderPass> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igRenderTargetCustomDataList : igObjectList<igRenderTargetCustomData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igRenderTargetInputDataList : igObjectList<igRenderTargetInputData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igRenderTargetList : igObjectList<igRenderTarget> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igRenderTargetMemPolicy : igObject { }
    [ObjectAttr(ctr: 16, align: 4)] public class igSceneRenderPassEnableIfUsedData : igSceneRenderPassEnableData { }
    [ObjectAttr(nst: 24, ctr: 24, align: 8)] public class igShaderConstantBundle : igGraphicsObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igShaderConstantBundleList : igObjectList<igShaderConstantBundle> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igShaderConstantDataList : igObjectList<igShaderConstantData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igShortListList : igObjectList<igShortList> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igSingleton : igObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igSkeleton2List : igObjectList<igSkeleton2> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igSkeletonBoneList : igObjectList<igSkeletonBone> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igSmartHandleList : igHandleList { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igSortKeyCommandInterpreter : igObject { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igSoundUpdateMethod : igObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igSoundUpdateMethodList : igObjectList<igSoundUpdateMethod> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igSplineControlPoint2List : igObjectList<igSplineControlPoint2> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igSplineEventList : igObjectList<igSplineEvent> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igSplineFloatKeyframeList : igObjectList<igSplineFloatKeyframe> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8, refCountKeys: false)] public class igSplineFloatKeyframeTrackTable : igHashTable<igObject, igSplineFloatKeyframeTrack> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igSplinePointList : igObjectList<igSplinePoint> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igSplineRotationKeyframeList : igObjectList<igSplineRotationKeyframe> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8, refCountKeys: false)] public class igSplineRotationKeyframeTrackTable : igHashTable<igObject, igSplineRotationKeyframeTrack> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igSplineVec3fKeyframeList : igObjectList<igSplineVec3fKeyframe> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8, refCountKeys: false)] public class igSplineVec3fKeyframeTrackTable : igHashTable<igObject, igSplineVec3fKeyframeTrack> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igSpriteDrawCallModifier : igObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igStreamingChunkList : igObjectList<igObject> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igStreamList : igObjectList<igStream> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igStringFloatHashTable : igHashTable<string, float> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igStringInsensitiveStringHashTable : igHashTable<string, string?> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igStringIntHashTable : igHashTable<string, int> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igStringObjectHashTable : igHashTable<string, igObject> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igStringRefListList : igObjectList<igStringRefList> { }
    [ObjectAttr(ctr: 64, align: 8)] public class igStringSpawnGroupPassDataHashTable : igHashTable<string, igVfxSpawnGroupPassInfo> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igStringStringHashTable : igHashTable<string, string?> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igStringUnsignedIntHashTable : igHashTable<string, u32> { }
    [ObjectAttr(nst: 40, align: 8)] public class igTechniqueList : igObjectList<igTechnique> { }
    [ObjectAttr(nst: 40, align: 8)] public class igTechniqueParameterList : igObjectList<igTechniqueParameter> { }
    [ObjectAttr(nst: 40, align: 8)] public class igTechniqueSamplerList : igObjectList<igTechniqueSampler> { }
    [ObjectAttr(nst: 40, align: 8)] public class igTechniqueVertexComponentList : igObjectList<igTechniqueVertexComponent> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igTextureSamplerSourceList : igObjectList<igTextureSamplerSource> { }
    [ObjectAttr(nst: 40, align: 8)] public class igThreadList : igObjectList<igThread> { }
    [ObjectAttr(nst: 24, ctr: 24, align: 8)] public class igTransformSource2 : igNamedObject { }
    [ObjectAttr(nst: 24, ctr: 24, align: 8)] public class igTransformSource2Keyframed : igTransformSource2 { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igTransformSource2List : igObjectList<igTransformSource2> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igUnsignedIntIntHashTable : igHashTable<u32, int> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igUnsignedIntStringHashTable : igHashTable<u32, string?> { }
    [ObjectAttr(nst: 64, ctr: 64, align: 8)] public class igUnsignedIntUnsignedIntHashTable : igHashTable<u32, u32> { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8, meta: true)] public class igUpdateable : Object { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igUpdateableList : igObjectList<igUpdateable> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igVertexBlender : igObject { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igVertexBlenderCustom_P32N32 : igVertexBlender { }
    [ObjectAttr(nst: 16, ctr: 16, align: 8)] public class igVertexBlenderDefault : igVertexBlender { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igVertexDataList : igObjectList<igVertexData> { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class igVfxAccelerateBaseOperator : igVfxFrameOperator { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class igVfxCameraFadeOperator : igVfxCameraBaseOperator { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class igVfxCameraFadeShrinkOperator : igVfxCameraBaseOperator { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class igVfxCameraShrinkOperator : igVfxCameraBaseOperator { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class igVfxCommitOperator : igVfxOperator { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igVfxEffectHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class igVfxLoadOperator : igVfxFrameOperator { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class igVfxMotionLoadOperator : igVfxLoadOperator { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igVfxNonRefCountedPrimitiveInfoList : igNonRefCountedObjectList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igVfxNonRefCountedSpawnedEffectList : igNonRefCountedObjectList { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class igVfxOrientationInvertOperator : igVfxFrameOperator { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class igVfxOrientationLoadOperator : igVfxLoadOperator { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class igVfxPoseLoadOperator : igVfxLoadOperator { }
    [ObjectAttr(nst: 104, ctr: 88, align: 8)] public class igVfxPosePlacedPrimitiveRotateFixedRotationsOperator : igVfxPosePlacedPrimitiveRotateOperatorBase { }
    [ObjectAttr(nst: 32, align: 4)] public class igVfxPositionLoadOperator : igVfxLoadOperator { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igVfxPrimitiveDataList : igObjectList<igVfxPrimitiveData> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igVfxPrimitiveList : igNonRefCountedObjectList { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class igVfxRotateRandomOperator : igVfxFrameOperator { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igVfxRuntimeObject : igObject { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class igVfxSizeScaleOperator : igVfxFrameOperator { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igVfxSpawnedEffectHandleList : igSmartHandleList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igVfxSpawnedEffectList : igObjectList<igVfxSpawnedEffect> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igVfxStackOperatorList : igObjectList<igVfxOperator> { }
    [ObjectAttr(nst: 32, ctr: 24, align: 8)] public class igVfxVelocityLoadBaseOperator : igVfxLoadOperator { }
    [ObjectAttr(nst: 24, ctr: 24, align: 4)] public class igVisualAttribute : igAttr { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igVolume : igObject { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igVolumeApplicator : igObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igVscAccessorList : igObjectList<igVscAccessor> { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igVscActionNode : igVscPlaceable { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igVscActionNodeList : igObjectList<igVscActionNode> { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class igVscBoolAccessor : igVscAccessor { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class igVscColorAccessor : igVscAccessor { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igVscDelegatorList : igObjectList<igVscDelegator> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igVscEntryPointNodeList : igObjectList<igVscEntryPointNode> { }
    [ObjectAttr(nst: 104, align: 8)] public class igVscEnum : igMetaEnum { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class igVscEnumAccessor : igVscAccessor { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class igVscFloatAccessor : igVscAccessor { }
    [ObjectAttr(nst: 176, ctr: 176, align: 8)] public class igVscHiddenSequenceNode : igVscSequenceNode { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class igVscIntAccessor : igVscAccessor { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class igVscMethodList : igObjectList<igVscMethod> { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class igVscObjectAccessor : igVscAccessor { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igVscPlaceable : igVscSelectable { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igVscPrivateGraphEventAttribute : igObject { }
    [ObjectAttr(nst: 16, ctr: 16, align: 4)] public class igVscSelectable : igObject { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class igVscStringAccessor : igVscAccessor { }
    [ObjectAttr(nst: 24, ctr: 16, align: 8)] public class igVscThisObjectAccessor : igVscObjectAccessor { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class igVscVec2fAccessor : igVscAccessor { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class igVscVec3fAccessor : igVscAccessor { }
    [ObjectAttr(nst: 24, ctr: 16, align: 4)] public class igVscVec4fAccessor : igVscAccessor { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class JuiceAnimationList : igObjectList<JuiceAnimation> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class JuiceFieldValueList : igObjectList<JuiceFieldValue> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class JuiceFloatKeyframeList : igObjectList<JuiceFloatKeyframe> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class JuiceTrack : igObjectList { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class JuiceTrackList : igObjectList<JuiceTrack> { }
    [ObjectAttr(nst: 24, ctr: 24, align: 8)] public class JuiceVisualAction : JuiceAction { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class JuiceVisualList : igObjectList<JuiceVisual> { }
    [ObjectAttr(nst: 56, ctr: 56, align: 8, metaType: typeof(Delegate))] public class MulticastDelegate : Delegate { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_AddComponentsUtilityComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_AddRemovableComponentComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_AnimateEntityComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_BoltEntityComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_BoltOnComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_CancelAttackComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_CelebrateAbilityUpgradeComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_DamageAuraComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_DamageDampeningComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_DebuffChillComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_GenerateRipplesComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_HazardTriggerVolumeComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_MakeUniqueComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_MaterialOverrideComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_ModComponentManagerComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_ScreenDistortComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_SfxEventsComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_SpawnCollectiblesComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_UpgradeRequiredComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_VortexComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class NovaScript_CDotNetEntityComponentData_1_Scripts_WanderAIComponent_ : CDotNetEntityComponentData_1 { }
    [ObjectAttr(nst: 32, ctr: 32, align: 8, meta: true)] public class Object : igDynamicObject { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class OcclusionBoxList : igObjectList<COcclusionBox> { }
    [ObjectAttr(nst: 40, align: 8, metaType: typeof(CDotNetEntityComponentData_1))] public class Scripts_CancelAttackComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_CancelAttackComponent_ { }
    [ObjectAttr(nst: 80, align: 8, metaType: typeof(CBehaviorLogic))] public class Scripts_CDisableRunHandler : CBehaviorLogic { }
    [ObjectAttr(nst: 80, align: 8, metaType: typeof(CBehaviorLogic))] public class Scripts_CDisableWalkHandler : CBehaviorLogic { }
    [ObjectAttr(nst: 56, align: 8, metaType: typeof(List_1))] public class Scripts_MaterialRedirectTableList : List_1 { }
    [ObjectAttr(nst: 32, align: 8, metaType: typeof(CDotNetCombatNodeEvent))] public class Scripts_SnapModelEvent : CDotNetCombatNodeEvent { }
    [ObjectAttr(nst: 32, align: 8, metaType: typeof(Object))] public class Scripts_SpawnCollectiblesComponentData_CollectibleSelectionMethod : Object { }
    [ObjectAttr(nst: 40, align: 8)] public class SpeedVfxSpecList : igObjectList<SpeedVfxSpec> { }
    [ObjectAttr(ctr: 64, align: 8)] public class StringUShortHashTable : igHashTable<string, u16> { }
    [ObjectAttr(nst: 40, ctr: 40, align: 8)] public class SurfaceVfxSpecList : igObjectList<SurfaceVfxSpec> { }
    [ObjectAttr(nst: 56, align: 8, metaType: typeof(List_1))] public class System_Collections_Generic_List_1_Scripts_BoltOnData_ : List_1 { }
    [ObjectAttr(nst: 40, align: 8)] public class VfxIntensityLayersList : igObjectList { }
}