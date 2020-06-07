﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using EnsureThat;

namespace Microsoft.Health.Fhir.Ingest.Data
{
    public class CorrelationMeasurementObservationGroupFactory : IObservationGroupFactory<IMeasurementGroup>
    {
        public IEnumerable<IObservationGroup> Build(IMeasurementGroup input)
        {
            EnsureArg.IsNotNull(input, nameof(input));

            var observationGroup = new CorrelationMeasurementObservationGroup(input.CorrelationId);
            foreach (var m in input.Data)
            {
                observationGroup.AddMeasurement(m);
            }

            yield return observationGroup;
        }
    }
}