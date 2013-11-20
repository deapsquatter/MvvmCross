using System.Reflection;
using Cirrious.MvvmCross.Binding.Bindings.Target;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Binding;
using MonoMac.AppKit;

namespace Cirrious.MvvmCross.Binding.Mac
{
	public class MvxNSTextFieldTextTargetBinding : MvxPropertyInfoTargetBinding<NSTextField>
	{        
		public MvxNSTextFieldTextTargetBinding(object target, PropertyInfo targetPropertyInfo)
			: base(target, targetPropertyInfo)
		{
			var editText = View;
			if (editText == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error,"Error - NSTextField is null in MvxNSTextFieldTextTargetBinding");
			}
			else
			{
				editText.Changed += HandleEditTextValueChanged;
			}
		}

		void HandleEditTextValueChanged (object sender, System.EventArgs e)
		{
			FireValueChanged(View.StringValue);
		}

		public override MvxBindingMode DefaultMode
		{
			get
			{
				return MvxBindingMode.TwoWay;
			}
		}

		protected override void Dispose(bool isDisposing)
		{
			base.Dispose(isDisposing);
			if (isDisposing)
			{
				var editText = View;
				if (editText != null)
				{
					editText.Changed -= HandleEditTextValueChanged;
				}
			}
		}
	}
}