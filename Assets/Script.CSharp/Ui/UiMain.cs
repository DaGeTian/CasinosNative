// Copyright (c) Cragon. All rights reserved.

namespace Casinos
{
    using System;
    using UnityEngine;
    using FairyGUI;

    public class UiMain : UiBase
    {
        //---------------------------------------------------------------------
        GButton BtnClose { get; set; }
        GButton BtnBugly { get; set; }
        GRichTextField TxtInfo { get; set; }
        float TxtInfoTm { get; set; }

        //---------------------------------------------------------------------
        public override void OnCreate()
        {
            BtnClose = ComUi.GetChild("BtnClose").asButton;
            BtnClose.onClick.Add(_onClickBtnClose);

            BtnBugly = ComUi.GetChild("BtnBugly").asButton;
            BtnBugly.onClick.Add(_onClickBtnBugly);

            TxtInfo = ComUi.GetChild("TxtInfo").asRichTextField;
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