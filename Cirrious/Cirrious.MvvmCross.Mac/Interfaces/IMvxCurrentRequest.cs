// IMvxTouchViewCreator.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.comusing Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.ViewModels;

namespace Cirrious.MvvmCross.Mac.Interfaces
{
	public interface IMvxCurrentRequest
	{
		MvxViewModelRequest CurrentRequest { get; }
	}
}