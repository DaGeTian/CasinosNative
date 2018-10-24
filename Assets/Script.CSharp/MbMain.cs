// Copyright (c) Cragon. All rights reserved.

namespace Casinos
{
    using System;
    using UnityEngine;

    public class MbMain : MonoBehaviour
    {
        //---------------------------------------------------------------------
        CasinosContext CasinosContext { get; set; }

        //---------------------------------------------------------------------
        void Awake()
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;

            CasinosContext = new CasinosContext();
        }

        //---------------------------------------------------------------------
        void Update()
        {
            CasinosContext.Update(Time.deltaTime);

#if UNITY_ANDROID
            // ���û������ֻ��ķ��ؼ��˳���Ϸ
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
#endif
        }

        //---------------------------------------------------------------------
        void OnDestroy()
        {
            CasinosContext.Destroy();
        }

        //-------------------------------------------------------------------------
        void OnApplicationPause(bool pause)
        {
            CasinosContext.OnApplicationPause(pause);
        }

        //-------------------------------------------------------------------------
        void OnApplicationFocus(bool focusStatus)
        {
            CasinosContext.OnApplicationFocus(focusStatus);
        }
    }
}