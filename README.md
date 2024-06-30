# *Elden Ring* Boss Data Extractor

This is a largely hacked-together tool for extracting data about bosses from *Elden Ring* and
printing it, eventually in an HTML format suitable for the Fextralife wiki.

To use this:

* Download and extract the latest version of [Smithbox] and update the `paramdefPath` variable in
  `Program.cs` to point to its paramdef directory.

* Copy the [`src/Andre/SoulsFormats`] directory from Smithbox's source code to the directory above
  this project.

* Use [UXM Selective Unpack] to extract the *Elden Ring* game files, and update the `gamePath`
  variable in `Program.cs` to refer to the game directory.

* Build and run the project and it'll print some stuff! That's all it does for now but it'll do
  more later.

[Smithbox]: https://github.com/vawser/Smithbox/tree/ad54d3a376478bf6ca99bd3ae9c9ae7cd22303d7
[`src/Andre/SoulsFormats`]: https://github.com/vawser/Smithbox/tree/main/src/Andre/SoulsFormats
[UXM Selective Unpack]: https://github.com/Nordgaren/UXM-Selective-Unpack
