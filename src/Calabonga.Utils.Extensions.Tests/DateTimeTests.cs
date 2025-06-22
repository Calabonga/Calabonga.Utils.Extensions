using Shouldly;

namespace Calabonga.Utils.Extensions.Tests;
public class DateTimeTests
{
    [Fact]
    [Trait("DateTimeExtensions", "Converting")]
    public void ItShould_Convert_to_short_from_week_en()
    {
        // arrange
        var dateStart = new DateTime(2025, 5, 15, 22, 44, 00);
        var dateEnd = new DateTime(2025, 6, 22, 20, 43, 14);
        var timeSpan = dateEnd - dateStart;

        // act
        var sut = timeSpan.ToJiraString();

        // assert
        sut.ShouldBe("5w 2d 21h 59m 14s");
    }

    [Fact]
    [Trait("DateTimeExtensions", "Converting")]
    public void ItShould_Convert_to_short_from_week_spacing_underscore_en()
    {
        // arrange
        var dateStart = new DateTime(2025, 5, 15, 22, 44, 00);
        var dateEnd = new DateTime(2025, 6, 22, 20, 43, 14);
        var timeSpan = dateEnd - dateStart;

        // act
        var sut = timeSpan.ToJiraString(spacing: Spacing.Underscore);

        // assert
        sut.ShouldBe("5w_2d_21h_59m_14s");
    }

    [Fact]
    [Trait("DateTimeExtensions", "Converting")]
    public void ItShould_Convert_to_short_from_week_spacing_dashed_en()
    {
        // arrange
        var dateStart = new DateTime(2025, 5, 15, 22, 44, 00);
        var dateEnd = new DateTime(2025, 6, 22, 20, 43, 14);
        var timeSpan = dateEnd - dateStart;

        // act
        var sut = timeSpan.ToJiraString(spacing: Spacing.Dashed);

        // assert
        sut.ShouldBe("5w-2d-21h-59m-14s");
    }

    [Fact]
    [Trait("DateTimeExtensions", "Converting")]
    public void ItShould_Convert_to_short_from_week_no_spacing_en()
    {
        // arrange
        var dateStart = new DateTime(2025, 5, 15, 22, 44, 00);
        var dateEnd = new DateTime(2025, 6, 22, 20, 43, 14);
        var timeSpan = dateEnd - dateStart;

        // act
        var sut = timeSpan.ToJiraString(spacing: Spacing.NoSpace);

        // assert
        sut.ShouldBe("5w2d21h59m14s");
    }

    [Fact]
    [Trait("DateTimeExtensions", "Converting")]
    public void ItShould_Convert_to_short_from_week_spacing_en()
    {
        // arrange
        var dateStart = new DateTime(2025, 5, 15, 22, 44, 00);
        var dateEnd = new DateTime(2025, 6, 22, 20, 43, 14);
        var timeSpan = dateEnd - dateStart;

        // act
        var sut = timeSpan.ToJiraString(spacing: Spacing.Space);

        // assert
        sut.ShouldBe("5w 2d 21h 59m 14s");
    }

    [Fact]
    [Trait("DateTimeExtensions", "Converting")]
    public void ItShould_Convert_to_short_from_week_ru()
    {
        // arrange
        var dateStart = new DateTime(2025, 5, 15, 22, 44, 00);
        var dateEnd = new DateTime(2025, 6, 22, 20, 43, 14);
        var timeSpan = dateEnd - dateStart;

        // act
        var sut = timeSpan.ToJiraString(cultureName: CultureName.Ru);

        // assert
        sut.ShouldBe("5н 2д 21ч 59м 14с");
    }

    [Fact]
    [Trait("DateTimeExtensions", "Converting")]
    public void ItShould_Convert_to_short_from_year_en()
    {
        // arrange
        var dateStart = new DateTime(2021, 5, 15, 22, 44, 00);
        var dateEnd = new DateTime(2025, 6, 22, 20, 43, 14);
        var timeSpan = dateEnd - dateStart;

        // act
        var sut = timeSpan.ToJiraString();

        // assert
        sut.ShouldBe("214w 0d 21h 59m 14s");
    }

    [Fact]
    [Trait("DateTimeExtensions", "Converting")]
    public void ItShould_Convert_to_short_from_year_ru()
    {
        // arrange
        var dateStart = new DateTime(2021, 5, 15, 22, 44, 00);
        var dateEnd = new DateTime(2025, 6, 22, 20, 43, 14);
        var timeSpan = dateEnd - dateStart;

        // act
        var sut = timeSpan.ToJiraString(cultureName: CultureName.Ru);

        // assert
        sut.ShouldBe("214н 0д 21ч 59м 14с");
    }

    [Fact]
    [Trait("DateTimeExtensions", "Extract date")]
    public void ItShould_return_GetMonthStartDay()
    {
        // arrange
        var expected = new DateTime(2025, 6, 1);
        var date = new DateTime(2025, 6, 22, 20, 43, 14);

        // act
        var sut = date.GetMonthStartDay();

        // assert
        sut.ShouldBe(expected);
    }

    [Fact]
    [Trait("DateTimeExtensions", "Extract date")]
    public void ItShould_return_GetMonthEndDay()
    {
        // arrange
        var expected = new DateTime(2025, 6, 30);
        var date = new DateTime(2025, 6, 22, 20, 43, 14);

        // act
        var sut = date.GetMonthEndDay();

        // assert
        sut.ShouldBe(expected);
    }

    [Fact]
    [Trait("DateTimeExtensions", "Extract date")]
    public void ItShould_return_GetWeekStartDay()
    {
        // arrange
        var expected = new DateTime(2025, 6, 16);
        var date = new DateTime(2025, 6, 22, 20, 43, 14);

        // act
        var sut = date.GetWeekStartDay();

        // assert
        sut.ShouldBe(expected);
    }

    [Fact]
    [Trait("DateTimeExtensions", "Extract date")]
    public void ItShould_return_GetWeekEndDay()
    {
        // arrange
        var expected = new DateTime(2025, 6, 22);
        var date = new DateTime(2025, 6, 22, 20, 43, 14);

        // act
        var sut = date.GetWeekEndDay();

        // assert
        sut.ShouldBe(expected);
    }
}
