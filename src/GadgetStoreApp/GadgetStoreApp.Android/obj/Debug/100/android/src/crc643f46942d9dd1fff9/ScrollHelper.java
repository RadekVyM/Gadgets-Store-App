package crc643f46942d9dd1fff9;


public class ScrollHelper
	extends androidx.recyclerview.widget.RecyclerView.OnScrollListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onScrolled:(Landroidx/recyclerview/widget/RecyclerView;II)V:GetOnScrolled_Landroidx_recyclerview_widget_RecyclerView_IIHandler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.ScrollHelper, Xamarin.Forms.Platform.Android", ScrollHelper.class, __md_methods);
	}


	public ScrollHelper ()
	{
		super ();
		if (getClass () == ScrollHelper.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ScrollHelper, Xamarin.Forms.Platform.Android", "", this, new java.lang.Object[] {  });
	}

	public ScrollHelper (androidx.recyclerview.widget.RecyclerView p0)
	{
		super ();
		if (getClass () == ScrollHelper.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ScrollHelper, Xamarin.Forms.Platform.Android", "AndroidX.RecyclerView.Widget.RecyclerView, Xamarin.AndroidX.RecyclerView", this, new java.lang.Object[] { p0 });
	}


	public void onScrolled (androidx.recyclerview.widget.RecyclerView p0, int p1, int p2)
	{
		n_onScrolled (p0, p1, p2);
	}

	private native void n_onScrolled (androidx.recyclerview.widget.RecyclerView p0, int p1, int p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
