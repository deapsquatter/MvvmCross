#region Copyright
// <copyright file="MvxBaseTouchSetup.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Mac;


#endregion

using System;
using System.Reflection;
using System.Collections.Generic;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.Platform;
using Cirrious.MvvmCross.Mac.Interfaces;
using Cirrious.MvvmCross.Mac.Views;
using Cirrious.MvvmCross.Binding.Binders;
using Cirrious.MvvmCross.Views;

namespace Cirrious.MvvmCross.Mac.Platform
{
    public abstract class MvxMacSetup
        : MvxSetup
    {
        private readonly MvxApplicationDelegate _applicationDelegate;
        private readonly IMvxMacViewPresenter _presenter;

        protected MvxMacSetup(MvxApplicationDelegate applicationDelegate, IMvxMacViewPresenter presenter)
        {
			_presenter = presenter;
			_applicationDelegate = applicationDelegate;
        }

        protected override void InitializeDebugServices()
        {
			Mvx.RegisterSingleton<IMvxTrace>(new MvxDebugTrace());
            base.InitializeDebugServices();
        }

        protected override IMvxPluginManager CreatePluginManager()
        {
			var toReturn = new MvxLoaderPluginManager();
			var registry = new MvxLoaderPluginRegistry(".Mac", toReturn.Finders);
			AddPluginsLoaders(registry);
			return toReturn;
		}
		
		protected virtual void AddPluginsLoaders(MvxLoaderPluginRegistry loaders)
		{
			// none added by default
		}

        protected sealed override MvxViewsContainer CreateViewsContainer()
        {
			var container = new MvxMacViewsContainer();
            RegisterTouchViewCreator(container);            
            return container;
        }

        protected void RegisterTouchViewCreator(MvxMacViewsContainer container)
        {
            Mvx.RegisterSingleton<IMvxMacViewCreator>(container);
        }

		protected override IMvxViewDispatcher CreateViewDispatcher()
		{
			return new MvxMacViewDispatcher(_presenter);
		}

		protected override void InitializePlatformServices ()
		{
			Mvx.RegisterSingleton<IMvxLifetime>(_applicationDelegate);
		}

		protected override void InitializeLastChance()
		{
			InitialiseBindingBuilder();
			base.InitializeLastChance();
		}
		
		protected virtual void InitialiseBindingBuilder()
		{
			var bindingBuilder = CreateBindingBuilder();
			bindingBuilder.DoRegistration();
		}
		
		protected virtual MvxBindingBuilder CreateBindingBuilder()
		{
			var bindingBuilder = new MvxMacBindingBuilder(FillTargetFactories, FillValueConverters, FillBindingNames);
			return bindingBuilder;
		}
		
		protected virtual void FillValueConverters(IMvxValueConverterRegistry registry)
		{
			registry.Fill(ValueConverterAssemblies);
			registry.Fill(ValueConverterHolders);
		}

		protected virtual List<Type> ValueConverterHolders
		{
			get { return new List<Type>(); }
		}

		protected virtual List<Assembly> ValueConverterAssemblies
		{
			get
			{
				var toReturn = new List<Assembly>();
				toReturn.AddRange(GetViewModelAssemblies());
				toReturn.AddRange(GetViewAssemblies());
				return toReturn;
			}
		}

		protected virtual void FillBindingNames (IMvxBindingNameRegistry registry)
		{

		}
		
		protected virtual void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
		{
			// this base class does nothing
		}   
	}
}