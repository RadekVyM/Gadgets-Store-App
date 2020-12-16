package crc644bcdcf6d99873ace;


public class FFAnimatedDrawable
	extends crc644bcdcf6d99873ace.SelfDisposingBitmapDrawable
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Platform", FFAnimatedDrawable.class, __md_methods);
	}


	public FFAnimatedDrawable ()
	{
		super ();
		if (getClass () == FFAnimatedDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Platform", "", this, new java.lang.Object[] {  });
	}


	public FFAnimatedDrawable (android.content.res.Resources p0)
	{
		super (p0);
		if (getClass () == FFAnimatedDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Platform", "Android.Content.Res.Resources, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public FFAnimatedDrawable (android.content.res.Resources p0, android.graphics.Bitmap p1)
	{
		super (p0, p1);
		if (getClass () == FFAnimatedDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Platform", "Android.Content.Res.Resources, Mono.Android:Android.Graphics.Bitmap, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public FFAnimatedDrawable (android.content.res.Resources p0, java.io.InputStream p1)
	{
		super (p0, p1);
		if (getClass () == FFAnimatedDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Platform", "Android.Content.Res.Resources, Mono.Android:System.IO.Stream, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public FFAnimatedDrawable (android.content.res.Resources p0, java.lang.String p1)
	{
		super (p0, p1);
		if (getClass () == FFAnimatedDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Platform", "Android.Content.Res.Resources, Mono.Android:System.String, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public FFAnimatedDrawable (android.graphics.Bitmap p0)
	{
		super (p0);
		if (getClass () == FFAnimatedDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Platform", "Android.Graphics.Bitmap, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public FFAnimatedDrawable (java.io.InputStream p0)
	{
		super (p0);
		if (getClass () == FFAnimatedDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Platform", "System.IO.Stream, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public FFAnimatedDrawable (java.lang.String p0)
	{
		super (p0);
		if (getClass () == FFAnimatedDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Platform", "System.String, mscorlib", this, new java.lang.Object[] { p0 });
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
