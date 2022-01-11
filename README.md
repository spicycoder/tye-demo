---
marp: true
theme: gaia
---

# Project Tye

## Install Tye

> Requires .NET Core 3.1 SDK

> Check [nuget](dotnet tool install --global Microsoft.Tye --version 0.10.0-alpha.21420.1) for latest version

```ps1
dotnet tool install -g Microsoft.Tye --version "0.10.0-alpha.21420.1"
```

---

## Add nuget package

> Check [nuget](https://www.nuget.org/packages/Microsoft.Tye.Extensions.Configuration) for latest version

```ps1
dotnet add package Microsoft.Tye.Extensions.Configuration --version 0.10.0-alpha.21420.1
```

## Initialize

```ps1
tye init
```
