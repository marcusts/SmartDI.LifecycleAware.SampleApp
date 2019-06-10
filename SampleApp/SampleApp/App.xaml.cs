// *********************************************************************************
// <copyright file=App.xaml.cs company="Marcus Technical Services, Inc.">
//     Copyright @2019 Marcus Technical Services, Inc.
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

namespace Com.MarcusTS.SmartDi.LifecycleAware.SampleApp
{
   using Com.MarcusTS.LifecycleAware.Common.Interfaces;
   using Com.MarcusTS.SharedUtils.Utils;
   using Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.Common.Services;
   using Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels;
   using Com.MarcusTS.SmartDI;
   using Com.MarcusTS.SmartDI.LifecycleAware.SampleApp.Common.Navigation;
   using System;
   using Xamarin.Forms;

   /// <summary>
   ///    Class App.
   ///    Implements the <see cref="Xamarin.Forms.Application" />
   ///    Implements the <see cref="Com.MarcusTS.LifecycleAware.Common.Interfaces.IManagePageChanges" />
   ///    Implements the <see cref="Com.MarcusTS.LifecycleAware.Common.Interfaces.IReportAppLifecycle" />
   /// </summary>
   /// <seealso cref="Xamarin.Forms.Application" />
   /// <seealso cref="Com.MarcusTS.LifecycleAware.Common.Interfaces.IManagePageChanges" />
   /// <seealso cref="Com.MarcusTS.LifecycleAware.Common.Interfaces.IReportAppLifecycle" />
   public partial class App : Application, IManagePageChanges, IReportAppLifecycle
   {
      // Using the standard version because this only contains global service singletons
      /// <summary>
      ///    The global service container
      /// </summary>
      public static readonly ISmartDIContainer GlobalServiceContainer = new SmartDIContainer();

      /// <summary>
      ///    Initializes a new instance of the <see cref="App" /> class.
      /// </summary>
      public App()
      {
         InitializeComponent();

         // Required by IOS
         MainPage = new ContentPage();

         GlobalServiceContainer.RegisterTypeAsInterface<GlobalServiceOne>(typeof(IGlobalServiceOne),
                                                                          StorageRules.GlobalSingleton);
         GlobalServiceContainer.RegisterTypeAsInterface<GlobalServiceTwo>(typeof(IGlobalServiceTwo),
                                                                          StorageRules.GlobalSingleton);
         GlobalServiceContainer.RegisterTypeAsInterface<GlobalServiceThree>(typeof(IGlobalServiceThree),
                                                                            StorageRules.GlobalSingleton);
         GlobalServiceContainer.RegisterTypeAsInterface<ViewModelFactory>(typeof(IViewModelFactory));

         StateMachine.ResetCurrentPageMode();
      }

      /// <summary>
      ///    Sets the main page.
      /// </summary>
      /// <param name="newPage">The new page.</param>
      public void SetMainPage(Page newPage)
      {
         try
         {
            MainPage = newPage;
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
         }
      }

      /// <summary>
      ///    Occurs when [application is going to sleep].
      /// </summary>
      public event EventUtils.NoParamsDelegate AppIsGoingToSleep;

      /// <summary>
      ///    Occurs when [application is resuming].
      /// </summary>
      public event EventUtils.NoParamsDelegate AppIsResuming;

      /// <summary>
      ///    Occurs when [application is starting].
      /// </summary>
      public event EventUtils.NoParamsDelegate AppIsStarting;

      /// <summary>
      ///    Application developers override this method to perform actions when the application resumes from a sleeping state.
      /// </summary>
      /// <remarks>To be added.</remarks>
      protected override void OnResume()
      {
         AppIsResuming?.Invoke();
      }

      /// <summary>
      ///    Application developers override this method to perform actions when the application enters the sleeping state.
      /// </summary>
      /// <remarks>To be added.</remarks>
      protected override void OnSleep()
      {
         AppIsGoingToSleep?.Invoke();
      }

      /// <summary>
      ///    Called when [start].
      /// </summary>
      protected override void OnStart()
      {
         AppIsStarting?.Invoke();
      }
   }
}