package crc643f46942d9dd1fff9;


public class TextViewHolder
	extends crc643f46942d9dd1fff9.SelectableViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.TextViewHolder, Xamarin.Forms.Platform.Android", TextViewHolder.class, __md_methods);
	}


	public TextViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == TextViewHolder.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.TextViewHolder, Xamarin.Forms.Platform.Android", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
