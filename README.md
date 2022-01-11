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

---

## Local development

```ps1
tye run
```

Open [Tye Dashboard](http://localhost:8000/) to view application uri, metrics, and logs.

---

## Build

Build the docker images with `tye build`

```ps1
tye build
```

---

## Publish

Push the images to container registry with `tye push`

> Make sure, you are logged into the registry, using `docker login`

```ps1
tye push -i
```

> `-i` enables interactive mode. Alternatively, you can configure this in the `yaml` file.

---

## Deploy

> Make sure Kubernetes cluster is up and running

```ps1
tye deploy -i
```

To forward port

```ps1
kubectl port-forward svc/heroesapi 2500:80
```

> Now visit <http://localhost:2500/swagger> to access the application