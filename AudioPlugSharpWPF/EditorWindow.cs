﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using AudioPlugSharp;

namespace AudioPlugSharpWPF
{
    public class EditorWindow : Window
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public IAudioPluginEditor Editor { get; private set; }
        public EditorView EditorView { get; private set; }

        public EditorWindow(IAudioPluginEditor editor)
        {
            this.Editor = editor;

            DataContext = Editor.Processor;

            EditorView = new EditorView() { Width = editor.EditorWidth, Height = editor.EditorHeight };
        }

        public void Show(IntPtr parentWindow)
        {
            Content = EditorView;

            Top = 0;
            Left = 0;
            Width = EditorView.Width;
            Height = EditorView.Height;
            ShowInTaskbar = false;
            WindowStyle = System.Windows.WindowStyle.None;
            ResizeMode = System.Windows.ResizeMode.NoResize;

            Show();

            var windowHwnd = new System.Windows.Interop.WindowInteropHelper(this);
            IntPtr hWnd = windowHwnd.Handle;
            SetParent(hWnd, parentWindow);
        }
    }
}
