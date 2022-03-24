﻿using System;
using DryIoc;
using xam.course.example1.Features.Contacts;
using xam.course.example1.Services;
using Xam.Zero;
using Xam.Zero.DryIoc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace xam.course.example1
{
    public partial class App : Application
    {
        public static readonly Container Container = new Container(rules =>
        {
            rules = rules.WithDefaultIfAlreadyRegistered(IfAlreadyRegistered.Keep);
            return rules.WithoutFastExpressionCompiler();
        });
        
        public App()
        {
            InitializeComponent();
            
            Container.Register<IContactService,ContactService>(Reuse.Singleton);
            ZeroApp.On(this)
                .WithContainer(DryIocZeroContainer.Build(Container))
                .StartWithPage<ContactsPage>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}