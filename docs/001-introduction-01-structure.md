[... CONTENTS](index.md)

---

# FlexiMvvm structure

### Core vs Platform

For tutorials simplicity, let's define just 2 project types for our Visual Studio solutions.
- In *Some.Product.Core* project which we traditionally name where code is shared between the mobile platforms, we define common abstractions, Infrastrucutre, View Models with Application Services like Navigation, Validation, Exception Handling, Connectivity, and so on.
- In *Some.Product.iOS* and *Some.Product.Droid* platform projects, all the mobile specific code is settled (View Controllers, Cell Views, Activities, Fragments, mobile native services, whatever else). These projects have references to the *Some.Product.Core*.

![Simple projects structure](images/001-Intro-001-Projects-Simple.png)

As FlexiMvvm is modular in nature and has several Nuget packages which cover specific functionality and do depend on "Core" or platform projects, we'll review where FlexiMvvm works best and which NuGet packages are suitable.

### NuGet Packages

> On the time of documentation, FlexiMvvm was in the Preview mode, with **"PreRelease"** suffixes in the titles.

| Package                      | Solution Projects to add | Description |
| ---                          | --- | --- |
| **FlexiMvvm.Lifecycle**      | Core | One of the most important pieces which enables MVVM adoption and proper navigation approach on iOS and Android, leveraging native lifecycle specifics. |
| **FlexiMvvm.FullStack**      | iOS and Android Apps | This package is suited for platform-dependent projects bringing everything needed there |
| **FlexiMvvm.Collections**    | iOS and Android Apps | Helps to better incorporate and populate enhanced Observable Collections on mobile UI |
| **FlexiMvvm.Validation**     | Core | Helps to adopt a solid validation approach, leveraging [Fluent Validation](https://github.com/JeremySkinner/FluentValidation) |
| FlexiMvvm.Bindings           | - | Automatically added as a dependency by FlexiMvvm.FullStack, adding Data Bindings support on platforms in terms of MVVM pattern adoption, with standard or custom Views and Controls |
| FlexiMvvm.Essentials         | - | Automatically added as a dependency by FlexiMvvm.Lifecycle or FlexiMvvm.FullStack. Inspired by [Xamarin.Essentials](https://github.com/xamarin/Essentials), has platform specific capabilities like better UI-in-code technic on iOS via [FluentLayout](https://github.com/FluentLayout/Cirrious.FluentLayout)|
| FlexiMvvm.Common             | - | Automatically added as a dependency by FlexiMvvm.Lifecycle or FlexiMvvm.FullStack, contains building blocks which are shared across the framework like interfaces or Commands implementation, base Value Converter, Configuration abilities and enhanced Observable Collections |
| FlexiMvvm.Generation         | TBD | TBD |

---

[Next: First Screen ...](001-introduction-02-first-screen.md)