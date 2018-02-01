using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppClass.Droid;
using AppClass.Interfaces;
using Xamarin.Forms;

[assembly:Dependency(typeof(ClipService_Droid))]
namespace AppClass.Droid
{
    public class ClipService_Droid : IClipService
    {
        public void SetText(string text)
        {
            var clipboardManager = (ClipboardManager)Forms.Context.GetSystemService(Context.ClipboardService);
            ClipData clip = ClipData.NewPlainText("title", text);
            clipboardManager.PrimaryClip = clip;
        }
    }
}