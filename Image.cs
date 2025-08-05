using System.Runtime.CompilerServices;

public abstract class Image
{
    public abstract string ToHtml(Boss boss);

    public static Image None() => new NoImage();

    public static Image SingleRes(string url) => new SingleResImage(url);

    public static Image MultiRes(string linkUrl, IEnumerable<string> urls) => new MultiResImage(linkUrl, urls);

    public static Image Full4K(string fullBase) => new MultiResImage($"{fullBase}-full.jpg", [
        $"{fullBase}-300px.jpg",
        $"{fullBase}-600px.jpg",
        $"{fullBase}-900px.jpg",
        $"{fullBase}-1200px.jpg",
        $"{fullBase}-full.jpg",
    ]);

    public static Image Crop4K(string fullBase) => new MultiResImage($"{fullBase}-full.jpg", [
        $"{fullBase}-300px.jpg",
        $"{fullBase}-600px.jpg",
        $"{fullBase}-900px.jpg",
        $"{fullBase}-1200px.jpg",
        $"{fullBase}-crop.jpg",
    ]);

    public static Image Full1080p(string fullBase) => new MultiResImage($"{fullBase}-full.jpg", [
        $"{fullBase}-300px.jpg",
        $"{fullBase}-600px.jpg",
        $"{fullBase}-full.jpg",
    ]);

    public static Image Crop1080p(string fullBase) => new MultiResImage($"{fullBase}-full.jpg", [
        $"{fullBase}-300px.jpg",
        $"{fullBase}-600px.jpg",
        $"{fullBase}-crop.jpg",
    ]);

    public static implicit operator Image(string url) => new SingleResImage(url);
}

file class NoImage : Image
{
    public override string ToHtml(Boss boss) => "__image__";
}

file class SingleResImage : Image
{
    private string _url;

    public SingleResImage(string url)
    {
        this._url = url;
    }

    public override string ToHtml(Boss boss) => $@"
        <img
		    src=""{_url}""
		    alt=""
			    {boss.Name}
			    {(boss.Nightlord ? "Nightlord" : "")}
			    elden ring nightreign wiki guide
		    ""
            width=300
            height=169>
    ";
}

file class MultiResImage : Image
{
    private string _linkUrl;

    private List<string> _urls;

    public MultiResImage(string linkUrl, IEnumerable<string> urls)
    {
        this._linkUrl = linkUrl;
        this._urls = [.. urls];
    }

    public override string ToHtml(Boss boss) => $@"
        <a class=""wiki_link"" href=""/file/Elden-Ring-Nightreign/{_linkUrl}"">
            <img
		        srcset=""{
                    String.Join(
                        ", ",
                        _urls.Select((url, i) => $"/file/Elden-Ring-Nightreign/{url} {i + 1}x")
                    )
                }""
		        alt=""{boss.Name}
			        {(boss.Nightlord ? "Nightlord" : "")}
			        elden ring nightreign wiki guide""
                width=300
                height=169>
        </a>
    ";
}
