﻿// <copyright file="JobGiver_AwesomeInventory_OpportunisticHaul.cs" company="Zizhen Li">
// Copyright (c) 2019 - 2020 Zizhen Li. All rights reserved.
// Licensed under the LGPL-3.0-only license. See LICENSE.md file in the project root for full license information.
// </copyright>

using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.AI;

namespace AwesomeInventory.Jobs
{
    /// <summary>
    /// Use the smallest search radius to search items that can be hauled.
    /// </summary>
    public class JobGiver_AwesomeInventory_OpportunisticHaul : ThinkNode_JobGiver
    {
        private JobGiver_FindItemByRadius _parent;

        /// <summary>
        /// Give a haul job to <paramref name="pawn"/>.
        /// </summary>
        /// <param name="pawn"> Pawm that looks for a job. </param>
        /// <returns> A potential job for <paramref name="pawn"/>. </returns>
        public override Job TryGiveJob(Pawn pawn)
        {
            if (_parent == null)
            {
                _parent = parent is JobGiver_FindItemByRadius p ? p : throw new InvalidOperationException(ErrorText.WrongTypeParentThinkNode);
            }

            if (_parent.Itemfound)
            {
                ValidateArg.NotNull(pawn, nameof(pawn));

                List<WorkGiverDef> workGivers = WorkTypeDefOf.Hauling.workGiversByPriority;

                if (workGivers[0].Worker is WorkGiver_Scanner scanner)
                {
                    IEnumerable<Thing> enumerable = scanner.PotentialWorkThingsGlobal(pawn);
                    if (enumerable == null || enumerable.Any())
                    {
                        return null;
                    }

                    Thing thing = GenClosest.ClosestThing_Global_Reachable(
                          pawn.Position
                        , pawn.Map
                        , enumerable
                        , scanner.PathEndMode
                        , TraverseParms.For(pawn, scanner.MaxPathDanger(pawn))
                        , _parent.Radius[0]
                        , t => !t.IsForbidden(pawn) && scanner.HasJobOnThing(pawn, t));
                    if (thing != null)
                    {
                        return scanner.JobOnThing(pawn, thing);
                    }
                }
            }

            return null;
        }
    }
}
