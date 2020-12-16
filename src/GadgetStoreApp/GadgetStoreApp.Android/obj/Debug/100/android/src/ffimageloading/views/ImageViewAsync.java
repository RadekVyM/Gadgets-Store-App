package ffimageloading.views;


public class ImageViewAsync
	extends android.widget.ImageView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMeasure:(II)V:GetOnMeasure_IIHandler\n" +
			"n_setFrame:(IIII)Z:GetSetFrame_IIIIHandler\n" +
			"";
		mono.android.Runtime.register ("FFImageLoading.Views.ImageViewAsync, FFImageLoading.Platform", ImageViewAsync.class, __md_methods);
	}


	public ImageViewAsync (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ImageViewAsync.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Views.ImageViewAsync, FFImageLoading.Platform", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ImageViewAsync (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ImageViewAsync.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Views.ImageViewAsync, FFImageLoading.Platform", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ImageViewAsync (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ImageViewAsync.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Views.ImageViewAsync, FFImageLoading.Platform", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public ImageViewAsync (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == ImageViewAsync.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Views.ImageViewAsync, FFImageLoading.Platform", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onMeasure (int p0, int p1)
	{
		n_onMeasure (p0, p1);
	}

	private native void n_onMeasure (int p0, int p1);


	public boolean setFrame (int p0, int p1, int p2, int p3)
	{
		return n_setFrame (p0, p1, p2, p3);
	}

	private native boolean n_setFrame (int p0, int p1, int p2, int p3);

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
