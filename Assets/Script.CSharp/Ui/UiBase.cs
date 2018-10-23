// Copyright (c) Cragon. All rights reserved.

namespace Casinos
{
    using FairyGUI;

    public abstract class UiBase
    {
        //---------------------------------------------------------------------
        public string Name { get; set; }
        public GComponent ComUi { get; set; }

        //---------------------------------------------------------------------
        public abstract void OnCreate();

        //---------------------------------------------------------------------
        public abstract void OnDestroy();

        //---------------------------------------------------------------------
        public abstract void Update(float tm);
    }

    public abstract class UiFactory
    {
        //---------------------------------------------------------------------
        public abstract string GetName();

        //---------------------------------------------------------------------
        public abstract UiBase CreateUi();
    }
}