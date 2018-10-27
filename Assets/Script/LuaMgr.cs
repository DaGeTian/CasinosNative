// Copyright (c) Cragon. All rights reserved.

namespace Casinos
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using XLua;

    [CSharpCallLua]
    public delegate void DelegateLua1(LuaTable lua_table);

    [CSharpCallLua]
    public delegate void DelegateLua2(LuaTable lua_table, float tm);

    [CSharpCallLua]
    public delegate void DelegateLua3(LuaTable lua_table, bool b);

    [CSharpCallLua]
    public delegate void DelegateLua4(LuaTable lua_table, List<AssetBundle> list_ab);

    [CSharpCallLua]
    public delegate void DelegateLua5(LuaTable lua_table, string s);

    public static class LuaCustomSettings
    {
        //---------------------------------------------------------------------
        [LuaCallCSharp]
        public static List<Type> CustomType = new List<Type>()
        {
            // Unity3D
            typeof(UnityEngine.ApplicationInstallMode),
            typeof(UnityEngine.ApplicationSandboxType),
            typeof(UnityEngine.CameraType),
            typeof(UnityEngine.CameraClearFlags),
            typeof(UnityEngine.NetworkReachability),
            typeof(UnityEngine.RuntimePlatform),
            typeof(UnityEngine.SystemLanguage),
            typeof(UnityEngine.ThreadPriority),
            typeof(UnityEngine.Application),
            typeof(UnityEngine.AssetBundle),
            typeof(UnityEngine.AudioClip),
            typeof(UnityEngine.AudioSource),
            typeof(UnityEngine.Camera),
            typeof(UnityEngine.Color),
            typeof(UnityEngine.Color32),
            typeof(UnityEngine.Coroutine),
            typeof(UnityEngine.Font),
            typeof(UnityEngine.GameObject),
            typeof(UnityEngine.Hash128),
            typeof(UnityEngine.Material),
            typeof(UnityEngine.Mathf),
            typeof(UnityEngine.Matrix4x4),
            typeof(UnityEngine.Mesh),
            typeof(UnityEngine.ParticleSystem),
            typeof(UnityEngine.Ping),
            typeof(UnityEngine.PlayerPrefs),
            typeof(UnityEngine.Quaternion),
            typeof(UnityEngine.Random),
            typeof(UnityEngine.Rect),
            typeof(UnityEngine.Renderer),
            typeof(UnityEngine.Resources),
            typeof(UnityEngine.Screen),
            typeof(UnityEngine.ScreenCapture),
            typeof(UnityEngine.SystemInfo),
            typeof(UnityEngine.Texture3D),
            typeof(UnityEngine.Time),
            typeof(UnityEngine.Networking.UnityWebRequest),
            typeof(UnityEngine.Vector3),
            typeof(UnityEngine.Vector2),
            typeof(UnityEngine.Vector4),
            typeof(UnityEngine.WWW),
            typeof(UnityEngine.WWWForm),
            //typeof(UnityEngine.Texture),
            //typeof(UnityEngine.Texture2D),
            //typeof(UnityEngine.MovieTexture),
            //typeof(UnityEngine.AudioSettings),
            //typeof(UnityEngine.Input),
            
            // System            
            typeof(Action),
            typeof(Action<int, string>),
            typeof(Action<string, WWW>),
            typeof(BitConverter),
            typeof(Array),
            typeof(Hashtable),
            typeof(List<string>),
            typeof(List<AssetBundle>),
            typeof(System.Text.RegularExpressions.Regex),
            typeof(System.Text.RegularExpressions.Match),
            typeof(System.Text.RegularExpressions.MatchCollection),
            typeof(System.IO.Directory),
            typeof(System.IO.File),
            typeof(System.IO.FileStream),
            typeof(System.IO.MemoryStream),
            typeof(System.IO.Path),
            
            // FairyGUI
            typeof(FairyGUI.EaseType),
            typeof(FairyGUI.RelationType),
            typeof(FairyGUI.TweenPropType),
            typeof(FairyGUI.Container),
            typeof(FairyGUI.Controller),
            typeof(FairyGUI.DisplayObject),
            typeof(FairyGUI.EventCallback0),
            typeof(FairyGUI.EventCallback1),
            typeof(FairyGUI.EventContext),
            typeof(FairyGUI.EventDispatcher),
            typeof(FairyGUI.EventListener),
            typeof(FairyGUI.InputEvent),
            typeof(FairyGUI.GObject),
            typeof(FairyGUI.GGraph),
            typeof(FairyGUI.GGroup),
            typeof(FairyGUI.GImage),
            typeof(FairyGUI.GLoader),
            typeof(FairyGUI.GMovieClip),
            typeof(FairyGUI.GTextField),
            typeof(FairyGUI.GRichTextField),
            typeof(FairyGUI.GTextInput),
            typeof(FairyGUI.GComponent),
            typeof(FairyGUI.GList),
            typeof(FairyGUI.GRoot),
            typeof(FairyGUI.GLabel),
            typeof(FairyGUI.GButton),
            typeof(FairyGUI.GComboBox),
            typeof(FairyGUI.GObjectPool),
            typeof(FairyGUI.GProgressBar),
            typeof(FairyGUI.GSlider),
            typeof(FairyGUI.GTween),
            typeof(FairyGUI.GTweener),
            typeof(FairyGUI.GTweenCallback),
            typeof(FairyGUI.GTweenCallback1),
            typeof(FairyGUI.ListItemRenderer),
            typeof(FairyGUI.Stage),
            typeof(FairyGUI.PlayCompleteCallback),
            typeof(FairyGUI.PopupMenu),
            typeof(FairyGUI.Relations),
            typeof(FairyGUI.ScrollPane),
            typeof(FairyGUI.TextFormat),
            typeof(FairyGUI.TimerCallback),
            typeof(FairyGUI.Transition),
            typeof(FairyGUI.TransitionHook),
            typeof(FairyGUI.TweenValue),
            typeof(FairyGUI.UIPackage),
            typeof(FairyGUI.Window),

            // Casinos
            //typeof(_eProjectItemDisplayNameKey),
            //typeof(_eAsyncAssetLoadType),
            //typeof(_ePayType),
            //typeof(AsyncAssetLoaderMgr),
            //typeof(AsyncAssetLoadGroup),
            //typeof(Card),
            //typeof(ChatParser),
            //typeof(EbTool),
            //typeof(EbTimeEvent),
            //typeof(EbTimer),
            //typeof(EbDoubleLinkNode<EbTimeEvent>),
            //typeof(EbDoubleLinkList<EbTimeEvent>),
            //typeof(EbTimeWheel),
            //typeof(LoaderTicket),
            typeof(MbHelper),
            typeof(UiMain),
            typeof(UiMgr),
            //typeof(NativeFun),
            //typeof(OpenInstall),
            //typeof(OpenInstallReceiver),
            //typeof(Push),
            //typeof(PushReceiver),
            //typeof(QRCodeMaker),
            //typeof(ShareSDKReceiver),
            //typeof(TcpClient),
            //typeof(ThirdPartyLogin),
            //typeof(TimerShaft),
            //typeof(UiHelper),
            //typeof(UpdateRemoteToPersistentData),
            //typeof(UiSoundMgr),
            //typeof(DevInfoSet),
            //typeof(MobLink),
            //typeof(MobLinkScene),
            //typeof(MobLinkReceiver),
            //typeof(UniWebView),
            //typeof(UniWebViewMessage),

            // SDKs
            //typeof(ZXing.BarcodeFormat),
            typeof(BuglyAgent),
            //typeof(OnePF.Purchase),
            //typeof(cn.sharesdk.unity3d.ShareContent),
            //typeof(cn.sharesdk.unity3d.ShareSDK),
            //typeof(ZXing.BarcodeWriter),
            //typeof(ZXing.QrCode.QrCodeEncodingOptions),
        };

        //---------------------------------------------------------------------
        [CSharpCallLua]
        public static List<Type> CustomType2 = new List<Type>()
        {
            typeof(Action),
            typeof(Action<string>),
            typeof(Action<string[]>),
            typeof(Action<byte[]>),
            typeof(Action<LuaTable>),
            typeof(Action<LuaTable, string>),
            typeof(Action<LuaTable, string, float>),
            typeof(Action<float>),
            typeof(Action<int, string>),
            typeof(Action<string, Action>),
            typeof(Action<string, Action, Action>),
            typeof(Action<string, WWW>),
            typeof(Action<string, string>),
            typeof(Action<string, int>),
            typeof(Action<string, float>),
            typeof(Action<string, bool>),
            typeof(Action<string, string, string>),
            typeof(Action<int, int>),
            typeof(Action<int>),
            typeof(Action<long>),
            typeof(Action<bool>),
            typeof(Action<float, string, Dictionary<byte, string>>),
            typeof(Action<float, long>),
            typeof(Action<Dictionary<string, long>>),
            typeof(Action<string, long>),
            typeof(Action<Dictionary<byte, long>>),
            typeof(Action<Dictionary<byte, long>, Dictionary<byte, long>>),
            typeof(Action<Dictionary<string,Dictionary<string, string>>>),
            typeof(Action<ushort, byte[]>),
            typeof(List<string>),
            typeof(List<AssetBundle>),
            typeof(EventHandler),

            // FairyGUI
            typeof(FairyGUI.EventCallback0),
            typeof(FairyGUI.EventCallback1),
            typeof(FairyGUI.EventContext),
            typeof(FairyGUI.EventListener),
            typeof(FairyGUI.GTweenCallback),
            typeof(FairyGUI.GTweenCallback1),
            typeof(FairyGUI.ListItemRenderer),

            // SDKs
            //typeof(cn.sharesdk.unity3d.ShareSDK.EventHandler),
            //typeof(MobLink.GetMobIdHandler),
            //typeof(MobLink.RestoreSceneHandler),
            //typeof(UniWebView.PageStartedDelegate),
            //typeof(UniWebView.PageFinishedDelegate),
            //typeof(UniWebView.PageErrorReceivedDelegate),
            //typeof(UniWebView.MessageReceivedDelegate),
            //typeof(UniWebView.ShouldCloseDelegate),
            //typeof(UniWebView.KeyCodeReceivedDelegate),
            //typeof(UniWebView.OreintationChangedDelegate),
            //typeof(UniWebView.OnWebContentProcessTerminatedDelegate),
        };
    }

    [LuaCallCSharp]
    public class LuaMgr
    {
        //---------------------------------------------------------------------
        public LuaEnv LuaEnv { get; private set; }
        Dictionary<string, byte[]> MapLuaFiles { get; set; }
        DelegateLua1 FuncLaunchClose { get; set; }
        DelegateLua3 FuncLaunchOnApplicationPause { get; set; }
        DelegateLua3 FuncLaunchOnApplicationFocus { get; set; }
        CasinosContext Context { get; set; }

        //---------------------------------------------------------------------
        public LuaMgr()
        {
            Context = CasinosContext.Instance;
            MapLuaFiles = new Dictionary<string, byte[]>();
            LuaEnv = new LuaEnv();
            LuaEnv.AddLoader(_luaLoaderCustom);

            LoadLuaFromResources("Lua/Launch");
            DoString("Launch");

            var lua_launch = LuaEnv.Global.Get<LuaTable>("Launch");
            FuncLaunchClose = lua_launch.Get<DelegateLua1>("Close");
            FuncLaunchOnApplicationPause = lua_launch.Get<DelegateLua3>("OnApplicationPause");
            FuncLaunchOnApplicationFocus = lua_launch.Get<DelegateLua3>("OnApplicationFocus");
            var func_setup = lua_launch.Get<DelegateLua1>("Setup");
            func_setup(lua_launch);
        }

        //---------------------------------------------------------------------
        public void Update(float tm)
        {
            LuaEnv.Tick();
        }

        //---------------------------------------------------------------------
        public void Destroy()
        {
            var lua_launch = LuaEnv.Global.Get<LuaTable>("Launch");
            if (FuncLaunchClose != null) FuncLaunchClose.Invoke(lua_launch);
            FuncLaunchClose = null;
            FuncLaunchOnApplicationPause = null;
            FuncLaunchOnApplicationFocus = null;

            if (LuaEnv != null)
            {
                LuaEnv.Dispose();
                LuaEnv = null;
            }
        }

        //---------------------------------------------------------------------
        public void DoString(string luafile_name)
        {
            string do_string = string.Format("require '{0}'", luafile_name);
            LuaEnv.DoString(do_string);
        }

        //---------------------------------------------------------------------
        public void LoadLuaFromResources(string filepath)
        {
            string name = filepath;
            if (name.EndsWith(".lua"))
            {
                name = name.Remove(name.Length - 4, 4);
            }
            name = name.Replace('\\', '/');

            var txt = Resources.Load<TextAsset>(name);

            int index = name.LastIndexOf('/');
            string name1 = name.Substring(index + 1, name.Length - index - 1);
            string name2 = name1.ToLower();
            MapLuaFiles[name2] = txt.bytes;
        }

        //---------------------------------------------------------------------
        // 自定义Lua文件加载函数
        byte[] _luaLoaderCustom(ref string file_name)
        {
            var key = file_name.ToLower();

            byte[] array_file = null;
            MapLuaFiles.TryGetValue(key, out array_file);
            if (array_file != null)
            {
                return array_file;
            }

            return null;
        }
    }
}