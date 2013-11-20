using System;
using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.Binding.BindingContext;
using MonoMac.AppKit;

namespace Cirrious.MvvmCross.Binding.Mac
{
	public class MvxMacBindingBuilder
		: MvxBindingBuilder
	{
		private readonly Action<IMvxTargetBindingFactoryRegistry> _fillRegistryAction;
		private readonly Action<IMvxValueConverterRegistry> _fillValueConvertersAction;
		private readonly Action<IMvxBindingNameRegistry> _fillBindingNamesAction;

		public MvxMacBindingBuilder(Action<IMvxTargetBindingFactoryRegistry> fillRegistryAction,
		                            Action<IMvxValueConverterRegistry> fillValueConvertersAction, Action<IMvxBindingNameRegistry> fillBindingNamesAction)
		{
			_fillRegistryAction = fillRegistryAction;
			_fillValueConvertersAction = fillValueConvertersAction;
			_fillBindingNamesAction = fillBindingNamesAction;
		}

		protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
		{
			base.FillTargetFactories(registry);

			// This was required in order to get two-way binding to work correctly.
			registry.RegisterPropertyInfoBindingFactory(typeof(MvxNSTextFieldTextTargetBinding), typeof(NSTextField), "StringValue");

			if (_fillRegistryAction != null)
				_fillRegistryAction(registry);
		}

		protected override void FillValueConverters(IMvxValueConverterRegistry registry)
		{
			base.FillValueConverters(registry);

			if (_fillValueConvertersAction != null)
				_fillValueConvertersAction(registry);
		}

		protected override void FillDefaultBindingNames(IMvxBindingNameRegistry registry)
		{
			base.FillDefaultBindingNames(registry);

			registry.AddOrOverwrite(typeof (NSTextField), "StringValue");
			registry.AddOrOverwrite(typeof (NSTextView), "Value");
			registry.AddOrOverwrite (typeof(NSButton), "Activated");

			if (_fillBindingNamesAction != null)
				_fillBindingNamesAction(registry);
		}
	}
}