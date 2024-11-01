using System.ComponentModel.DataAnnotations;

namespace Calabonga.Utils.Extensions.Tests;

[Flags]
public enum TestType2
{
    [Display(Name = "Значение1")]
    Value1 = 1 << 1,

    [Display(Name = "Значение2")]
    Value2 = 1 << 2,

    [Display(Name = "Значение3")]
    Value3 = 1 << 3,

    [Display(Name = "Значение4")]
    Value4 = 1 << 4,

    [Display(Name = "Все")]
    All = Value1 | Value2 | Value3 | Value4

}