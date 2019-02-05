[... CONTENTS](index.md)

---

# FlexiMvvm structure

### Core vs Platform

For tutorials simplicity, let's define just 2 project types for our Visual Studio solutions.
- In *Some.Product.Core* project which we traditionally name where code is shared between the mobile platforms, we define common abstractions, add View Models with Application Services like Navigation, Validation, Exception Handling, Connectivity, and so on.
- In *Some.Product.iOS* and *Some.Product.Droid* platform projects, all the mobile specific code is settled (View Controllers, Cell Views, Activities, Fragments, mobile native services, whatever else). These projects have references to the *Some.Product.Core*.

![Simple projects structure](images/001-Intro-001-Projects-Simple.png)

As FlexiMvvm is modular in nature and has several Nuget packages which cover specific functionality and do depend on "Core" or platform projects, we'll review where FlexiMvvm works best and which NuGet packages are suitable.

### NuGet Packages

> On the time of documentation, FlexiMvvm was in the Preview mode, with **"PreRelease"** suffixes in the titles.

| Package                      | Solution Projects to add | Description |
| ---                          | --- | --- |
| **FlexiMvvm.Lifecycle**      | Core | One of the most important pieces which enables MVVM adoption and proper navigation approach on iOS and Android, leveraging native lifecycle specifics. Needed on common and platform code. |
| **FlexiMvvm.FullStack**      | iOS and Android Apps | This package is suited for platform-dependent projects bringing everything needed there |
| FlexiMvvm.Bindings           | - | Automatically added as a dependency by FlexiMvvm.FullStack, adding Data Bindings support in terms of MVVM pattern adoption |
| FlexiMvvm.Essentials         | - | Automatically added as a dependency by FlexiMvvm.Lifecycle or FlexiMvvm.FullStack, contains important stuff which provides typical but time consuming implementations |
| FlexiMvvm.Common             | - | Automatically added as a dependency by FlexiMvvm.Lifecycle or FlexiMvvm.FullStack, contains shared building blocks |
| FlexiMvvm.Collections        | TBD | TBD |
| FlexiMvvm.Validation         | TBD | TBD |
| FlexiMvvm.Generation         | TBD | TBD |

---

[Next: First Screen ...](001-introduction-02-first-screen.md)