# *Elden Ring* Boss Data Extractor

This is a largely hacked-together tool for extracting data about bosses from *Elden Ring* and
serializing it in an HTML format suitable for the Fextralife wiki.

To use this:

* Download and extract the latest version of [Smithbox] and update the `paramdefPath` variable in
  `Program.cs` to point to its paramdef directory.

* Copy the [`src/Andre/SoulsFormats`] directory from Smithbox's source code to the directory above
  this project.

* Use [UXM Selective Unpack] to extract the *Elden Ring* game files, and update the `gamePath`
  variable in `Program.cs` to refer to the game directory.

* Make sure the boss you want to generate has its core data listed in the `Boss.cs` file, and
  set the `bossName` variable to the boss's name and the `displayType` variable to the particular
  HTML display you want to generate.

* Build and run the project and it'll add the HTML to your clipboard.

[Smithbox]: https://github.com/vawser/Smithbox/tree/ad54d3a376478bf6ca99bd3ae9c9ae7cd22303d7
[`src/Andre/SoulsFormats`]: https://github.com/vawser/Smithbox/tree/main/src/Andre/SoulsFormats
[UXM Selective Unpack]: https://github.com/Nordgaren/UXM-Selective-Unpack
