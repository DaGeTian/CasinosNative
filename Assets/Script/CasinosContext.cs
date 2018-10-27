// Copyright (c) Cragon. All rights reserved.

namespace Casinos
{
    public class CasinosContext
    {
        //---------------------------------------------------------------------
        public static CasinosContext Instance { get; private set; }
        public UiMgr UiMgr { get; private set; }
        public LuaMgr LuaMgr { get; private set; }

        //---------------------------------------------------------------------
        public CasinosContext()
        {
            Instance = this;

            UiMgr = new UiMgr();
            UiMgr.RegUiFactory(new UiFactoryMain());
            UiMgr.CreateUi("Main");

            LuaMgr = new LuaMgr();
        }

        //---------------------------------------------------------------------
        public void Update(float tm)
        {
            UiMgr.Update(tm);
            LuaMgr.Update(tm);
        }

        //---------------------------------------------------------------------
        public void Destroy()
        {
            UiMgr.Destroy();
            LuaMgr.Destroy();
        }

        //---------------------------------------------------------------------
        public void OnApplicationPause(bool pause)
        {
        }

        //---------------------------------------------------------------------
        public void OnApplicationFocus(bool focusStatus)
        {
        }

        //---------------------------------------------------------------------
        public void AddLog(string log)
        {
            UiMgr.GetUiMain().AddLog(log);
        }
    }
}