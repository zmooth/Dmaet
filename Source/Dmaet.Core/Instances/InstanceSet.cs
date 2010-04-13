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
    public sealed class InstanceSet
    {
        /// <summary>
        ///
        /// </summary>
        private List<IInstance> instances = new List<IInstance> ();
        /// <summary>
        ///
        /// </summary>
        private List<IAttribute> attributes = new List<IAttribute> ();
        /// <summary>
        ///
        /// </summary>
        private Dictionary<string, IAttribute> nameToAttributeMapping = new Dictionary<string, IAttribute> ();
        /// <summary>
        ///
        /// </summary>
        private Dictionary<IAttribute, List<double>> attributeValues = new Dictionary<IAttribute, List<double>> ();
        /// <summary>
        ///
        /// </summary>
        private int classAttributeIndex = -1;

        /// <summary>
        ///
        /// </summary>
        public InstanceSet ()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="attributes">
        /// A <see cref="List<IAttribute>"/>
        /// </param>
        public InstanceSet (List<IAttribute> attributes)
        {
            this.attributes = attributes;

            int classIndex = 0;
            foreach (IAttribute attribute in this.attributes)
            {
                this.nameToAttributeMapping[attribute.Name] = attribute;
                if (attribute.IsClassAttribute)
                    this.classAttributeIndex = classIndex;
                ++this.classAttributeIndex;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public int NumberOfAttributes {
            get { return this.attributes.Count; }
        }

        /// <summary>
        ///
        /// </summary>
        public int ClassAttributeIndex {
            get { return this.classAttributeIndex; }
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
        /// <param name="instance">
        /// A <see cref="IInstance"/>
        /// </param>
        public void AddInstance (IInstance instance)
        {
            this.instances.Add (instance);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="attributeName">
        /// A <see cref="System.String"/>
        /// </param>
        /// <returns>
        /// A <see cref="IAttribute"/>
        /// </returns>
        public IAttribute GetAttributeByName (string attributeName)
        {
            return this.nameToAttributeMapping[attributeName];
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
        public int GetIndexOfAttribute (IAttribute attribute)
        {
            return this.attributes.IndexOf (attribute);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="attribute">
        /// A <see cref="IAttribute"/>
        /// </param>
        /// <returns>
        /// A <see cref="List<System.Double>"/>
        /// </returns>
        public List<double> GetValuesForAttribute (IAttribute attribute)
        {
            if (this.attributeValues.ContainsKey (attribute))
                return this.attributeValues[attribute];

            List<double> result = new List<double> ();
            
            foreach (IInstance instance in this.instances)
                result.Add (instance.GetValueForAttribute (attribute));
            
            if (!this.attributeValues.ContainsKey (attribute))
                this.attributeValues[attribute] = result;
            
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="attributeName">
        /// A <see cref="System.String"/>
        /// </param>
        /// <returns>
        /// A <see cref="List<System.Double>"/>
        /// </returns>
        public List<double> GetValuesForAttribute (string attributeName)
        {
            return GetValuesForAttribute (GetAttributeByName (attributeName));
        }
    }
}
