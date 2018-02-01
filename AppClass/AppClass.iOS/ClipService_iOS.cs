using System;
using System.Collections.Generic;
using System.Linq;
using AppClass.Interfaces;
using AppClass.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(ClipService_iOS))]
namespace AppClass.iOS
{
    public class ClipService_iOS : IClipService
    {

        public void SetText(string text)
        {
            UIPasteboard clipboard = UIPasteboard.General;
            clipboard.String = text;
        }
    }
}