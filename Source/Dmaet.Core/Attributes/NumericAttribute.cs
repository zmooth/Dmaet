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

namespace Dmaet.Core.Attributes
{
    /// <summary>
    ///
    /// </summary>
    public sealed class NumericAttribute : IAttribute
    {
        /// <summary>
        ///
        /// </summary>
        private double lowerBound = double.NegativeInfinity;
        /// <summary>
        ///
        /// </summary>
        private double upperBound = double.PositiveInfinity;
        /// <summary>
        ///
        /// </summary>
        private bool lowerBoundIsOpen = true;
        /// <summary>
        ///
        /// </summary>
        private bool upperBoundIsOpen = true;

        /// <summary>
        ///
        /// </summary>
        /// <param name="name">
        /// A <see cref="System.String"/>
        /// </param>
        /// <param name="value">
        /// A <see cref="System.Double"/>
        /// </param>
        public NumericAttribute (string name) : this(name, false)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name">
        /// A <see cref="System.String"/>
        /// </param>
        /// <param name="value">
        /// A <see cref="System.Double"/>
        /// </param>
        /// <param name="isClassAttribute">
        /// A <see cref="System.Boolean"/>
        /// </param>
        public NumericAttribute (string name, bool isClassAttribute) : base(name, isClassAttribute)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public double LowerBound {
            get { return this.lowerBound; }
        }

        /// <summary>
        ///
        /// </summary>
        public double UpperBound {
            get { return this.upperBound; }
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
            if (this.upperBoundIsOpen && value >= this.upperBound)
                return false;
            if (this.lowerBoundIsOpen && value <= this.lowerBound)
                return false;
            return value < this.upperBound && value > this.lowerBound;
        }

        /// <summary>
        ///     Creates a deep copy of the attribute.
        /// </summary>
        /// <returns>
        ///     A deep copy equal to this attribute.
        /// </returns>
        public override IAttribute Copy ()
        {
            NumericAttribute copy = new NumericAttribute (this.Name, this.IsClassAttribute);
            base.FillCopy (copy);
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
            return base.AttributeEquals (other);
        }
    }
}
