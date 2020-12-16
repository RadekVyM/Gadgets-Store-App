package crc6414fa209700c2b9f3;


public class CachedImageView
	extends android.widget.ImageView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_invalidate:()V:GetInvalidateHandler\n" +
			"";
		mono.android.Runtime.register ("FFImageLoading.Forms.Platform.CachedImageView, FFImageLoading.Forms.Platform", CachedImageView.class, __md_methods);
	}


	public CachedImageView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CachedImageView.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Forms.Platform.CachedImageView, FFImageLoading.Forms.Platform", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CachedImageView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CachedImageView.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Forms.Platform.CachedImageView, FFImageLoading.Forms.Platform", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CachedImageView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CachedImageView.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Forms.Platform.CachedImageView, FFImageLoading.Forms.Platform", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CachedImageView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == CachedImageView.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Forms.Platform.CachedImageView, FFImageLoading.Forms.Platform", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void invalidate ()
	{
		n_invalidate ();
	}

	private native void n_invalidate ();

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
