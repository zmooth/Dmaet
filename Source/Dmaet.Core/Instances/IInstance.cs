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

using System.Collections.Generic;
using Dmaet.Core.Attributes;

namespace Dmaet.Core.Instances
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInstance : ICopyable<IInstance>
    {
        /// <summary>
        ///
        /// </summary>
        int ClassAttributeIndex { get; }
        /// <summary>
        ///
        /// </summary>
        ICollection<IAttribute> Attributes { get; }
        /// <summary>
        ///     Gets the class attribute
        /// </summary>
        IAttribute ClassAttribute { get; }
        /// <summary>
        ///     Returns an instance's class value as a floating-point number.
        /// </summary>
        double ClassValue { get; }
        /// <summary>
        ///     Gets the number of attributes
        /// </summary>
        int NumberOfAttributes { get; }
        /// <summary>
        ///
        /// </summary>
        /// <param name="attribute">
        /// A <see cref="IAttribute"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.Double"/>
        /// </returns>
        double GetValueForAttribute (IAttribute attribute);
    }
}
