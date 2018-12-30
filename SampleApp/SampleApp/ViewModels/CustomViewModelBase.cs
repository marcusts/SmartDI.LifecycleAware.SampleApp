// *********************************************************************************
// Assembly         : Com.MarcusTS.SmartDI.LifecycleAware.SampleApp
// Author           : Stephen Marcus (Marcus Technical Services, Inc.)
// Created          : 12-26-2018
// Last Modified On : 12-27-2018
//
// <copyright file="CustomViewModelBase.cs" company="Com.MarcusTS.SmartDI.LifecycleAware.SampleApp">
//     Copyright (c) . All rights reserved.
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
namespace Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels
{
   using System.Windows.Input;
   using MarcusTS.LifecycleAware.ViewModels;
   using PropertyChanged;
   using SmartDI.LifecycleAware.SampleApp.Common.Navigation;
   using Xamarin.Forms;

   /// <summary>
   /// Interface ICustomViewModelBase
   /// Implements the <see cref="Com.MarcusTS.LifecycleAware.ViewModels.IViewModelWithLifecycle" />
   /// </summary>
   /// <seealso cref="Com.MarcusTS.LifecycleAware.ViewModels.IViewModelWithLifecycle" />
   public interface ICustomViewModelBase : IViewModelWithLifecycle
   {
      #region Public Properties

      /// <summary>
      /// Gets the button command.
      /// </summary>
      /// <value>The button command.</value>
      ICommand ButtonCommand { get; }
      /// <summary>
      /// Gets or sets the content.
      /// </summary>
      /// <value>The content.</value>
      string Content       { get; set; }
      /// <summary>
      /// Gets or sets the description.
      /// </summary>
      /// <value>The description.</value>
      string Description   { get; set; }
      /// <summary>
      /// Gets or sets the title.
      /// </summary>
      /// <value>The title.</value>
      string Title         { get; set; }

      #endregion Public Properties
   }

   /// <summary>
   /// Class CustomViewModelBase.
   /// Implements the <see cref="Com.MarcusTS.LifecycleAware.ViewModels.ViewModelWithLifecycle" />
   /// Implements the <see cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.ICustomViewModelBase" />
   /// </summary>
   /// <seealso cref="Com.MarcusTS.LifecycleAware.ViewModels.ViewModelWithLifecycle" />
   /// <seealso cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.ICustomViewModelBase" />
   [AddINotifyPropertyChangedInterface]
   public class CustomViewModelBase : ViewModelWithLifecycle, ICustomViewModelBase
   {
      #region Public Properties

      /// <summary>
      /// Gets the button command.
      /// </summary>
      /// <value>The button command.</value>
      public ICommand ButtonCommand => new Command(StateMachine.GoToNextMode);
      /// <summary>
      /// Gets or sets the content.
      /// </summary>
      /// <value>The content.</value>
      public string   Content       { get; set; }
      /// <summary>
      /// Gets or sets the description.
      /// </summary>
      /// <value>The description.</value>
      public string   Description   { get; set; }
      /// <summary>
      /// Gets or sets the title.
      /// </summary>
      /// <value>The title.</value>
      public string   Title         { get; set; }

      #endregion Public Properties
   }
}
