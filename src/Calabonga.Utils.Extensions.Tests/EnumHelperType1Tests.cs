using System.Runtime.Serialization;
using Shouldly;

namespace Calabonga.Utils.Extensions.Tests
{
    public class EnumHelperType1Tests
    {

        [Fact]
        [Trait("EnumHelper", "Parsing")]
        public void ItShould_be_under_testing()
        {
            // arrange

            // act
            var sut = EnumHelper<TestType>.Parse("Value");

            // assert
            sut.ShouldBe(TestType.Value);
        }

        [Fact]
        [Trait("EnumHelper", "Parsing")]
        public void ItShould_extract_attribute_by_type()
        {
            // arrange

            var value = TestType.Multiple;

            // act
            var sut = EnumHelper<TestType>.TryGetFromAttribute<EnumMemberAttribute>(value);

            // assert
            sut.Value.ShouldBe(TestType.Multiple.ToString());
        }

        [Fact]
        [Trait("EnumHelper", "Parsing")]
        public void ItShould_extract_attribute_by_string()
        {
            // arrange

            var value = TestType.Multiple;

            // act
            var sut = EnumHelper<TestType>.TryGetFromAttribute<EnumMemberAttribute>(value.ToString());

            // assert
            sut.Value.ShouldBe(TestType.Multiple.ToString());
        }

        [Fact]
        [Trait("EnumHelper", "Parsing")]
        public void ItShould_be_parsed_but_not_equals_to_Value()
        {
            // arrange

            // act
            var sut = EnumHelper<TestType>.Parse("Multiple");

            // assert
            sut.ShouldNotBe(TestType.Value);
        }

        [Fact]
        [Trait("EnumHelper", "Parsing")]
        public void ItShould_not_be_parsed()
        {
            // arrange

            // act

            // assert
            Assert.Throws<ArgumentException>(() => EnumHelper<TestType>.Parse("NOT_FOUND"));
        }

        [Fact]
        [Trait("EnumHelper", "Parsing")]
        public void ItShould_parse_DisplayAttribute()
        {
            // arrange

            // act
            var sut = EnumHelper<TestType>.Parse("��������");

            // assert
            sut.ShouldBe(TestType.Value);
        }

        [Fact]
        [Trait("EnumHelper", "Parsing")]
        public void ItShould_parse_None()
        {
            // arrange

            // act
            var sut = EnumHelper<TestType>.Parse("None");

            // assert
            sut.ShouldBe(TestType.None);
        }

        [Fact]
        [Trait("EnumHelper", "Parsing")]
        public void ItShould_parse_DisplayAttribute_None()
        {
            // arrange

            // act
            var sut = EnumHelper<TestType>.Parse("�� ����������");

            // assert
            sut.ShouldBe(TestType.None);
        }

        [Fact]
        [Trait("EnumHelper", "Parsing")]
        public void ItShould_parse_DisplayAttribute_Multiple()
        {
            // arrange

            // act
            var sut = EnumHelper<TestType>.Parse("�������� 2");

            // assert
            sut.ShouldBe(TestType.Value);
        }

        [Fact]
        [Trait("EnumHelper", "Parsing")]
        public void ItShould_parse_Simple_as_string()
        {
            // arrange

            // act
            var sut = EnumHelper<TestType>.Parse("Simple");

            // assert
            sut.ShouldBe(TestType.Simple);
        }

        [Theory]
        [Trait("EnumHelper", "Parsing")]
        [InlineData(TestType.Value, "��������")]
        [InlineData(TestType.Simple, "�������")]
        [InlineData(TestType.Simple, "�������1")]
        [InlineData(TestType.Simple, "�������2")]
        [InlineData(TestType.Simple, "�������3")]
        public void ItShould_parse_DisplayAttribute_Simple_as_string(TestType expected, string actual)
        {
            // arrange

            // act
            var sut = EnumHelper<TestType>.Parse(actual);

            // assert
            sut.ShouldBe(expected);
        }


        [Trait("EnumHelper", "Parsing")]
        [Theory]
        [InlineData("�������1")]
        [InlineData("�������2")]
        [InlineData("�������3")]
        public void ItShould_parse_DisplayNamesAttribute_Simple(string actual)
        {
            // arrange

            // act
            var sut = EnumHelper<TestType>.Parse(actual);

            // assert
            sut.ShouldBe(TestType.Simple);
        }
    }
}