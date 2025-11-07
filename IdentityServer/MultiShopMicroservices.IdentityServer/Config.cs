// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShopMicroservices.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("ResourceCatalog")
                {
                    Scopes = { "CatalogFullPermission", "CatalogReadPermission" }
                },
                new ApiResource("ResourceDiscount")
                {
                    Scopes = { "DiscountFullPermission" }
                },
                new ApiResource("ResourceOrder")
                {
                    Scopes = { "OrderFullPermission", "OrderReadPermission" }
                },
                new ApiResource("ResourceCargo")
                {
                    Scopes = { "CargoFullPermission" }
                },
                new ApiResource("ResourceBasket")
                {
                    Scopes = { "BasketFullPermission" }
                },
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("CatalogFullPermission", "Full access to Catalog API"),
                new ApiScope("CatalogReadPermission", "Read access to Catalog API"),

                new ApiScope("DiscountFullPermission", "Full access to Discount API"),

                new ApiScope("OrderFullPermission", "Full access to Order API"),
                new ApiScope("OrderReadPermission", "Read access to Order API"),

                new ApiScope("CargoFullPermission", "Full access to Cargo API"),

                new ApiScope("BasketFullPermission", "Full access to Basket API"),

                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // Visitor
                new Client
                {
                    ClientId = "MultiShopVisitorId",
                    ClientName = "Multi Shop Visitor User",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                    AllowedScopes =
                    {
                        "CatalogReadPermission",
                        "OrderReadPermission"
                    }
                },

                // Manager
                new Client
                {
                    ClientId = "MultiShopManagerId",
                    ClientName = "Multi Shop Manager User",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                    AllowedScopes =
                    {
                        "CatalogFullPermission",
                        "CatalogReadPermission",
                        "OrderFullPermission"
                    }
                },

                // Admin
                new Client
                {
                    ClientId = "MultiShopAdminId",
                    ClientName = "Multi Shop Admin User",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                    AllowedScopes =
                    {
                        "CatalogFullPermission",
                        "CatalogReadPermission",
                        "DiscountFullPermission",
                        "OrderFullPermission",
                        "OrderReadPermission",
                        "CargoFullPermission",
                        "BasketFullPermission",
                        IdentityServerConstants.LocalApi.ScopeName,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    //AccessTokenLifetime = 600
                }
            };

    }
}