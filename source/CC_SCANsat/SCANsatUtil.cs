﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCANsat;
using UnityEngine;

namespace ContractConfigurator.SCANsat
{
    /// <summary>
    /// Utilities for interacting with SCANsat.
    /// </summary>
    public class SCANsatUtil
    {
        /// <summary>
        /// Validates the given SCANname and sees if SCANsat has a SCANtype that matches it.
        /// </summary>
        /// <param name="SCANname">The SCANname to validate.</param>
        /// <returns>Whether the validation succeeded, outputs an error if it did not.</returns>
        public static bool ValidateSCANname(string SCANname)
        {
            try
            {
                SCANUtil.GetSCANtype(SCANname);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return false;
            }

            return true;
        }
    }
}
