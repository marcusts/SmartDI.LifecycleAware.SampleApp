// *********************************************************************************
// <copyright file=ViewModel_Private.cs company="Marcus Technical Services, Inc.">
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

namespace Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels
{
   using Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.Common.Services;

   /// <summary>
   ///    Interface IViewModel_Private
   ///    Implements the <see cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.ICustomViewModelBase" />
   /// </summary>
   /// <seealso cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.ICustomViewModelBase" />
   public interface IViewModel_Private : ICustomViewModelBase
   {
   }

   /// <summary>
   ///    Class ViewModel_Private.
   ///    Implements the <see cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.CustomViewModelBase" />
   ///    Implements the <see cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.IViewModel_Private" />
   /// </summary>
   /// <seealso cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.CustomViewModelBase" />
   /// <seealso cref="Com.MarcusTS.SmartDi.LifecycleAware.SampleApp.ViewModels.IViewModel_Private" />
   public class ViewModel_Private : CustomViewModelBase, IViewModel_Private
   {
      /// <summary>
      ///    Initializes a new instance of the <see cref="ViewModel_Private" /> class.
      /// </summary>
      /// <param name="service1">The service1.</param>
      /// <param name="service3">The service3.</param>
      public ViewModel_Private
      (
         IGlobalServiceOne   service1,
         IGlobalServiceThree service3
      )
      {
      }
   }
}