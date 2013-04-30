#region Copyright
// <copyright file="MvxTouchViewControllerExtensionMethods.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
using System;
using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore;

#endregion
using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.Mac.Interfaces;

namespace Cirrious.MvvmCross.Mac.Views
{
	public class MvxViewModelInstaceRequest : MvxViewModelRequest
	{
		private readonly IMvxViewModel _viewModelInstance;

		public IMvxViewModel ViewModelInstance
		{
			get { return _viewModelInstance; }
		}

		public MvxViewModelInstaceRequest(IMvxViewModel viewModelInstance)
			: base(viewModelInstance.GetType(), null, null, MvxRequestedBy.Unknown)
		{
			_viewModelInstance = viewModelInstance;
		}
	}
}