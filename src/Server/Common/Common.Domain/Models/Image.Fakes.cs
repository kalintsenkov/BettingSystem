namespace BettingSystem.Domain.Common.Models;

using System;
using Bogus;
using FakeItEasy;

public class ImageFakes
{
    public class ImagesDummyFactory : IDummyFactory
    {
        public bool CanCreate(Type type) => type == typeof(Image);

        public object? Create(Type type) => new Faker<Image>()
            .CustomInstantiator(f => new Image(
                f.Random.Bytes(f.Random.Number()),
                f.Random.Bytes(f.Random.Number())))
            .Generate();

        public Priority Priority => Priority.Default;
    }
}