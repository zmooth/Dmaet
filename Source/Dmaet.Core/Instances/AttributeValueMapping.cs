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
    public class AttributeValueMapping : ICopyable<AttributeValueMapping>
    {
        /// <summary>
        ///
        /// </summary>
        private List<IAttribute> attributes = new List<IAttribute> ();
        /// <summary>
        ///
        /// </summary>
        private List<double> values = new List<double> ();

        /// <summary>
        ///
        /// </summary>
        public AttributeValueMapping ()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="attributes">
        /// A <see cref="List<IAttribute>"/>
        /// </param>
        /// <param name="values">
        /// A <see cref="List<System.Double>"/>
        /// </param>
        public AttributeValueMapping (List<IAttribute> attributes, List<double> values)
        {
            foreach (IAttribute attribute in attributes)
                this.attributes.Add (attribute.Copy ());
            this.values = new List<double> (values);
        }

        /// <summary>
        ///
        /// </summary>
        public List<IAttribute> Attributes {
            get { return this.attributes; }
        }

        /// <summary>
        ///
        /// </summary>
        public List<double> Values {
            get { return this.values; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count {
            get { return this.attributes.Count; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="attribute">
        /// A <see cref="IAttribute"/>
        /// </param>
        /// <param name="val">
        /// A <see cref="System.Double"/>
        /// </param>
        public void Add (IAttribute attribute, double val)
        {
            if (this.attributes.Contains (attribute))
                return;

            this.attributes.Add (attribute);
            this.values.Add (val);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="attribute">
        /// A <see cref="IAttribute"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.Double"/>
        /// </returns>
        public double GetValue (IAttribute attribute)
        {
            return this.values[IndexOf (attribute)];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">
        /// A <see cref="System.Int32"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.Double"/>
        /// </returns>
        public double GetValue (int index)
        {
            if (index < 0 || index >= this.values.Count)
                throw new System.IndexOutOfRangeException ();
            
            return this.values[index];
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="attribute">
        /// A <see cref="IAttribute"/>
        /// </param>
        /// <param name="val">
        /// A <see cref="System.Double"/>
        /// </param>
        public void SetValue (IAttribute attribute, double val)
        {
            this.values[IndexOf (attribute)] = val;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index">
        /// A <see cref="System.Int32"/>
        /// </param>
        /// <param name="val">
        /// A <see cref="System.Double"/>
        /// </param>
        public void SetValue (int index, double val)
        {
            this.values[index] = val;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="attribute">
        /// A <see cref="IAttribute"/>
        /// </param>
        public void Remove (IAttribute attribute)
        {
            int index = IndexOf (attribute);

            this.attributes.RemoveAt (index);
            this.values.RemoveAt (index);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="attribute">
        /// A <see cref="IAttribute"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.Int32"/>
        /// </returns>
        public int IndexOf (IAttribute attribute)
        {
            if (!this.attributes.Contains (attribute))
                throw new System.Exception ("Attribute not in list!");

            for (int i = 0; i < this.attributes.Count; ++i)
                if (attribute == this.attributes[i])
                    return i;
            throw new System.Exception ("Could not find attribute!");
        }

        /// <summary>
        ///     Creates a deep copy of the class.
        /// </summary>
        /// <returns>
        ///     A deep copy equal to this class.
        /// </returns>
        public AttributeValueMapping Copy ()
        {
            return new AttributeValueMapping (this.attributes, this.values);
        }
    }
}
