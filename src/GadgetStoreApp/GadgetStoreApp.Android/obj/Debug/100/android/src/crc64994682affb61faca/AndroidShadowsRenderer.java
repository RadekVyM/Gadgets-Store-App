package crc64994682affb61faca;


public class AndroidShadowsRenderer
	extends crc643f46942d9dd1fff9.ViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"";
		mono.android.Runtime.register ("Sharpnado.Shades.Droid.AndroidShadowsRenderer, Sharpnado.Shadows.Android", AndroidShadowsRenderer.class, __md_methods);
	}


	public AndroidShadowsRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == AndroidShadowsRenderer.class)
			mono.android.TypeManager.Activate ("Sharpnado.Shades.Droid.AndroidShadowsRenderer, Sharpnado.Shadows.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public AndroidShadowsRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == AndroidShadowsRenderer.class)
			mono.android.TypeManager.Activate ("Sharpnado.Shades.Droid.AndroidShadowsRenderer, Sharpnado.Shadows.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public AndroidShadowsRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == AndroidShadowsRenderer.class)
			mono.android.TypeManager.Activate ("Sharpnado.Shades.Droid.AndroidShadowsRenderer, Sharpnado.Shadows.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);

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
