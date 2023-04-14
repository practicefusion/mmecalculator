using FluentAssertions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PracticeFusion.MmeCalculator.UnitTests.Services
{
    [TestClass]
    public class DistributedCacheExtensions
    {
        [TestMethod]
        public void ExistsHandlesExistenceCorrectly()
        {
            IDistributedCache cache = DefaultDistributedCache();
            Assert.IsFalse(cache.Exists("key"));
            cache.Set("key", "value");
            cache.Exists("key").Should().BeTrue();
        }

        [TestMethod]
        public void GetReturnsDefaultWhenValueIsNull()
        {
            IDistributedCache cache = DefaultDistributedCache();
            Assert.IsFalse(cache.Exists("key"));
            var result = cache.Get<List<string>>("key");
            result.Should().BeEquivalentTo(default);
        }

        [TestMethod]
        public void SetWritesToCacheCorrectly()
        {
            IDistributedCache cache = DefaultDistributedCache();
            Assert.IsFalse(cache.Exists("key"));

            // set up the entity to cache
            var entity = new List<string> { "test" };

            // cache it
            cache.Set("key", entity);

            // check it
            var result = cache.Get<List<string>>("key");

            result.Should().BeEquivalentTo(entity);
        }

        [TestMethod]
        public void SetWithOptionsWritesToCacheCorrectly()
        {
            IDistributedCache cache = DefaultDistributedCache();
            Assert.IsFalse(cache.Exists("key"));

            // set up the entity to cache
            var entity = new List<string> { "test" };

            // cache it
            var options = new DistributedCacheEntryOptions();
            TimeSpan timeSpan = TimeSpan.FromSeconds(10);
            options.SetSlidingExpiration(timeSpan);
            cache.Set("key", entity, options);

            // check it
            var result = cache.Get<List<string>>("key");

            result.Should().BeEquivalentTo(entity);
        }

        [TestMethod]
        public void SetWithOptionsExpiresCorrectly()
        {
            IDistributedCache cache = DefaultDistributedCache();
            Assert.IsFalse(cache.Exists("key"));

            // set up the entity to cache
            var entity = new List<string> { "test" };

            // cache it with an expiration of 5 milliseconds
            var options = new DistributedCacheEntryOptions();
            options.SetAbsoluteExpiration(TimeSpan.FromMilliseconds(5));
            cache.Set("key", entity, options);

            // check it
            cache.Exists("key").Should().BeTrue();

            // wait for 10 milliseconds
            Thread.Sleep(10);

            // check it
            cache.Exists("key").Should().BeFalse();
        }


        [TestMethod]
        public void GetReturnsTypedValueWhenValueIsPresent()
        {
            IDistributedCache cache = DefaultDistributedCache();
            Assert.IsFalse(cache.Exists("key"));

            // set up the entity to cache
            var entity = new List<string> { "test" };

            // cache it
            cache.Set("key", entity);

            // check it
            var result = cache.Get<List<string>>("key");

            result.Should().BeEquivalentTo(entity);
        }

        [TestMethod]
        public void TryGetValueReturnsTypedValueWhenValueIsPresent()
        {
            IDistributedCache cache = DefaultDistributedCache();
            Assert.IsFalse(cache.Exists("key"));

            // set up the entity to cache
            var entity = new List<string> { "test" };

            // cache it
            cache.Set("key", entity);

            // check it
            cache.TryGetValue("key", out List<string> result).Should().BeTrue();
            result.Should().BeEquivalentTo(entity);
        }

        [TestMethod]
        public void TryGetValueReturnsDefaultWhenValueIsNotPresent()
        {
            IDistributedCache cache = DefaultDistributedCache();
            Assert.IsFalse(cache.Exists("key"));

            // check it
            cache.TryGetValue("key", out List<string> result).Should().BeFalse();
            result.Should().BeEquivalentTo(default);
        }

        private static IDistributedCache DefaultDistributedCache()
        {
            IOptions<MemoryDistributedCacheOptions> options = Options.Create(new MemoryDistributedCacheOptions());
            IDistributedCache cache = new MemoryDistributedCache(options);
            return cache;
        }
    }
}