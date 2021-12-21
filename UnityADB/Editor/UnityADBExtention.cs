using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEditor.Android;

namespace ifland.unity.adb { 
    public class UnityADB 
    {
        [MenuItem("ADB/Reinstall")]
        static void ReinstallAPK()
        {
            // Get Apk path
            var apkPath = EditorUserBuildSettings.GetBuildLocation(BuildTarget.Android);

            // exist apk
            if (!File.Exists(apkPath)) {
                Debug.LogError($"file not found ({apkPath})");

                return;
            }

            // adb install
            ADB.GetInstance().Run(new string[] { "install", "-r", "-d", apkPath }, "apk install fail");

            //Application.identifier

            // launcher activity
            //context.Get<string>("PackageName");
            //context.Get<string>("ActivityWithLaunchIntent");
            // "UnityManifest.xml"
            //  SelectSingleNode("/manifest/application") as XmlElement;
            //XmlNode xmlNode = SelectSingleNode("/manifest/application/activity[intent-filter/action/@android:name='android.intent.action.MAIN' and intent-filter/category/@android:name='android.intent.category.LAUNCHER']", nsMgr);
            //return (xmlNode != null) ? xmlNode.Attributes["android:name"].Value : "";

            ADB.GetInstance().Run(new string[]{
                    "shell",
                    "am",
                    "start",
                    "-a",
                    "android.intent.action.MAIN",
                    "-c",
                    "android.intent.category.LAUNCHER",
                    "-f",
                    "0x10200000",
                    "-S",
                    "-n",
                    //Quote(Androidbuild + "/" + activity)
                }, "Unable to launch application. Please make sure the Android SDK is installed and is properly configured in the Editor. See the Console for more details.");
        }

        static void Uninstall()
        {
            // Get package name
            // adb uninstall apk
        }

        static void ScreenShot()
        {
            // Take Screenshot
            // copy to desktop
        }

        static void RecordScreen()
        {
            // Record Video
            // copy to desktop
        }

        static string Quote(string val)
        {
            return "\"" + val + "\"";
        }
    }
}