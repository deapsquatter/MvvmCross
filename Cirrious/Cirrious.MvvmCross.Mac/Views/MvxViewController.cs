#region Copyright
// <copyright file="MvxTouchViewController.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
using MonoMac.Foundation;


#endregion

using System;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Mac.ExtensionMethods;
using Cirrious.MvvmCross.Mac.Interfaces;
using Cirrious.MvvmCross.Views;
using MonoMac.AppKit;


namespace Cirrious.MvvmCross.Mac.Views
{
	public abstract class MvxViewController
		: NSViewController ,IMvxMacView
	{
		private IMvxViewModel _viewModel;

		// Called when created from unmanaged code
		public MvxViewController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MvxViewController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public MvxViewController (string viewName, NSBundle bundle) : base (viewName, bundle)
		{
			Initialize ();
		}

		// Call to load from the XIB/NIB file
		public MvxViewController (string viewName) : base (viewName, NSBundle.MainBundle)
		{
			Initialize ();
		}

		// Shared initialization code
		void Initialize ()
		{
			//this.AdaptForBinding();
		}

		public override void LoadView ()
		{
			base.LoadView ();
			BindingContext = new MvxBindingContext ();
			this.OnViewCreate ();
		}

		public object DataContext
		{
			get { return BindingContext.DataContext; }
			set { BindingContext.DataContext = value; }
		}

		public IMvxViewModel ViewModel
		{
			get { return (IMvxViewModel) DataContext; }
			set { DataContext = value; }
		}

		public MvxViewModelRequest Request { get; set; }

		public IMvxBindingContext BindingContext { get; set; }
	}
}