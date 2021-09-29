// <copyright file="AwesomeInventoryTabBase.cs" company="Zizhen Li">
// Copyright (c) 2019 - 2020 Zizhen Li. All rights reserved.
// Licensed under the LGPL-3.0-only license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AwesomeInventory.HarmonyPatches;
using RimWorld;
using UnityEngine;
using Verse;

namespace AwesomeInventory.UI
{
    /// <summary>
    /// Replace RimWorld's default gear tab.
    /// </summary>
    public static class AwesomeInventoryTabBase
    {

        private const BindingFlags _nonPublicInstance = BindingFlags.NonPublic | BindingFlags.Instance;

        /// <summary>
        /// Gets InterfaceDrop method from base class.
        /// </summary>
        public static MethodInfo InterfaceDrop { get; } =
            typeof(ITab_Pawn_Gear).GetMethod("InterfaceDrop", _nonPublicInstance);

        /// <summary>
        /// Gets InterfaceIngest method from base class.
        /// </summary>
        public static MethodInfo InterfaceIngest { get; } =
            typeof(ITab_Pawn_Gear).GetMethod("InterfaceIngest", _nonPublicInstance);

        /// <summary>
        /// Gets ShouldShowInventory method from base class.
        /// </summary>
        public static MethodInfo ShouldShowInventory { get; } =
            typeof(ITab_Pawn_Gear).GetMethod("ShouldShowInventory", _nonPublicInstance);

        /// <summary>
        /// Gets ShouldShowApparel method from base class.
        /// </summary>
        public static MethodInfo ShouldShowApparel { get; } =
            typeof(ITab_Pawn_Gear).GetMethod("ShouldShowApparel", _nonPublicInstance);

        /// <summary>
        /// Gets ShouldShowEquipment method from base class.
        /// </summary>
        public static MethodInfo ShouldShowEquipment { get; } =
            typeof(ITab_Pawn_Gear).GetMethod("ShouldShowEquipment", _nonPublicInstance);

        /// <summary>
        /// Gets CanControlColonist property from base class.
        /// </summary>
        public static PropertyInfo CanControlColonist { get; } =
            typeof(ITab_Pawn_Gear).GetProperty("CanControlColonist", _nonPublicInstance);

        /// <summary>
        /// Gets CanControl property from base class.
        /// </summary>
        public static PropertyInfo CanControl { get; } =
            typeof(ITab_Pawn_Gear).GetProperty("CanControl", _nonPublicInstance);

        /// <summary>
        /// Gets private property SelPawnForGear from <see cref="ITab_Pawn_Gear"/>.
        /// </summary>
        public static PropertyInfo GetPawn { get; } =
            typeof(ITab_Pawn_Gear).GetProperty("SelPawnForGear", _nonPublicInstance);
    }
}
