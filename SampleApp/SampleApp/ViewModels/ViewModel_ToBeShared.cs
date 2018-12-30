// *********************************************************************************
// Assembly         : Com.MarcusTS.SmartDI.LifecycleAware.SampleApp
// Author           : Stephen Marcus (Marcus Technical Services, Inc.)
// Created          : 12-27-2018
// Last Modified On : 12-27-2018
//
// <copyright file="ViewModel_ToBeShared.cs" company="Com.MarcusTS.SmartDI.LifecycleAware.SampleApp">
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
   using Common.Services;

   /// <summary>
   /// Interface IViewModel_ToBeShared
   /// Implements the <see cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.ICustomViewModelBase" />
   /// </summary>
   /// <seealso cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.ICustomViewModelBase" />
   public interface IViewModel_ToBeShared : ICustomViewModelBase
   { }

   /// <summary>
   /// Class ViewModel_ToBeShared.
   /// Implements the <see cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.CustomViewModelBase" />
   /// Implements the <see cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.IViewModel_ToBeShared" />
   /// </summary>
   /// <seealso cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.CustomViewModelBase" />
   /// <seealso cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.IViewModel_ToBeShared" />
   public class ViewModel_ToBeShared : CustomViewModelBase, IViewModel_ToBeShared
   {
      #region Public Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="ViewModel_ToBeShared" /> class.
      /// </summary>
      /// <param name="service2">The service2.</param>
      public ViewModel_ToBeShared(IGlobalServiceTwo service2)
      { }

      #endregion Public Constructors
   }
}