using System;
using FluentAssertions;
using NUnit.Framework;

namespace serialization.tests
{
    [TestFixture]
    public class SampleTests
    {
        [Test]
        public void serializes_the_class_name()
        {
            var someClass = new SomeClass();
            var serializer = new Serializer();

            var serializedString = serializer.Serialize(someClass);

            serializedString.Should().Be("SomeClass");
        }

        public class SomeClass
        {
        }

        [Test]
        public void serializes_public_getter_property()
        {
            var someClass = new ClassWithPublicAutoProperty() {SomeAutoProperty = "Foo"};
            var serializer = new Serializer();

            var serializedString = serializer.Serialize(someClass);

            serializedString.Should().Be(string.Format("ClassWithPublicAutoProperty{0}{1}SomeAutoProperty:{2}Foo", Environment.NewLine, "\t", " "));
        }

        public class ClassWithPublicAutoProperty
        {
            public string SomeAutoProperty { get; set; }
        }
    }
}