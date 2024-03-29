﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace FTK_MultiMax_Rework {
    public static class DummiesHandler {

        public static void CreateDummies() {
            Debug.Log("MAKING DUMMIES");
            List<GameObject> dummies = new List<GameObject>();
            for (int j = 0; j < Mathf.Max(3, GameFlowMC.gMaxPlayers); j++) {
                if (j < 3) {
                    dummies.Add(FTKHub.Instance.m_Dummies[j]);
                    continue;
                }
                GameObject copy2 = UnityEngine.Object.Instantiate(FTKHub.Instance.m_Dummies[2], FTKHub.Instance.m_Dummies[2].transform.parent);
                copy2.name = "Player " + (j + 1) + " Dummy";
                copy2.GetComponent<PhotonView>().viewID = 3245 + j;
                dummies.Add(copy2);
            }
            for (int i = 0; i < Mathf.Max(3, GameFlowMC.gMaxEnemies); i++) {
                if (i < 3) {
                    dummies.Add(FTKHub.Instance.m_Dummies[i + 3]);
                    continue;
                }
                GameObject copy = UnityEngine.Object.Instantiate(FTKHub.Instance.m_Dummies[5], FTKHub.Instance.m_Dummies[5].transform.parent);
                copy.name = "Enemy " + (i + 1) + " Dummy";
                copy.GetComponent<PhotonView>().viewID = 3045 + i;
                dummies.Add(copy);
            }
            FTKHub.Instance.m_Dummies = dummies.ToArray();
            GameObject[] dummies2 = FTKHub.Instance.m_Dummies;
            Debug.Log("MultiMax - Done");
        }

        public static GameObject CreateDummy(GameObject[] source, int index, string prefix) {
            GameObject dummy;
            if (index < 3) {
                dummy = source[index];
            } else {
                dummy = UnityEngine.Object.Instantiate(source[2], source[2].transform.parent);
                dummy.name = $"{prefix} {index + 1} Dummy";
                dummy.GetComponent<PhotonView>().viewID = 3245 + index;
            }
            return dummy;
        }
    }
}
