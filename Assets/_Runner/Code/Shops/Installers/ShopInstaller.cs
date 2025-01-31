﻿using UnityEngine;

namespace Game.Shops.Installers
{
public static class ShopInstaller
{
    private const string ResourcesSettingsPath = "Shop/ProductsConfig";
    private static readonly ProductsSettingsCollections Settings;

    static ShopInstaller()
    {
        Settings = LoadProductsFromResources();
    }

    private static ProductsSettingsCollections LoadProductsFromResources()
    {
        var so = Resources.Load<ProductsSettingsCollections>(ResourcesSettingsPath);
        if (so == null)
        {
            Log.Error($"Can't load localization so settings. Path to so: {ResourcesSettingsPath}");

            return default;
        }

        return so;
    }

    public static IShopManager IAP()
    {
        return new IAPShopManager(Settings.products);
    }
}
}