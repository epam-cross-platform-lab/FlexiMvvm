# INTRODUCTION

## Prerequisites

Firstly, we need to recap how to do this with Xamarin originally, having these steps completed:

1. Our Xamarin development environment is ready:
  - [Xamarin.iOS Setup and Installation](https://docs.microsoft.com/en-us/xamarin/ios/get-started/index)
  - [Xamarin.Droid Setup and Installation](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/index)
2. We're able to build and run such iOS and Android Quickstart samples:
  - [Hello, iOS](https://docs.microsoft.com/en-us/xamarin/ios/get-started/hello-ios/hello-ios-quickstart?pivots=windows)
  - [Hello, Android](https://docs.microsoft.com/en-us/xamarin/android/get-started/hello-android/hello-android-quickstart?pivots=windows)
3. And we're familiar with MVVM. Consider Wintellect's [blog post](https://www.wintellect.com/model-view-viewmodel-mvvm-explained/) to revisit core concepts through the .NET and related frameworks perspective.

## Ideas drove the creation

Based on the experience gained building mobile cross-platform applications with Xamarin and leveraging this framework's major advantages, implementing FlexiMvvm became crucial to address the minimal **time to market** demand and maintain overall product **quality** constrained to high standards for our clients.

Time to market means we're able to deliver advantage with Xamarin over mobile native approach, with code reuse, minimizing build efforts. Less code, no unnecessary research, no compromises with degrading performance due to some shared code which should be native instead. 

Quality is a more complex term reflecting many aspects of a product, the mobile app in hands of a consumer. It comprises system and user quality attributes like Usability, Performance, Native look and feel, etc. We believe, a mobile solution which properly leverages iOS and Android native capabilities with less customizations over a common denominator, has higher chances for 5 consumer feedback stars.

### Aims

The following aims were pursued while implementing FlexiMvvm:

- For medium and big term developments, proper application architecture is driven and consistently reused across different projects, by different teams
- Proper code sharing approach is incorporated, introducing clear decomposition of application layers
- Flexibility and reasonable level of abstraction from native platform APIs is established, preserving an easy way to access capabilities with less code
- Smooth learning curve for new members during onboarding, simplifying a range of challenging mobile-specific tasks
- Infrastructural efforts are minimal as typical functionality is provided; whole team is able to start parallelized development from the kick-off immediately.

## FlexiMvvm structure

### Core vs Platform

Let's recap that we have different project types in our Visual Studio solution.
Typically we select appropriate dependencies to add to our solution projects:
- In *Some.Product.Core* project which we traditionally name where code is shared between the mobile platforms, we define common abstractions, add View Models with Application Services like Navigation, Validation, Exception Handling, Connectivity, and so on.
- In *Some.Product.iOS* and *Some.Product.Droid* platform projects, all the mobile specific code is settled (View Controllers, Cell Views, Activities, Fragments, mobile native services, whatever else). And these projects have references to the *Some.Product.Core*.

![Simple projects structure](images/001-Intro-001-Projects-Simple.png)

But going further with a more sophisticated scenario, application architecture may introduce several explicit layers to deal with the complexity, like this:

![Advanced projects structure](images/001-Intro-002-Projects-Domain.png)

As FlexiMvvm is modular in nature and has several Nuget packages which cover specific functionality and do depend on "Core" or platform projects, we'll review where FlexiMvvm works best and which NuGet packages are suitable.

### NuGet Packages

| Package | Solution Projects to add | Description |
| --- | --- | --- |
| **FlexiMvvm.Lifecycle** | Core (or its Presentation for advanced structure)   | One of the most important pieces which enables MVVM adoption and proper navigation approach on iOS and Android, leveraging native lifecycle specifics.  |
| **FlexiMvvm.FullStack** | iOS and Android platform projects | Contains iOS and Android implementations, so this package is suited for platform-dependent projects |
| FlexiMvvm.Bindings | - | Automatically added as a dependency by FlexiMvvm.Lifecycle or FlexiMvvm.FullStack, bringing Data Bindings support in terms of MVVM pattern adoption |
| FlexiMvvm.Essentials | - | Automatically added as a dependency by FlexiMvvm.Lifecycle or FlexiMvvm.FullStack, contains important stuff which provides typical but time consuming implementations |
| FlexiMvvm.Common | - | Automatically added as a dependency by FlexiMvvm.Lifecycle or FlexiMvvm.FullStack, shared building blocks |
| FlexiMvvm.Collections | TBD | TBD |
| FlexiMvvm.Validation | TBD | TBD |
| FlexiMvvm.Generation | TBD | TBD |



