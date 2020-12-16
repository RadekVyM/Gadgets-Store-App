package crc644bcdcf6d99873ace;


public class SelfDisposingBitmapDrawable
	extends android.graphics.drawable.BitmapDrawable
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_finalize:()V:GetJavaFinalizeHandler\n" +
			"";
		mono.android.Runtime.register ("FFImageLoading.Drawables.SelfDisposingBitmapDrawable, FFImageLoading.Platform", SelfDisposingBitmapDrawable.class, __md_methods);
	}


	public SelfDisposingBitmapDrawable ()
	{
		super ();
		if (getClass () == SelfDisposingBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.SelfDisposingBitmapDrawable, FFImageLoading.Platform", "", this, new java.lang.Object[] {  });
	}


	public SelfDisposingBitmapDrawable (android.content.res.Resources p0)
	{
		super (p0);
		if (getClass () == SelfDisposingBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.SelfDisposingBitmapDrawable, FFImageLoading.Platform", "Android.Content.Res.Resources, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SelfDisposingBitmapDrawable (android.content.res.Resources p0, android.graphics.Bitmap p1)
	{
		super (p0, p1);
		if (getClass () == SelfDisposingBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.SelfDisposingBitmapDrawable, FFImageLoading.Platform", "Android.Content.Res.Resources, Mono.Android:Android.Graphics.Bitmap, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SelfDisposingBitmapDrawable (android.content.res.Resources p0, java.io.InputStream p1)
	{
		super (p0, p1);
		if (getClass () == SelfDisposingBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.SelfDisposingBitmapDrawable, FFImageLoading.Platform", "Android.Content.Res.Resources, Mono.Android:System.IO.Stream, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public SelfDisposingBitmapDrawable (android.content.res.Resources p0, java.lang.String p1)
	{
		super (p0, p1);
		if (getClass () == SelfDisposingBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.SelfDisposingBitmapDrawable, FFImageLoading.Platform", "Android.Content.Res.Resources, Mono.Android:System.String, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public SelfDisposingBitmapDrawable (android.graphics.Bitmap p0)
	{
		super (p0);
		if (getClass () == SelfDisposingBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.SelfDisposingBitmapDrawable, FFImageLoading.Platform", "Android.Graphics.Bitmap, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SelfDisposingBitmapDrawable (java.io.InputStream p0)
	{
		super (p0);
		if (getClass () == SelfDisposingBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.SelfDisposingBitmapDrawable, FFImageLoading.Platform", "System.IO.Stream, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public SelfDisposingBitmapDrawable (java.lang.String p0)
	{
		super (p0);
		if (getClass () == SelfDisposingBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.SelfDisposingBitmapDrawable, FFImageLoading.Platform", "System.String, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void finalize ()
	{
		n_finalize ();
	}

	private native void n_finalize ();

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
