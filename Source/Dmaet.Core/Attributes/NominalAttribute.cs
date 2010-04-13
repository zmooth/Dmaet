/// Copyright (c) 2010, Matthias Hannen & Simon Wollwage
/// All rights reserved.
///
/// Redistribution and use in source and binary forms, with or without
/// modification, are permitted provided that the following conditions are met:
///     * Redistributions of source code must retain the above copyright
///       notice, this list of conditions and the following disclaimer.
///     * Redistributions in binary form must reproduce the above copyright
///       notice, this list of conditions and the following disclaimer in the
///       documentation and/or other materials provided with the distribution.
///     * Neither the name of the <organization> nor the
///       names of its contributors may be used to endorse or promote products
///       derived from this software without specific prior written permission.
///
/// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
/// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
/// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
/// DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
/// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
/// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
/// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
/// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
/// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
/// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Collections.Generic;

namespace Dmaet.Core.Attributes
{
    /// <summary>
    ///
    /// </summary>
    public class NominalAttribute : IAttribute
    {
        /// <summary>
        ///
        /// </summary>
        private Dictionary<string, int> valueMappings = new Dictionary<string, int> ();

        /// <summary>
        ///
        /// </summary>
        /// <param name="name">
        /// <param values="values">
        /// A <see cref="System.String"/>
        /// </param>
        public NominalAttribute (string name, Dictionary<string, int>.KeyCollection values) : this(name, values, false)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name">
        /// <param name="values">
        /// <param name="isClassAttribute">
        /// A <see cref="System.String"/>
        /// </param>
        public NominalAttribute (string name, Dictionary<string, int>.KeyCollection values, bool isClassAttribute) : base(name, isClassAttribute)
        {
            int index = 0;
            foreach (string key in values)
            {
                if (valueMappings.ContainsKey (key))
                    throw new ArgumentException ("A nominal attribute mustn't have duplicate values (" + name + ", " + key + ")", "values");
                else
                    valueMappings.Add (key, index++);
            }
        }

        public Dictionary<string, int>.KeyCollection Values {
            get { return this.valueMappings.Keys; }
        }

        /// <summary>
        ///
        /// </summary>
        public override int NumberOfValues {
            get { return this.valueMappings.Count; }
        }

        /// <summary>
        ///     Checks if the given value is inside the
        ///     attribute's range.
        /// </summary>
        /// <param name="value">
        ///     Value to check
        /// </param>
        /// <returns>
        ///     True if the value is inside the attribute's
        ///     range, False otherwise.
        /// </returns>
        public override bool IsValueInRange (double value)
        {
            return value >= 0.0 && value < this.valueMappings.Count;
        }

        public string LookUpValue (double value)
        {
            //TODO
            return null;
        }

        /// <summary>
        ///     Creates a deep copy of the attribute.
        /// </summary>
        /// <returns>
        ///     A deep copy equal to this attribute.
        /// </returns>
        public override IAttribute Copy ()
        {
            NominalAttribute copy = new NominalAttribute (this.Name, this.Values);
            base.FillCopy (copy);
            copy.valueMappings = new Dictionary<string, int> (this.valueMappings);
            
            return copy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other">
        /// A <see cref="IAttribute"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.Boolean"/>
        /// </returns>
        public override bool Equals (IAttribute other)
        {
            if (!(other is NominalAttribute))
                return false;
            
            foreach (string key in this.valueMappings.Keys) {
                if (!(other as NominalAttribute).valueMappings.ContainsKey (key))
                    return false;
                if ((other as NominalAttribute).valueMappings[key] != this.valueMappings[key])
                    return false;
            }
            
            return base.AttributeEquals (other);
        }
    }
}
