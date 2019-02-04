# CONTENTS

- [INTRODUCTION](index.md)
	- [FlexiMvvm Structure](001-introduction-01-strucuture.md)
	- [First screen](001-introduction-02-first-screen.md)
	- [Second Screen with Parameters](001-introduction-03-second-screen-with-parameters.md)

---

# INTRODUCTION

### Prerequisites

Firstly, we need to recap how to do this with Xamarin originally, having these steps completed:

1. Our Xamarin development environment is ready:
  - [Xamarin.iOS Setup and Installation](https://docs.microsoft.com/en-us/xamarin/ios/get-started/index)
  - [Xamarin.Droid Setup and Installation](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/index)
2. We're able to build and run such iOS and Android Quickstart samples:
  - [Hello, iOS](https://docs.microsoft.com/en-us/xamarin/ios/get-started/hello-ios/hello-ios-quickstart?pivots=windows)
  - [Hello, Android](https://docs.microsoft.com/en-us/xamarin/android/get-started/hello-android/hello-android-quickstart?pivots=windows)
3. And we're familiar with MVVM. Consider Wintellect's [blog post](https://www.wintellect.com/model-view-viewmodel-mvvm-explained/) to revisit core concepts through the .NET and related frameworks perspective.

### Ideas drove the creation

Based on the experience gained building mobile cross-platform applications with Xamarin and leveraging this framework's major advantages, implementing FlexiMvvm became crucial to address the minimal **time to market** demand and maintain overall product **quality** constrained to high standards for our clients.

Time to market means we're able to deliver advantage with Xamarin over mobile native approach, with code reuse, minimizing build efforts. Less code, no unnecessary research, no compromises with degrading performance due to some shared code which should be native instead. 

Quality is a more complex term reflecting many aspects of a product, the mobile app in hands of a consumer. It comprises system and user quality attributes like Usability, Performance, Native look and feel, etc. We believe, a mobile solution which properly leverages iOS and Android native capabilities with less customizations over a common denominator, has higher chances for 5 consumer feedback stars.

#### Aims

The following aims were pursued while implementing FlexiMvvm:

- For medium and big term developments, proper application architecture is driven and consistently reused across different projects, by different teams
- Proper code sharing approach is incorporated, introducing clear decomposition of application layers
- Flexibility and reasonable level of abstraction from native platform APIs is established, preserving an easy way to access capabilities with less code
- Smooth learning curve for new members during onboarding, simplifying a range of challenging mobile-specific tasks
- Infrastructural efforts are minimal as typical functionality is provided; whole team is able to start parallelized development from the kick-off immediately.

---

[Next: FlexiMvvm Structure ...](001-introduction-01-strucuture.md)