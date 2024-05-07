# ricaun.Revit.CefSharp

[![Revit 2019](https://img.shields.io/badge/Revit-2019+-blue.svg)](https://github.com/ricaun-io/ricaun.Revit.CefSharp)
[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](https://github.com/ricaun-io/ricaun.Revit.CefSharp)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](https://github.com/ricaun-io/ricaun.Revit.CefSharp/actions/workflows/Build.yml/badge.svg)](https://github.com/ricaun-io/ricaun.Revit.CefSharp/actions)
[![Release](https://img.shields.io/nuget/v/ricaun.Revit.CefSharp?logo=nuget&label=release&color=blue)](https://www.nuget.org/packages/ricaun.Revit.CefSharp)

This package automatically provides access to the appropriate `CefSharp` version that has already been loaded and initialised by Revit, cf. the explanation 
on [encountering an error while using CefSharp](https://forums.autodesk.com/t5/revit-api-forum/encountered-an-error-while-using-cefsharp/m-p/12209481#M73837).

## PackageReference
```xml
<PackageReference Include="ricaun.Revit.CefSharp" Version="$(RevitVersion).*" IncludeAssets="build; compile" PrivateAssets="All" />
```

## Revit - CefSharp
* Revit 2025 - 119.4.30
* Revit 2024 - 105.3.390
* Revit 2023 - 92.0.260
* Revit 2022 - 65.0.1
* Revit 2021 - 65.0.1
* Revit 2020 - 65.0.1
* Revit 2019 - 57.0.0

## Usage

The `CefSharp` is already initialized inside Revit before any plugin, just use the `CefSharp.Wpf` reference inside your wpf works without any initializetion requirement.

```xaml
xmlns:cef="clr-namespace:CefSharp.Wpf;assembly=CefSharp.Wpf"
```

Use the `cef:ChromiumWebBrowser` with an `Address` to create a web browser in your wpf.

```xaml
<cef:ChromiumWebBrowser Address="https://github.com/ricaun-io/ricaun.Revit.CefSharp" />
```

### Example

```xaml
<Window x:Class="RevitAddin.WebView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:cef="clr-namespace:CefSharp.Wpf;assembly=CefSharp.Wpf"
        mc:Ignorable="d">
    <Grid>
        <cef:ChromiumWebBrowser Address="https://github.com/ricaun-io/ricaun.Revit.CefSharp" />
    </Grid>
</Window>
```

## Release

* [Latest release](https://github.com/ricaun-io/ricaun.Revit.CefSharp/releases/latest)

## License

This project is [licensed](LICENSE) under the [MIT Licence](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this project? Please [star this project on GitHub](https://github.com/ricaun-io/ricaun.Revit.CefSharp/stargazers)!
