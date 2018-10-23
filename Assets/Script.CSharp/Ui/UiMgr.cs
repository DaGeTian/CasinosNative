// Copyright (c) Cragon. All rights reserved.

namespace Casinos
{
    using System.Collections.Generic;
    using UnityEngine;
    using FairyGUI;

    public class UiMgr
    {
        //---------------------------------------------------------------------
        List<UiBase> ListUi { get; set; }
        Dictionary<string, UiFactory> MapUiFactory { get; set; }

        //---------------------------------------------------------------------
        public UiMgr()
        {
            ListUi = new List<UiBase>();
            MapUiFactory = new Dictionary<string, UiFactory>();

            GRoot.inst.SetContentScaleFactor(1136, 640, UIContentScaler.ScreenMatchMode.MatchWidthOrHeight);

            UIPackage.AddPackage("Ui/Main");
        }

        //---------------------------------------------------------------------
        public void Update(float tm)
        {
            foreach (var i in ListUi)
            {
                i.Update(tm);
            }
        }

        //---------------------------------------------------------------------
        public void Destroy()
        {
            foreach (var i in ListUi)
            {
                i.OnDestroy();
            }
            ListUi.Clear();
        }

        //---------------------------------------------------------------------
        public void RegUiFactory(UiFactory factory)
        {
            MapUiFactory[factory.GetName()] = factory;
        }

        //---------------------------------------------------------------------
        public void CreateUi(string name)
        {
            UiFactory factory = null;
            MapUiFactory.TryGetValue(name, out factory);
            if (factory == null)
            {
                return;
            }

            UiBase ui = factory.CreateUi();
            ui.Name = factory.GetName();
            ui.ComUi = UIPackage.CreateObject(ui.Name, ui.Name).asCom;
            GRoot.inst.AddChild(ui.ComUi);

            ListUi.Add(ui);

            ui.OnCreate();
        }

        //---------------------------------------------------------------------
        public void DestoryUi(UiBase ui)
        {
            foreach (var i in ListUi)
            {
                if (i == ui)
                {
                    i.OnDestroy();
                    ListUi.Remove(i);

                    Object.Destroy(i.ComUi.displayObject.gameObject);

                    return;
                }
            }
        }

        //---------------------------------------------------------------------
        public UiBase GetUi(string name)
        {
            foreach (var i in ListUi)
            {
                if (i.Name == name)
                {
                    return i;
                }
            }
            return null;
        }
    }
}