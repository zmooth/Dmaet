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
        private double value;
        /// <summary>
        ///
        /// </summary>
        private double lowerBound;
        /// <summary>
        ///
        /// </summary>
        private double uppderBound;
        /// <summary>
        ///
        /// </summary>
        private bool lowerBoundIsOpen;
        /// <summary>
        ///
        /// </summary>
        private bool upperBoundIsOpen;

        /// <summary>
        ///
        /// </summary>
        /// <param name="name">
        /// A <see cref="System.String"/>
        /// </param>
        /// <param name="value">
        /// A <see cref="System.Double"/>
        /// </param>
        public NumericAttribute (string name, double value) : this(name, value, false)
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
        public NumericAttribute (string name, double value, bool isClassAttribute) : base(name, isClassAttribute)
        {
            this.value = value;
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
            get { return this.uppderBound; }
        }

        /// <summary>
        ///
        /// </summary>
        public override double Value {
            get { return this.value; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value">
        /// A <see cref="System.Double"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.Boolean"/>
        /// </returns>
        public override bool IsValueInRange (double value)
        {
            if (this.upperBoundIsOpen && value >= this.uppderBound)
                return false;
            if (this.lowerBoundIsOpen && value <= this.lowerBound)
                return false;
            return value < this.uppderBound && value > this.lowerBound;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns>
        /// A <see cref="IAttribute"/>
        /// </returns>
        public override IAttribute Copy ()
        {
            NumericAttribute copy = new NumericAttribute (this.Name, this.value, this.IsClassAttribute);
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
            return this.Value == other.Value && base.AttributeEquals (other);
        }
    }
}
