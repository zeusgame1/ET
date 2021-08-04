using ET;
using ETCold;
using UnityEditor;

namespace ETEditor
{
    public static class FUIImporter
    {

        static string FUI_Dir => System.IO.Path.Combine(UnityEngine.Application.dataPath,"..", "FUI", "Projects");

        static string FUI_Codes_Dir => System.IO.Path.Combine(FUI_Dir, "Codes", "ModelView");
        static string FUI_Res_Dir => System.IO.Path.Combine(FUI_Dir, "Codes");


        [MenuItem("Tools/FUI/导入fui代码")]
        public static void ImportCodes()
        {
            ET.Log.Debug("=========开始导入fui代码，请耐心等待=========");

           // FileHelper.CleanDirectory("Assets/ModelView/Demo/FUI/AutoGen");

            var files = System.IO.Directory.GetFiles(FUI_Codes_Dir);

            if (files.Length == 0)
            {
                ET.Log.Error("找不到fui代码");
                return;
            }
            FileHelper.CleanDirectory("Assets/ModelView/Demo/FUI/AutoGen");
            FileHelper.CopyDirectory(FUI_Codes_Dir, "Assets/ModelView/Demo/FUI/AutoGen");

           // var asset_files = System.IO.Directory.GetFiles(FUI_Res_Dir);

            FileHelper.CopyDirectory(FUI_Res_Dir, "Assets/Bundles/FUI",false);


            AssetDatabase.Refresh();
            return;
          

        }

    }
}
