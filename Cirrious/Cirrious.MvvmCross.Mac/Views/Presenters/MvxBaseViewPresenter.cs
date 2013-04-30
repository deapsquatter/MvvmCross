#region Copyright
// <copyright file="MvxBaseTouchViewPresenter.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com


#endregion

using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Mac.Interfaces;
using Cirrious.MvvmCross.Views;

namespace Cirrious.MvvmCross.Mac.Views.Presenters
{
    public class MvxBaseViewPresenter 
        : IMvxMacViewPresenter
    {
		#region IMvxViewPresenter implementation

		public virtual void Show (MvxViewModelRequest request)
		{

		}

		public virtual void ChangePresentation (MvxPresentationHint hint)
		{
			throw new System.NotImplementedException ();
		}

		#endregion


    }
}