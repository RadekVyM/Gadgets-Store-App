package crc643f46942d9dd1fff9;


public class ListViewRenderer_ListViewScrollDetector
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.widget.AbsListView.OnScrollListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onScroll:(Landroid/widget/AbsListView;III)V:GetOnScroll_Landroid_widget_AbsListView_IIIHandler:Android.Widget.AbsListView/IOnScrollListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onScrollStateChanged:(Landroid/widget/AbsListView;I)V:GetOnScrollStateChanged_Landroid_widget_AbsListView_IHandler:Android.Widget.AbsListView/IOnScrollListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.ListViewRenderer+ListViewScrollDetector, Xamarin.Forms.Platform.Android", ListViewRenderer_ListViewScrollDetector.class, __md_methods);
	}


	public ListViewRenderer_ListViewScrollDetector ()
	{
		super ();
		if (getClass () == ListViewRenderer_ListViewScrollDetector.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ListViewRenderer+ListViewScrollDetector, Xamarin.Forms.Platform.Android", "", this, new java.lang.Object[] {  });
	}

	public ListViewRenderer_ListViewScrollDetector (crc643f46942d9dd1fff9.ListViewRenderer p0)
	{
		super ();
		if (getClass () == ListViewRenderer_ListViewScrollDetector.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ListViewRenderer+ListViewScrollDetector, Xamarin.Forms.Platform.Android", "Xamarin.Forms.Platform.Android.ListViewRenderer, Xamarin.Forms.Platform.Android", this, new java.lang.Object[] { p0 });
	}


	public void onScroll (android.widget.AbsListView p0, int p1, int p2, int p3)
	{
		n_onScroll (p0, p1, p2, p3);
	}

	private native void n_onScroll (android.widget.AbsListView p0, int p1, int p2, int p3);


	public void onScrollStateChanged (android.widget.AbsListView p0, int p1)
	{
		n_onScrollStateChanged (p0, p1);
	}

	private native void n_onScrollStateChanged (android.widget.AbsListView p0, int p1);

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
