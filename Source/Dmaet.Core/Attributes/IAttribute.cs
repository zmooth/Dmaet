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
    public abstract class IAttribute : ICopyable<IAttribute>, IEquatable<IAttribute>
    {
        /// <summary>
        ///     The attribute's name
        /// </summary>
        private readonly string name;

        /// <summary>
        ///     True if the attribute is the class attribute
        /// </summary>
        private readonly bool isClassAttribute;

        /// <summary>
        ///
        /// </summary>
        /// <param name="name">
        ///     The attribute's name
        /// </param>
        public IAttribute (string name)
        {
            this.name = name;
            this.isClassAttribute = false;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name">
        ///     The attribute's name
        /// </param>
        /// <param name="isClassAttribute">
        ///     Is it a class attribute
        /// </param>
        public IAttribute (string name, bool isClassAttribute)
        {
            this.name = name;
            this.isClassAttribute = isClassAttribute;
        }

        /// <summary>
        ///     Gets the attribute's name
        /// </summary>
        public string Name {
            get { return this.name; }
        }

        /// <summary>
        ///     Checks if the attribute is a class attribute
        /// </summary>
        public bool IsClassAttribute {
            get { return this.isClassAttribute; }
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
        public abstract bool IsValueInRange (double value);

        /// <summary>
        ///     Creates a deep copy of the attribute.
        /// </summary>
        /// <returns>
        ///     A deep copy equal to this attribute.
        /// </returns>
        public abstract IAttribute Copy ();

        /// <summary>
        ///
        /// </summary>
        /// <param name="other">
        /// A <see cref="IAttribute"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.Boolean"/>
        /// </returns>
        public abstract bool Equals (IAttribute other);

        /// <summary>
        ///
        /// </summary>
        public virtual int NumberOfValues {
            get { return 0; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="attribute">
        /// A <see cref="IAttribute"/>
        /// </param>
        protected void FillCopy (IAttribute attribute)
        {
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
        protected bool AttributeEquals (IAttribute other)
        {
            return this.Name == other.Name && this.IsClassAttribute == other.IsClassAttribute;
        }
    }
}
