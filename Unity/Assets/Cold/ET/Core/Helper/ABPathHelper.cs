namespace ETCold
{
    /// <summary>
    /// AB实用函数集，主要是路径拼接
    /// </summary>
    public class ABPathHelper
    {
        public static string GetTexturePath(string fileName)
        {
            return $"Assets/Bundles/Altas/{fileName}.prefab";
        }

        public static string GetFGUIDesPath(string fileName)
        {
            return $"Assets/Bundles/FUI/{fileName}.bytes";
        }
        public static string GetFGUIAtlasResPath(string fileName)
        {
            return $"Assets/Bundles/FUI/{fileName}";
        }
        public static string GetFGUIResPath(string fileName, string extension)
        {
            return $"Assets/Bundles/FUI/{fileName}{extension}";
        }
        public static string GetUGUIPath(string name)
        {
            return $"Assets/Bundles/UI/{name}.prefab";
        }
        public static string GetConfigPath(string fileName)
        {
            return $"Assets/Bundles/Config/{fileName}.bytes";
        }
        public static string GetNormalConfigPath(string fileName)
        {
            return $"Assets/Bundles/Independent/{fileName}.prefab";
        }

        public static string GetSoundPath(string fileName)
        {
            return $"Assets/Bundles/Sounds/{fileName}.prefab";
        }

        public static string GetSkillConfigPath(string fileName)
        {
            return $"Assets/Bundles/SkillConfigs/{fileName}.prefab";
        }

        public static string GetUnitPath(string fileName)
        {
            return $"Assets/Bundles/Unit/{fileName}.prefab";
        }

        public static string GetScenePath(string fileName)
        {
            return $"Assets/Scenes/{fileName}.unity";
        }
    }
}