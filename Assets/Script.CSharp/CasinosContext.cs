// Copyright (c) Cragon. All rights reserved.

namespace Casinos
{
    public class CasinosContext
    {
        //---------------------------------------------------------------------
        public static CasinosContext Instance { get; private set; }
        public UiMgr UiMgr { get; private set; }

        //---------------------------------------------------------------------
        public CasinosContext()
        {
            Instance = this;

            UiMgr = new UiMgr();
            UiMgr.RegUiFactory(new UiFactoryMain());
            UiMgr.CreateUi("Main");
        }

        //---------------------------------------------------------------------
        public void Update(float tm)
        {
            UiMgr.Update(tm);
        }

        //---------------------------------------------------------------------
        public void Destroy()
        {
            UiMgr.Destroy();
        }

        //-------------------------------------------------------------------------
        public void OnApplicationPause(bool pause)
        {
        }

        //-------------------------------------------------------------------------
        public void OnApplicationFocus(bool focusStatus)
        {
        }
    }
}