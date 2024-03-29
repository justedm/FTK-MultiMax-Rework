﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace FTK_MultiMax_Rework {
    public class uiGoldMenuPatches {
        public static bool GoldAwake(uiGoldMenu __instance) {
            var m_GoldEntriesField = Traverse.Create(__instance).Field("m_GoldEntries");

            __instance.m_InputFocus = __instance.gameObject.GetComponent<FTKInputFocus>();
            __instance.m_InputFocus.m_InputMode = FTKInput.InputMode.InGameUI;
            __instance.m_InputFocus.m_Cancel = __instance.OnButtonCancel;

            if (m_GoldEntriesField.GetValue() != null) {
                int maxEntries = (GameFlowMC.gMaxPlayers - 2);

                m_GoldEntriesField.GetValue<List<uiGoldMenuEntry>>().Add(__instance.m_FirstEntry);

                for (int i = 0; i < maxEntries; i++) {
                    uiGoldMenuEntry newEntry = UnityEngine.Object.Instantiate(__instance.m_FirstEntry);
                    newEntry.transform.SetParent(__instance.m_FirstEntry.transform.parent, worldPositionStays: false);
                    m_GoldEntriesField.GetValue<List<uiGoldMenuEntry>>().Add(newEntry);
                }
            }

            return false;
        }
    }
}
