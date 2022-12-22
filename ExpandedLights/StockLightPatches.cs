using HarmonyLib;
using UnityEngine;

namespace ExpandedLights
{
    public class StockLightsPatch
    {
        public static string ModName = "ExpandedLights_Stock";

        [HarmonyPatch(typeof(CeilingLightConfig), "CreateBuildingDef")]
        public static class CeilingLightConfig_CreateBuildingDef_Patch
        {
            public static void Postfix(BuildingDef __result)
            {
                __result.SelfHeatKilowattsWhenActive = 0.1f;
            }
        }

        [HarmonyPatch(typeof(CeilingLightConfig), "DoPostConfigurePreview")]
        public static class CeilingLightConfig_DoPostConfigurePreview_Patch
        {
            public static void Postfix(GameObject go)
            {
                if (go.TryGetComponent(out LightShapePreview preview))
                    preview.shape = ExpandedLightsPatch.FixedSemi.KleiLightShape;
            }
        }

        [HarmonyPatch(typeof(CeilingLightConfig), "DoPostConfigureComplete")]
        public static class CeilingLightConfig_DoPostConfigureComplete_Patch
        {
            public static void Postfix(GameObject go)
            {
                if (go.TryGetComponent(out Light2D light))
                    light.shape = ExpandedLightsPatch.FixedSemi.KleiLightShape;
            }
        }

        [HarmonyPatch(typeof(FloorLampConfig), "CreateBuildingDef")]
        public static class FloorLampConfig_CreateBuildingDef_Patch
        {
            public static void Postfix(BuildingDef __result)
            {
                __result.EnergyConsumptionWhenActive = 4f;
                __result.SelfHeatKilowattsWhenActive = 0.1f;
            }
        }

        [HarmonyPatch(typeof(FloorLampConfig), "DoPostConfigurePreview")]
        public static class FloorLampConfig_DoPostConfigurePreview_Patch
        {
            public static void Postfix(GameObject go)
            {
                if (go.TryGetComponent(out LightShapePreview preview))
                    preview.shape = ExpandedLightsPatch.SmoothCircle.KleiLightShape;
            }
        }

        [HarmonyPatch(typeof(FloorLampConfig), "DoPostConfigureComplete")]
        public static class FloorLampConfig_DoPostConfigureComplete_Patch
        {
            public static void Postfix(GameObject go)
            {
                if (go.TryGetComponent(out Light2D light))
                    light.shape = ExpandedLightsPatch.SmoothCircle.KleiLightShape;
            }
        }
    }
}
