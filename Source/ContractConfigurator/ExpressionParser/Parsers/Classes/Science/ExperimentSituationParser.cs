using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using ContractConfigurator.Util;

namespace ContractConfigurator.ExpressionParser
{
    /// <summary>
    /// Expression parser subclass for Experiment.
    /// </summary>
    public class ExperimentSituationParser : EnumExpressionParser<ExperimentSituations>, IExpressionParserRegistrer
    {
        public void RegisterExpressionParsers()
        {
            RegisterParserType(typeof(ExperimentSituations), typeof(ExperimentSituationParser));
        }

        public ExperimentSituationParser()
        {
        }

        public override U ConvertType<U>(ExperimentSituations value)
        {
            return typeof(U) == typeof(string) ? (U)(object)value.Print() : base.ConvertType<U>(value);
        }
    }
}
