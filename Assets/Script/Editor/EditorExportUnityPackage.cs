// Copyright(c) Cragon. All rights reserved.

namespace Casinos
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using UnityEditor;
    using UnityEngine;

    public static class EditorExportUnityPackage
    {
        [MenuItem("Casinos/导出CasinosNative.unitypackage")]
        public static void ExprotCasinosNative()
        {
            UnityEngine.Object[] selected_asset = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.DeepAssets);
            List<string> list = new List<string>();
            for (int i = 0; i < selected_asset.Length; i++)
            {
                list.Add(AssetDatabase.GetAssetPath(selected_asset[i]));
            }

            ExportPackageOptions op = ExportPackageOptions.IncludeDependencies | ExportPackageOptions.Recurse;
            AssetDatabase.ExportPackage(list.ToArray(), "./CasinosNative.unitypackage", op);
            Debug.Log("导出CasinosNative.unitypackage成功！");
        }
    }
}