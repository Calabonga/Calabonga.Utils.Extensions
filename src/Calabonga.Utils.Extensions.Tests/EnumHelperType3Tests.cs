using Shouldly;
using Xunit.Abstractions;

namespace Calabonga.Utils.Extensions.Tests
{
    public class EnumHelperType3Tests
    {
        private readonly ITestOutputHelper _outputHelper;

        public EnumHelperType3Tests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void GetValuesFromType_ShouldBe_Count_5()
        {
            var items = EnumHelper<TestType2>.GetValues();

            items.Count.ShouldBe(5);
        }

        [Fact]
        public void GetValuesFromType_Filtered_ShouldBe_Count_2()
        {
            var testType = TestType2.Value2 | TestType2.Value3;
            var items = EnumHelper<TestType2>.GetValues(testType).ToList();

            foreach (var item in items)
            {
                _outputHelper.WriteLine(item.ToString());
            }

            items.Count().ShouldBe(2);
        }

        [Fact]
        public void GetValuesFromType_ShouldBeNot_Count_6()
        {
            var items = EnumHelper<TestType2>.GetValues();

            items.Count.ShouldNotBe(6);
        }

        [Fact]
        public void GetValuesWithDisplayNames_ShouldReturn_Dictionary()
        {
            // arrange

            // act
            var sut = EnumHelper<TestType2>.GetValuesWithDisplayNames();
            _outputHelper.WriteLine(sut.ToString());
            // assert
            sut.ShouldBeAssignableTo<Dictionary<TestType2, string>>();
        }

        [Fact]
        public void GetValuesWithDisplayNames_WithParams_ShouldReturn_Dictionary()
        {
            // arrange

            // act
            var sut = EnumHelper<TestType2>.GetValuesWithDisplayNamesByMask(TestType2.Value1 | TestType2.Value2);

            // assert
            sut.ShouldBeAssignableTo<Dictionary<TestType2, string>>();
            sut.Count().ShouldBe(2);
        }

        [Fact]
        public void GetValuesWithDisplayNames_WithParams_ShouldReturn_Dictionary_WithValues1()
        {
            // arrange

            // act
            var sut = EnumHelper<TestType2>.GetValuesWithDisplayNamesByMask(TestType2.Value1 | TestType2.Value2);

            // assert
            sut.ShouldBeAssignableTo<Dictionary<TestType2, string>>();
            sut.Count().ShouldBe(2);
            sut[TestType2.Value1].ShouldBe("Значение1");
        }

        [Fact]
        public void GetValuesWithDisplayNames_WithParams_ShouldReturn_Dictionary_WithValues2()
        {
            // arrange

            // act
            var sut = EnumHelper<TestType2>.GetValuesWithDisplayNamesByMask(TestType2.Value2 | TestType2.Value4);

            // assert
            sut.ShouldBeAssignableTo<Dictionary<TestType2, string>>();
            sut.Count().ShouldBe(2);
        }
    }
}
