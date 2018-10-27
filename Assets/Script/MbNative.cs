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
            Debug.Log("RegisterWakeupHandler, GetInstall");

            var openinstall = GetComponent<io.openinstall.unity.OpenInstall>();
            openinstall.RegisterWakeupHandler(_onWakeupFinish);
            openinstall.GetInstall(60, _onGetInstallFinish);

            //openinstall.ReportRegister();
            //openinstall.ReportEffectPoint("aaa", 1);
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
        void _onGetInstallFinish(io.openinstall.unity.OpenInstallData data)
        {
            Debug.Log("_onGetInstallFinish");

            string channel_code = " ";
            if (!string.IsNullOrEmpty(data.channelCode))
            {
                channel_code = data.channelCode;
            }

            string bind_data = " ";
            if (!string.IsNullOrEmpty(data.bindData))
            {
                bind_data = data.bindData;
            }

            var log = string.Format("MbNative._onGetInstallFinish() 渠道编号={0}，自定义数据={1}",
                channel_code, bind_data);
            CasinosContext.Instance.AddLog(log);
        }

        //---------------------------------------------------------------------
        void _onWakeupFinish(io.openinstall.unity.OpenInstallData data)
        {
            Debug.Log("_onWakeupFinish");

            string channel_code = " ";
            if (!string.IsNullOrEmpty(data.channelCode))
            {
                channel_code = data.channelCode;
            }

            string bind_data = " ";
            if (!string.IsNullOrEmpty(data.bindData))
            {
                bind_data = data.bindData;
            }

            var log = string.Format("MbNative._onWakeupFinish() 渠道编号={0}，自定义数据={1}",
                channel_code, bind_data);
            CasinosContext.Instance.AddLog(log);
        }
    }
}