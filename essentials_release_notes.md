# FlexiMvvm.Essentials Package Release Notes

## v.0.14 (preview)

### New functionality

- Added extension methods for getting and setting an associated object in iOS.
- Added extension methods for NSLayoutConstraint, UIStackView and UIView.
- Extended existing LayoutView and ScrollableLayoutView classes. Added new StylizedLayoutView and StylizedScrollableLayoutView classes with theme support.

### Existing functionality changes

- FluentLayout plugin extension methods are marked as obsolete. This plugin will be excluded from FlexiMvvm soon.

### Bug fixes

- The success handler is called even if an operation is canceled.

## v.0.13 (preview)

### New functionality

- Added IsAlive extension method for Java Object and NSObject to determine if the object wasn't garbage collected.

## v.0.13 (preview)

### New functionality

- Added IsAlive extension method for Java Object and NSObject to determine if the object wasn't garbage collected.

## v.0.12 (preview)

### New functionality

- Added support for AndroidX. Set the target Android API to 10.0 (Android 10 - API 29) to use AndroidX libraries instead of Android Support ones. The target Android API prior to 10.0 will continue to use Android Support libraries.
