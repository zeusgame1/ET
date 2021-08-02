"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.genCode = void 0;
const csharp_1 = require("csharp");
const CodeWriter_1 = require("./CodeWriter");
function genCode(handler) {
    let settings = handler.project.GetSettings("Publish").codeGeneration;
    let codePkgName = handler.ToFilename(handler.pkg.name); //convert chinese to pinyin, remove special chars etc.
    let exportCodePath = handler.exportCodePath + '/' + codePkgName;
    let namespaceName = codePkgName;
    let isMonoGame = handler.project.type == csharp_1.FairyEditor.ProjectType.MonoGame;
    if (settings.packageName)
        namespaceName = settings.packageName + '.' + namespaceName;
    //CollectClasses(stripeMemeber, stripeClass, fguiNamespace)
    let classes = handler.CollectClasses(settings.ignoreNoname, settings.ignoreNoname, null);
    handler.SetupCodeFolder(exportCodePath, "cs"); //check if target folder exists, and delete old files
    let getMemberByName = settings.getMemberByName;
    let classCnt = classes.Count;
    let old_dirs = csharp_1.System.IO.Directory.GetDirectories(exportCodePath);
    for (let index = 0; index < old_dirs.Length; index++) {
        const element = old_dirs[index];
        let files = csharp_1.System.IO.Directory.GetFiles(element);
        for (let index0 = 0; index0 < files.Length; index0++) {
            const element0 = files[index0];
            csharp_1.System.IO.File.Delete(element0);
        }
        csharp_1.System.IO.Directory.Delete(element);
    }
    let template0 = csharp_1.System.IO.File.ReadAllText(handler.project.assetsPath + "/../plugins/gen_et/Template.txt");
    let writer = new CodeWriter_1.default();
    for (let i = 0; i < classCnt; i++) {
        let template = template0.toString();
        let classInfo = classes.get_Item(i);
        let members = classInfo.members;
        let ns = "ET";
        if (settings.packageName)
            ns = "ET." + settings.packageName;
        template = template.split("(@Namespace)").join(ns);
        template = template.split("(@UIName)").join(classInfo.className);
        template = template.split("(@URL)").join(classInfo.res.GetURL());
        template = template.split("(@PkgName)").join(codePkgName);
        template = template.split("(@ResName)").join(classInfo.resName);
        template = template.split("(@SELF)").join(classInfo.superClassName);
        template = template.split("(@BASE)").join(classInfo.superClassName);
        let memberCnt = members.Count;
        writer.reset();
        for (let j = 0; j < memberCnt; j++) {
            let memberInfo = members.get_Item(j);
            writer.writeln('\t\tpublic %s %s;', memberInfo.type, memberInfo.varName);
        }
        template = template.split("(@COMS)").join(writer.toString());
        writer.reset();
        for (let j = 0; j < memberCnt; j++) {
            let memberInfo = members.get_Item(j);
            let typeName = memberInfo.type;
            if (memberInfo.group == 0) {
                if (typeName.indexOf("FUI") != -1) {
                    writer.writeln("\t\t\t%s.Dispose();", memberInfo.varName);
                }
                writer.writeln("\t\t\t%s = null;", memberInfo.varName);
            }
            else if (memberInfo.group == 1) {
                writer.writeln("\t\t\t%s = null;", memberInfo.varName);
            }
            else {
                writer.writeln("\t\t\t%s = null;", memberInfo.varName);
            }
        }
        template = template.split("(@Dispose)").join(writer.toString());
        writer.reset();
        for (let j = 0; j < memberCnt; j++) {
            let memberInfo = members.get_Item(j);
            let typeName = memberInfo.type;
            if (memberInfo.group == 0) {
                if (getMemberByName) {
                    let isCustomComponent = false;
                    for (let index = 0; index < classCnt; index++) {
                        if (typeName == classes.get_Item(index).className) {
                            isCustomComponent = true;
                            break;
                        }
                    }
                    if (isCustomComponent) {
                        writer.writeln("\t\t\t\t%s = %s.Create(this.Domain,com.GetChild(\"%s\"));", memberInfo.varName, memberInfo.type, memberInfo.name);
                    }
                    else {
                        writer.writeln("\t\t\t\t%s = (%s)com.GetChild(\"%s\");", memberInfo.varName, memberInfo.type, memberInfo.name);
                    }
                }
                else {
                    let isCustomComponent = false;
                    for (let index = 0; index < classCnt; index++) {
                        if (typeName == classes.get_Item(index).className) {
                            isCustomComponent = true;
                            break;
                        }
                    }
                    if (isCustomComponent) {
                        writer.writeln("\t\t\t\t%s = %s.Create(this.Domain,com.GetChildAt(%s));", memberInfo.varName, memberInfo.type, memberInfo.index);
                    }
                    else {
                        writer.writeln("\t\t\t\t%s = (%s)com.GetChildAt(%s);", memberInfo.varName, memberInfo.type, memberInfo.index);
                    }
                }
            }
            else if (memberInfo.group == 1) {
                if (getMemberByName) {
                    writer.writeln('\t\t\t\t%s = com.GetController("%s");', memberInfo.varName, memberInfo.name);
                }
                else {
                    writer.writeln('\t\t\t\t%s = com.GetControllerAt(%s);', memberInfo.varName, memberInfo.index);
                }
            }
            else {
                if (getMemberByName) {
                    writer.writeln('\t\t\t\t%s = com.GetTransition("%s");', memberInfo.varName, memberInfo.name);
                }
                else {
                    writer.writeln('\t\t\t\t%s = com.GetTransitionAt(%s);', memberInfo.varName, memberInfo.index);
                }
            }
        }
        template = template.split("(@INIT)").join(writer.toString());
        if (!csharp_1.System.IO.Directory.Exists(exportCodePath + '/' + classInfo.className)) {
            csharp_1.System.IO.Directory.CreateDirectory(exportCodePath + '/' + classInfo.className);
        }
        csharp_1.System.IO.File.WriteAllText(exportCodePath + '/' + classInfo.className + '/' + classInfo.className + '.cs', template);
    }
    // writer.reset();
    // writer.writeln(template);
    // writer.save("f:/g412.cs");
    writer.reset();
    let binderName = codePkgName + 'Binder';
    writer.writeln('using FairyGUI;');
    writer.writeln();
    writer.writeln('namespace ET');
    // writer.writeln('namespace ET.%s', namespaceName);
    writer.startBlock();
    writer.writeln('public static partial class FUIPackage');
    writer.startBlock();
    writer.writeln('public const string %s = "%s";', codePkgName, codePkgName);
    for (let index = 0; index < handler.items.Count; index++) {
        const temp_url = handler.items.get_Item(index).GetURL();
        writer.writeln('public const string %s_%s_%s = "%s";', codePkgName, handler.items.get_Item(index).name, index, temp_url);
    }
    //  writer.endBlock(); //bindall
    writer.endBlock(); //class
    writer.endBlock(); //namespace
    writer.save(exportCodePath + '/' + binderName + '.cs');
}
exports.genCode = genCode;
