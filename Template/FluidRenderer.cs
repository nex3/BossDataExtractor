using Fluid;
using Fluid.Values;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using WebMarkupMin.Core;

public class FluidRenderer
{
    private static readonly FluidParser fluid = new();

    private static readonly string templateRoot = Path.Combine(
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
        @"Template"
    );

    private static TemplateOptions MakeOptions()
    {
        TemplateOptions options = new()
        {
            MemberAccessStrategy = UnsafeMemberAccessStrategy.Instance,
            FileProvider = new PhysicalFileProvider(templateRoot),
        };
        options.Filters.AddFilter("spaceToPlus", (input, args, context) =>
            new StringValue(input.ToStringValue().Replace(' ', '+')));
        options.Filters.AddFilter("number", (input, args, context) =>
            new StringValue($"{input.ToNumberValue():n0}"));
        options.Filters.AddFilter("slugify", (input, args, context) =>
            new StringValue(Regex.Replace(
                input.ToStringValue().ToLower().Replace("'s", "s"),
                @"[^a-z0-9]+", "-")
            ));
        options.Filters.AddFilter("noXCount", (input, args, context) =>
            new StringValue(Regex.Replace(input.ToStringValue(), @" x[0-9]+$", "")));
        options.Filters.AddFilter("onlyXCount", (input, args, context) =>
            new StringValue(Regex.Replace(input.ToStringValue(), @"(.*?)( x[0-9]+)?$", "$2")));
        options.Filters.AddFilter("iconify", (input, args, context) => {
            var text = input.ToStringValue();
            var boss = (args.At(0).ToObjectValue() as Boss)!;
            return new StringValue(text switch
            {
                "Strong Affinity Reward" or "Weak Affinity Reward" =>
                    boss.Affinity is IconLink affinity
                    ? text.Replace("Affinity", affinity.Image + affinity.Name)
                    : text,
                "Strong Standard Reward" or "Weak Standard Reward" =>
                    text.Replace("Standard", DamageType.Physical.Image + "Standard"),
                "Strong Crater Reward" or "Weak Crater Reward" =>
                    text.Replace("Crater", ShiftingEarth.Crater.Image + "Crater"),
                "Noklateo Reward" => ShiftingEarth.Noklateo.Image + text,
                "Mountaintops Reward" => ShiftingEarth.Mountaintops.Image + text,
                _ => text,
            });
        });
        return options;
    }

    private static readonly TemplateOptions options = MakeOptions();

    public static string RenderTemplate(string name, object model)
    {
        string path = options.FileProvider.GetFileInfo(name + ".liquid").PhysicalPath!;
        var template = fluid.Parse(File.ReadAllText(path));
        return template.Render(new TemplateContext(model, options));
    }

    public static string RenderBoss(
        Display displayType,
        Boss boss,
        List<Boss>? bossGroup = null,
        bool minify = false,
        bool eldenRing = false
    )
    {
        var html = RenderTemplate(
            Enum.GetName(typeof(Display), displayType),
            new Context(displayType, boss, bossGroup, eldenRing)
        );
        return minify ? new HtmlMinifier().Minify(html).MinifiedContent : html;
    }
}
