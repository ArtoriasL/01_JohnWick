#if UNITY_EDITOR
//=======================================================\\
// - FileName:      Copyright.cs                         \\
// - Created:       #AuthorName#                         \\
// - UserName:      #CreateTime#                         \\
// - Email:         #AuthorEmail#                        \\
// - Description:                                        \\
// -  (C) Copyright 2019 - 2029, Allen Zhang,Inc.        \\
// -  All Rights Reserved.                               \\
//=======================================================\\
using System.Collections;
using System.IO;
using UnityEngine;

public class Copyright : UnityEditor.AssetModificationProcessor {
    private const string AuthorName = "Allen Zhang";
    private const string AuthorEmail = "allen.zhang@sencity.city";

    private const string DateFormat = "MM/dd/yyyy HH:mm:ss";
    private static void OnWillCreateAsset (string path) {
        path = path.Replace (".meta", "");
        if (path.EndsWith (".cs")) {
            string allText = File.ReadAllText (path);
            allText = allText.Replace ("#AuthorName#", AuthorName);
            allText = allText.Replace ("#AuthorEmail#", AuthorEmail);
            allText = allText.Replace ("#CreateTime#", System.DateTime.Now.ToString (DateFormat));
            File.WriteAllText (path, allText);
            UnityEditor.AssetDatabase.Refresh ();
        }
    }
}
#endif