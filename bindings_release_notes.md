# FlexiMvvm.Bindings Package Release Notes

## v.0.13 (preview)

### New functionality

- Added support for AndroidX. Set the target Android API to 10.0 (Android 10 - API 29) to use AndroidX libraries instead of Android Support ones. The target Android API prior to 10.0 will continue to use Android Support libraries.

## v.0.12 (preview)

### New functionality

 - Added a new set of bindings for the following views:
&nbsp;&nbsp;**Android**: *Activity, EditText, ImageView, IMenuItem, ProgressBar, SearchView, SwipeRefreshLayout, TextView, View*.
&nbsp;&nbsp;**iOS**: *UIButton, UICollectionViewCell, UIImageView, UINavigationController, UISearchBar, UITextField, UIView*.

- Added new value converters for views visibility management:
&nbsp;&nbsp;**Android**: *InvertedVisibleGoneValueConverter, InvertedVisibleInvisibleValueConverter*.
&nbsp;&nbsp;**iOS**: *HiddenValueConverter, InvertedHiddenValueConverter*.

### Existing functionality changes

- *BindDefault* extension methods are marked obsolete since it is not obvious which binding is used under the hood.

So write just

     bindingSet.Bind(view)
         .Fov(v => v.SomePropertyBinding())

instead of

     bindingSet.BindDefault(view)

- All new and existing visibility-related value converters now support more types in addition to boolean one when converting a value from a view model side. Value converter returns true if:
-- *bool* value is *true*;
-- *int, float, double* value > 0;
-- *string.IsNullOrEmpty(value)* == *false*;
-- *IEnumerable\<object\>* value is not *null* or empty.
-- *object* (used as fallback type) value is not *null*.

Inverted condition is used for *Inverted\*ValueConverter*s.