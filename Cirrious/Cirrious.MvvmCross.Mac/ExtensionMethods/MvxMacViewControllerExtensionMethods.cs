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
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Mac.Views;
using Cirrious.CrossCore.Exceptions;


#endregion

using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.Mac.Interfaces;

namespace Cirrious.MvvmCross.Mac.ExtensionMethods
{
    public static class MvxMacViewControllerExtensionMethods
    {
		public static void OnViewCreate(this IMvxMacView macView)
		{
			macView.OnViewCreate(() => { return macView.LoadViewModel(); });
		}

		private static IMvxViewModel LoadViewModel(this IMvxMacView macView)
		{
			if (macView.Request == null)
			{
				MvxTrace.Trace(
					"Request is null - assuming this is a TabBar type situation where ViewDidLoad is called during construction... patching the request now - but watch out for problems with virtual calls during construction");
				macView.Request = Mvx.Resolve<IMvxCurrentRequest>().CurrentRequest;
			}

			var instanceRequest = macView.Request as MvxViewModelInstaceRequest;
			if (instanceRequest != null)
			{
				return instanceRequest.ViewModelInstance;
			}

			var loader = Mvx.Resolve<IMvxViewModelLoader>();
			var viewModel = loader.LoadViewModel(macView.Request, null /* no saved state on Mac currently */);
			if (viewModel == null)
				throw new MvxException("ViewModel not loaded for " + macView.Request.ViewModelType);
			return viewModel;
		}



    }
}