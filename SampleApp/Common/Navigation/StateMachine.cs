// *********************************************************************************
// <copyright file=StateMachine.cs company="Marcus Technical Services, Inc.">
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

namespace Com.MarcusTS.SmartDI.LifecycleAware.SampleApp.Common.Navigation
{
   using Com.MarcusTS.LifecycleAware.ViewModels;
   using Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels;
   using Com.MarcusTS.SmartDI.LifecycleAware.SampleApp.Views;
   using System;
   using Xamarin.Forms;

   /// <summary>
   ///    Class StateMachine.
   /// </summary>
   /// <summary>
   ///    Class StateMachine.
   /// </summary>
   public static class StateMachine
   {
      /// <summary>
      ///    Enum PageModes
      /// </summary>
      public enum PageModes
      {
         /// <summary>
         ///    The private 1
         /// </summary>
         Private_1,

         /// <summary>
         ///    The private 2
         /// </summary>
         Private_2,

         /// <summary>
         ///    The shared 1
         /// </summary>
         Shared_1,

         /// <summary>
         ///    The shared 2
         /// </summary>
         Shared_2,

         /// <summary>
         ///    The global 1
         /// </summary>
         Global_1,

         /// <summary>
         ///    The global 2
         /// </summary>
         Global_2,

         /// <summary>
         ///    The end
         /// </summary>
         END
      }

      /// <summary>
      ///    The end view model
      /// </summary>
      /// <summary>
      ///    The end view model
      /// </summary>
      private static readonly ICustomViewModelBase _endViewModel =
         ViewModelUtils.ViewModelBuilder.CreateViewModel<IViewModel_Private>();

      /// <summary>
      ///    The general page1
      /// </summary>
      /// <summary>
      ///    The general page1
      /// </summary>
      private static readonly ContentPage _generalPage1 = new GeneralPage();

      /// <summary>
      ///    The general page2
      /// </summary>
      /// <summary>
      ///    The general page2
      /// </summary>
      private static readonly ContentPage _generalPage2 = new GeneralPage();

      /// <summary>
      ///    The global view model1
      /// </summary>
      /// <summary>
      ///    The global view model1
      /// </summary>
      private static readonly ICustomViewModelBase _globalViewModel1 =
         ViewModelUtils.ViewModelBuilder.CreateViewModel<IViewModel_Global>();

      /// <summary>
      ///    The global view model2
      /// </summary>
      /// <summary>
      ///    The global view model2
      /// </summary>
      private static readonly ICustomViewModelBase _globalViewModel2 =
         ViewModelUtils.ViewModelBuilder.CreateViewModel<IViewModel_Global>();

      /// <summary>
      ///    The private view model1
      /// </summary>
      /// <summary>
      ///    The private view model1
      /// </summary>
      private static readonly ICustomViewModelBase _privateViewModel1 =
         ViewModelUtils.ViewModelBuilder.CreateViewModel<IViewModel_Private>();

      /// <summary>
      ///    The private view model2
      /// </summary>
      /// <summary>
      ///    The private view model2
      /// </summary>
      private static readonly ICustomViewModelBase _privateViewModel2 =
         ViewModelUtils.ViewModelBuilder.CreateViewModel<IViewModel_Private>();

      /// <summary>
      ///    The shared view model1
      /// </summary>
      /// <summary>
      ///    The shared view model1
      /// </summary>
      private static readonly ICustomViewModelBase _sharedViewModel1 =
         ViewModelUtils.ViewModelBuilder.CreateSharedViewModel<IViewModel_ToBeShared>(_generalPage1);

      /// <summary>
      ///    The shared view model2
      /// </summary>
      /// <summary>
      ///    The shared view model2
      /// </summary>
      private static readonly ICustomViewModelBase _sharedViewModel2 =
         ViewModelUtils.ViewModelBuilder.CreateSharedViewModel<IViewModel_ToBeShared>(_generalPage2);

      /// <summary>
      ///    The current page mode
      /// </summary>
      private static PageModes _currentPageMode;

      /// <summary>
      ///    Initializes static members of the <see cref="StateMachine" /> class.
      /// </summary>
      static StateMachine()
      {
         _privateViewModel1.Title = "Private View Model #1";
         _privateViewModel1.Description =
            "This view model's content is separate from any other view model.  It is never stored globally.";
         _privateViewModel1.Content = "C A T";

         _privateViewModel2.Title = "Private View Model #2";
         _privateViewModel2.Description =
            "This view model's content is also private, but the content has changed.  It is completely different from the previous view model.";
         _privateViewModel2.Content = "C H A I R";

         _sharedViewModel1.Description =
            "This view model is shared, so no matter how many copies we Resolve they are always the same.  They are stored globally until their parent pages fall out of scope.";
         _sharedViewModel1.Content = "H O U S E";

         // No need to set _sharedViewModel2; it is the same memory reference as _sharedViewModel1

         _globalViewModel1.Description =
            "This view model is global, so, like shared, no matter how many copies we Resolve they are always the same.  They are stored globally for the life of the container, which, in this case, is the life olf the app.";
         _globalViewModel1.Content = "W A T E R";

         // No need to set _globalViewModel2; it is the same memory reference as _globalViewModel1
         _endViewModel.Title       = "END";
         _endViewModel.Description = "To restart, click 'NEXT'";
      }

      /// <summary>
      ///    The global 1
      /// </summary>
      /// <value>The current page mode.</value>
      private static PageModes CurrentPageMode
      {
         get => _currentPageMode;
         set
         {
            _currentPageMode = value;

            switch (_currentPageMode)
            {
               case PageModes.Private_1:
                  SetMainPage(_generalPage1, _privateViewModel1);
                  break;

               case PageModes.Private_2:
                  SetMainPage(_generalPage2, _privateViewModel2);
                  break;

               case PageModes.Shared_1:
                  // We over-write the shared title for the sake of clarity
                  _sharedViewModel1.Title = "Shared View Model #1";
                  SetMainPage(_generalPage1, _sharedViewModel1);
                  break;

               case PageModes.Shared_2:
                  // We over-write the shared title for the sake of clarity
                  _sharedViewModel2.Title = "Shared View Model #2";
                  SetMainPage(_generalPage2, _sharedViewModel2);
                  break;

               case PageModes.Global_1:
                  // We over-write the global title for the sake of clarity
                  _globalViewModel1.Title = "Global View Model #1";
                  SetMainPage(_generalPage1, _globalViewModel1);
                  break;

               case PageModes.Global_2:
                  // We over-write the global title for the sake of clarity
                  _globalViewModel1.Title = "Global View Model #2";
                  SetMainPage(_generalPage2, _globalViewModel2);
                  break;

               default:
                  SetMainPage(_generalPage1, _endViewModel);
                  break;
            }
         }
      }

      /// <summary>
      ///    Goes to next mode.
      /// </summary>
      public static void GoToNextMode()
      {
         if ((int) CurrentPageMode < Enum.GetValues(typeof(PageModes)).Length - 1)
         {
            CurrentPageMode = (PageModes) ((int) CurrentPageMode + 1);
         }
         else
         {
            ResetCurrentPageMode();
         }
      }

      /// <summary>
      ///    Resets the current page mode.
      /// </summary>
      public static void ResetCurrentPageMode()
      {
         CurrentPageMode = 0;
      }

      /// <summary>
      ///    Sets the main page.
      /// </summary>
      /// <param name="page">The page.</param>
      /// <param name="viewModel">The view model.</param>
      private static void SetMainPage
      (
         ContentPage             page,
         IViewModelWithLifecycle viewModel
      )
      {
         page.BindingContext          = viewModel;
         Application.Current.MainPage = page;
      }
   }
}