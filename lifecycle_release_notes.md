# FlexiMvvm.Lifecycle Package Release Notes

## v.0.12 (preview)

### New functionality

- Added support for AndroidX. Set the target Android API to 10.0 (Android 10 - API 29) to use AndroidX libraries instead of Android Support ones. The target Android API prior to 10.0 will continue to use Android Support libraries.

### Existing functionality changes

- FlexiMvvm-specific activities and fragments for Android, as well as view controllers for iOS, were renamed by adding 'Flexi' prefix at the beginning of the existing name. For example, 'Fragment' now is 'FlexiFragment'.
