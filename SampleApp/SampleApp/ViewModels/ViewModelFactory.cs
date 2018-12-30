// *********************************************************************************
// Assembly         : Com.MarcusTS.SmartDI.LifecycleAware.SampleApp
// Author           : Stephen Marcus (Marcus Technical Services, Inc.)
// Created          : 12-26-2018
// Last Modified On : 12-27-2018
//
// <copyright file="ViewModelFactory.cs" company="Com.MarcusTS.SmartDI.LifecycleAware.SampleApp">
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
   using SmartDI;
   using SmartDI.LifecycleAware;

   /// <summary>
   /// Interface IViewModelFactory
   /// </summary>
   public interface IViewModelFactory
   {
      #region Public Methods

      /// <summary>
      /// Creates the shared view model.
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="obj">The object.</param>
      /// <returns>ICustomViewModelBase.</returns>
      ICustomViewModelBase CreateSharedViewModel<T>(object obj) where T : class, ICustomViewModelBase;

      /// <summary>
      /// Creates the view model.
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <returns>ICustomViewModelBase.</returns>
      ICustomViewModelBase CreateViewModel<T>() where T : class, ICustomViewModelBase;

      #endregion Public Methods
   }

   /// <summary>
   /// Class ViewModelFactory.
   /// Implements the <see cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.IViewModelFactory" />
   /// </summary>
   /// <seealso cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.IViewModelFactory" />
   public class ViewModelFactory : IViewModelFactory
   {
      #region Private Fields

      /// <summary>
      /// The view model container
      /// </summary>
      private readonly SmartDIContainerWithLifecycle _viewModelContainer = new SmartDIContainerWithLifecycle();

      #endregion Private Fields

      #region Public Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="ViewModelFactory" /> class.
      /// </summary>
      /// <param name="service1">The service1.</param>
      /// <param name="service2">The service2.</param>
      /// <param name="service3">The service3.</param>
      public ViewModelFactory(IGlobalServiceOne   service1,
                              IGlobalServiceTwo   service2,
                              IGlobalServiceThree service3)
      {
         // Perform registrations at the constructor, privately.

         // Register the services as singletons
         _viewModelContainer.RegisterTypeAsInterface<GlobalServiceOne>(typeof(IGlobalServiceOne),
                                                                       StorageRules.GlobalSingleton);
         _viewModelContainer.RegisterTypeAsInterface<GlobalServiceTwo>(typeof(IGlobalServiceTwo),
                                                                       StorageRules.GlobalSingleton);
         _viewModelContainer.RegisterTypeAsInterface<GlobalServiceThree>(typeof(IGlobalServiceThree),
                                                                         StorageRules.GlobalSingleton);

         // Register other known types using various access levels
         _viewModelContainer.RegisterTypeAsInterface<ViewModel_Private>(typeof(IViewModel_Private),
                                                                        StorageRules.DoNotStore);
         _viewModelContainer.RegisterTypeAsInterface<ViewModel_ToBeShared>(typeof(IViewModel_ToBeShared),
                                                                           StorageRules
                                                                             .SharedDependencyBetweenInstances);
         _viewModelContainer.RegisterTypeAsInterface<ViewModel_Global>(typeof(IViewModel_Global),
                                                                       StorageRules.GlobalSingleton);
      }

      #endregion Public Constructors

      #region Public Methods

      /// <summary>
      /// This case requires an object "parent".
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="obj">The object.</param>
      /// <returns>ICustomViewModelBase.</returns>
      public ICustomViewModelBase CreateSharedViewModel<T>(object obj) where T : class, ICustomViewModelBase
      {
         return _viewModelContainer.Resolve<T>(boundInstance: obj);
      }

      /// <summary>
      /// This method will return the view model based on its registration rules.
      /// It is safer than registering as "All Access" and then resolving using more narrow guidance.
      /// It also encapsulates the private (static) view model container, insulating it from the rest of the app.
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <returns>ICustomViewModelBase.</returns>
      public ICustomViewModelBase CreateViewModel<T>() where T : class, ICustomViewModelBase
      {
         return _viewModelContainer.Resolve<T>();
      }

      #endregion Public Methods
   }
}