﻿using System;
using System.Net.Http;
using Meerkat.Net.Http;
using Meerkat.Security;
using Meerkat.Security.Authentication;
using Meerkat.Security.Authentication.Hmac;
using Microsoft.Practices.Unity;

namespace Sample.Client
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ISecretStore, SecretStore>();
            container.RegisterType<IMessageRepresentationBuilder, HmacMessageRepresentationBuilder>();
            container.RegisterType<ISignatureCalculator, HmacSignatureCalculator>();

            container.RegisterType<HmacSigningHandler>();
        }
    }
}
