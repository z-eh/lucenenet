﻿using Lucene.Net.Index;
using Lucene.Net.Queries.Function;
using System.Collections;
using System.Collections.Generic;
using JCG = J2N.Collections.Generic;

namespace Lucene.Net.Spatial.Util
{
    /*
     * Licensed to the Apache Software Foundation (ASF) under one or more
     * contributor license agreements.  See the NOTICE file distributed with
     * this work for additional information regarding copyright ownership.
     * The ASF licenses this file to You under the Apache License, Version 2.0
     * (the "License"); you may not use this file except in compliance with
     * the License.  You may obtain a copy of the License at
     *
     *     http://www.apache.org/licenses/LICENSE-2.0
     *
     * Unless required by applicable law or agreed to in writing, software
     * distributed under the License is distributed on an "AS IS" BASIS,
     * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     * See the License for the specific language governing permissions and
     * limitations under the License.
     */

    /// <summary>
    /// Caches the doubleVal of another value source in a HashMap
    /// so that it is computed only once.
    /// @lucene.internal
    /// </summary>
    public class CachingDoubleValueSource : ValueSource
    {
        protected readonly ValueSource m_source;
        protected readonly IDictionary<int, double> m_cache;
        
        public CachingDoubleValueSource(ValueSource source)
        {
            this.m_source = source;
            m_cache = new JCG.Dictionary<int, double>();
        }

        public override string GetDescription()
        {
            return "Cached[" + m_source.GetDescription() + "]";
        }

        public override FunctionValues GetValues(IDictionary context, AtomicReaderContext readerContext)
        {
            int @base = readerContext.DocBase;
            FunctionValues vals = m_source.GetValues(context, readerContext);
            return new CachingDoubleFunctionValue(@base, vals, m_cache);
        }

        #region Nested type: CachingDoubleFunctionValue

        internal class CachingDoubleFunctionValue : FunctionValues
        {
            private readonly IDictionary<int, double> cache;
            private readonly int docBase;
            private readonly FunctionValues values;

            public CachingDoubleFunctionValue(int docBase, FunctionValues vals, IDictionary<int, double> cache)
            {
                this.docBase = docBase;
                values = vals;
                this.cache = cache;
            }

            public override double DoubleVal(int doc)
            {
                int key = docBase + doc;
                double v;
                if (!cache.TryGetValue(key, out v))
                {
                    v = values.DoubleVal(doc);
                    cache[key] = v;
                }
                return v;
            }

            /// <summary>
            /// NOTE: This was floatVal() in Lucene
            /// </summary>
            public override float SingleVal(int doc)
            {
                return (float)DoubleVal(doc);
            }

            public override string ToString(int doc)
            {
                return DoubleVal(doc) + string.Empty;
            }
        }

        #endregion

        public override bool Equals(object o)
        {
            if (this == o) return true;

            var that = o as CachingDoubleValueSource;

            if (that == null) return false;
            if (m_source != null ? !m_source.Equals(that.m_source) : that.m_source != null) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return m_source != null ? m_source.GetHashCode() : 0;
        }
    }
}