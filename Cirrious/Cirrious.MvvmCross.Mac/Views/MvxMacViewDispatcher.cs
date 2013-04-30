// <copyright file="MvxTouchViewDispatcher.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com

using System;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.Mac.Interfaces;
using Cirrious.CrossCore.Platform;

namespace Cirrious.MvvmCross.Mac.Views
{
    public class MvxMacViewDispatcher 
        : MvxMacUIThreadDispatcher
        , IMvxViewDispatcher
    {
        private readonly IMvxMacViewPresenter _presenter;

        public MvxMacViewDispatcher(IMvxMacViewPresenter presenter)
        {
            _presenter = presenter;
        }


		#region IMvxViewDispatcher implementation

		public bool ShowViewModel(MvxViewModelRequest request)
		{
			Action action = () =>
			{
				MvxTrace.TaggedTrace("TouchNavigation", "Navigate requested");
				_presenter.Show(request);
			};
			return RequestMainThreadAction(action);
		}

		public bool ChangePresentation(MvxPresentationHint hint)
		{
			return RequestMainThreadAction(() => _presenter.ChangePresentation(hint));
		}

        #endregion
    }
}