using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using Sample.Core.Presentation.ViewModels;
using Sample.Droid.Bindings;

namespace Sample.Droid.Views
{
    [Activity(Theme = "@style/AppTheme.NoActionBar")]
    public class LanguagesActivity : BindableAppCompatActivity<LanguagesViewModel>
    {
        private RecyclerView _recyclerView;

        public event EventHandler<string> LanguageSelected;

        public void InvokeLanguageSelected(string @value)
        {
            LanguageSelected?.Invoke(this, @value);
        }

        public override void Bind(BindingSet<LanguagesViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(this)
              .For(v => v.LanguageSelectedBinding())
              .To(vm => vm.SelectLanguage);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_languages);

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view);
            _recyclerView.SetLayoutManager(new LinearLayoutManager(this, 1, false));
            _recyclerView.SetAdapter(new LanguagesRecyclerAdapter(
                new List<Language>()
                {
                    new Language { Title = "English" },
                    new Language { Title = "Español" },
                }));
        }
    }

    public class LanguagesRecyclerAdapter : RecyclerView.Adapter
    {
        private readonly IList<Language> _items;

        public LanguagesRecyclerAdapter(IEnumerable<Language> items)
        {
            _items = items.ToList();
        }

        public override int ItemCount => _items.Count;

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_language, parent, false);
            var txtTitle = itemView.FindViewById<TextView>(Resource.Id.txtTitle);

            return new LanguageRecyclerViewHolder(itemView, txtTitle);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var h = (LanguageRecyclerViewHolder)holder;
            h.Title.Text = _items[position].Title;
        }
    }

    public class LanguageRecyclerViewHolder : RecyclerView.ViewHolder
    {
        public LanguageRecyclerViewHolder(View itemView, TextView txtTitle)
            : base(itemView)
        {
            itemView.Click += ItemViewClick;
            Title = txtTitle;
        }

        public TextView Title { get; private set; }

        private void ItemViewClick(object sender, System.EventArgs e)
        {
            var a = (LanguagesActivity)ItemView.Context;
            a.InvokeLanguageSelected(Title.Text);
        }
    }
}
