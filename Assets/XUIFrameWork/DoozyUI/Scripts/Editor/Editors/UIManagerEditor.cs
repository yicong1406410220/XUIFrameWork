// Copyright (c) 2015 - 2018 Doozy Entertainment / Marlink Trading SRL. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using QuickEditor;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace DoozyUI
{
    [CustomEditor(typeof(UIManager), true)]
    [DisallowMultipleComponent]
    public class UIManagerEditor : QEditor
    {
        UIManager uiManager { get { return (UIManager)target; } }

        SerializedProperty
            debugGameEvents, debugUIButtons, debugUIElements, debugUINotifications, debugUICanvases,
            autoDisableButtonClicks;

        float GlobalWidth { get { return DUI.GLOBAL_EDITOR_WIDTH; } }

        protected override void SerializedObjectFindProperties()
        {
            base.SerializedObjectFindProperties();

            debugGameEvents = serializedObject.FindProperty("debugGameEvents");
            debugUIButtons = serializedObject.FindProperty("debugUIButtons");
            debugUIElements = serializedObject.FindProperty("debugUIElements");
            debugUINotifications = serializedObject.FindProperty("debugUINotifications");
            autoDisableButtonClicks = serializedObject.FindProperty("autoDisableButtonClicks");
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            requiresContantRepaint = true;
        }

        public override void OnInspectorGUI()
        {
            DrawHeader(DUIResources.headerUIManager.normal, WIDTH_420, HEIGHT_42);

            serializedObject.Update();

            DrawTopButtons(GlobalWidth);
            QUI.Space(SPACE_4);

            DrawOrientationManagerButton(GlobalWidth);
            QUI.Space(SPACE_4);

            DrawDebugOptions(GlobalWidth);
            QUI.Space(SPACE_4);

            DrawSettings(GlobalWidth);

            if(EditorApplication.isPlaying)
            {
                QUI.Space(SPACE_8);
                DrawBackButtonStatus(GlobalWidth);
                QUI.Space(SPACE_2);
                DrawButtonClicksStatus(GlobalWidth);
            }

            serializedObject.ApplyModifiedProperties();

            QUI.Space(SPACE_4);
        }

        void DrawTopButtons(float width)
        {
            QUI.BeginHorizontal(width);
            {
                if(QUI.GhostButton("Control Panel", QColors.Color.Gray, (width - SPACE_4) / 3, 18))
                {
                    ControlPanelWindow.OpenWindow(ControlPanelWindow.Page.General);
                }
                if(QUI.GhostButton("Editor Settings", QColors.Color.Gray, (width - SPACE_4) / 3, 18))
                {
                    ControlPanelWindow.OpenWindow(ControlPanelWindow.Page.EditorSettings);
                }
                if(QUI.GhostButton("Help", QColors.Color.Gray, (width - SPACE_4) / 3, 18))
                {
                    ControlPanelWindow.OpenWindow(ControlPanelWindow.Page.Help);
                }
            }
            QUI.EndHorizontal();
        }

        void DrawOrientationManagerButton(float width)
        {
            if(!UIManager.useOrientationManager) { return; }
            if(QUI.GhostButton("Add Orientation Manager to Scene", QColors.Color.Gray, width, 18))
            {
                OrientationManager.AddOrientationManagerToScene();
            }
        }

        void DrawDebugOptions(float width)
        {
            QUI.BeginHorizontal(width);
            {
                QUI.LabelWithBackground("Debug");
                QUI.FlexibleSpace();
                QUI.QToggle("GameEvents", debugGameEvents, Style.Text.Small);
                QUI.FlexibleSpace();
                QUI.QToggle("UIButtons", debugUIButtons, Style.Text.Small);
                QUI.FlexibleSpace();
                QUI.QToggle("UIElements", debugUIElements, Style.Text.Small);
                QUI.FlexibleSpace();
                QUI.QToggle("UINotifications", debugUINotifications, Style.Text.Small);
            }
            QUI.EndHorizontal();
        }

        void DrawSettings(float width)
        {
            QUI.QToggle("Auto disable Button Clicks when an UIElement is in trasition", autoDisableButtonClicks);
        }

        void DrawBackButtonStatus(float width)
        {
            QUI.LabelWithBackground("The 'Back' button is " + (UIManager.Instance.BackButtonDisabled ? "DISABLED" : "ENABLED"));
        }

        void DrawButtonClicksStatus(float width)
        {
            QUI.LabelWithBackground("Button clicks are " + (UIManager.Instance.ButtonClicksDisabled ? "DISABLED" : "ENABLED"));
        }
    }
}
