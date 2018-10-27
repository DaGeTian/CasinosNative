// Copyright (c) Cragon. All rights reserved.

namespace Casinos
{
    using UnityEngine;

    public class MbNative : MonoBehaviour
    {
        //---------------------------------------------------------------------
        public string BuglyAppIDAndroid = "208266275a";
        public string BuglyAppIDiOS = "5a6993e9b7";

        //---------------------------------------------------------------------
        void Awake()
        {
#if DEBUG
            BuglyAgent.ConfigDebugMode(true);
#else
            BuglyAgent.ConfigDebugMode(false);
#endif

            // Config default channel, version, user 
            BuglyAgent.ConfigDefault(null, null, null, 0);
            // Config auto report log level, default is LogSeverity.LogError, so the LogError, LogException log will auto report
            BuglyAgent.ConfigAutoReportLogLevel(LogSeverity.LogError);
            // Config auto quit the application make sure only the first one c# exception log will be report, please don't set TRUE if you do not known what are you doing.
            BuglyAgent.ConfigAutoQuitApplication(false);
            // If you need register Application.RegisterLogCallback(LogCallback), you can replace it with this method to make sure your function is ok.
            //BuglyAgent.RegisterLogCallback(null);

#if UNITY_IPHONE || UNITY_IOS
            BuglyAgent.InitWithAppId(BuglyAppIDiOS);
#elif UNITY_ANDROID
            BuglyAgent.InitWithAppId(BuglyAppIDAndroid);
#endif

            // TODO Required. If you do not need call 'InitWithAppId(string)' to initialize the sdk(may be you has initialized the sdk it associated Android or iOS project),
            // please call this method to enable c# exception handler only.
            BuglyAgent.EnableExceptionHandler();

            // TODO NOT Required. If you need to report extra data with exception, you can set the extra handler
            // BuglyAgent.SetLogCallbackExtrasHandler (MyLogCallbackExtrasHandler);
            //BuglyAgent.PrintLog(LogSeverity.LogInfo, "Init the bugly sdk");
        }

        //---------------------------------------------------------------------
        void Start()
        {
            CasinosContext.Instance.AddLog("OpenInstall.RegisterWakeupHandler(_onWakeupFinish)");

            var openinstall = GetComponent<io.openinstall.unity.OpenInstall>();
            openinstall.RegisterWakeupHandler(_onWakeupFinish);
        }

        //---------------------------------------------------------------------
        void Update()
        {
        }

        //---------------------------------------------------------------------
        void OnDestroy()
        {
        }

        //---------------------------------------------------------------------
        void _onWakeupFinish(io.openinstall.unity.OpenInstallData wakeup_data)
        {
            var log = string.Format("MbNative._onWakeupFinish() 渠道编号={0}，自定义数据={1}",
                wakeup_data.channelCode, wakeup_data.bindData);
            CasinosContext.Instance.AddLog(log);
        }
    }
}