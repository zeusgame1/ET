using ET;
using System.IO;
using UnityEditor;

namespace ETEditor
{

    [InitializeOnLoad]
    public  class BunildHotfixEditor
    {
        private const string ScriptAssembliesDir = "Library/ScriptAssemblies";
        private const string CodeDir = "Assets/Res/Code/";

        private const string HotfixDll = "Unity.Hotfix.dll";
        private const string HotfixPdb = "Unity.Hotfix.pdb";

        private const string HotfixViewDll = "Unity.HotfixView.dll";
        private const string HotfixViewPdb = "Unity.HotfixView.pdb";

        private const string ModelDll = "Unity.Model.dll";
        private const string ModelPdb = "Unity.Model.pdb";

        private const string ModelViewDll = "Unity.ModelView.dll";
        private const string ModelViewPdb = "Unity.ModelView.pdb";



        private const string ScriptDll = "Unity.Script.dll";
        private const string ScriptPdb = "Unity.Script.pdb";


        static BunildHotfixEditor() 
        {
            File.Copy(Path.Combine(ScriptAssembliesDir, HotfixDll), Path.Combine(CodeDir, "Hotfix.dll.bytes"), true);
            File.Copy(Path.Combine(ScriptAssembliesDir, HotfixPdb), Path.Combine(CodeDir, "Hotfix.pdb.bytes"), true);

            File.Copy(Path.Combine(ScriptAssembliesDir, HotfixViewDll), Path.Combine(CodeDir, "HotfixView.dll.bytes"), true);
            File.Copy(Path.Combine(ScriptAssembliesDir, HotfixViewPdb), Path.Combine(CodeDir, "HotfixView.pdb.bytes"), true);

            File.Copy(Path.Combine(ScriptAssembliesDir, ModelDll), Path.Combine(CodeDir, "Model.dll.bytes"), true);
            File.Copy(Path.Combine(ScriptAssembliesDir, ModelPdb), Path.Combine(CodeDir, "Model.pdb.bytes"), true);

            File.Copy(Path.Combine(ScriptAssembliesDir, ModelViewDll), Path.Combine(CodeDir, "ModelView.dll.bytes"), true);
            File.Copy(Path.Combine(ScriptAssembliesDir, ModelViewPdb), Path.Combine(CodeDir, "ModelView.pdb.bytes"), true);


           // File.Copy(Path.Combine(ScriptAssembliesDir, ScriptDll), Path.Combine(CodeDir, "Script.dll.bytes"), true);
           // File.Copy(Path.Combine(ScriptAssembliesDir, ScriptPdb), Path.Combine(CodeDir, "Script.pdb.bytes"), true);
//
            Log.Info($"复制程序集完成");
            AssetDatabase.Refresh();
        }
    }
}
