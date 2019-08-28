using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace XUI
{
    /// <summary>
    /// 键值处理
    /// </summary>
    public static class EditorPlayerPrefs
    {

#if UNITY_EDITOR
        [MenuItem("Tools/PlayPrefs/DeleteAll #&D", false, 1)]
#endif
        static public void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}

