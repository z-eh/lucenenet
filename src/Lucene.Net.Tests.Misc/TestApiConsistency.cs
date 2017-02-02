﻿using Lucene.Net.Attributes;
using Lucene.Net.Util;
using NUnit.Framework;
using System;

namespace Lucene.Net.Tests.Misc
{
    /// <summary>
    /// LUCENENET specific tests for ensuring API conventions are followed
    /// </summary>
    public class TestApiConsistency : ApiScanTestBase
    {
        [Test, LuceneNetSpecific]
        [TestCase(typeof(Lucene.Net.Misc.SweetSpotSimilarity))]
        public override void TestProtectedFieldNames(Type typeFromTargetAssembly)
        {
            base.TestProtectedFieldNames(typeFromTargetAssembly);
        }

        [Test, LuceneNetSpecific]
        [TestCase(typeof(Lucene.Net.Misc.SweetSpotSimilarity))]
        public override void TestPrivateFieldNames(Type typeFromTargetAssembly)
        {
            base.TestPrivateFieldNames(typeFromTargetAssembly, @"Snowball\.Ext\..+Stemmer");
        }

        [Test, LuceneNetSpecific]
        [TestCase(typeof(Lucene.Net.Misc.SweetSpotSimilarity))]
        public override void TestPublicFields(Type typeFromTargetAssembly)
        {
            base.TestPublicFields(typeFromTargetAssembly);
        }

        [Test, LuceneNetSpecific]
        [TestCase(typeof(Lucene.Net.Misc.SweetSpotSimilarity))]
        public override void TestMethodParameterNames(Type typeFromTargetAssembly)
        {
            base.TestMethodParameterNames(typeFromTargetAssembly);
        }

        [Test, LuceneNetSpecific]
        [TestCase(typeof(Lucene.Net.Misc.SweetSpotSimilarity))]
        public override void TestInterfaceNames(Type typeFromTargetAssembly)
        {
            base.TestInterfaceNames(typeFromTargetAssembly);
        }

        [Test, LuceneNetSpecific]
        [TestCase(typeof(Lucene.Net.Misc.SweetSpotSimilarity))]
        public override void TestClassNames(Type typeFromTargetAssembly)
        {
            base.TestClassNames(typeFromTargetAssembly);
        }

        [Test, LuceneNetSpecific]
        [TestCase(typeof(Lucene.Net.Misc.SweetSpotSimilarity))]
        public override void TestForPropertiesWithNoGetter(Type typeFromTargetAssembly)
        {
            base.TestForPropertiesWithNoGetter(typeFromTargetAssembly);
        }

        [Test, LuceneNetSpecific]
        [TestCase(typeof(Lucene.Net.Misc.SweetSpotSimilarity))]
        public override void TestForPropertiesThatReturnArray(Type typeFromTargetAssembly)
        {
            base.TestForPropertiesThatReturnArray(typeFromTargetAssembly);
        }

        [Test, LuceneNetSpecific]
        [TestCase(typeof(Lucene.Net.Misc.SweetSpotSimilarity))]
        public override void TestForMethodsThatReturnWritableArray(Type typeFromTargetAssembly)
        {
            base.TestForMethodsThatReturnWritableArray(typeFromTargetAssembly);
        }

        [Test, LuceneNetSpecific]
        [TestCase(typeof(Lucene.Net.Misc.SweetSpotSimilarity))]
        public override void TestForPublicMembersContainingComparer(Type typeFromTargetAssembly)
        {
            base.TestForPublicMembersContainingComparer(typeFromTargetAssembly);
        }

        [Test, LuceneNetSpecific]
        [TestCase(typeof(Lucene.Net.Misc.SweetSpotSimilarity))]
        public override void TestForPublicMembersNamedSize(Type typeFromTargetAssembly)
        {
            base.TestForPublicMembersNamedSize(typeFromTargetAssembly);
        }

        [Test, LuceneNetSpecific]
        [TestCase(typeof(Lucene.Net.Misc.SweetSpotSimilarity))]
        public override void TestForPublicMembersContainingNonNetNumeric(Type typeFromTargetAssembly)
        {
            base.TestForPublicMembersContainingNonNetNumeric(typeFromTargetAssembly);
        }

        [Test, LuceneNetSpecific]
        [TestCase(typeof(Lucene.Net.Misc.SweetSpotSimilarity))]
        public override void TestForPublicMembersWithNullableEnum(Type typeFromTargetAssembly)
        {
            base.TestForPublicMembersWithNullableEnum(typeFromTargetAssembly);
        }

        // LUCENENET NOTE: This test is only for identifying members who were changed from
        // ICollection, IList or ISet to IEnumerable during the port (that should be changed back)
        //[Test, LuceneNetSpecific]
        //[TestCase(typeof(Lucene.Net.Misc.SweetSpotSimilarity))]
        //public override void TestForMembersAcceptingOrReturningIEnumerable(Type typeFromTargetAssembly)
        //{
        //    base.TestForMembersAcceptingOrReturningIEnumerable(typeFromTargetAssembly);
        //}

        [Test, LuceneNetSpecific]
        [TestCase(typeof(Lucene.Net.Misc.SweetSpotSimilarity))]
        public override void TestForMembersAcceptingOrReturningListOrDictionary(Type typeFromTargetAssembly)
        {
            base.TestForMembersAcceptingOrReturningListOrDictionary(typeFromTargetAssembly);
        }
    }
}