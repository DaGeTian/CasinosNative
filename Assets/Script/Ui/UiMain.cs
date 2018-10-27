// Copyright (c) Cragon. All rights reserved.

namespace Casinos
{
    using System;
    using UnityEngine;
    using FairyGUI;
    using XLua;

    public class UiMain : UiBase
    {
        //---------------------------------------------------------------------
        GButton BtnClose { get; set; }
        GButton BtnBugly { get; set; }
        GButton BtnLuaLog { get; set; }
        GRichTextField TxtInfo { get; set; }
        GList ListLog { get; set; }
        float TxtInfoTm { get; set; }
        int Count { get; set; }

        //---------------------------------------------------------------------
        public override void OnCreate()
        {
            BtnClose = ComUi.GetChild("BtnClose").asButton;
            BtnClose.onClick.Add(_onClickBtnClose);

            BtnBugly = ComUi.GetChild("BtnBugly").asButton;
            BtnBugly.onClick.Add(_onClickBtnBugly);

            BtnLuaLog = ComUi.GetChild("BtnLuaLog").asButton;
            BtnLuaLog.onClick.Add(_onClickBtnLuaLog);

            TxtInfo = ComUi.GetChild("TxtInfo").asRichTextField;

            ListLog = ComUi.GetChild("ListLog").asList;
            ListLog.RemoveChildren();
        }

        //---------------------------------------------------------------------
        public override void OnDestroy()
        {
        }

        //---------------------------------------------------------------------
        public override void Update(float tm)
        {
            if (!string.IsNullOrEmpty(TxtInfo.text))
            {
                TxtInfoTm += tm;
                if (TxtInfoTm > 2f)
                {
                    TxtInfoTm = 0f;
                    TxtInfo.text = "";
                }
            }
        }

        //---------------------------------------------------------------------
        public void AddLog(string log)
        {
            GComponent com = UIPackage.CreateObject("Main", "ListItemLog").asCom;
            var txt_log = com.GetChild("TxtLog").asTextField;
            txt_log.text = log;

            ListLog.AddChildAt(com, 0);
        }

        //---------------------------------------------------------------------
        void _onClickBtnClose()
        {
            TxtInfo.text = "OnClick BtnClose 1";

            Application.Quit();
        }

        //---------------------------------------------------------------------
        void _onClickBtnBugly()
        {
            TxtInfo.text = "OnClick BtnBugly";

            Debug.LogError("OnClick BtnBugly LogError");
            //Debug.LogException(new Exception("LogException"));
            //throw new ArgumentNullException();
        }

        //---------------------------------------------------------------------
        void _onClickBtnLuaLog()
        {
            var lua_mgr = CasinosContext.Instance.LuaMgr;
            var lua_launch = lua_mgr.LuaEnv.Global.Get<LuaTable>("Launch");
            var func = lua_launch.Get<DelegateLua5>("Log");

            Count++;
            func(lua_launch, "UiMain._onClickBtnLuaLog() Count=" + Count);
        }
    }

    public class UiFactoryMain : UiFactory
    {
        //---------------------------------------------------------------------
        public override string GetName()
        {
            return "Main";
        }

        //---------------------------------------------------------------------
        public override UiBase CreateUi()
        {
            var ui = new UiMain();
            return ui;
        }
    }
}