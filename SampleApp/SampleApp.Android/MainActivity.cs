// *********************************************************************************
// Assembly         : SampleApp.Android
// Author           : Stephen Marcus (Marcus Technical Services, Inc.)
// Created          : 12-26-2018
// Last Modified On : 12-27-2018
//
// <copyright file="MainActivity.cs" company="">
//     Copyright ©  2014
// </copyright>
//
// MIT License
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// *********************************************************************************
namespace SampleApp.Droid
{
   using Android.App;
   using Android.Content.PM;
   using Android.OS;
   using Com.MarcusTS.SmartDi.LifecycleAware.SampleApp;
   using Xamarin.Forms;
   using Xamarin.Forms.Platform.Android;

   /// <summary>
   /// Class MainActivity.
   /// Implements the <see cref="Xamarin.Forms.Platform.Android.FormsAppCompatActivity" />
   /// </summary>
   /// <seealso cref="Xamarin.Forms.Platform.Android.FormsAppCompatActivity" />
   [Activity(Label         = "SampleApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,
      ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
   public class MainActivity : FormsAppCompatActivity
   {
      #region Protected Methods

      /// <summary>
      /// Called when [create].
      /// </summary>
      /// <param name="savedInstanceState">State of the saved instance.</param>
      protected override void OnCreate(Bundle savedInstanceState)
      {
         TabLayoutResource = Resource.Layout.Tabbar;
         ToolbarResource   = Resource.Layout.Toolbar;

         base.OnCreate(savedInstanceState);
         Forms.Init(this, savedInstanceState);
         LoadApplication(new App());
      }

      #endregion Protected Methods
   }
}