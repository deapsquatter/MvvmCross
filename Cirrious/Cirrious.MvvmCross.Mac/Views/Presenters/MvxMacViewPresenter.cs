// <copyright file="MvxTouchViewPresenter.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
using System;
using Cirrious.CrossCore;


using Cirrious.CrossCore.Exceptions;
using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using MonoMac.AppKit;
using Cirrious.MvvmCross.Mac.Interfaces;

namespace Cirrious.MvvmCross.Mac.Views.Presenters
{
    public class MvxMacViewPresenter 
        : MvxBaseViewPresenter
    {
        private readonly NSApplicationDelegate _applicationDelegate;
		private readonly NSWindow _window;
		private IMvxView _view;

		protected NSWindow Window{
			get{
				return _window;
			}
		}
        
        public MvxMacViewPresenter (NSApplicationDelegate applicationDelegate, NSWindow window)
        {
            _applicationDelegate = applicationDelegate;
			_window = window;
        } 

		protected virtual void PlaceView(MvxViewModelRequest request, NSViewController viewController)
		{
			Window.ContentView.AddSubview(viewController.View);
		}

		protected virtual IMvxMacView GetView(MvxViewModelRequest request)
		{
			var creator = Mvx.Resolve<IMvxMacViewCreator>();
			return creator.CreateView(request);
		}

        public override void Show(MvxViewModelRequest request)
        {
			try
			{
				_view = GetView(request);

				var viewController = _view as NSViewController;
				if (viewController == null)
					throw new MvxException("Passed in IMvxTouchView is not a NSViewController");

				PlaceView(request, viewController);
			}
			catch (Exception exception)
			{
				MvxTrace.Trace("Error seen during navigation request to {0} - error {1}", request.ViewModelType.Name,
				               exception.ToLongString());
			}
        }
    }	
}
