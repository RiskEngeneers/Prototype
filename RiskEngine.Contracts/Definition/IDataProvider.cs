﻿using System;
using System.Threading.Tasks;

namespace RiskEngine.Contracts.Definition
{
    public interface IDataProvider
    {
        string Name { get; }
        Type OutputType { get; }
        Type InputType { get; }
        object ProvideData(object input);
    }
}